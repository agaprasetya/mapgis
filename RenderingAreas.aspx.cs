using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // add an area layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));

        // set the area symbol
        AspMap.Symbol symbol = layer.Symbol;
        symbol.FillStyle = FillStyle.Solid;
        symbol.FillColor = Color.Ivory;
        symbol.LineStyle = LineStyle.Solid;
        symbol.LineColor = Color.Gray;
        symbol.Size = 1; // outline size               

        // set the label font
        AspMap.Font font = layer.LabelFont;
        font.Name = "Verdana";
        font.Size = 16;
        font.Outline = true;
        font.OutlineColor = Color.White;

        // enable labels
        layer.LabelField = "NAME"; // set the NAME field from the world.dbf file
        layer.ShowLabels = true;

        // label styles
        layer.LabelStyle = LabelStyle.PolygonCenter;

        // set the initial scale
        map.ZoomScale(new AspMap.Point(2.35099, 48.85676), 10000000);
    }
    protected void lineStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["world"].Symbol.LineStyle = (LineStyle)Enum.Parse(typeof(LineStyle), lineStyle.SelectedItem.Value);
    }
    protected void lineSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["world"].Symbol.Size = Convert.ToInt32(lineSize.SelectedItem.Value);
    }
    protected void FontName_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["world"].LabelFont.Name = FontName.SelectedItem.Value;
    }
    protected void fontSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["world"].LabelFont.Size = Convert.ToInt32(fontSize.SelectedItem.Value);
    }
    protected void fillStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["world"].Symbol.FillStyle = (FillStyle)Enum.Parse(typeof(FillStyle), fillStyle.SelectedItem.Value);

        if (map["world"].Symbol.FillStyle == FillStyle.Bitmap)
            map["world"].Symbol.Bitmap = MapPath("symbols/CustomFill.bmp");
    }
    protected void fillColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["world"].Symbol.FillColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), fillColor.SelectedItem.Value));
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        lineStyle_SelectedIndexChanged(sender, e);
        lineSize_SelectedIndexChanged(sender, e);
        fillStyle_SelectedIndexChanged(sender, e);
        fillColor_SelectedIndexChanged(sender, e);
        FontName_SelectedIndexChanged(sender, e);
        fontSize_SelectedIndexChanged(sender, e);
    }
}
