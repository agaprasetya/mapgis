using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Layer layer = AddLayer();

        Polygon filterShape = new Polygon(new AspMap.Rectangle(-50, 50, 50, -50));

        // set a spatial filter
        layer.FilterMethod = SearchMethod.Inside;
        layer.FilterShape = filterShape;

        // dislay the filter shape
        MapShape ms = map.MapShapes.Add(filterShape);
        ms.Symbol.Size = 1;
        ms.Symbol.FillStyle = FillStyle.Invisible;
        ms.Symbol.LineColor = Color.Red;
    }

    protected Layer AddLayer()
    {
        // add the world.shp shapefile as a map layer
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

        return layer;
    }

}
