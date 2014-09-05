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

public partial class OverviewMapApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;
        map.ScaleBar.Visible = true;
        map.ScaleBar.BarUnit = UnitSystem.Imperial;

        overviewMap.MapTool = MapTool.Point;
        overviewMap.ClientScript = ClientScriptType.NoScript;

        AddMapLayers();
        AddOverviewMapLayers();
        FillLayerList();
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        UpdateLayerProperties();
        UpdateLayerVisibility();
        UpdateOverviewMapProperties();
    }

    private void AddOverviewMapLayers()
    {
        string LayerFolder = MapPath("MAPS/STREETS/");

        AspMap.Layer layer = overviewMap.AddLayer(LayerFolder + "County.shp");
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.FromArgb(199, 172, 116);
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);
    }

    private void UpdateOverviewMapProperties()
    {
        overviewMap.ZoomFull();
        overviewMap.MapShapes.Clear();

        AspMap.Rectangle extent = map.Extent;

        // draw the extent of the map as a rectangle
        MapShape mapShape = overviewMap.MapShapes.Add(extent);
        mapShape.Symbol.Size = 2;
        mapShape.Symbol.LineColor = Color.Red;
        mapShape.Symbol.FillStyle = FillStyle.Invisible;

        // draw the extent of the map as a point (if it is too small to be displayed as a rectangle)
        mapShape = overviewMap.MapShapes.Add(new AspMap.Point(extent.Left, extent.Top));
        mapShape.Symbol.Size = 2;
        mapShape.Symbol.LineColor = Color.Red;
        mapShape.Symbol.PointStyle = PointStyle.Square;
    }

    private void FillLayerList()
    {
        if (IsPostBack) return;

        foreach (AspMap.Layer layer in map)
        {
            ListItem item = new ListItem(layer.Description, layer.Name);
            item.Selected = layer.Visible;
            layerList.Items.Add(item);
        }
    }

    private void UpdateLayerVisibility()
    {
        if (!IsPostBack) return;

        foreach (ListItem item in layerList.Items)
        {
            map[item.Value].Visible = item.Selected;
        }
    }

    private void AddMapLayers()
    {
        AspMap.Layer layer;
        string LayerFolder = MapPath("MAPS/STREETS/");

        layer = map.AddLayer(LayerFolder + "County.shp");
        layer.Description = "County";

        layer = map.AddLayer(LayerFolder + "Park.shp");
        layer.Description = "Parks";

        layer = map.AddLayer(LayerFolder + "WaterArea.shp");
        layer.Description = "Lakes";

        layer = map.AddLayer(LayerFolder + "Water.shp");
        layer.Visible = false;
        layer.Description = "Rivers";

        layer = map.AddLayer(LayerFolder + "Airport.shp");
        layer.Description = "Airports";

        layer = map.AddLayer(LayerFolder + "Street.shp");
        layer.Visible = false;
        layer.Description = "Streets";

        layer = map.AddLayer(LayerFolder + "Railroad.shp");
        layer.Visible = false;
        layer.Description = "Railroad";

        layer = map.AddLayer(LayerFolder + "Institution.shp");
        layer.Description = "Institutions";
    }

    private void UpdateLayerProperties()
    {
        AspMap.Layer Layer;
        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;

        //----------------------------------------------------
        Layer = map["county"];

        Layer.LabelField = "NAME";
        Layer.Symbol.Size = 2;
        Layer.Symbol.LineColor = Color.FromArgb(199, 172, 116);
        Layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);

        //----------------------------------------------------
        Layer = map["park"];

        Layer.LabelField = "NAME";
        Layer.ShowLabels = true;
        Layer.LabelFont.Outline = true;
        Layer.LabelFont.Size = 11;
        Layer.LabelFont.Bold = true;
        Layer.Symbol.FillColor = Color.FromArgb(143, 175, 47);
        Layer.Symbol.LineColor = Layer.Symbol.FillColor;

        //----------------------------------------------------
        Layer = map["waterarea"];

        Layer.LabelField = "NAME";
        Layer.ShowLabels = true;
        Layer.LabelFont.Outline = true;
        Layer.LabelFont.Size = 12;
        Layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        Layer.Symbol.LineColor = Layer.Symbol.FillColor;

        //----------------------------------------------------
        Layer = map["water"];

        Layer.LabelField = "NAME";
        Layer.ShowLabels = true;
        Layer.LabelFont.Size = 9;
        Layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        Layer.Symbol.LineColor = Layer.Symbol.FillColor;
        Layer.LabelFont.Color = Color.FromArgb(0, 0, 128);

        //----------------------------------------------------
        Layer = map["airport"];

        Layer.LabelField = "NAME";
        Layer.ShowLabels = true;
        Layer.LabelFont.Outline = true;
        Layer.LabelFont.Size = 11;
        Layer.Symbol.FillColor = Color.FromArgb(43, 147, 43);

        //----------------------------------------------------
        Layer = map["street"];

        Layer.LabelField = "NAME";
        Layer.LabelFont.Size = 10;

        Layer.Symbol.LineStyle = LineStyle.Road;
        Layer.Symbol.LineColor = Color.FromArgb(171, 158, 137);
        Layer.Symbol.InnerColor = Color.White;

        if (map.MapScale >= 75000)
            Layer.Symbol.Size = 3;
        else if (map.MapScale >= 37000)
        {
            Layer.Symbol.Size = 4;
            Layer.ShowLabels = true;
            Layer.LabelFont.Outline = true;
        }
        else
        {
            Layer.Symbol.Size = 6;
            Layer.ShowLabels = true;
            Layer.LabelFont.Outline = true;
        }

        //----------------------------------------------------
        Layer = map["railroad"];

        Layer.LabelField = "NAME";
        Layer.ShowLabels = true;
        Layer.LabelFont.Outline = true;
        Layer.LabelFont.Size = 10;
        Layer.Symbol.LineStyle = LineStyle.Railroad;

        //----------------------------------------------------
        Layer = map["institution"];

        Layer.LabelField = "NAME";
        Layer.ShowLabels = true;
        Layer.LabelFont.Name = "Times New Roman";
        Layer.LabelFont.Outline = true;
        Layer.LabelFont.Size = 12;
        Layer.UseDefaultSymbol = false;

        renderer = Layer.Renderer;
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
        feature.Symbol.PointStyle = PointStyle.Bitmap;
        feature.Symbol.Bitmap = MapPath("symbols/school.bmp");
        feature.Symbol.Size = 16;
        feature.Symbol.TransparentColor = Color.White;
        feature.Description = "School";

        // church symbol
        feature = renderer.Add();
        feature.Value = "D44";
        feature.Symbol.PointStyle = PointStyle.Bitmap;
        feature.Symbol.Bitmap = MapPath("symbols/church.bmp");
        feature.Symbol.Size = 16;
        feature.Symbol.TransparentColor = Color.White;
        feature.Description = "Church";

        // hospital symbol
        feature = renderer.Add();
        feature.Value = "D31";
        feature.Symbol.PointStyle = PointStyle.Bitmap;
        feature.Symbol.Bitmap = MapPath("symbols/hospital.bmp");
        feature.Symbol.Size = 16;
        feature.Symbol.TransparentColor = Color.White;
        feature.Description = "Hospital";
    }

    protected void zoomFull_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        map.ZoomFull();
    }


    protected void overviewMap_PointTool(object sender, PointToolEventArgs e)
    {
        AspMap.Rectangle extent = map.Extent;
        extent.Offset(e.Point.X - extent.Center.X, e.Point.Y - extent.Center.Y);
        map.Extent = extent;
    }
}

