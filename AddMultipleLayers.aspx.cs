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
        map.MapUnit = MeasureUnit.Degree;

        AddMapLayers();
    }

    protected void AddMapLayers()
    {
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/STREETS/");

        // add County layer
        layer = map.AddLayer(LayerFolder + "County.shp");
        layer.Symbol.Size = 2;
        layer.Symbol.LineColor = Color.FromArgb(199, 172, 116);
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);

        // add Park layer
        layer = map.AddLayer(LayerFolder + "Park.shp");
        layer.Symbol.FillColor = Color.FromArgb(143, 175, 47);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        // add WaterArea layer
        layer = map.AddLayer(LayerFolder + "WaterArea.shp");
        layer.MaxScale = 300000;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;        

        // add Water layer
        layer = map.AddLayer(LayerFolder + "Water.shp");
        layer.MaxScale = 300000;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        // add Airport layer
        layer = map.AddLayer(LayerFolder + "Airport.shp");
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.FillColor = Color.Gray;

        // add Street layer
        layer = map.AddLayer(LayerFolder + "Street.shp");
        layer.MaxScale = 150000;
        layer.LabelMaxScale = 37000;
        layer.ShowLabels = true;
        layer.DuplicateLabels = false;
        layer.LabelField = "NAME";
        layer.LabelFont.Name = "Calibri";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Quality = FontQuality.AntiAlias;
        layer.Symbol.Size = 4;
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.InnerColor = Color.White;
        layer.Symbol.LineStyle = LineStyle.Road;

        // add Railroad layer
        layer = map.AddLayer(LayerFolder + "Railroad.shp");
        layer.MaxScale = 200000;
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.LineStyle = LineStyle.DashDotRoad;
        layer.Symbol.Size = 3;

        // add Institution layer
        layer = map.AddLayer(LayerFolder + "Institution.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Tahoma";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 11;
        layer.Symbol.PointStyle = PointStyle.Square;
        layer.Symbol.FillColor = Color.LightYellow;
        layer.Symbol.Size = 10;
    }
}
