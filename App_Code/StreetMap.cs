using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using AspMap;
using AspMap.Web;

public class StreetMap
{
    private string tileLayerID;
    private Map mapContext;
    private TileLayer tileLayer;
    private string dataFolder;
    private string tileCacheVirtualDir;
    private bool enableTileCache = true;
    private int maxDynamicCacheSize = 1000;

    public StreetMap(string tileLayerID, string tileCacheVirtualDir, int maxDynamicCacheSize)
	{
        this.tileLayerID = tileLayerID;

        if (!Directory.Exists(MapPath(tileCacheVirtualDir)))
            throw new Exception("Tile cache folder not found: " + tileCacheVirtualDir);

        this.tileCacheVirtualDir = tileCacheVirtualDir;    

        this.maxDynamicCacheSize = maxDynamicCacheSize;
    }

    // set to false to prevent the web browser from caching the tile images (during development)
    public bool EnableCache { set { enableTileCache = value; } }

    public TileLayer CreateTileLayer(Map mapContext)
    {
        this.dataFolder = MapPath("App_Data/" + tileLayerID);

        if (!Directory.Exists(this.dataFolder))
            throw new Exception("Map data folder not found: " + this.dataFolder);

        this.mapContext = mapContext;

        InitZoomLevels();

        return InitTileLayer();
    }

    void InitZoomLevels()
    {
        // add 19 zoom levels
        mapContext.ZoomLevels.Add(220000000); // world level
        mapContext.ZoomLevels.Add(147914387);
        mapContext.ZoomLevels.Add(73957193);
        mapContext.ZoomLevels.Add(36978596);
        mapContext.ZoomLevels.Add(18489298);
        mapContext.ZoomLevels.Add(9244649);
        mapContext.ZoomLevels.Add(4622324);
        mapContext.ZoomLevels.Add(2311162);
        mapContext.ZoomLevels.Add(1155581);
        mapContext.ZoomLevels.Add(577790);
        mapContext.ZoomLevels.Add(288895);
        mapContext.ZoomLevels.Add(144447);
        mapContext.ZoomLevels.Add(72223);
        mapContext.ZoomLevels.Add(36111);
        mapContext.ZoomLevels.Add(18055);
        mapContext.ZoomLevels.Add(9027);
        mapContext.ZoomLevels.Add(4513);
        mapContext.ZoomLevels.Add(2256);
        mapContext.ZoomLevels.Add(1128); // street level
    }

    TileLayer InitTileLayer()
    {
        // create a new TileLayer
        tileLayer = TileLayer.Create(tileLayerID);

        if (tileLayer == null)
        {
            // the TileLayer already has been created, return it
            return TileLayer.Find(tileLayerID);
        }

        if (mapContext.CoordinateSystem != null && mapContext.CoordinateSystem.Code != 0)
            tileLayer.CoordinateSystem = new CoordSystem(mapContext.CoordinateSystem.Code);

        // set the size of tiles in pixels
        tileLayer.TileSize = new Size(384, 384);

        // enable client-side caching of tile images (in the browser's cache)
        tileLayer.EnableClientCache = enableTileCache;

        // enable dynamic caching
        tileLayer.TileCacheMode = TileCacheMode.Dynamic;

        // set a directory where the TileLayer will cache dynamically generated tile images
        // this directory must have read/write/delete permissions
        if (enableTileCache)
            tileLayer.TileCacheDirectory = tileCacheVirtualDir;

        // set the maximum size of the tile cache directory
        tileLayer.MaxDynamicCacheSize = maxDynamicCacheSize;

        // set color/font/line styles
        tileLayer.BackColor = mapContext.BackColor;
        tileLayer.SmoothingMode = SmoothingMode.AntiAlias;
        tileLayer.FontQuality = FontQuality.ClearType;

        InitLayers();        

	tileLayer.Initialize();

        return tileLayer;
    }

    void InitLayers()
    {
        World();
        Country();
        Natural();
        Waterways();        
        Roads();
        Buildings(); 
        Railways();
        Points();
        Places();
    }

    void World()
    {
        if (!FileExists("world")) return;

        Layer layer = AddLayer("world");
        layer.LabelMinScale = Zoom(8);
        layer.Symbol.LineStyle = LineStyle.Invisible;
        layer.Symbol.FillColor = Color.FromArgb(242, 242, 234);
        layer.ShowLabels = true;        
        layer.LabelField = "NAME";
        layer.LabelStyle = LabelStyle.PolygonCentroid;
        layer.LabelFont.Name = "Arial";
        layer.LabelFont.Size = 17;
        layer.LabelFont.Bold = true;
        layer.LabelFont.Outline = true;

        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.FromArgb(200, 200, 200);
        layer.Symbol.LineStyle = LineStyle.Dot;
    }

