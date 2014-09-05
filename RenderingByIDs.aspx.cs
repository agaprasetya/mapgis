using System;
using System.Drawing;
using System.Web.UI.WebControls;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddLayer();
    }
    protected void List1_SelectedIndexChanged(object sender, EventArgs e)
    {
        AspMap.Layer layer = map["states"];
        AspMap.FeatureRenderer renderer = layer.Renderer;

        // use the hidden FeatureID column to match the feature IDs of each record
        // with the feature IDs added to the FeatureRenderer collection
        renderer.Field = "FeatureID";

        foreach (ListItem item in List1.Items)
        {
            if (!item.Selected) continue;

            AspMap.Feature feature = renderer.Add();
            feature.Value = item.Value; // feature ID
            feature.Symbol.FillColor = Color.Yellow;
        }
    }

    void AddLayer()
    {
        // add the states.shp shapefile as a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/USA/states.shp"));

        // line size and color
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.Gray;

        // fill color
        layer.Symbol.FillColor = Color.Ivory;

        if (!IsPostBack)
        {
            AspMap.Recordset rs = layer.Recordset;
            while (!rs.EOF)
            {
                List1.Items.Add(new ListItem(rs["STATE_NAME"] + " (" + rs.FeatureID + ")",rs.FeatureID.ToString()));
                rs.MoveNext();
            }
        }    
    }

}
