using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class SimpleMapApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        zoomBar.Map = map.UniqueID; // or use the Properties window to associate the ZoomBar with a map control

        // set custom zoom bar images
        zoomBar.ImagePath = "TOOLS/CustomZoomBar";

        // Add the world.shp shapefile as a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.FillColor = Color.Ivory;    

        // Add zoom levels.
        map.ZoomLevels.Add(250000000);
        map.ZoomLevels.Add(125000000);
        map.ZoomLevels.Add(62500000);
        map.ZoomLevels.Add(31250000);
        map.ZoomLevels.Add(15625000);
        map.ZoomLevels.Add(7812500);
        map.ZoomLevels.Add(3906250);
        map.ZoomLevels.Add(1953125);
        map.ZoomLevels.Add(976562);
    }
}
