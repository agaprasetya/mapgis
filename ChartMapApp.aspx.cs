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
using AspMap.Web;

public partial class ChartMapApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddMapLayers();
        DoThematicMapping();
    }

    void DoThematicMapping()
    {
        AspMap.Layer layer = map["states"];
        AspMap.ChartRenderer chartRenderer = layer.ChartRenderer;

        // population 1990
        chartRenderer.Add("POP1990", Color.Red);
        // population 1997
        chartRenderer.Add("POP1997", Color.LightGreen);

        if (chartType.SelectedValue == "Bar")
        {
            chartRenderer.ChartType = AspMap.ChartType.Bar;
            chartRenderer.BarHeight = 40;
            chartRenderer.BarWidth = 30;
        }
        else // Pie
        {
            chartRenderer.ChartType = AspMap.ChartType.Pie;
            chartRenderer.MinPieSize = 40;
            chartRenderer.MaxPieSize = 60;            
        }

        chartRenderer.OutlineColor = Color.Black;
        chartRenderer.OutlineWidth = 1;
        
        // populate the legend
        foreach (ChartItem item in chartRenderer)
        {
            AddLegendItem(LayerType.Polygon, item.FillColor, item.Field);
        }
    }

    void AddLegendItem(LayerType type, Color fillColor, string text)
    {
        AspMap.Symbol s = new AspMap.Symbol();
        s.FillColor = fillColor;
        s.Size = 1;
        LegendItem item = legend.Insert(0);
        item.LayerType = type;
        item.Text = text;
        item.Symbol = s;
    }

    void AddMapLayers()
    {
        string LayerFolder = MapPath("MAPS/USA/");

        AspMap.Layer layer = map.AddLayer(LayerFolder + "states.shp");

        layer.LabelField = "STATE_ABBR";
        layer.LabelStyle = LabelStyle.Default;
        layer.ShowLabels = true;
        layer.LabelMaxScale = 50000000;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Bold = true;        
        layer.Symbol.LineColor = Color.LightGray;

        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MapPath("DATA/demography.mdb");
        string select = "SELECT STATE_ABBR, POP1990, POP1997 FROM demography";

        OleDbDataAdapter adapter = new OleDbDataAdapter(select,
                    connectionString);
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        
        DataTable table = new DataTable();

        adapter.Fill(table);

        // create a relation between the USA shapefile and the 
        // database by the state abbreviation field       
        if (!layer.AddRelate("STATE_ABBR", table, "STATE_ABBR"))
        {
            throw new Exception("Cannot add a relate to the database: " + MapPath("DATA/demography.mdb"));
        }
    }

    protected void fullExtent_Click(object sender, System.EventArgs e)
    {
        map.ZoomFull();
    }
}
