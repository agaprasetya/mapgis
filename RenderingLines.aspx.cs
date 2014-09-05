using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // add a line layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/ROUTING/roads.shp"));

        // set the line symbol
        AspMap.Symbol symbol = layer.Symbol;
        symbol.LineStyle = LineStyle.Road;
        symbol.Size = 14;
        symbol.LineColor = Color.LightCoral;
        symbol.InnerColor = Color.White;

        // set the label font
        AspMap.Font font = layer.LabelFont;
        font.Name = "Calibri";
        font.Size = 16;
        font.Quality = FontQuality.AntiAlias;
        font.Outline = true;
        font.OutlineColor = Color.White;

        // enable labels
        layer.LabelField = "FNAME"; // set the FNAME field from the roads.dbf file
        layer.ShowLabels = true;
        layer.DuplicateLabels = false; // remove duplicate labels        

        // set the initial scale
        map.ZoomScale(map.Extent.Center, 50000);
    }
    protected void lineStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["roads"].Symbol.LineStyle = (LineStyle)Enum.Parse(typeof(LineStyle), lineStyle.SelectedItem.Value);
    }
    protected void lineSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["roads"].Symbol.Size = Convert.ToInt32(lineSize.SelectedItem.Value);
    }
    protected void FontName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = FontName.SelectedItem.Value;
        map["roads"].LabelFont.Name = name;

        // use the Calibri font with FontQuality.AntiAlias to render nice looking labels for streets
        if (name == "Calibri")
            map["roads"].LabelFont.Quality = FontQuality.AntiAlias;
        else
            map["roads"].LabelFont.Quality = FontQuality.Default; // use Map.FontQuality
    }
    protected void fontSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        map["roads"].LabelFont.Size = Convert.ToInt32(fontSize.SelectedItem.Value);
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        lineStyle_SelectedIndexChanged(sender, e);
        lineSize_SelectedIndexChanged(sender, e);
        FontName_SelectedIndexChanged(sender, e);
        fontSize_SelectedIndexChanged(sender, e);
    }

}
