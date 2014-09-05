using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using AspMap;
using AspMap.Data;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{    
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddMapLayers();
        AddDatabase();
    }

    void AddTooltips()
    {
        map.Hotspots.Clear();

        map.TooltipStyle.BackColor = Color.LightYellow;
        map.TooltipStyle.Width = Unit.Pixel(220);

        AspMap.Recordset records = map["database"].SearchShape(map.Extent, SearchMethod.Inside);

        while (!records.EOF)
        {
            string argument = records["ID"].ToString();
            string tooltip = records["DESCRIP"].ToString();

            map.Hotspots.AddInfo(records.RecordExtent.Center, 9, tooltip, argument);

            records.MoveNext();
        }
    }

    protected void map_HotspotInfoClick(object sender, HotspotClickEventArgs e)
    {
        // search for a record by its ID
        Recordset records = map["database"].SearchExpression("ID = " + e.Argument);

        if (records.EOF) return;

        e.InfoWindow.Width = 300;
        e.InfoWindow.Height = 150;
        e.InfoWindow.HorizontalAlign = HorizontalAlign.Center;
        e.InfoWindow.Font.Bold = true;
        e.InfoWindow.ScrollBars = System.Web.UI.WebControls.ScrollBars.Auto;

        // add a DataGrid control to the InfoWindow to render the records
        if (!records.EOF)
        {
            DataGrid grid = new DataGrid();
            grid.DataSource = records;
            grid.DataBind();

            e.InfoWindow.Controls.Add(grid);
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        // add hotspots for airport locations
        AddTooltips();
    }

    void AddDatabase()
    {
        string connectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" + MapPath("DATA/airports.mdb");

        PointDataLayer pointData = new PointDataLayer("System.Data.OleDb", connectionString, "airports", "LONGITUDE", "LATITUDE");

        AspMap.Layer dbLayer = map.AddLayer(pointData);

        if (dbLayer == null)
            return;

        dbLayer.Name = "database";
        dbLayer.Symbol.Size = 16;
        dbLayer.Symbol.PointStyle = PointStyle.Bitmap;
        dbLayer.Symbol.Bitmap = MapPath("SYMBOLS/airport.bmp");
        dbLayer.Symbol.TransparentColor = Color.White;
    }

    void AddMapLayers()
    {
        AspMap.Layer layer;
        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;

        string LayerFolder = MapPath("MAPS/USA/");

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "states.shp");
        layer.LabelField = "STATE_ABBR";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;       

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "cities.shp");

        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.UseDefaultSymbol = false;

        renderer = layer.Renderer;

        feature = renderer.Add();
        feature.Expression = "CAPITAL = \"Y\"";
        feature.Symbol.PointStyle = PointStyle.CircleWithLargeCenter;
        feature.Symbol.Size = 10;
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 0);
        feature.LabelFont.Name = "Arial";
        feature.LabelFont.Bold = true;
        feature.LabelFont.Size = 14;
        feature.LabelFont.Outline = true;
        feature.LabelFont.OutlineColor = Color.FromArgb(255, 255, 0);
    }
}
