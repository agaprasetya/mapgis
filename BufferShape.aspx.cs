using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddLayer();
        AddShapes();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AspMap.Shape shape = map.MapShapes[0].Shape;

        // buffer the shape 
        AspMap.Shape buffer = shape.Buffer(1.0);

        // draw the buffered shape
        map.MapShapes.Clear();
        MapShape ms = map.MapShapes.Add(buffer);
        ms.Symbol.FillColor = Color.Yellow;
        ms.Symbol.Size = 1;

        // draw the original shape
        ms = map.MapShapes.Add(shape);
        ms.Symbol.FillColor = Color.Red;
        ms.Symbol.Size = 1;
    }

    void AddShapes()
    {
        // add a shape to the map
        AspMap.Polygon shape = new Polygon();
        shape.MakeRectangle(-7.11, 47.22, 5.01, 41.44);
        MapShape ms = map.MapShapes.Add(shape);
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
