using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddLayer();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {       
        // create a Points collection
        AspMap.Points points = new Points();
        points.Add(2.35, 48.85);
        points.Add(10.98, 44.31);
        points.Add(14.69, 47.52);
        points.Add(14.48, 37.35);
        points.Add(-03.24, 34.40);

        // create a line
        AspMap.Polyline line = new AspMap.Polyline();
        line.Add(points);
        
        // draw the line
        MapShape ms = map.MapShapes.Add(line, "Line");
        ms.Symbol.LineStyle = LineStyle.Solid;
        ms.Symbol.LineColor = Color.Red;
        ms.Symbol.Size = 2;

        map.MapShapes.Opacity = 0.5;
    }

    void AddLayer()
    {
        map.MapShapes.Clear();

        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.FillColor = Color.Ivory;

        map.ZoomScale(new AspMap.Point(2.9, 40.00), 30000000);
    }
}
