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

public partial class DemographicMapApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.Enabled = false;

        AddMapLayers();

        if (!IsPostBack)
        {
            AspMap.Fields fields = map["USA"].Recordset.Fields;
            for (int i = 4; i < fields.Count; i++)
                thematicFields.Items.Add(fields[i].Name);

            thematicFields.SelectedValue = "POP1990";
        }

        DoThematicMapping();
    }

    void DoThematicMapping()
    {
        double Delta, Prev, Curr;

        // calculate statistics
        AspMap.Statistics statistics = map["USA"].Recordset.CalculateStatistics(thematicFields.SelectedValue);

        // calculate ranges
        Color[] colors = { Color.FromArgb(251, 234, 208), Color.FromArgb(248, 215, 165), 
								 Color.FromArgb(244, 197, 125), Color.FromArgb(240, 174, 74),
								 Color.FromArgb(236, 130, 55), Color.FromArgb(230, 100, 40) };

        Delta = (statistics.Max - statistics.Min) / colors.Length;
        Prev = statistics.Min;

        legend.Add("No data", LayerType.Polygon, map["USA"].Symbol);

        for (int index = 0; index < colors.Length; index++)
        {
            Curr = Prev + Delta;

            AspMap.Feature feature = map["USA"].Renderer.Add();
            feature.Expression = thematicFields.SelectedValue + "<=" + Convert.ToInt32(Curr);
            feature.Symbol.FillColor = colors[index];
            feature.Symbol.LineColor = Color.White;

            legend.Add(Convert.ToInt32(Prev) + " - " + Convert.ToInt32(Curr), LayerType.Polygon, feature.Symbol);

            Prev = Curr;
        }
    }

    void AddMapLayers()
    {
        string LayerFolder = MapPath("MAPS/USA/");

        AspMap.Layer layer = map.AddLayer(LayerFolder + "USA.shp");

        layer.Symbol.FillColor = Color.White; // no data
        layer.ShowLabels = true;
        layer.LabelField = "STATE_ABBR";
        layer.LabelStyle = LabelStyle.PolygonCenter;

        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MapPath("DATA/demography.mdb");
        string select = "SELECT * FROM demography";

        OleDbDataAdapter adapter = new OleDbDataAdapter(select,
                    connectionString);
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        DataTable table = new DataTable();

        adapter.Fill(table);

        // create a relation between the USA shapefile and the 
        // database by the state abbreviation field
        if (!map["USA"].AddRelate("STATE_ABBR", table, "STATE_ABBR"))
        {
            throw new Exception("Cannot add a relate to the database.");
        }
    }

    private void fullExtent_Click(object sender, System.EventArgs e)
    {
        map.ZoomFull();
    }
}

