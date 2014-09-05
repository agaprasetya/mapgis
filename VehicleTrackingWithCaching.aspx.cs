using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddTileLayer();

        // set the transparency of the map GIF image to show the TileLayer
        map.ImageOpacity = 0;

        if (!IsPostBack)
        {
            map.EnableAnimation = true;
            map.ZoomLevel = 1;
        }
    }

    void AddTileLayer()
    {
        // initialize the ZoomLevels collection
        map.ZoomLevels.Add(200000);
        map.ZoomLevels.Add(100000);
        map.ZoomLevels.Add(50000);
        map.ZoomLevels.Add(25000);
        map.ZoomLevels.Add(12500);

        // create a new TileLayer
        TileLayer tileLayer = TileLayer.Create("Tracking");

        if (tileLayer == null)
        {
            // the TileLayer already has been created, just add it to the map
            tileLayer = TileLayer.Find("Tracking");
            map.AddLayer(tileLayer);
            return;
        }

        // enable client-side caching of tile images (in the browser's cache)
        tileLayer.EnableClientCache = true;

        // enable dynamic caching
        tileLayer.TileCacheMode = TileCacheMode.Dynamic;

        // set a directory where the TileLayer will cache dynamically generated tile images
        // this directory must have read/write/delete permissions
        tileLayer.TileCacheDirectory = "~/TileCache";

        // set the size of tiles in pixels
        tileLayer.TileSize = new Size(384, 384);

        // set the maximum size of the tile cache directory to 300 megabytes
        tileLayer.MaxDynamicCacheSize = 300;

        // set font/line styles
        tileLayer.SmoothingMode = SmoothingMode.AntiAlias;
        tileLayer.FontQuality = FontQuality.ClearType;

        // add layers to the TileLayer
        string LayerFolder = MapPath("MAPS/STREETS/");

        AspMap.Layer layer = tileLayer.AddLayer(LayerFolder + "street.shp");
        layer.LabelField = "NAME";
        layer.LabelMaxScale = 50000;
        layer.ShowLabels = true;
        layer.DuplicateLabels = false;
        layer.Symbol.LineStyle = LineStyle.Road;
        layer.Symbol.LineColor = Color.FromArgb(171, 158, 137);
        layer.Symbol.InnerColor = Color.White;
        layer.Symbol.Size = 3;

        Feature feature = layer.Renderer.Add(-1, 70000);
        feature.LabelFont.Name = "Calibri";
        feature.LabelFont.Size = 12;
        feature.LabelFont.Quality = FontQuality.AntiAlias;
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.LineColor = Color.FromArgb(230, 230, 230);
        feature.Symbol.InnerColor = Color.White;
        feature.Symbol.Size = 6;

        // initialize the TileLayer
        tileLayer.Initialize();

        // add the TileLayer to the map
        map.AddLayer(tileLayer);
    }

    protected void map_RefreshAnimationLayer(object sender, AspMap.Web.RefreshAnimationLayerArgs e)
    {
        e.NeedRefreshMap = TrackVehicles();
    }

    bool TrackVehicles()
    {
        AspMap.Points path = null;

        AspMap.Point vehicleLocation = GetVehicleCoordinates(ref path);

        GeoEvent geoEvent = new GeoEvent();

        geoEvent.Location = vehicleLocation;
        geoEvent.ImageUrl = "SYMBOLS/vehicle.gif";
        geoEvent.ImageWidth = 20;
        geoEvent.ImageHeight = 20;
        geoEvent.ImageStyle.BorderColor = Color.Red;
        geoEvent.ImageStyle.BorderWidth = Unit.Pixel(1);
        geoEvent.Label = "Vehicle 1";
        geoEvent.LabelStyle.Width = Unit.Pixel(150);
        geoEvent.NavigateUrl = "javascript:alert('Vehicle 1')";

        geoEvent.Path = path;
        geoEvent.PathColor = Color.Red;
        geoEvent.PathWidth = 2;

        map.AnimationLayer.Add(geoEvent);

        // move the map if the vehicle is outside of the map
        if (!map.Extent.IsPointIn(geoEvent.Location))
        {
            map.CenterAt(geoEvent.Location);
            return true; // refresh map
        }

        return false;
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        TrackVehicles();
    }

    // For demostration purposes, the GPS coordinates (latitude/longitude) are stored in a text file.
    AspMap.Point GetVehicleCoordinates(ref AspMap.Points path)
    {
        StreamReader reader = File.OpenText(MapPath("DATA/vehicle_points.txt"));

        string line;
        AspMap.Points points = new AspMap.Points();

        while ((line = reader.ReadLine()) != null)
        {
            string[] coords = line.Split(' ');
            points.Add(Convert.ToDouble(coords[0], NumberFormatInfo.InvariantInfo), Convert.ToDouble(coords[1], NumberFormatInfo.InvariantInfo));
        }

        reader.Close();

        int position = 0;
        if (Session["position"] != null)
            position = Convert.ToInt32(Session["position"]);

        if (position >= points.Count)
            position = 0;

        Session["position"] = Convert.ToString(position + 1);

        AspMap.Point currentLocation = points[position];               

        // remove unnecesary points
        for (int i = points.Count - 1; i > position; i--) points.Remove(i);

        path = points;

        return currentLocation;
    }
}
