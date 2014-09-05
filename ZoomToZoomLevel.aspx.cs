using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {       
        map.MapUnit = MeasureUnit.Degree;

        // add zoom levels              level  scale
        // --------------------------------------------
        map.ZoomLevels.Add(1000000); // 0      MaxScale
        map.ZoomLevels.Add(100000);  // 1
        map.ZoomLevels.Add(10000);   // 2      MinScale

        AddLayers();

        if (!IsPostBack)
        {
            // set the initial zoom
            map.CenterAndZoom(new AspMap.Point(1.2939, 52.6331), 0);
        }
    }

    void AddLayers()
    {
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/NORFOLK/");

        layer = map.AddLayer(LayerFolder + "county.shp");
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);
        layer.Symbol.LineColor = Color.FromArgb(242, 236, 223);

        layer = map.AddLayer(LayerFolder + "natural.shp");
        layer.Symbol.FillColor = Color.FromArgb(181, 210, 156);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        layer = map.AddLayer(LayerFolder + "waterways.shp");
        layer.MaxScale = map.ZoomToScale(1); // zoom level = 1
        layer.Symbol.Size = 1;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        layer = map.AddLayer(LayerFolder + "buildings.shp");
        layer.MaxScale = map.ZoomToScale(1); // zoom level = 1
        layer.Symbol.FillColor = Color.Tan;
        layer.Symbol.LineColor = Color.DarkGray;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;

        layer = map.AddLayer(LayerFolder + "roads.shp");
        layer.MaxScale = map.ZoomToScale(2); // zoom level = 2
        layer.DuplicateLabels = false;
        layer.LabelField = "NAME";
        layer.LabelFont.Name = "Arial";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Bold = true;
        layer.LabelFont.Quality = FontQuality.AntiAlias;
        layer.ShowLabels = true;
        layer.Symbol.LineStyle = LineStyle.Road;
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.InnerColor = Color.White;
        layer.Symbol.Size = 8;
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        map.ZoomLevel = ListBox1.SelectedIndex;
    }
}
