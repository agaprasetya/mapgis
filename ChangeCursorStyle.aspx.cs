using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        map.Cursor = ListBox1.SelectedValue;
        map.PanCursor = ListBox2.SelectedValue;
    }
}
