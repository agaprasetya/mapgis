using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using AspMap;
using AspMap.Web;

//
// StreetMap Template Sample
//
// 
// The template uses the OpenStreetMap data of New Zealand (http://www.vdstech.com/osm-data.aspx)
// Zoom levels: 0 - 18 (App_Code/StreetMap.cs, CreateTileLayer method)
//
// Files:
//   /App_Code/StreetMap.cs - the code of the template
//   /App_Data/StreetMap - map data directory (.shp)
//   /TileCache - tile cache directory
// If you run this template under IIS, the tile cache directory must allow READ/WRITE/DELETE access 
// for the ASP.NET user account to let AspMap manage tile images in the cache.
//

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;
        map.BackColor = Color.FromArgb(165, 191, 221);
        map.ImageOpacity = 0.5;
        map.ImageFormat = ImageFormat.Png;
        map.MapTool = MapTool.Pan;
        map.Cursor = "handover";
        map.PanCursor = "handdrag";

        AddStreetMap();

        if (!IsPostBack)
        {
            // set the initial zoom
            map.CenterAndZoom(new AspMap.Point(175.3099, -41.1783), 6);
        }        
    }

    protected void AddStreetMap()
    {
        // Set the OpenStreetMap map data directory and tile layer ID to 'StreetMap'.
        // Set the tile cache virtual directory and the maximum size of the directory in megabytes.
        StreetMap streetMap = new StreetMap("StreetMap", "~/TileCache", 1000);
        
        // Set EnableCache to false to prevent the web browser from caching the tile images during development.
        // If map caching has been enabled earlier, the browser's cache and the TileImageCache directory should be cleared manually.
        streetMap.EnableCache = true; 
        
        // Get the tile layer.        
        AspMap.Web.TileLayer tileLayer = streetMap.CreateTileLayer(map);
        
        // Add the tile layer.
        if (tileLayer != null)
        {
            map.AddLayer(tileLayer);
        }
    }

    protected void map_ZoomFullExecuted(object sender, EventArgs e)
    {
        // set the initial zoom
        map.CenterAndZoom(new AspMap.Point(175.3099, -41.1783), 6);
    }

}