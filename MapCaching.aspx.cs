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
        map.ZoomLevels.Add(228000);
        map.ZoomLevels.Add(114000);
        map.ZoomLevels.Add(57000);
        map.ZoomLevels.Add(28500);
        map.ZoomLevels.Add(14250);
        map.ZoomLevels.Add(7125);
        map.ZoomLevels.Add(3562);

        // create a new TileLayer
        TileLayer tileLayer = TileLayer.Create("CountyMap");

        if (tileLayer == null)
        {
            // the TileLayer already has been created, just add it to the map
            tileLayer = TileLayer.Find("CountyMap");
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
        
        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/STREETS/");

        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "County.shp");
        layer.LabelField = "NAME";
        layer.Symbol.Size = 2;
        layer.Symbol.LineColor = Color.FromArgb(199, 172, 116);
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);

        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "Park.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 11;
        layer.LabelFont.Bold = true;
        layer.Symbol.FillColor = Color.FromArgb(143, 175, 47);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "WaterArea.shp");
        layer.MaxScale = 300000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 9;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;
        layer.LabelFont.Color = Color.FromArgb(0, 0, 128);

        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "Water.shp");
        layer.MaxScale = 300000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 9;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;
        layer.LabelFont.Color = Color.FromArgb(0, 0, 128);

        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "Airport.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 11;
        layer.Symbol.FillColor = Color.FromArgb(43, 147, 43);

        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "Street.shp");
        layer.MaxScale = 150000;
        layer.DuplicateLabels = false;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 13;
        layer.LabelFont.Name = "Calibri";
        layer.LabelFont.Quality = FontQuality.AntiAlias;
        layer.LabelMaxScale = 37000;
        layer.Symbol.LineColor = Color.LightGray;
        layer.ShowLabels = true;        

        // set different street line width for different scales
        feature = new AspMap.Feature();
        feature.MaxScale = 75000;
        feature.MinScale = 37000;
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.LineColor = Color.FromArgb(230,230,230);
        feature.Symbol.InnerColor = Color.White;
        feature.Symbol.Size = 4;
        feature.LabelFont.Size = 14;
        feature.LabelFont.Name = "Calibri";
        feature.LabelFont.Quality = FontQuality.AntiAlias;
        layer.Renderer.Add(feature);

        feature = feature.Clone();
        feature.MaxScale = 37000;
        feature.MinScale = 16000;
        feature.Symbol.Size = 5;
        layer.Renderer.Add(feature);

        feature = feature.Clone();
        feature.MaxScale = 16000;
        feature.MinScale = -1; // no minimum scale
        feature.Symbol.Size = 8;
        layer.Renderer.Add(feature);
       
        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "Railroad.shp");
        layer.MaxScale = 200000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 10;
        layer.Symbol.LineStyle = LineStyle.Railroad;

        //----------------------------------------------------
        layer = tileLayer.AddLayer(LayerFolder + "Institution.shp");

        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Arial";
        layer.LabelFont.Outline = true;
        layer.LabelFont.Bold = true;
        layer.LabelFont.Size = 10;
        layer.UseDefaultSymbol = false;

        renderer = layer.Renderer;
        renderer.Field = "FCC";

        // cemetery symbol
        feature = renderer.Add();
        feature.Value = "D82";
        feature.Symbol.PointStyle = PointStyle.Bitmap;
        feature.Symbol.Bitmap = MapPath("symbols/cemetery.bmp");
        feature.Symbol.Size = 16;
        feature.Symbol.TransparentColor = Color.White;
        feature.Description = "Cemetery";

        // school symbol
        feature = renderer.Add();
        feature.Value = "D43";
        feature.Symbol.PointStyle = PointStyle.School;
        feature.Symbol.Size = 20;
        feature.Symbol.TransparentColor = Color.White;
        feature.Description = "School";

        // worship symbol
        feature = renderer.Add();
        feature.Value = "D44";
        feature.Symbol.PointStyle = PointStyle.PlaceOfWorship;
        feature.Symbol.Size = 20;
        feature.Symbol.TransparentColor = Color.White;
        feature.Description = "Church";

        // hospital symbol
        feature = renderer.Add();
        feature.Value = "D31";
        feature.Symbol.PointStyle = PointStyle.Hospital;
        feature.Symbol.Size = 20;
        feature.Symbol.TransparentColor = Color.White;
        feature.Description = "Hospital";

        // initialize the TileLayer
        tileLayer.Initialize(System.Environment.ProcessorCount);

        // add the TileLayer to the map
        map.AddLayer(tileLayer);
    }
}
