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

public partial class ClientApiApp : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        map.ZoomLevels.Add(102400000);
        map.ZoomLevels.Add(51200000);
        map.ZoomLevels.Add(25600000);
        map.ZoomLevels.Add(12800000);
        map.ZoomLevels.Add(6400000);
        map.ZoomLevels.Add(3200000);
        map.ZoomLevels.Add(1600000);
        map.ZoomLevels.Add(800000);
        map.ZoomLevels.Add(400000);
        map.ZoomLevels.Add(200000);
        map.ZoomLevels.Add(100000);

        AddMapLayers();
    }

    void AddMapLayers()
    {
        AspMap.Layer layer;

        string LayerFolder = MapPath("MAPS/USA/");

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "states.shp");
        layer.LabelField = "STATE_ABBR";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "roads.shp");        
        layer.Symbol.LineColor = Color.FromArgb(255, 0, 0);
        layer.Symbol.Size = 1;

        //------------------------------------------------------------------
        layer = map.AddLayer(LayerFolder + "capitals.shp");

        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.Symbol.PointStyle = PointStyle.CircleWithSmallCenter;
        layer.Symbol.Size = 10;
        layer.Symbol.FillColor = Color.Yellow;
    }
}