    void Country()
    {
        if (!FileExists("country")) return;

        Layer layer = AddLayer("country");
        layer.Symbol.LineStyle = LineStyle.Invisible;
        layer.Symbol.FillColor = Color.FromArgb(242, 242, 234);
    }

    void Natural()
    {
        Layer layer = AddLayer("natural");
        layer.MaxScale = Zoom(6);
        layer.Symbol.FillColor = Color.FromArgb(220, 230, 210);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        FeatureRenderer renderer = layer.Renderer;
        renderer.Field = "TYPE";

        Feature feature = renderer.Add();
        feature.Value = "water";
        layer.Symbol.FillColor = Color.FromArgb(220, 219, 171);
        layer.Symbol.LineColor = Color.FromArgb(220, 219, 171);
    }

    void Waterways()
    {
        Layer layer = AddLayer("waterways");
        layer.MaxScale = Zoom(7);
        layer.Symbol.LineColor = Color.FromArgb(179, 198, 212);
        layer.Symbol.Size = 1;        

        Feature feature = layer.Renderer.Add();        
        feature.MaxScale = Zoom(10);
        feature.MinScale = Zoom(13);
        feature.Symbol.LineColor = Color.FromArgb(179, 198, 212);
        feature.Symbol.Size = 2;

        feature = layer.Renderer.Add();
        feature.MaxScale = Zoom(14);
        feature.Symbol.LineColor = Color.FromArgb(179, 198, 212);
        feature.Symbol.Size = 4;
    }

    void Railways()
    {
        Layer layer = AddLayer("railways");
        layer.MaxScale = Zoom(10);
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.LineStyle = LineStyle.DashDotRoad;
        layer.Symbol.Size = 3;
    }

    void Buildings()
    {
        Layer layer = AddLayer("buildings");
        layer.MaxScale = Zoom(15);
        layer.Symbol.FillColor = Color.FromArgb(220, 220, 220);
        layer.Symbol.LineColor = Color.LightGray;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 15;
        layer.LabelStyle = LabelStyle.PolygonCentroid;
    }

    void Places()
    {
        Layer layer = AddLayer("places");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.UseDefaultSymbol = false;
        layer.DuplicateLabels = false;

        FeatureRenderer renderer = layer.Renderer;
        renderer.Field = "TYPE";

        // city
        Feature feature = new AspMap.Feature();
        feature.MaxScale = Zoom(4);
        feature.Value = "city";
        feature.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        feature.Symbol.FillColor = Color.LightSalmon;
        feature.Symbol.Size = 8;
        feature.LabelFont.Size = 16;
        feature.LabelFont.Bold = true;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);

