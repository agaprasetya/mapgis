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

public partial class SearchByDistance : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // set the map units
        map.MapUnit = MeasureUnit.Degree;

        AddLayers();

        if (!IsPostBack)
        {
            InitTownsList();
            SearchFeature("Norwich", 5);
        }
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        SearchFeature(townsList.SelectedValue, Convert.ToInt32(distanceList.SelectedValue));
    }

    void SearchFeature(string town, int distance)
    {
        errorMsg.Text = "";
        map.Markers.Clear();
        ListBox1.Items.Clear();
        
        AspMap.Layer places = AspMap.Layer.Open(MapPath("MAPS/NORFOLK/places.shp"));

        // get the coordinate of the town
        AspMap.Recordset rs = places.SearchExpression("NAME = \"" + town + "\"");        
        if (rs.EOF) return;

        AspMap.Point townCoordinate = rs.Shape.GetPoint(0);

        // convert the distance from miles to map units
        double distanceInMapUnits = map.ConvertDistance(distance, MeasureUnit.Mile, map.MapUnit);
        
        AspMap.Layer points = AspMap.Layer.Open(MapPath("MAPS/NORFOLK/points.shp"));
        
        // search for nearest features
        rs = points.SearchNearest(townCoordinate, distanceInMapUnits, "TYPE = \"pub\"");
        if (rs.EOF)
        {
            errorMsg.Text = "No locations found.";
            return;
        }

        // add markers
        while (!rs.EOF)
        {
            if (map.Markers.Count >= 10) break; // limit the results to 10 records

            AspMap.Point position = rs.Shape.GetPoint(0);

            string tooltip = rs["NAME"].ToString();
            string html = "<b>" + rs["NAME"].ToString() + "</b><br/>" + town + "<br/><img src=\"SYMBOLS/building.gif\">";

            AspMap.Web.Marker marker = new AspMap.Web.Marker(position, tooltip, html);

            map.Markers.Add(marker);
            
            rs.MoveNext();
        }

        // zoom into the markers
        AspMap.Rectangle markerExtent = new AspMap.Rectangle();
        foreach (Marker marker in map.Markers) markerExtent.Union(marker.Position);

        map.Extent = markerExtent;

        // fill the list box
        ListBox1.DataSource = map.Markers;
        ListBox1.DataTextField = "TOOLTIP";
        ListBox1.DataBind();
    }

    void InitTownsList()
    { 
        AspMap.Layer places = AspMap.Layer.Open(MapPath("MAPS/NORFOLK/places.shp"));
        AspMap.Recordset rs = places.SearchExpression("TYPE = \"town\" or TYPE=\"city\"");
        if (!rs.EOF)
        {
            townsList.DataSource = rs;
            townsList.DataTextField = "NAME";
            townsList.DataValueField = "NAME";
            townsList.DataBind();
        }
    }

    void AddLayers()
    {
        // initialize the ZoomLevels collection
        map.ZoomLevels.Add(1155581);
        map.ZoomLevels.Add(577790);
        map.ZoomLevels.Add(288895);
        map.ZoomLevels.Add(144447);
        map.ZoomLevels.Add(72223);
        map.ZoomLevels.Add(36111);
        map.ZoomLevels.Add(18055);
        map.ZoomLevels.Add(9027);
        map.ZoomLevels.Add(4513);

        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/NORFOLK/");

        layer = map.AddLayer(LayerFolder + "county.shp");
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);
        layer.Symbol.LineColor = Color.FromArgb(242, 236, 223);

        layer = map.AddLayer(LayerFolder + "natural.shp");
        layer.Symbol.FillColor = Color.FromArgb(181, 210, 156);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        layer = map.AddLayer(LayerFolder + "waterways.shp");
        layer.MaxScale = map.ZoomToScale(1);
        layer.Symbol.Size = 1;
        layer.Symbol.FillColor = Color.FromArgb(159, 159, 223);
        layer.Symbol.LineColor = layer.Symbol.FillColor;

        feature = layer.Renderer.Add();
        feature.MaxScale = map.ZoomToScale(4);
        layer.Symbol.Size = 3;

        layer = map.AddLayer(LayerFolder + "buildings.shp");
        layer.MaxScale = map.ZoomToScale(5);
        layer.Symbol.FillColor = Color.Tan;
        layer.Symbol.LineColor = Color.DarkGray;
        layer.LabelField = "NAME";
        layer.ShowLabels = true;

        layer = map.AddLayer(LayerFolder + "roads.shp");
        layer.MaxScale = map.ZoomToScale(1);
        layer.DuplicateLabels = false;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 11;
        layer.ShowLabels = true;
        layer.UseDefaultSymbol = false; // do not use the default Layer.Symbol

        renderer = layer.Renderer;
        renderer.Field = "TYPE";

        // primary roads
        feature = new AspMap.Feature();
        feature.MaxScale = map.ZoomToScale(1);
        feature.MinScale = -1;
        feature.Value = "primary";
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.LineColor = Color.FromArgb(222, 156, 112);
        feature.Symbol.InnerColor = Color.FromArgb(255, 195, 69);
        feature.Symbol.Size = 7;
        feature.LabelFont.Name = "Calibri";
        feature.LabelFont.Quality = FontQuality.AntiAlias;
        feature.LabelFont.Size = 16;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);

        // secondary roads
        feature = new AspMap.Feature();
        feature.MaxScale = map.ZoomToScale(3);
        feature.MinScale = -1;
        feature.Value = "secondary";
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.LineColor = Color.LightGray;
        feature.Symbol.InnerColor = Color.Yellow;
        feature.Symbol.Size = 6;
        feature.LabelFont.Size = 15;
        feature.LabelFont.Name = "Calibri";
        feature.LabelFont.Quality = FontQuality.AntiAlias;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);

        // set different line width for other street types (for different zoom levels)
        feature = new AspMap.Feature();
        feature.MaxScale = map.ZoomToScale(4);
        feature.MinScale = map.ZoomToScale(4);
        feature.Symbol.LineColor = Color.LightGray;
        feature.Symbol.Size = 1;
        feature.ShowLabels = false;
        renderer.Add(feature);

        feature = feature.Clone();
        feature.MaxScale = map.ZoomToScale(5);
        feature.MinScale = map.ZoomToScale(5);
        feature.Symbol.Size = 2;
        renderer.Add(feature);

        feature = feature.Clone();
        feature.MaxScale = map.ZoomToScale(6);
        feature.MinScale = map.ZoomToScale(6);
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.LineColor = Color.LightGray;
        feature.Symbol.InnerColor = Color.White;
        feature.Symbol.Size = 5;
        renderer.Add(feature);

        feature = feature.Clone();
        feature.MinScale = map.ZoomToScale(7);
        feature.Symbol.Size = 6;
        feature.LabelFont.Size = 14;
        feature.LabelFont.Name = "Calibri";
        feature.LabelFont.Quality = FontQuality.AntiAlias;
        feature.LabelFont.Outline = true;
        feature.ShowLabels = true;
        renderer.Add(feature);

        feature = feature.Clone();
        feature.MinScale = -1;
        feature.Symbol.Size = 7;
        feature.LabelFont.Outline = true;
        feature.ShowLabels = true;
        renderer.Add(feature);

        layer = map.AddLayer(LayerFolder + "railways.shp");
        layer.MaxScale = map.ZoomToScale(2);
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.LineStyle = LineStyle.DashDotRoad;
        layer.Symbol.Size = 3;

        layer = map.AddLayer(LayerFolder + "places.shp");
        layer.LabelField = "NAME";
        layer.ShowLabels = true;
        layer.UseDefaultSymbol = false;

        renderer = layer.Renderer;
        renderer.Field = "TYPE";

        // city
        feature = new AspMap.Feature();
        feature.Value = "city";
        feature.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        feature.Symbol.FillColor = Color.Yellow;
        feature.Symbol.Size = 12;
        feature.LabelFont.Size = 16;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);

        // town
        feature = new AspMap.Feature();
        feature.Value = "town";
        feature.Symbol.PointStyle = PointStyle.Circle;
        feature.Symbol.FillColor = Color.Yellow;
        feature.Symbol.Size = 8;
        feature.LabelFont.Size = 15;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);

        // other places
        feature = new AspMap.Feature();
        feature.MaxScale = map.ZoomToScale(3);
        feature.Symbol.PointStyle = PointStyle.Circle;
        feature.Symbol.FillColor = Color.Yellow;
        feature.Symbol.Size = 4;
        feature.LabelFont.Size = 13;
        feature.LabelFont.Outline = true;
        renderer.Add(feature);
    }
}
