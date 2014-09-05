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

        // labels
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;

        // line size and color
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;

        // fill color
        layer.Symbol.FillColor = Color.Ivory;

        layer = map.AddLayer(MapPath("MAPS/WORLD/capitals.shp"));
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        layer.Symbol.Size = 8;
        layer.Symbol.FillColor = Color.Yellow;
    }

    protected void button1_Click(object sender, EventArgs e)
    {
        map.Markers.Clear();

        AspMap.Layer layer = Layer.Open(MapPath("MAPS/WORLD/capitals.shp"));

        AspMap.Recordset capitals = layer.SearchNearest(new AspMap.Point(2.35099, 48.85676), map.ConvertDistance(300, MeasureUnit.Mile, MeasureUnit.Degree));

        while (!capitals.EOF)
        {
            Marker marker = new Marker(capitals.Shape.Centroid, capitals["NAME"].ToString());
            map.Markers.Add(marker);

            capitals.MoveNext();
        }

        map.Extent = capitals.Extent;
        map.MapScale += 1000000;

        layer.Dispose();  // close capitals.shp
    }
}
