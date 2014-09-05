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
        AspMap.Shape shape1 = map.MapShapes[0].Shape;
        AspMap.Shape shape2 = map.MapShapes[1].Shape;

        // union the shapes 
        AspMap.Shape result = shape1.Union(shape2);

        // highlight the result
        map.MapShapes.Clear();

        MapShape ms = map.MapShapes.Add(result);
        ms.Symbol.FillColor = Color.Yellow;
        ms.Symbol.Size = 1;
    }

    void AddShapes()
    {
        // add two shapes
        AspMap.Polygon shape1 = new Polygon();
        shape1.MakeCircle(2.35099, 48.85676, 4);
        MapShape ms = map.MapShapes.Add(shape1);
        ms.Symbol.FillColor = Color.Blue;
        ms.Symbol.Size = 1;

        AspMap.Polygon shape2 = new Polygon();
        shape2.MakeRectangle(-7.11, 47.22, 5.01, 41.44);
        ms = map.MapShapes.Add(shape2);
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