        // town
        feature = new AspMap.Feature();
        feature.MaxScale = Zoom(6);
        feature.Value = "town";
        feature.Symbol.PointStyle = PointStyle.Circle;
        feature.Symbol.FillColor = Color.GhostWhite;
        feature.Symbol.Size = 6;
        feature.LabelFont.Size = 14;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);

        feature = new AspMap.Feature();
        feature.MaxScale = Zoom(10);
        feature.Symbol.PointStyle = PointStyle.Circle;
        feature.Symbol.FillColor = Color.GhostWhite;
        feature.Symbol.Size = 4;
        feature.LabelFont.Name = "Verdana";
        feature.LabelFont.Size = 14;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);    
    }

    // points of interest
    void Points()
    {
        Layer layer = AddLayer("points");
        layer.MaxScale = Zoom(15);
        layer.LabelMaxScale = Zoom(17);
        layer.UseDefaultSymbol = false;
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;        

        FeatureRenderer renderer = layer.Renderer;
        renderer.Field = "TYPE";

        AddPOI("antenna", PointStyle.TowerCommunications, renderer);
        AddPOI("artwork", PointStyle.ArtGallery, renderer);
        AddPOI("bank", PointStyle.Bank, renderer);
        AddPOI("bar", PointStyle.Bar, renderer);
        AddPOI("bus_station", PointStyle.BusStation, renderer);
        AddPOI("cafe", PointStyle.Cafe, renderer);
        AddPOI("car_rental", PointStyle.RentalCar, renderer);
        AddPOI("caravan_site", PointStyle.CaravanPark, renderer);
        AddPOI("casino", PointStyle.Casino, renderer);
        AddPOI("cinema", PointStyle.Cinema, renderer);
        AddPOI("college", PointStyle.University, renderer);
        AddPOI("university", PointStyle.University, renderer);
        AddPOI("courthouse", PointStyle.Court, renderer);
        AddPOI("doctors", PointStyle.Doctors, renderer);
        //AddPOI("drinking_water", PointStyle.Drinkingtap, renderer);
        AddPOI("embassy", PointStyle.Embassy, renderer);
        AddPOI("fast_food", PointStyle.Fastfood, renderer);
        AddPOI("fire_station", PointStyle.Firestation, renderer);
        AddPOI("fountain", PointStyle.Fountain, renderer);
        AddPOI("fuel", PointStyle.Fuel, renderer);
        AddPOI("hair_salon", PointStyle.Hairdresser, renderer);
        AddPOI("hospital", PointStyle.Hospital, renderer);
        AddPOI("hostel", PointStyle.BedAndBreakfast, renderer);
        AddPOI("hotel", PointStyle.Hotel, renderer);
        //AddPOI("information", PointStyle.Information, renderer);
        AddPOI("library", PointStyle.Library, renderer);
        AddPOI("lighthouse", PointStyle.Lighthouse, renderer);
        AddPOI("memorial", PointStyle.Memorial, renderer);
        //AddPOI("monument", PointStyle.Monument, renderer);
        AddPOI("motel", PointStyle.Hotel, renderer);
        AddPOI("museum", PointStyle.Museum, renderer);
        //AddPOI("parking", PointStyle.Parking, renderer);
        AddPOI("pharmacy", PointStyle.Pharmacy, renderer);
        AddPOI("picnic_site", PointStyle.Picnic, renderer);
        AddPOI("place_of_worship", PointStyle.PlaceOfWorship, renderer);
        AddPOI("playground", PointStyle.Playground, renderer);
        AddPOI("police", PointStyle.Police, renderer);
        //AddPOI("post_office", PointStyle.PostOffice, renderer);
        //AddPOI("prison", PointStyle.Prison, renderer);
        AddPOI("pub", PointStyle.Pub, renderer);
        AddPOI("restaurant", PointStyle.Restaurant, renderer);
        AddPOI("ruins", PointStyle.Ruin, renderer);
        AddPOI("school", PointStyle.School, renderer);
        AddPOI("shelter", PointStyle.Shelter, renderer);
        AddPOI("station", PointStyle.TrainStation, renderer);
        AddPOI("theatre", PointStyle.Theatre, renderer);
        AddPOI("veterinary", PointStyle.Veterinary, renderer);
        AddPOI("windmill", PointStyle.Windmill, renderer);
        AddPOI("zoo", PointStyle.Zoo, renderer);
        //AddPOI("viewpoint", PointStyle.ViewPoint, renderer);
        //AddPOI("water_tower", PointStyle.TowerWater, renderer);
    }

    void AddPOI(string value, PointStyle style, FeatureRenderer renderer)
    {
        Feature feature = renderer.Add();
        feature.Value = value;

        Symbol symbol = feature.Symbol;
        symbol.PointStyle = style;
        symbol.Size = 20;
    }

    // roads
    void Roads()
    {
        Layer layer = AddLayer("roads");
        layer.DuplicateLabels = false;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 11;
        layer.ShowLabels = true;
        layer.UseDefaultSymbol = false;

        FeatureRenderer renderer = layer.Renderer;
        renderer.Field = "TYPE";

        // primary roads
        AddPrimary(5, 7, "primary", 1, 0, renderer);
        AddPrimary(8, 10, "primary", 3, 12, renderer);
        AddPrimary(11, 13, "primary", 5, 12, renderer);
        AddPrimary(14, 15, "primary", 8, 13, renderer);
        AddPrimary(16, -1, "primary", 11, 14, renderer);

        AddPrimaryService("primary_link", renderer);
        AddPrimaryService("trunk", renderer);

        // secondary roads
        AddSecondaryClass("secondary", renderer);
        AddSecondaryClass("secondary_link", renderer);
        AddSecondaryClass("tertiary", renderer);
        AddSecondaryClass("tertiary_link", renderer);

        // streets
        AddRoadClass("residential", renderer);
        AddRoadClass("road", renderer);
        AddRoadClass("service", renderer);
    }

    void AddPrimaryService(string value, FeatureRenderer renderer)
    {
        AddPrimary(5, 8, value, 1, 0, renderer);
        AddPrimary(9, 11, value, 2, 0, renderer);
        AddPrimary(12, 14, value, 4, 0, renderer);
        AddPrimary(15, -1, value, 6, 0, renderer);
    }

    void AddPrimary(int startZoom, int endZoom, string value, int symbolSize, int fontSize, FeatureRenderer renderer)
    {
        Feature feature  = renderer.Add();
        feature.LabelStyle = LabelStyle.Default; // avoid labeling of short lines for primary roads

        feature.MaxScale = Zoom(startZoom);
        feature.MinScale = Zoom(endZoom);

        if (value != null)
            feature.Value = value;
        
        feature.Symbol.LineColor = Color.FromArgb(222, 156, 112);
        feature.Symbol.InnerColor = Color.FromArgb(255, 195, 69);
        feature.Symbol.Size = symbolSize;
        if (symbolSize > 2)
            feature.Symbol.LineStyle = LineStyle.Road;

        feature.ShowLabels = false;

        if (fontSize > 0)
        {
            feature.ShowLabels = true;
            feature.LabelFont.Name = "Arial";
            feature.LabelFont.Quality = FontQuality.AntiAlias;
            feature.LabelFont.Bold = true;
            feature.LabelFont.Size = fontSize;
            feature.LabelFont.Outline = true;
        }
    }

    void AddSecondaryClass(string value, FeatureRenderer renderer)
    {
        AddSecondary(8, 10, value, 2, 0, renderer);
        AddSecondary(11, 13, value, 5, 12, renderer);
        AddSecondary(14, 15, value, 8, 12, renderer);
        AddSecondary(16, 17, value, 13, 14, renderer);
        AddSecondary(18, -1, value, 15, 14, renderer);
    }

    void AddSecondary(int startZoom, int endZoom, string value, int symbolSize, int fontSize, FeatureRenderer renderer)
    {
        Feature feature = renderer.Add();

        feature.MaxScale = Zoom(startZoom);
        feature.MinScale = Zoom(endZoom);

        feature.Value = value;

        feature.Symbol.LineColor = Color.LightGray;
        feature.Symbol.InnerColor = Color.FromArgb(255, 255, 134);
        feature.Symbol.Size = symbolSize;
        if (symbolSize > 2)
            feature.Symbol.LineStyle = LineStyle.Road;

        feature.ShowLabels = false;

        if (fontSize > 0)
        {
            feature.ShowLabels = true;
            feature.LabelFont.Name = "Arial";
            feature.LabelFont.Quality = FontQuality.AntiAlias;
            feature.LabelFont.Bold = true;
            feature.LabelFont.Size = fontSize;
            feature.LabelFont.Outline = true;
        }
    }
    
    void    AddRoadClass(string value, FeatureRenderer renderer)        
    {
        AddRoad(11, 12, value, 1, 0, renderer);
        AddRoad(13, 13, value, 1, 0, renderer);
        AddRoad(14, 14, value, 3, 15, renderer);
        AddRoad(15, 15, value, 7, 15, renderer);
        AddRoad(16, 16, value, 10, 16, renderer);
        AddRoad(17, 17, value, 13, 17, renderer);
        AddRoad(18, -1, value, 15, 18, renderer);
    }

    void AddRoad(int startZoom, int endZoom, string value, int symbolSize, int fontSize, FeatureRenderer renderer)
    {
        Feature feature = renderer.Add();

        feature.MaxScale = Zoom(startZoom);
        feature.MinScale = Zoom(endZoom);

        if (!String.IsNullOrEmpty(value))
            feature.Value = value;

        feature.Symbol.LineColor = Color.LightGray;
        feature.Symbol.InnerColor = Color.White;
        feature.Symbol.Size = symbolSize;
        if (symbolSize > 2)
            feature.Symbol.LineStyle = LineStyle.Road;

        feature.ShowLabels = false;

        if (fontSize > 0)
        {
            feature.ShowLabels = true;
            feature.LabelFont.Name = "Calibri";
            feature.LabelFont.Quality = FontQuality.AntiAlias;
            feature.LabelFont.Size = fontSize;
            feature.LabelFont.Bold = startZoom >= 14;
            feature.LabelFont.Outline = false;
        }
    }

    // helpers
    Layer AddLayer(string fileName)
    {
        string path = Path.Combine(dataFolder, fileName + ".shp");
        Layer layer = tileLayer.AddLayer(path);
        return layer;
    }

    bool FileExists(string fileName)
    {
        return  File.Exists(Path.Combine(dataFolder, fileName + ".shp"));        
    }
    
    private double Zoom(int level)
    {
        if (level < 0) return -1;
        return mapContext.ZoomToScale(level);
    }    
    
    private string MapPath(string virtualPath)
    {
        return HttpContext.Current.Server.MapPath(virtualPath);
    }
}