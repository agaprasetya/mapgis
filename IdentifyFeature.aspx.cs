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
        AddMapLayers();

        map.MapTool = MapTool.InfoWindow;
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

    protected String GetCalloutText(AspMap.Recordset rs)
    {
        int index = rs.Fields.GetFieldIndex("NAME");
        if (index < 0) index = rs.Fields.GetFieldIndex(rs.Layer.LabelField);
        if (index < 0) index = 0;
        return rs[index].ToString();
    }

    protected void AddMapLayers()
    {
        AspMap.Feature feature;
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/STREETS/");

        layer = map.AddLayer(LayerFolder + "County.shp");
        layer.LabelField = "NAME";
        layer.Symbol.Size = 2;
        layer.Symbol.LineColor = Color.FromArgb(199, 172, 116);
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);

        layer = map.AddLayer(LayerFolder + "Park.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 11;
        layer.LabelFont.Bold = true;
        layer.Symbol.FillColor = Color.FromArgb(143, 175, 47);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        layer = map.AddLayer(LayerFolder + "WaterArea.shp");
        layer.MaxScale = 300000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 12;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        layer = map.AddLayer(LayerFolder + "Water.shp");
        layer.MaxScale = 300000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 9;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;
        layer.LabelFont.Color = Color.FromArgb(0, 0, 128);

        layer = map.AddLayer(LayerFolder + "Airport.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 11;
        layer.Symbol.FillColor = Color.FromArgb(43, 147, 43);

        layer = map.AddLayer(LayerFolder + "Street.shp");
        layer.MaxScale = 150000;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 8;
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
        layer.Symbol.PointStyle = PointStyle.Monument;
        layer.Symbol.Size = 18;
    }
}
