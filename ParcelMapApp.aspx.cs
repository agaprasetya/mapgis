using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using AspMap;
using AspMap.Web;
using System.Text.RegularExpressions;

public partial class ParcelMapApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Foot;
        map.ScaleBar.Visible = true;
        map.ScaleBar.BarUnit = UnitSystem.Imperial;

        AddMapLayers();

        // add a relation to the parcel tax database
        AddRelation();

        if (!Page.IsPostBack)
            map.Extent = map["parcels"].Extent;

        label.Text = "";
    }

    protected void AddMapLayers()
    {
        AspMap.Layer layer;
        string LayerFolder = MapPath("MAPS/PARCELS/");

        map.AddLayer(LayerFolder + "aerialphoto.tif");

        layer = map.AddLayer(LayerFolder + "parcels.shp");
        layer.ShowLabels = true;
        layer.LabelField = "PARNUM";
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelFont.Size = 15;
        layer.LabelFont.Outline = true;
        layer.LabelFont.OutlineColor = Color.Yellow;
        layer.LabelFont.Color = Color.Black;
        layer.LabelMaxScale = 10000;
        layer.Symbol.FillStyle = FillStyle.Invisible;
        layer.Symbol.LineColor = Color.Yellow;

        layer = map.AddLayer(LayerFolder + "streets.shp");
        layer.MaxScale = 10000;
        layer.ShowLabels = true;
        layer.LabelField = "STREET";
        layer.LabelFont.Name = "Arial";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Size = 12;
        layer.LabelFont.Outline = true;
        layer.LabelFont.OutlineColor = Color.White;
        layer.LabelFont.Quality = FontQuality.AntiAlias;
        layer.Symbol.Size = 10;
        layer.Symbol.LineColor = Color.White;
        layer.LabelMaxScale = 10000;
        layer.Opacity = 0.5;
    }

    // adds a relation to the parcel tax database
    void AddRelation()
    {
        AspMap.DataSource dataSource = new AspMap.DataSource();

        string dataFile = MapPath("DATA/taxattr.mdb");

        dataSource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataFile;
        dataSource.CommandText = "SELECT * From taxattr";

        // create a relation between the parcel shapefile and the 
        // database by the parcel number field
        if (!map["parcels"].AddRelate("PARNUM", dataSource, "PARNUM"))
        {
            throw new Exception("Cannot add a relate to the database: " + dataFile);
        }
    }


    protected void zoomFull_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        map.ZoomFull();
        map.Extent = map["parcels"].Extent;
    }

    protected void map_InfoTool(object sender, AspMap.Web.InfoToolEventArgs e)
    {
        map.Callouts.Clear();

        AspMap.Recordset records = map.Identify(e.InfoPoint, 5);

        if (!records.EOF)
        {
            identifyGrid.DataSource = records;
            identifyGrid.DataBind();
            identifyGrid.Caption = records.Layer.Name.ToUpper();

            Callout callout = map.Callouts.Add();
            callout.X = e.InfoPoint.X;
            callout.Y = e.InfoPoint.Y;
            callout.Text = GetCalloutText(records);
            callout.Font.Size = 16;
        }
    }

    protected String GetCalloutText(AspMap.Recordset rs)
    {
        int index = rs.Fields.GetFieldIndex("NAME");
        if (index < 0) index = rs.Fields.GetFieldIndex(rs.Layer.LabelField);
        if (index < 0) index = 0;
        return rs[index].ToString();
    }

    protected void searchAddress_Click(object sender, System.EventArgs e)
    {
        map.Callouts.Clear();

        string simpleAddrPattern = @"^(?<num>\d+)\W+(?<street>.+)";

        string address = addressTextBox.Text.Trim();

        if (!Regex.IsMatch(address, simpleAddrPattern))
            return;

        Match m = Regex.Match(address, simpleAddrPattern);

        string houseNum = m.Groups["num"].Value;
        string streetName = m.Groups["street"].Value;

        // strip extra spaces
        streetName = Regex.Replace(streetName, @"\s+", " ");

        string addrExpr = "LIKE(STREET,\"" + streetName + "\") ";

        // search within street numbers range
        if (houseNum.Length > 0)
        {
            addrExpr = addrExpr + "AND ((FRADDL < TOADDL AND (FRADDL <= " + houseNum + " AND " + houseNum + "<= TOADDL)) OR ";
            addrExpr = addrExpr + "(FRADDL > TOADDL AND (FRADDL >= " + houseNum + " AND " + houseNum + " >= TOADDL)) OR ";
            addrExpr = addrExpr + "(FRADDR < TOADDR AND (FRADDR <= " + houseNum + " AND " + houseNum + " <= TOADDR)) OR ";
            addrExpr = addrExpr + "(FRADDR > TOADDR AND (FRADDR >= " + houseNum + " AND " + houseNum + " >= TOADDR)))";
        }

        AspMap.Recordset records = map["streets"].SearchExpression(addrExpr);
        if (records.EOF)
        {
            label.Text = "Not found";
            return;
        }

        Callout callout = map.Callouts.Add();
        AspMap.Point center = records.Shape.Centroid;
        callout.X = center.X;
        callout.Y = center.Y;
        callout.Text = address;
        callout.Font.Size = 16;

        map.Extent = records.RecordExtent;
        map.MapScale = 3000;
    }

    protected void searchParcel_Click(object sender, System.EventArgs e)
    {
        map.Callouts.Clear();

        string expr = "PARNUM = \"" + parcelTextBox.Text.Trim() + "\"";

        AspMap.Recordset rs = map["parcels"].SearchExpression(expr);
        if (rs.EOF)
        {
            label.Text = "Not found";
            return;
        }

        identifyGrid.DataSource = rs;
        identifyGrid.DataBind();
        identifyGrid.Caption = rs.Layer.Name.ToUpper();

        Callout callout = map.Callouts.Add();
        AspMap.Point center = rs.Shape.Centroid;
        callout.X = center.X;
        callout.Y = center.Y;
        callout.Text = rs["PARNUM"] + "\n" + rs["OWNERNAME"];
        callout.Font.Size = 16;

        map.Extent = rs.RecordExtent;
        map.MapScale = 3000;
    }

    protected void searchOwner_Click(object sender, System.EventArgs e)
    {
        map.Callouts.Clear();

        string expr = "LIKE(OWNERNAME,\"" + ownerTextBox.Text.Trim() + "*\")";

        AspMap.Recordset rs = map["parcels"].SearchExpression(expr);

        if (rs.EOF)
        {
            label.Text = "Not found";
            return;
        }

        identifyGrid.DataSource = rs;
        identifyGrid.DataBind();
        identifyGrid.Caption = rs.Layer.Name.ToUpper();

        Callout callout = map.Callouts.Add();
        AspMap.Point center = rs.Shape.Centroid;
        callout.X = center.X;
        callout.Y = center.Y;
        callout.Text = rs["PARNUM"] + "\n" + rs["OWNERNAME"];
        callout.Font.Size = 16;

        map.Extent = rs.RecordExtent;
        map.MapScale = 3000;
    }

}
