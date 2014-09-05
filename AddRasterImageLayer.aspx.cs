using System;
using System.Web;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        // add an ECW image layer
        map.AddLayer(MapPath("MAPS/WORLD/earth.ecw"));

        // add a semi-transparent shapefile over the image layer
        AspMap.Layer layer  = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Opacity = 0.3;
    }
 }
