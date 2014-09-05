using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // use the MapTool.Info tool to get the user click
        map.MapTool = MapTool.Info;

        // add a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;       
    }
    
    // this event handler receives the user click
    protected void map_InfoTool(object sender, InfoToolEventArgs e)
    {
        AspMap.Recordset rs = map.Identify(e.InfoPoint, 10);
        if (!rs.EOF)
            map.Extent = rs.RecordExtent;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        map.ZoomFull();
    }
}
