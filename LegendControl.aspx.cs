using System;
using System.IO;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddLayers();                
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        // set legend properties
        legend.AutoSize = true;
        legend.Add("Legend:"); // title
        legend.LegendFont.Name = "Arial";
        legend.LegendFont.Size = 16;
        legend.LegendFont.Bold = true;

        // populate the legend from the map layers collection
        // see also the Legend.Populate method
        for (int i = 0; i < map.LayerCount; i++)
        {
            if (map.IsLayerVisible(i))
            {
                AspMap.Layer layer = map[i];
                legend.Add(layer.Name, layer.LayerType, layer.Symbol);
            }
        }
   }

    void AddLayers()
    { 
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
        layer.LabelFont.Size = 9;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;
        layer.LabelFont.Color = Color.FromArgb(0, 0, 128);

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
        layer.LabelFont.Name = "Calibri";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.LabelMaxScale = 37000;
        layer.ShowLabels = true;
        layer.DuplicateLabels = false;
        layer.Symbol.Size = 4;
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.InnerColor = Color.White;
        layer.Symbol.LineStyle = LineStyle.Road;
       
        layer = map.AddLayer(LayerFolder + "Railroad.shp");
        layer.MaxScale = 200000;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 10;
        layer.Symbol.LineStyle = LineStyle.Railroad;

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
