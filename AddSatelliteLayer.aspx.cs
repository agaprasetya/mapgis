using System;
using System.Web;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        // add an TIFF image layer
        map.AddLayer(MapPath("MAPS/PARCELS/aerialphoto.tif"));
    }
 }
