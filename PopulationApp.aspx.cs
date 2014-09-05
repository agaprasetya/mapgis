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

public partial class PopulationApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddMapLayers();
        DoThematicMapping();
    }

    void DoThematicMapping()
    {
        AspMap.Feature feature;
        AspMap.Layer layer = map["cities"];
        AspMap.FeatureRenderer renderer = layer.Renderer;

        feature = renderer.Add();
        feature.Expression = "POP <= 5000";
        feature.Symbol.FillColor = Color.White;
        feature.Symbol.Size = 4;
        AddLegendItem(layer.LayerType, feature.Symbol, "0 - 5000");

        feature = renderer.Add();
        feature.Expression = "POP <= 50000";
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 0);
        feature.Symbol.Size = 8;
        AddLegendItem(layer.LayerType, feature.Symbol, "5000 - 50000");

        feature = renderer.Add();
        feature.Expression = "POP <= 250000";
        feature.Symbol.FillColor = Color.FromArgb(255, 0, 255);
        feature.Symbol.Size = 12;
        AddLegendItem(layer.LayerType, feature.Symbol, "50000 - 250000");

        feature = renderer.Add();
        feature.Expression = "POP <= 500000";
        feature.Symbol.FillColor = Color.Blue;
        feature.Symbol.Size = 16;
        AddLegendItem(layer.LayerType, feature.Symbol, "250000 - 500000");

        feature = renderer.Add();
        feature.Expression = "POP <= 1000000";
        feature.Symbol.FillColor = Color.FromArgb(0, 255, 255);
        feature.Symbol.Size = 20;
        AddLegendItem(layer.LayerType, feature.Symbol, "500000 - 1000000");

        feature = renderer.Add();
        feature.Expression = "POP <= 5000000";
        feature.Symbol.FillColor = Color.Green;
        feature.Symbol.Size = 24;
        AddLegendItem(layer.LayerType, feature.Symbol, "1000000 - 5000000");

        feature = renderer.Add();
        feature.Expression = "POP > 5000000";
        feature.Symbol.FillColor = Color.Red;
        feature.Symbol.Size = 28;
        AddLegendItem(layer.LayerType, feature.Symbol, "5000000 +");

        legend.IconWidth = feature.Symbol.Size;
        legend.IconHeight = feature.Symbol.Size;
    }

    void AddLegendItem(LayerType type, AspMap.Symbol symbol, string text)
    {
        LegendItem item = legend.Insert(0);
        item.LayerType = type;
        item.Text = text;
        item.Symbol = symbol;
    }

    void AddMapLayers()
    {
        string LayerFolder = MapPath("MAPS/USA/");

        AspMap.Layer layer = map.AddLayer(LayerFolder + "states.shp");
        layer.LabelField = "STATE_ABBR";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.Symbol.LineColor = Color.LightGray;
                
        layer = map.AddLayer(LayerFolder + "cities.shp");
        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.LabelMaxScale = 5000000;
        layer.LabelFont.Name = "Arial";
        layer.LabelFont.Outline = true;
        layer.LabelFont.Size = 13;

        if (!IsPostBack)
        {
            statesList.DataSource = map["states"].Recordset;
            statesList.DataTextField = "STATE_NAME";
            statesList.DataValueField = "STATE_ABBR";
            statesList.DataBind();
        }
    }

    protected void statesList_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        AspMap.Recordset state;
        state = map["states"].SearchExpression("STATE_ABBR = \"" + statesList.SelectedValue.ToUpper() + "\"");
        if (!state.EOF)
        {
            map.Extent = state.RecordExtent;
        }
    }
}
