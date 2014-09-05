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
        // The Map.EnableSession property is set to True in the Properties window
        if (!map.IsSessionRestored) 
        {
            // define zoom levels
            map.ZoomLevels.Add(75000000, "COUNTRY");
            map.ZoomLevels.Add(30000000, "REGION");
            map.ZoomLevels.Add(15000000, "SUBREGION");
            map.ZoomLevels.Add(7400000, "STATE");
            map.ZoomLevels.Add(2500000, "COUNTY");
            map.ZoomLevels.Add(1000000, "CITY");

            AddMapLayers();
        }
    }

    void AddMapLayers()
    {
        AspMap.Layer layer;
        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;

        string LayerFolder = MapPath("MAPS/USA/");

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "states.shp");
        layer.LabelField = "STATE_ABBR";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;
        
        ColorStates(layer);

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "roads.shp");        
        layer.LabelField = "NUMBER";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 12;
        layer.Symbol.LineColor = Color.FromArgb(255, 0, 0);
        layer.Symbol.Size = 1;

        renderer = layer.Renderer;
        renderer.Field = "CLASS";

        // INTERSTATE ROAD CLASS

        feature = renderer.Add();
        feature.MinScale = map.ZoomToScale("SUBREGION");
        feature.LabelStyle = LabelStyle.Shield;
        feature.Value = "Interstate";
        feature.ShieldSymbol.PointStyle = PointStyle.Bitmap;
        feature.ShieldSymbol.Bitmap = MapPath("symbols/interstate_highway.bmp");
        feature.ShieldSymbol.Size = 20;
        feature.ShieldSymbol.TransparentColor = Color.FromArgb(255, 255, 255);
        feature.Symbol.LineStyle = LineStyle.Solid;
        feature.Symbol.Size = 1;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);
        feature.LabelFont.Color = Color.FromArgb(255, 255, 255);

        feature = feature.Clone();
        feature.MinScale = map.ZoomToScale("COUNTY");
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.Size = 3;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);
        feature.Symbol.InnerColor = Color.FromArgb(249, 208, 137);
        renderer.Add(feature);

        feature = feature.Clone();
        feature.MinScale = -1;
        feature.Symbol.LineStyle = LineStyle.DualRoad;
        feature.Symbol.Size = 5;
        renderer.Add(feature);

        // US HIGHWAY ROAD CLASS
        
        feature = renderer.Add();
        feature.MinScale = map.ZoomToScale("SUBREGION");
        feature.LabelStyle = LabelStyle.Shield;
        feature.Value = "US Highway";
        feature.ShieldSymbol.PointStyle = PointStyle.Bitmap;
        feature.ShieldSymbol.Bitmap = MapPath("symbols/us_highway.bmp");
        feature.ShieldSymbol.Size = 20;
        feature.ShieldSymbol.TransparentColor = Color.White;
        feature.Symbol.LineStyle = LineStyle.Solid;
        feature.Symbol.Size = 1;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);

        feature = feature.Clone();
        feature.MinScale = map.ZoomToScale("COUNTY");
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.Size = 3;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);
        feature.Symbol.InnerColor = Color.FromArgb(254, 244, 131);
        renderer.Add(feature);

        feature = feature.Clone();
        feature.MinScale = -1;
        feature.Symbol.LineStyle = LineStyle.DualRoad;
        feature.Symbol.Size = 5;
        renderer.Add(feature);

        // STATE HIGHWAY ROAD CLASS
        
        feature = renderer.Add();
        feature.MinScale = map.ZoomToScale("SUBREGION");
        feature.LabelStyle = LabelStyle.Shield;
        feature.Value = "State Highway";
        feature.ShieldSymbol.PointStyle = PointStyle.Bitmap;
        feature.ShieldSymbol.Bitmap = MapPath("symbols/state_highway.bmp");
        feature.ShieldSymbol.Size = 20;
        feature.ShieldSymbol.TransparentColor = Color.White;
        feature.Symbol.LineStyle = LineStyle.Solid;
        feature.Symbol.Size = 1;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);

        feature = feature.Clone();
        feature.MinScale = map.ZoomToScale("COUNTY");
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.Size = 3;
        feature.Symbol.LineColor = Color.FromArgb(205, 120, 45);
        feature.Symbol.InnerColor = Color.FromArgb(255, 255, 204);
        renderer.Add(feature);

        feature = feature.Clone();
        feature.MinScale = -1;
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.Size = 5;
        renderer.Add(feature);

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "cities.shp");

        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.UseDefaultSymbol = false;

        renderer = layer.Renderer;

        feature = renderer.Add();
        feature.Expression = "CAPITAL = \"Y\"";
        feature.Symbol.PointStyle = PointStyle.CircleWithLargeCenter;
        feature.Symbol.Size = 10;
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 0);
        feature.LabelFont.Name = "Arial";
        feature.LabelFont.Bold = true;
        feature.LabelFont.Size = 14;
        feature.LabelFont.Outline = true;
        feature.LabelFont.OutlineColor = Color.FromArgb(255, 255, 0);

        feature = renderer.Add();
        feature.MaxScale = map.ZoomToScale("SUBREGION");
        feature.Expression = "POP > 500000";
        feature.Symbol.PointStyle = PointStyle.SquareWithLargeCenter;
        feature.Symbol.Size = 10;
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 255);
        feature.LabelFont.Name = "Arial";
        feature.LabelFont.Bold = true;
        feature.LabelFont.Size = 13;
        feature.LabelFont.Outline = true;

        feature = renderer.Add();
        feature.MaxScale = map.ZoomToScale("SUBREGION");
        feature.Expression = "POP > 250000";
        feature.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        feature.Symbol.Size = 10;
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 255);
        feature.LabelFont.Name = "Arial";
        feature.LabelFont.Bold = true;
        feature.LabelFont.Size = 13;
        feature.LabelFont.Outline = true;

        feature = renderer.Add();
        feature.MaxScale = map.ZoomToScale("SUBREGION");
        feature.Expression = "POP > 150000";
        feature.Symbol.PointStyle = PointStyle.SquareWithSmallCenter;
        feature.Symbol.Size = 8;
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 255);
        feature.LabelFont.Size = 12;
        
        feature = renderer.Add();
        feature.MaxScale = map.ZoomToScale("COUNTY");
        feature.Expression = "POP > 50000";
        feature.Symbol.PointStyle = PointStyle.Square;
        feature.Symbol.Size = 6;
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 255);
        feature.LabelFont.Size = 12;
        
        feature = renderer.Add();
        feature.MaxScale = map.ZoomToScale("CITY");
        feature.Expression = "POP <= 50000";
        feature.Symbol.PointStyle = PointStyle.Circle;
        feature.Symbol.Size = 6;
        feature.Symbol.FillColor = Color.FromArgb(255, 255, 255);
        feature.LabelFont.Size = 12;
    }

    void ColorStates(AspMap.Layer statesLayer)
    {
        int index;
        AspMap.Feature feature;
        AspMap.FeatureRenderer renderer;
        AspMap.Recordset records = statesLayer.Recordset;

        renderer = statesLayer.Renderer;
        renderer.Field = "STATE_ABBR";
        index = 1;

        while (!records.EOF)
        {
            feature = renderer.Add();
            feature.Value = records["STATE_ABBR"];
            feature.Symbol.Size = 1;
            feature.Symbol.FillColor = GenerateColor(index);
            feature.Symbol.LineColor = Color.FromArgb(140, 140, 140);
            records.MoveNext();
            index++;
        }
    }

    Color GenerateColor(int currentIndex)
    {
        Color[] colors = { Color.FromArgb(165, 211, 148), Color.FromArgb(231, 166, 165), Color.FromArgb(206, 166, 206), Color.FromArgb(255, 166, 165), Color.FromArgb(173, 174, 214), Color.FromArgb(206, 219, 156), Color.FromArgb(147, 199, 222), Color.FromArgb(239, 227, 90), Color.FromArgb(239, 239, 239), Color.FromArgb(198, 170, 123), Color.FromArgb(231, 227, 123), Color.FromArgb(181, 227, 255), Color.FromArgb(239, 223, 255), Color.FromArgb(231, 255, 239), Color.FromArgb(255, 247, 132), Color.FromArgb(206, 255, 132), Color.FromArgb(140, 255, 151), Color.FromArgb(214, 211, 214), Color.FromArgb(222, 199, 173), Color.FromArgb(173, 174, 214) };
        int colorIndex;
        if (currentIndex >= colors.Length - 1)
            colorIndex = currentIndex - (colors.Length - 1) * (int)(currentIndex / (colors.Length - 1));
        else
            colorIndex = currentIndex;
        return colors[colorIndex];
    }
}

