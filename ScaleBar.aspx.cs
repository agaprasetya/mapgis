using System;
using System.IO;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;

        // set the map unit to Degree because the units of the world.shp shapefile are decimal degrees
        map.MapUnit = MeasureUnit.Degree;

        map.ScaleBar.Visible = true;
        map.ScaleBar.Symbol.FillColor = Color.Yellow;
        map.ScaleBar.Symbol.LineColor = Color.Gray;
        map.ScaleBar.Symbol.Size = 1; // border size in pixels
        map.ScaleBar.Font.Name = "Arial";
        map.ScaleBar.Font.Bold = true;
    }
    
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex == 0)
        {
            map.ScaleBar.BarUnit = UnitSystem.Imperial;
            map.ScaleBar.MilesString = "mi";
            map.ScaleBar.FeetString = "ft";
        }
        else
        {
            map.ScaleBar.BarUnit = UnitSystem.Metric;
            map.ScaleBar.KilometersString = "km";
            map.ScaleBar.MetersString = "m";
        }
    }
}
