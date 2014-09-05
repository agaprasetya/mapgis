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
        // create a Shape of type Point
        AspMap.Shape pointShape = new AspMap.Shape( new AspMap.Point(2.35099, 48.85676) );
        
        // draw the point shape
        MapShape ms = map.MapShapes.Add(pointShape, "Point Shape");
        ms.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        ms.Symbol.FillColor = Color.Red;
        ms.Symbol.Size = 12;
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
