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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // set the map units (depending on the units of the map layers)
        map.MapUnit = MeasureUnit.Degree;

        // add a TileLayer to the map
        AddTileLayer();

        // set the transparency of the map image to show the tile images from the TileLayer
        map.ImageOpacity = 0.3;
        map.ImageFormat = ImageFormat.Png;        
    }

    protected void AddTileLayer()
    {
        // initialize the ZoomLevels collection
        map.ZoomLevels.Add(220000000);
        map.ZoomLevels.Add(110000000);
        map.ZoomLevels.Add(55000000);
        map.ZoomLevels.Add(27500000);
        map.ZoomLevels.Add(13750000);
        map.ZoomLevels.Add(6875000);
        map.ZoomLevels.Add(3437500);

        // create a new TileLayer
        TileLayer tileLayer = TileLayer.Create("WorldMap");

        if (tileLayer == null)
        {
            // the TileLayer already has been created, just add it to the map
            tileLayer = TileLayer.Find("WorldMap");
            map.AddLayer(tileLayer);
            return;
        }

        // set the size of tiles in pixels
        tileLayer.TileSize = new Size(384, 384);

        // enable client-side caching of tile images (in the browser's cache)
        // (set this property to false during design-time, otherwise any changes will be not visible in the browser)
        tileLayer.EnableClientCache = true;

        // enable dynamic caching
        tileLayer.TileCacheMode = TileCacheMode.Dynamic;

        // set a directory where the TileLayer will cache dynamically generated tile images
        // this directory must have read/write/delete permissions
        // (comment this line during design-time, otherwise any changes will be not visible in the browser)
        tileLayer.TileCacheDirectory = "~/TileCache";

        // set the maximum size of the tile cache directory to 300 megabytes
        tileLayer.MaxDynamicCacheSize = 300;      

        // set color/font/line styles
        tileLayer.BackColor = map.BackColor;
        tileLayer.SmoothingMode = SmoothingMode.AntiAlias;
        tileLayer.FontQuality = FontQuality.ClearType;        

        // add layers to the TileLayer       
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/WORLD/");

        // world
        layer = tileLayer.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        // the PolygonCentroid style must be used with polygonal layers to avoid duplicate labels
        layer.LabelStyle = LabelStyle.PolygonCentroid;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.FillColor = Color.Ivory;

        // lakes
        layer = tileLayer.AddLayer(MapPath("MAPS/WORLD/lakes.shp"));
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 10;
        layer.LabelFont.Outline = true;
        layer.Symbol.FillColor = map.BackColor;
        layer.Symbol.LineColor = map.BackColor;
        // the PolygonCentroid style must be used with polygonal layers to avoid duplicate labels
        layer.LabelStyle = LabelStyle.PolygonCentroid; 

        // capitals
        layer = tileLayer.AddLayer(MapPath("MAPS/WORLD/capitals.shp"));
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Size = 12;
        layer.LabelFont.Outline = true;
        layer.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        layer.Symbol.Size = 8;
        layer.Symbol.FillColor = Color.White;

        // initialize the TileLayer
        tileLayer.Initialize(System.Environment.ProcessorCount);

        // add the TileLayer to the map
        map.AddLayer(tileLayer);
    }

    // TILE GENERATOR
    // Generates tiles for the current zoom level.
    // Pre-generated tiles are marked as static and will not be removed by the TileLayer class.
    // The time needed to generate tiles depends on the scale of the zoom level and the density of 
    // information in the map. Even using a powerful computer, this process can sometimes take hours or days.
    // Typically, it is enough to generate tiles for the first 0 - 10 zoom levels, other tiles will be generated dynamically.
    protected void generateTiles_Click(object sender, EventArgs e)
    {
        AspMap.Web.TileLayer tileLayer = TileLayer.Find("WorldMap");
        if (tileLayer != null)
        {
            Server.ScriptTimeout = 3600; // 1 hour timeout

            string tileFolder = MapPath("TileCache");
            double currentScale = map.ZoomToScale(map.ZoomLevel);
            tileLayer.GenerateTiles(currentScale, tileFolder);
        }
    }

}
