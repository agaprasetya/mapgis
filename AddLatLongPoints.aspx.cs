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
        map.MapUnit = MeasureUnit.Degree;

        AddLayers();
        AddLatLongDatabase();
    }

    void AddLatLongDatabase()
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
        dbLayer.LabelFont.Color = Color.Green;
        dbLayer.LabelFont.Bold = true;
    }

    void AddLayers()
    {
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/USA/");

        layer = map.AddLayer(LayerFolder + "states.shp");
        layer.LabelField = "STATE_ABBR";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;       

        layer = map.AddLayer(LayerFolder + "capitals.shp");

        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.Symbol.PointStyle = PointStyle.CircleWithLargeCenter;
        layer.Symbol.Size = 10;
        layer.Symbol.FillColor = Color.FromArgb(255, 255, 0);
        layer.LabelFont.Name = "Arial";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.LabelFont.OutlineColor = Color.FromArgb(255, 255, 0);
    }
}
