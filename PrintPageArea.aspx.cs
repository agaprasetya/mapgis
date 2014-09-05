using System;
using System.Drawing;
using AspMap;
using AspMap.Web;
using AspMap.Web.Extensions;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));
        layer.CoordinateSystem = CoordSystem.WGS1984;
        
        layer.Symbol.FillColor = Color.Ivory;
        layer.Symbol.LineColor = Color.LightGray;
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;

        if (!IsPostBack)
        {
            SetPageSize(pageSize.SelectedValue);
            map.MapScale = 100000000;
        }
    }

    protected void pageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetPageSize(pageSize.SelectedValue);
    }

    protected void orientation_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetPageSize(pageSize.SelectedValue);
    }

    // See the styles for UpdatePanel1 in PrintPageArea.aspx

    void SetPageSize(string size)
    {
        const int ScreenDPI = 96;

        if (size == "A5")
        {
            printArea.Width = Unit.Pixel((int)Math.Round(5.83 * ScreenDPI));
            printArea.Height = Unit.Pixel((int)Math.Round(8.27 * ScreenDPI));
        }
        else if (size == "A4")
        {
            printArea.Width = Unit.Pixel((int)Math.Round(8.27 * ScreenDPI));
            printArea.Height = Unit.Pixel((int)Math.Round(11.69 * ScreenDPI));            
        }
        else if (size == "A3")
        {
            printArea.Width = Unit.Pixel((int)Math.Round(11.69 * ScreenDPI));
            printArea.Height = Unit.Pixel((int)Math.Round(16.54 * ScreenDPI));                       
        }        

        if (orientation.SelectedIndex == 0) // landscape
        {
            Unit temp = printArea.Width;
            printArea.Width = printArea.Height;
            printArea.Height = temp;
        }
    }
}
