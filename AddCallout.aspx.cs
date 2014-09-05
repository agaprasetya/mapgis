using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;
    }
    protected void callout_Click(object sender, EventArgs e)
    {
        // callouts are persisted between postbackes        

        Callout callout = map.Callouts.Add();
        callout.X = 2.35099; // longitude
        callout.Y = 48.85676; // latitude
        callout.Text = "Paris, France";
        callout.Font.Size = 20;
    }
}
