using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // add a background layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;
        layer.Symbol.FillColor = Color.Ivory;

        // add a point layer
        layer = map.AddLayer(MapPath("MAPS/WORLD/capitals.shp"));

        // set the point symbol
        AspMap.Symbol symbol = layer.Symbol;
        symbol.PointStyle = PointStyle.CircleWithLargeCenter;
        symbol.Size = 16;
        symbol.LineColor = Color.Gray;
        symbol.FillColor = Color.Yellow;

        // set the label font
        AspMap.Font font = layer.LabelFont;
        font.Name = "Verdana";
        font.Size = 16;
        font.Outline = true;
        font.OutlineColor = Color.Yellow;

        // enable labels
        layer.LabelField = "NAME"; // set the NAME field from the capitals.dbf file
        layer.ShowLabels = true;

        // set the initial scale
        map.ZoomScale(new AspMap.Point(2.35099, 48.85676), 10000000);
    }
    protected void pointStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        Symbol symbol = map["capitals"].Symbol;

        if (pointStyle.SelectedItem.Value == "Custom Bitmap")
        {           
            symbol.PointStyle = PointStyle.Bitmap;
            symbol.Bitmap = MapPath("symbols/airport.bmp");
            symbol.TransparentColor = Color.White;
        }
        else if (pointStyle.SelectedItem.Value == "Custom Font")
        {
            symbol.PointStyle = PointStyle.Font;
            symbol.PointFont.Name = "Webdings";
            symbol.PointFont.Color = Color.Blue;
            symbol.CharIndex = 64;
        }
        else
            symbol.PointStyle = (PointStyle)Enum.Parse(typeof(PointStyle), pointStyle.SelectedItem.Value);
    }
    protected void pointSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["capitals"].Symbol.Size = Convert.ToInt32(pointSize.SelectedItem.Value);
    }
    protected void FontName_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["capitals"].LabelFont.Name = FontName.SelectedItem.Value;
    }
    protected void fontSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["capitals"].LabelFont.Size = Convert.ToInt32(fontSize.SelectedItem.Value);
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        pointStyle_SelectedIndexChanged(sender, e);
        pointSize_SelectedIndexChanged(sender, e);
        FontName_SelectedIndexChanged(sender, e);
        fontSize_SelectedIndexChanged(sender, e);
    }
}
