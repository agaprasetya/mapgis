using System;
using System.Drawing;
using System.Web.UI.WebControls;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddLayer();
    }
    protected void List1_SelectedIndexChanged(object sender, EventArgs e)
    {
        AspMap.Layer layer = map["states"];
        AspMap.FeatureRenderer renderer = layer.Renderer;

        AspMap.Feature feature = renderer.Add();
        feature.Expression = List1.SelectedValue; // an expression
        feature.Symbol.FillColor = Color.Yellow;
    }

    void AddLayer()
    {
        // add the states.shp shapefile as a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/USA/states.shp"));

        // line size and color
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.Gray;

        // fill color
        layer.Symbol.FillColor = Color.Ivory;

        layer.ShowLabels = true;
        layer.LabelField = "STATE_ABBR";
        layer.LabelStyle = LabelStyle.PolygonCenter;
    }

}
