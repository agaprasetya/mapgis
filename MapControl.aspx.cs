using System;
using System.IO;
using System.Drawing;
using AspMap;
using AspMap.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AddLayer();        
    }
    
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddLayer();
    }

    void AddLayer()
    { 
        map.RemoveAllLayers();

        if (File.Exists(MapPath("MAPS/" + ListBox1.SelectedValue)))
        {
            // add the layer
            map.AddLayer(MapPath("MAPS/" + ListBox1.SelectedValue));
            map.ZoomFull();
        }
        else
        {
            map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        }
    }
}
