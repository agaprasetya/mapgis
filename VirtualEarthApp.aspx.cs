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

public partial class VirtualEarthApp : System.Web.UI.Page
{
    // Your use of the Virtual Earth API is subject to the terms of a legal agreement between you and Microsoft, Inc.
    // Please read the MICROSOFT VIRTUAL EARTH PLATFORM API TERMS OF USE (http://www.microsoft.com/maps/product/terms.html)
    // for more information.   
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddVirtualEarthLayer();
        
        AddShapefile();

        map.ImageFormat = ImageFormat.Png;
        map.ImageOpacity = 0.4;

        if (!IsPostBack)
        {
            map.CenterAt(map.CoordinateSystem.FromWgs84(-101.95, 39.85));
            map.ZoomLevel = 3;
        }
    }

    void AddVirtualEarthLayer()
    {
        VirtualEarthLayer ve = new VirtualEarthLayer(VirtualEarthMapType.Aerial);

        // When a VirtualEarthLayer object is set as a background layer: 1) the coordinate system of the
        // Map control will be set to PCS_PopularVisualisationMercator; 2) 19 zoom levels
        // from Virtual Earth will be added to the ZoomLevels collection of the Map control;
        // 3) the FullExtent property of the Map control will be set to the full extent of Virtual Earth maps.

        map.BackgroundLayer = ve;
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

