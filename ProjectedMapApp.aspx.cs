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

public partial class ProjectedMapApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddMapLayers();

        if (!IsPostBack)
        {
            coordSystemList.Items.Add(new ListItem("World Robinson", Convert.ToString((int)CoordSystemCode.PCS_WorldRobinson)));
            coordSystemList.Items.Add(new ListItem("Plate Carree", Convert.ToString((int)CoordSystemCode.PCS_WorldPlateCarree)));
            coordSystemList.Items.Add(new ListItem("World Equidistant Cylindrical", Convert.ToString((int)CoordSystemCode.PCS_WorldEquidistantCylindrical)));
            coordSystemList.Items.Add(new ListItem("WorldMiller Cylindrical", Convert.ToString((int)CoordSystemCode.PCS_WorldMillerCylindrical)));
            coordSystemList.Items.Add(new ListItem("World Mercator", Convert.ToString((int)CoordSystemCode.PCS_WorldMercator)));
            coordSystemList.Items.Add(new ListItem("World Sinusoidal", Convert.ToString((int)CoordSystemCode.PCS_WorldSinusoidal)));
            coordSystemList.Items.Add(new ListItem("World Mollweide", Convert.ToString((int)CoordSystemCode.PCS_WorldMollweide)));
            coordSystemList.Items.Add(new ListItem("World Eckert I", Convert.ToString((int)CoordSystemCode.PCS_WorldEckertI)));
            coordSystemList.Items.Add(new ListItem("World Eckert II", Convert.ToString((int)CoordSystemCode.PCS_WorldEckertII)));
            coordSystemList.Items.Add(new ListItem("World Eckert III", Convert.ToString((int)CoordSystemCode.PCS_WorldEckertIII)));
            coordSystemList.Items.Add(new ListItem("World Eckert IV", Convert.ToString((int)CoordSystemCode.PCS_WorldEckertIV)));
            coordSystemList.Items.Add(new ListItem("World Eckert V", Convert.ToString((int)CoordSystemCode.PCS_WorldEckertV)));
            coordSystemList.Items.Add(new ListItem("World Eckert VI", Convert.ToString((int)CoordSystemCode.PCS_WorldEckertVI)));
            coordSystemList.Items.Add(new ListItem("World Gall Stereographic", Convert.ToString((int)CoordSystemCode.PCS_WorldGallStereographic)));
            coordSystemList.Items.Add(new ListItem("World Winkel I", Convert.ToString((int)CoordSystemCode.PCS_WorldWinkelI)));
            coordSystemList.Items.Add(new ListItem("World Winkel II", Convert.ToString((int)CoordSystemCode.PCS_WorldWinkelII)));
            coordSystemList.Items.Add(new ListItem("World Polyconic", Convert.ToString((int)CoordSystemCode.PCS_WorldPolyconic)));
            coordSystemList.Items.Add(new ListItem("World Quartic Authalic", Convert.ToString((int)CoordSystemCode.PCS_WorldQuarticAuthalic)));
            coordSystemList.Items.Add(new ListItem("World Loximuthal", Convert.ToString((int)CoordSystemCode.PCS_WorldLoximuthal)));
            coordSystemList.Items.Add(new ListItem("World Bonne", Convert.ToString((int)CoordSystemCode.PCS_WorldBonne)));
            coordSystemList.Items.Add(new ListItem("World Vander Grinten I", Convert.ToString((int)CoordSystemCode.PCS_WorldVanderGrintenI)));
            coordSystemList.Items.Add(new ListItem("World Two Point Equidistant", Convert.ToString((int)CoordSystemCode.PCS_WorldTwoPointEquidistant)));

            coordSystemList.SelectedIndex = 0;
        }

        coordSystemList_SelectedIndexChanged(sender, e);
    }

    private void AddMapLayers()
    {
        string MapFolder = MapPath("MAPS/WORLD/");

        AspMap.Layer layer = map.AddLayer(MapFolder + "world.shp");
        layer.CoordinateSystem = CoordSystem.WGS1984;        
        layer.Symbol.LineColor = Color.Gray;        

        layer = map.AddLayer(MapFolder + "lakes.shp");
        layer.CoordinateSystem = CoordSystem.WGS1984;
        layer.Symbol.LineColor = map.BackColor;
        layer.Symbol.FillColor = map.BackColor;        
    }

    protected void coordSystemList_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        CoordSystemCode code = (CoordSystemCode)Convert.ToInt32(coordSystemList.SelectedValue);

        map.CoordinateSystem = new AspMap.CoordSystem(code);

        map.ZoomFull();
    }
}
