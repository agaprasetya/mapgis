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
    }

    void AddMapLayers()
    {
        // define zoom levels            zoom   scale
        //----------------------------------------------
        map.ZoomLevels.Add(75000000); // 0      MaxScale
        map.ZoomLevels.Add(30000000); // 1
        map.ZoomLevels.Add(15000000); // 2
        map.ZoomLevels.Add(7400000);  // 3
        map.ZoomLevels.Add(2500000);  // 4
        map.ZoomLevels.Add(1000000);  // 5      MinScale

        AspMap.Layer layer;
        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;

        // add the roads.shp file
        layer = map.AddLayer(MapPath("MAPS/USA/roads.shp"));

        // default styles
        layer.LabelField = "NUMBER";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 12;
        layer.Symbol.LineColor = Color.FromArgb(205, 120, 45);
        layer.Symbol.Size = 1;

        renderer = layer.Renderer;
        renderer.Field = "CLASS"; // road class

        // The code below uses the Feature.MinScale property to display different 
        // road styles/sizes at different zoom levels.
        // For example, if the size of a road must be 2 pixels from the 0 to 3 zoom level, 
        // set feature.MinScale = map.ZoomToScale(3).

        // styles for 0 - 1 zoom levels
        feature = renderer.Add();
        feature.MinScale = map.ZoomToScale(1); // 0 - 1
        feature.Symbol.LineStyle = LineStyle.Solid;
        feature.Symbol.Size = 2;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);
        feature.LabelStyle = LabelStyle.Shield;
        feature.ShieldSymbol.FillColor = Color.White;

        // styles for 2 - 3 zoom levels
        feature = feature.Clone();
        feature.MinScale = map.ZoomToScale(3); // 2 - 3
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.Size = 5;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);
        feature.Symbol.InnerColor = Color.FromArgb(249, 208, 137);
        feature.LabelFont.Size = 14;
        renderer.Add(feature);

        // styles for 4 - 5 zoom levels
        feature = feature.Clone();
        feature.MinScale = map.ZoomToScale(5); // 4 - 5
        feature.Symbol.LineStyle = LineStyle.DualRoad;
        feature.Symbol.Size = 7;
        feature.LabelFont.Size = 16;
        feature.LabelFont.Bold = true;
        renderer.Add(feature);
    }
}

