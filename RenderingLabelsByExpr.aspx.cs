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
        AspMap.Layer layer = map["street"];
        layer.LabelExpression = List1.SelectedValue; // expression must return a string value
    }

    void AddLayer()
    {
        // add the states.shp shapefile as a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/STREETS/street.shp"));

        // line size and color
        layer.Symbol.Size = 8;
        layer.Symbol.LineColor = Color.FromArgb(230,230,230);

        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Quality = FontQuality.AntiAlias;

        map.ZoomScale(map.Extent.Center, 30000);
    }

}
