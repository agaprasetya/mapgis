using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        // add a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;

        // add a marker
        if (!IsPostBack)
        {
            string HTML = "<div style=\"width:300px;\"><i>Paris is the capital and most populous city of France. It is situated on the river Seine, in the north of the country, at the heart of the Ile-de-France region.</i><br/><a href=\"https://en.wikipedia.org/wiki/Paris\" target=\"_blank\">Wikipedia</a></div>";
        
            AspMap.Point point = new AspMap.Point(2.35099, 48.85676); // longitude, latitude
            Marker marker = new Marker(point, "Paris, France", HTML);
            map.Markers.Add(marker);
        }

    }
}
