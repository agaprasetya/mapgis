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

        // Disable the default Layer.Symbol.
        // Only the features listed in the Layer.Renderer collection will 
        // be dislayed. Selecive rendering is possible by values or expressions.
        layer.UseDefaultSymbol = false;

        // use the STATE_NAME column from the states.dbf file to match values listed in the column
        // with the values added to the FeatureRenderer collection
        renderer.Field = "STATE_NAME";

        foreach (ListItem item in List1.Items)
        {
            if (!item.Selected) continue;

            AspMap.Feature feature = renderer.Add();
            feature.Value = item.Value; // state name
            feature.Symbol.LineColor = Color.Gray;
            feature.Symbol.FillColor = Color.Ivory;
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

        // labels
        layer.ShowLabels = true;
        layer.LabelField = "STATE_ABBR";

        if (!IsPostBack)
        {
            List1.DataTextField = "STATE_NAME";
            List1.DataValueField = "STATE_NAME";
            List1.DataSource = layer.Recordset;
            List1.DataBind();
        }    
    }

}
