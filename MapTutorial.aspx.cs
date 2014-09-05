using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using AspMap;
using AspMap.Data;
using AspMap.Web;

public partial class MapTutorial : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // define zoom levels
        Map1.ZoomLevels.Add(75000000, "COUNTRY");
        Map1.ZoomLevels.Add(30000000, "REGION");
        Map1.ZoomLevels.Add(15000000, "SUBREGION");
        Map1.ZoomLevels.Add(7500000, "STATE");
        Map1.ZoomLevels.Add(2500000, "COUNTY");
        Map1.ZoomLevels.Add(1000000, "CITY");

        AddMapLayers();

        AddDatabase();
    }

    protected void AddMapLayers()
    {
        AspMap.Layer layer;
        string MapDir = MapPath("MAPS/USA/");

        // add States layer
        layer = Map1.AddLayer(MapDir + "States.shp");

        layer.LabelField = "STATE_ABBR";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;

        RenderStates(layer);

        // add Roads layer
        layer = Map1.AddLayer(MapDir + "Roads.shp");

        layer.Symbol.LineColor = Color.Red;
        layer.Symbol.Size = 2;

        layer.LabelField = "NUMBER";
        layer.ShowLabels = true;
        layer.LabelFont.Size = 12;

        RenderRoads(layer);

        // add Capitals layer
        layer = Map1.AddLayer(MapDir + "Capitals.shp");

        layer.Symbol.PointStyle = PointStyle.CircleWithLargeCenter;
        layer.Symbol.Size = 10;
        layer.Symbol.FillColor = Color.FromArgb(255, 255, 0);

        layer.LabelField = "CITY_NAME";
        layer.ShowLabels = true;
        layer.LabelFont.Name = "Arial";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;
        layer.LabelFont.OutlineColor = Color.FromArgb(255, 255, 0);
    }

    void RenderRoads(AspMap.Layer RoadLayer)
    {
        FeatureRenderer renderer;
        Feature feature;

        renderer = RoadLayer.Renderer;
        renderer.Field = "CLASS";

        feature = renderer.Add();
        feature.Value = "Interstate";
        feature.Symbol.LineColor = Color.Red;
        feature.Symbol.Size = 2;

        feature = renderer.Add();
        feature.Value = "US Highway";
        feature.Symbol.LineColor = Color.Blue;
        feature.Symbol.Size = 2;

        feature = renderer.Add();
        feature.Value = "State Highway";
        feature.Symbol.LineColor = Color.Green;
        feature.Symbol.Size = 2;
    }

    void RenderStates(AspMap.Layer StateLayer)
    {
        FeatureRenderer renderer;
        Feature feature;

        renderer = StateLayer.Renderer;

        feature = renderer.Add();
        feature.Expression = "POPULATION < 1000000";
        feature.Symbol.FillColor = Color.LightYellow;

        feature = renderer.Add();
        feature.Expression = "POPULATION < 5000000";
        feature.Symbol.FillColor = Color.Yellow;

        feature = renderer.Add();
        feature.Expression = "POPULATION < 10000000";
        feature.Symbol.FillColor = Color.Pink;

        feature = renderer.Add();
        feature.Expression = "POPULATION >= 10000000";
        feature.Symbol.FillColor = Color.Red;
    }

    void AddDatabase()
    {
        string dataFile = MapPath("DATA/airports.mdb");       
        string connectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" + dataFile;

        PointDataLayer pointData = new PointDataLayer("System.Data.OleDb", connectionString, "airports", "LONGITUDE", "LATITUDE");

        AspMap.Layer dbLayer = Map1.AddLayer(pointData);

        if (dbLayer == null)
            return;

        dbLayer.Name = "Airports";
        dbLayer.Symbol.PointStyle = PointStyle.Circle;
        dbLayer.Symbol.FillColor = Color.Silver;

        dbLayer.LabelField = "DESCRIP";
        dbLayer.LabelFont.Name = "Arial";
        dbLayer.LabelFont.Size = 12;
        dbLayer.ShowLabels = true;
        // dislpay the labels when MapScale is less than 15000000
        dbLayer.LabelMaxScale = 15000000;

	dbLayer.MaxScale = Map1.ZoomToScale("REGION");
    }

    protected void zoomFull_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Map1.ZoomFull();
    }

    protected void Map1_InfoTool(object sender, AspMap.Web.InfoToolEventArgs e)
    {
        Map1.Callouts.Clear();

        AspMap.Recordset records = Map1.Identify(e.InfoPoint, 5);

        if (!records.EOF)
        {
            DataGrid1.DataSource = records;
            DataGrid1.DataBind();
            DataGrid1.Caption = records.Layer.Name.ToUpper();

            Callout callout = Map1.Callouts.Add();
            callout.X = e.InfoPoint.X;
            callout.Y = e.InfoPoint.Y;
            callout.Font.Size = 16;

            if (records.Layer.LabelField.Length > 0)
                callout.Text = records[records.Layer.LabelField].ToString();
            else
                callout.Text = records[0].ToString();
        }
    }

    protected void Map1_InfoWindowTool(object sender, InfoWindowToolEventArgs e)
    {
        AspMap.Recordset records = Map1.Identify(e.InfoPoint, 5);

        // add a DataGrid control to the info window to render the records
        if (!records.EOF)
        {
            e.InfoWindow.Width = 300;
            e.InfoWindow.Height = 150;
            e.InfoWindow.HorizontalAlign = HorizontalAlign.Center;
            e.InfoWindow.Font.Bold = true;
            e.InfoWindow.ScrollBars = System.Web.UI.WebControls.ScrollBars.Auto;

            DataGrid grid = new DataGrid();
            grid.DataSource = records;
            grid.DataBind();

            e.InfoWindow.Controls.Add(grid);

            if (records.Layer.LabelField.Length > 0)
                e.InfoWindow.Content = records[records.Layer.LabelField].ToString();
            else
                e.InfoWindow.Content = records[0].ToString();
        }
    }
}
