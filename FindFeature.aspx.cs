using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        map.MapTool = MapTool.InfoWindow;

        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;        
    }
    protected void map_InfoWindowTool(object sender, InfoWindowToolEventArgs e)
    {
        AspMap.Layer layer = map["world"];
       
        AspMap.Recordset records = layer.SearchShape(e.InfoPoint, SearchMethod.PointInPolygon);

        if (!records.EOF)
        {
            e.InfoWindow.Content = "Country: " + records["name"].ToString() + "<br>" +
                "Population: " + records["population"].ToString();
        }
    }
}
