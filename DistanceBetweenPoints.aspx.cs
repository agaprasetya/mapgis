using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    AspMap.Point point1;
    AspMap.Point point2;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddLayer();
        map.MapUnit = MeasureUnit.Degree;

        point1 = new AspMap.Point(2.35, 48.85);
        point2 = new AspMap.Point(14.48, 37.35);

        // add two points
        MapShape ms = map.MapShapes.Add(point1, "Point 1");
        ms.Symbol.Size = 10;
        ms = map.MapShapes.Add(point2, "Point 2");
        ms.Symbol.Size = 10;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {       
        double distance;

        // measure the distance
        distance = map.MeasureDistance(point1, point2, MeasureUnit.Mile);
        
        // draw a line
        AspMap.Polyline line = new AspMap.Polyline(point1, point2);
        MapShape ms = map.MapShapes.Add(line, distance.ToString("#.#") + " mi");
        ms.Symbol.LineStyle = LineStyle.Solid;
        ms.Symbol.LineColor = Color.Red;
        ms.Font.Size = 18;
        ms.Font.Outline = true;
        ms.Symbol.Size = 2;
    }

    void AddLayer()
    {
        map.MapShapes.Clear();

        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.FillColor = Color.Ivory;

        map.ZoomScale( new AspMap.Point(2.9, 40.00), 20000000);
    }
}
