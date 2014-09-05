using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using AspMap;
using AspMap.Web;
using AspMap.Web.Extensions;

public partial class OpenStreetMapApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddOSMLayer();
        
        AddShapefile();

        map.ImageFormat = ImageFormat.Png;
        map.ImageOpacity = 0.4;

        if (!IsPostBack)
        {
            map.CenterAt(map.CoordinateSystem.FromWgs84(-101.95, 39.85));
            map.ZoomLevel = 3;
        }
    }

    void AddOSMLayer()
    {
        OSMLayer osmLayer = new OSMLayer("http://a.tile.openstreetmap.org/{z}/{x}/{y}.png");

        map.BackgroundLayer = osmLayer;
    }

    void AddShapefile()
    {
        AspMap.Layer layer;

        layer = map.AddLayer(MapPath("MAPS/USA/states.shp"));
        layer.Symbol.FillColor = Color.LightYellow;
        layer.LabelField = "STATE_ABBR";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;

        // The coordinate system of the shapefile must be set explicitly or must
        // be specified in a .prj file.
        layer.CoordinateSystem = CoordSystem.WGS1984;
    }
}

