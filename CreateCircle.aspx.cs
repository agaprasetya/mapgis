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
        // create a circle
        AspMap.Ellipse circle = new AspMap.Ellipse( new AspMap.Point(2.35099, 48.85676), 4.0, 4.0 );
        
        // draw the circle
        MapShape ms = map.MapShapes.Add(circle, "Circle");
        ms.Symbol.FillStyle = FillStyle.Solid;
        ms.Symbol.FillColor = Color.Red;
        ms.Symbol.Size = 1;

        map.MapShapes.Opacity = 0.5;
    }

    void AddLayer()
    {
        map.MapShapes.Clear();

        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.FillColor = Color.Ivory;

        map.ZoomScale(new AspMap.Point(2.9, 47.00), 15000000);
    }
}
