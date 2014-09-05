using System;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddLayer();

        map.MapTool = MapTool.Line;
    }

    protected void map_LineTool(object sender, LineToolEventArgs e)
    {
        AspMap.Recordset rs;
        MapShape ms;        

        double distance = map.ConvertDistance(1000, MeasureUnit.Mile, MeasureUnit.Degree);

        rs = map["world"].SearchBuffer(e.Line, distance, SearchMethod.Inside);

        // highlight the result        
        map.MapShapes.Clear();

        while (!rs.EOF)
        {
            ms = map.MapShapes.Add(rs.Shape);
            ms.Symbol.FillColor = Color.Yellow;
            ms.Symbol.Size = 1;
            rs.MoveNext();
        }

        Polygon bufferShape = new Polyline(e.Line).Buffer(distance);
        ms = map.MapShapes.Add(bufferShape);
        ms.Symbol.FillStyle = FillStyle.Invisible;
        ms.Symbol.Size = 1;

        ListBox1.DataSource = rs;
        ListBox1.DataTextField = "NAME";
        ListBox1.DataBind();        
    }

    protected void AddLayer()
    {
        // add the world.shp shapefile as a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));

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
        layer.Symbol.FillColor = Color.Ivory;   
    }
}
