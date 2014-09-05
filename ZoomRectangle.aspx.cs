using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapTool = MapTool.ZoomIn;

        AddLayers();
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
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;

        layer = map.AddLayer(LayerFolder + "roads.shp");
        layer.Symbol.LineColor = Color.FromArgb(255, 0, 0);
        layer.Symbol.Size = 1;

        layer = map.AddLayer(LayerFolder + "capitals.shp");

        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        layer.Symbol.Size = 10;
        layer.Symbol.FillColor = Color.Yellow;
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        map.ZoomFull();
    }
}
