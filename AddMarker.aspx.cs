using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        // add a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        AspMap.Point point = new AspMap.Point(2.35099, 48.85676); // longitude, latitude
        Marker marker = new Marker(point, "Paris, France");
        map.Markers.Add(marker);
    }
}
