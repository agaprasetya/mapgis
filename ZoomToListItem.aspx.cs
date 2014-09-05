using System;
using System.IO;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // add the world.shp shapefile as a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.FillColor = Color.Ivory;

        if (!IsPostBack)
        {
            ListBox1.DataSource = layer.Recordset;
            ListBox1.DataTextField = "NAME";
            ListBox1.DataValueField = "NAME";
            ListBox1.DataBind();
        }
    }
    
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        AspMap.Recordset rs = map["world"].SearchExpression("NAME=\"" + ListBox1.SelectedValue + "\"");

        if (!rs.EOF)
        {            
            // zoom to the feature
            map.Extent = rs.RecordExtent;
            
            // highlight the feature
            map.MapShapes.Clear();
            MapShape ms = map.MapShapes.Add(rs.Shape);
            ms.Symbol.FillColor = Color.Yellow;
            ms.Symbol.Size = 2;
        }
    }
}
