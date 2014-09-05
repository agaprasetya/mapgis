using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // add a line layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/USA/roads.shp"));       

        // set the line symbol
        AspMap.Symbol lineSymbol = layer.Symbol;
        lineSymbol.LineStyle = LineStyle.DualRoad;
        lineSymbol.Size = 5;
        lineSymbol.LineColor = Color.FromArgb(205, 120, 45);
        lineSymbol.InnerColor = Color.FromArgb(249, 208, 137);

        // set the highway label by using the Layer.ShieldSymbol property
        AspMap.Symbol highwaySymbol = layer.ShieldSymbol;
        highwaySymbol.PointStyle = PointStyle.Bitmap;
        highwaySymbol.Bitmap = MapPath("symbols/interstate_highway.bmp");
        highwaySymbol.Size = 20;
        highwaySymbol.TransparentColor = Color.White;
        layer.LabelField = "NUMBER"; // from roads.dbf
        layer.LabelFont.Color = Color.White;
        layer.LabelFont.Size = 13;

        // enable shield labels
        layer.LabelStyle = LabelStyle.Shield;
        layer.ShowLabels = true;

        // set the initial scale
        map.ZoomScale(map.Extent.Center, 10000000);
    }
}
