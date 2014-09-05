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

public partial class GoogleMapsApp : System.Web.UI.Page
{
    // Your use of the Google Maps API is subject to the terms of a legal agreement between you and Google, Inc.
    // Please read the Google Maps API Terms of Service (http://code.google.com/apis/maps/terms.html) 
    // for more information.
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddGoogleMapsLayer();
        
        AddShapefile();

        map.ImageFormat = ImageFormat.Png;
        map.ImageOpacity = 0.4;

        if (!IsPostBack)
        {
            map.CenterAt(map.CoordinateSystem.FromWgs84(-101.95, 39.85));
            map.ZoomLevel = 3;
        }
    }

    void AddGoogleMapsLayer()
    {
        // You have to sign up for a Maps API key at http://code.google.com/apis/maps/signup.html.
      
        GoogleMapsLayer gml = new GoogleMapsLayer();

        gml.MapType = GoogleMapType.Satellite;

        // When a GoogleMapsLayer object is set as a background layer: 1) the coordinate system of the
        // Map control will be set to PCS_PopularVisualisationMercator; 2) 20 zoom levels
        // from Google Maps will be added to the ZoomLevels collection of the Map control;
        // 3) the FullExtent property of the Map control will be set to the full extent of Google Maps.

        map.BackgroundLayer = gml;
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

