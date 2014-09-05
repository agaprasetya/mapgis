using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        AspMap.Recordset rs = map["world"].SearchExpression("FEATUREID = " + TextBox1.Text.Trim());

        if (!rs.EOF)
        {
            // zoom into the feature
            map.ZoomScale(rs.Shape.Centroid, 20000000);
            map.Markers.Add(new Marker(rs.Shape.Centroid, rs["NAME"].ToString()));
        }
    }
}
