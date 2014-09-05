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

public partial class MapToolsApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;
        map.ScaleBar.Visible = true;
        map.ScaleBar.BarUnit = UnitSystem.Imperial;

        AddMapLayers();
    }

    protected void zoomFull_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        map.ZoomFull();
    }

    protected void map_InfoTool(object sender, AspMap.Web.InfoToolEventArgs e)
    {
        map.Callouts.Clear();

        AspMap.Recordset records = map.Identify(e.InfoPoint, 5);

        if (!records.EOF)
        {
            dataGrid.DataSource = records;
            dataGrid.DataBind();
            dataGrid.Caption = records.Layer.Name.ToUpper();

            Callout callout = map.Callouts.Add();
            callout.X = e.InfoPoint.X;
            callout.Y = e.InfoPoint.Y;
            callout.Text = GetCalloutText(records);
            callout.Font.Size = 16;
        }
    }

    protected String GetCalloutText(AspMap.Recordset rs)
    {
        int index = rs.Fields.GetFieldIndex("NAME");
        if (index < 0) index = rs.Fields.GetFieldIndex(rs.Layer.LabelField);
        if (index < 0) index = 0;
        return rs[index].ToString();
    }

    protected void map_InfoWindowTool(object sender, InfoWindowToolEventArgs e)
    {
        AspMap.Recordset records = map.Identify(e.InfoPoint, 5);

        e.InfoWindow.Width = 300;
        e.InfoWindow.HorizontalAlign = HorizontalAlign.Center;
        e.InfoWindow.ScrollBars = System.Web.UI.WebControls.ScrollBars.Auto;

        // set the content of the info window
        e.InfoWindow.Content = GetCalloutText(records);

        // add a DataGrid control to the info window to render the records
        if (!records.EOF)
        {
            DataGrid grid = new DataGrid();
            grid.DataSource = records;
            grid.DataBind();

            e.InfoWindow.Controls.Add(grid);
        }
    }

    protected void map_PointTool(object sender, AspMap.Web.PointToolEventArgs e)
    {
        map.MapShapes.Clear();

        MapShape mapShape = map.MapShapes.Add(e.Point);
        mapShape.Symbol.Size = 6;
        mapShape.Symbol.FillColor = Color.Red;

        AspMap.Layer activeLayer = map.FindLayer(layerList.SelectedValue);

        if (activeLayer != null && activeLayer.LayerType == LayerType.Polygon)
        {
            AspMap.Recordset records = activeLayer.SearchShape(e.Point, SearchMethod.PointInPolygon);

            if (!records.EOF)
            {
                dataGrid.DataSource = records;
                dataGrid.DataBind();
                dataGrid.Caption = records.Layer.Name.ToUpper();
            }
        }
    }

    protected void map_LineTool(object sender, AspMap.Web.LineToolEventArgs e)
    {
        map.MapShapes.Clear();

        MapShape mapShape = map.MapShapes.Add(e.Line);
        mapShape.Symbol.Size = 2;
        mapShape.Symbol.LineColor = Color.Red;

        AspMap.Layer activeLayer = map.FindLayer(layerList.SelectedValue);

        if (activeLayer != null)
        {
            AspMap.Recordset records = activeLayer.SearchShape(e.Line, SearchMethod.Intersect);

            if (!records.EOF)
            {
                dataGrid.DataSource = records;
                dataGrid.DataBind();
                dataGrid.Caption = records.Layer.Name.ToUpper();
            }
        }
    }

    protected void map_PolylineTool(object sender, AspMap.Web.PolylineToolEventArgs e)
    {
        map.MapShapes.Clear();

        MapShape mapShape = map.MapShapes.Add(e.Polyline);
        mapShape.Symbol.Size = 2;
        mapShape.Symbol.LineColor = Color.Red;

        AspMap.Layer activeLayer = map.FindLayer(layerList.SelectedValue);

        if (activeLayer != null)
        {
            AspMap.Recordset records = activeLayer.SearchShape(e.Polyline, SearchMethod.Intersect);

            if (!records.EOF)
            {
                dataGrid.DataSource = records;
                dataGrid.DataBind();
                dataGrid.Caption = records.Layer.Name.ToUpper();
            }
        }
    }

    protected void map_RectangleTool(object sender, AspMap.Web.RectangleToolEventArgs e)
    {
        map.MapShapes.Clear();

        MapShape mapShape = map.MapShapes.Add(e.Rectangle);
        mapShape.Symbol.Size = 2;
        mapShape.Symbol.LineColor = Color.Red;
        mapShape.Symbol.FillStyle = FillStyle.Invisible;

        AspMap.Layer activeLayer = map.FindLayer(layerList.SelectedValue);

        if (activeLayer != null)
        {
            AspMap.Recordset records = activeLayer.SearchShape(e.Rectangle, SearchMethod.Inside);

            if (!records.EOF)
            {
                dataGrid.DataSource = records;
                dataGrid.DataBind();
                dataGrid.Caption = records.Layer.Name.ToUpper();
            }
        }
    }

    protected void map_CircleTool(object sender, AspMap.Web.CircleToolEventArgs e)
    {
        map.MapShapes.Clear();

        MapShape mapShape = map.MapShapes.Add(e.Circle);
        mapShape.Symbol.Size = 2;
        mapShape.Symbol.LineColor = Color.Red;
        mapShape.Symbol.FillStyle = FillStyle.Invisible;

        AspMap.Layer activeLayer = map.FindLayer(layerList.SelectedValue);

        if (activeLayer != null)
        {
            AspMap.Recordset records = activeLayer.SearchShape(e.Circle, SearchMethod.Inside);

            if (!records.EOF)
            {
                dataGrid.DataSource = records;
                dataGrid.DataBind();
                dataGrid.Caption = records.Layer.Name.ToUpper();
            }
        }
    }

    protected void map_PolygonTool(object sender, AspMap.Web.PolygonToolEventArgs e)
    {
        map.MapShapes.Clear();

        MapShape mapShape = map.MapShapes.Add(e.Polygon);
        mapShape.Symbol.Size = 2;
        mapShape.Symbol.LineColor = Color.Red;
        mapShape.Symbol.FillStyle = FillStyle.Invisible;

        AspMap.Layer activeLayer = map.FindLayer(layerList.SelectedValue);

        if (activeLayer != null)
        {
            AspMap.Recordset records = activeLayer.SearchShape(e.Polygon, SearchMethod.Inside);

            if (!records.EOF)
            {
                dataGrid.DataSource = records;
                dataGrid.DataBind();
                dataGrid.Caption = records.Layer.Name.ToUpper();
            }
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        UpdateLayerList();
    }

    void UpdateLayerList()
    {
        string activeLayer;

        if (layerList.Items.Count == 0)
            activeLayer = map[0].Name;
        else
            activeLayer = layerList.SelectedValue;

        layerList.Items.Clear();

        for (int i = 0; i < map.LayerCount; i++)
        {
            if (map.IsLayerVisible(i))
                layerList.Items.Add(map[i].Name);
        }

        if (layerList.Items.FindByText(activeLayer) != null)
            layerList.SelectedValue = activeLayer;
        else
            layerList.SelectedIndex = 0;
    }

    protected void AddMapLayers()
    {
        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/STREETS/");

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "County.shp");
        layer.LabelField = "NAME";
        layer.Symbol.Size = 2;
        layer.Symbol.LineColor = Color.FromArgb(199, 172, 116);
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "Park.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 11;
        layer.LabelFont.Bold = true;
        layer.Symbol.FillColor = Color.FromArgb(143, 175, 47);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "WaterArea.shp");
        layer.MaxScale = 300000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 12;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "Water.shp");
        layer.MaxScale = 300000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 9;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;
        layer.LabelFont.Color = Color.FromArgb(0, 0, 128);

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "Airport.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 11;
        layer.Symbol.FillColor = Color.FromArgb(43, 147, 43);

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "Street.shp");
        layer.MaxScale = 150000;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 10;
        layer.LabelMaxScale = 37000;
        layer.ShowLabels = true;

        // set different street line width on different scales
        feature = new AspMap.Feature();
        feature.MaxScale = 75000;
        feature.MinScale = 37000;
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.LineColor = Color.FromArgb(171, 158, 137);
        feature.Symbol.InnerColor = Color.White;
        feature.Symbol.Size = 3;
        layer.Renderer.Add(feature);

        feature = feature.Clone();
        feature.MaxScale = 37000;
        feature.MinScale = 16000;
        feature.Symbol.Size = 4;
        feature.LabelFont.Outline = true;
        layer.Renderer.Add(feature);

        feature = feature.Clone();
        feature.MaxScale = 16000;
        feature.MinScale = -1; // no minimum scale
        feature.Symbol.Size = 6;
        layer.Renderer.Add(feature);

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "Railroad.shp");
        layer.MaxScale = 200000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 10;
        layer.Symbol.LineStyle = LineStyle.Railroad;

        //----------------------------------------------------
        layer = map.AddLayer(LayerFolder + "Institution.shp");

        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Times New Roman";
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 12;
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
}
