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

public partial class WmsLayerApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        AddWmsLayer();

        AddOverlayLayer();

        // make the map image transparent to display background WMS layers
        map.ImageOpacity = 0;
        map.BackColor = Color.Gray;
        map.ImageFormat = ImageFormat.Gif;
    }

    protected void AddWmsLayer()
    {
        // add the "UrbanArea" layer of the MSRMAPS WMS service: http://msrmaps.com/ogcwms.aspx
        WmsLayer wms = new WmsLayer("http://msrmaps.com/ogcmap.ashx",
                            new AspMap.Rectangle(-122.47, 37.87, -122.18, 37.73));
        wms.AddLayer("UrbanArea");
        wms.ImageFormat = ImageFormat.Jpeg;

        // add the WMS layer to the map
        AspMap.Layer wmsLayer = map.AddLayer(wms);

        // set the coordinate system of the map to the coordinate system of the MSRMAPS WMS layer
        map.CoordinateSystem = CoordSystem.WGS1984;

        // limit the full extent of the map to the extent of the WMS layer
        map.FullExtent = wmsLayer.Extent;
    }

    protected void AddOverlayLayer()
    {
        string LayerFolder = MapPath("MAPS/USA/");

        AspMap.Layer layer = map.AddLayer(LayerFolder + "cities.shp");

        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 16;
        layer.LabelFont.Outline = true;
        layer.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        layer.Symbol.FillColor = Color.Yellow;
        layer.Symbol.Size = 10;
    }

 }
