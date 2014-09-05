using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        AddLayers();

        if (!IsPostBack)
            AddMarkers();

        map.Markers.EnableClusters = true;
        map.Markers.ClusterDistance = 20; // pixels        
    }

    protected void AddMarkers()
    {
        map.Markers.Clear();

        AspMap.Layer layer = Layer.Open(MapPath("MAPS/NORFOLK/points.shp"));

        AspMap.Recordset locations = layer.SearchExpression("TYPE = \"pub\"");

        while (!locations.EOF)
        {
            Marker marker = new Marker(locations.Shape.Centroid, locations["NAME"].ToString());
            map.Markers.Add(marker);

            locations.MoveNext();
        }

        layer.Dispose(); 
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
        layer.MaxScale = 500000;
        layer.Symbol.Size = 1;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        layer = map.AddLayer(LayerFolder + "buildings.shp");
        layer.MaxScale = 100000;
        layer.Symbol.FillColor = Color.Tan;
        layer.Symbol.LineColor = Color.DarkGray;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;

        layer = map.AddLayer(LayerFolder + "roads.shp");
        layer.MaxScale = 50000;
        layer.DuplicateLabels = false;
        layer.LabelField = "NAME";
        layer.LabelFont.Name = "Calibri";
        layer.LabelFont.Size = 16;
        layer.LabelFont.Quality = FontQuality.AntiAlias;
        layer.ShowLabels = true;
        layer.Symbol.LineStyle = LineStyle.Road;
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.InnerColor = Color.White;
        layer.Symbol.Size = 8;
    }
}
