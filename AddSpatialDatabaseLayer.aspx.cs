using System;
using System.Drawing;
using AspMap;
using AspMap.Data;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        string connectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" + MapPath("DATA/shapes.mdb");
        
        AspMap.Data.WkbDataLayer wkbDataLayer = new WkbDataLayer("System.Data.OleDb", connectionString, "World", "WKBDATA");
        wkbDataLayer.FieldList = "ID, NAME";
        wkbDataLayer.ShapeType = ShapeType.Polygon;
        wkbDataLayer.Extent = new AspMap.Rectangle(-180, 90, 180, -90); // decimal degrees
        wkbDataLayer.CoordinateSystem = CoordSystem.WGS1984;

        AspMap.Layer layer = map.AddLayer(wkbDataLayer);

        // labels
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;

        // line size and color
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;

        // fill color
        layer.Symbol.FillColor = Color.Khaki;    
    }
}
