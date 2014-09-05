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

public partial class CoordSystemApp : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // project the layers to World Winkel I
        map.CoordinateSystem = new AspMap.CoordSystem(CoordSystemCode.PCS_WorldWinkelI);

        AddMapLayers();
    }

    private void AddMapLayers()
    {
        string LayerFolder = MapPath("MAPS/PROJECTED/");

        map.AddLayer(LayerFolder + "world.shp");
        map.AddLayer(LayerFolder + "lakes.shp");
        map.AddLayer(LayerFolder + "capitals.shp");

        AspMap.Layer layer;

        // World Mercator
        layer = map["world"];
        layer.CoordinateSystem = new CoordSystem(CoordSystemCode.PCS_WorldMercator);
        layer.ShowLabels = true;
        layer.LabelField = "CODE";
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.Symbol.LineColor = Color.Gray;

        // Sphere Miller Cylindrical
        layer = map["lakes"];
        layer.CoordinateSystem = new CoordSystem(CoordSystemCode.PCS_SphereMillerCylindrical);
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 10;
        layer.LabelFont.Outline = true;
        layer.Symbol.FillColor = Color.Blue;
        layer.Symbol.LineColor = layer.Symbol.FillColor;
        layer.LabelStyle = LabelStyle.PolygonCenter;

        // WGS 1984
        layer = map["capitals"];
        layer.CoordinateSystem = CoordSystem.WGS1984;
        layer.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        layer.Symbol.Size = 8;
        layer.Symbol.LineColor = Color.Gray;
        layer.Symbol.FillColor = Color.White;
        layer.ShowLabels = true;
        layer.LabelMaxScale = 100000000;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Outline = true;
    }
 
}
