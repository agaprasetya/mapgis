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

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        // add tooltips to airport locations
        AddTooltips();
    }

    void AddTooltips()
    {
        map.Hotspots.Clear();

        map.TooltipStyle.BackColor = Color.LightYellow;
        map.TooltipStyle.Width = Unit.Pixel(220);

        AspMap.Recordset records = map["database"].SearchShape(map.Extent, SearchMethod.Inside);

        while (!records.EOF)
        {
            string tooltip = "<b>Airport:</b> " + records["DESCRIP"] + "<br><b>City:</b> " + records["CITY"];

            map.Hotspots.Add(records.RecordExtent.Center, 9, tooltip);

            records.MoveNext();
        }
    }

    void AddDatabase()
    {
        string connectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" + MapPath("DATA/airports.mdb");

        PointDataLayer pointData = new PointDataLayer("System.Data.OleDb", connectionString, "airports", "LONGITUDE", "LATITUDE");

        AspMap.Layer dbLayer = map.AddLayer(pointData);

        if (dbLayer == null)
            return;

        dbLayer.Name = "database";
        dbLayer.Symbol.Size = 16; // default symbol size

        // render airports depending on the value of the AVAILABLE field
        dbLayer.Renderer.Field = "AVAILABLE";

        // available airports
        AspMap.Feature feature = dbLayer.Renderer.Add();
        feature.Value = "Yes";
        feature.Symbol.Size = 16;
        feature.Symbol.PointStyle = PointStyle.Bitmap;
        feature.Symbol.Bitmap = MapPath("SYMBOLS/airport.bmp");
        feature.LabelFont.Color = Color.Green;
        feature.LabelFont.Bold = true;

        // closed airports
        feature = map["database"].Renderer.Add();
        feature.Value = "No";
        feature.Symbol.Size = 16;
        feature.Symbol.PointStyle = PointStyle.Bitmap;
        feature.Symbol.Bitmap = MapPath("SYMBOLS/airport_closed.bmp");
        feature.LabelFont.Color = Color.Red;
        feature.LabelFont.Bold = true;
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
