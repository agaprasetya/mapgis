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

public partial class LocationEditorApp : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {        
        AddMapLayers();
        AddLocationsDatabase();

        map.ToolShape.LineWidth = 2;
        map.ToolShape.VertexSize = 12;
    }

    protected void map_InfoTool(object sender, InfoToolEventArgs e)
    {
        RestoreState();

        Recordset rs = map["locations"].SearchNearest(e.InfoPoint, map.ToMapDistance(8));

        if (rs.EOF)
        {
            // add new location
            map.EditShape(e.InfoPoint);           
        }
        else
        {
            locationTitle.Text = rs["TITLE"].ToString();
            ViewState["locationID"] = rs["ID"];
            remove.Visible = true;
            operation.Text = "Edit location:";

            // edit the location
            map.EditShape(rs.Shape);
        }

        locationPanel.Visible = true;
    }

    protected void map_EndEdit(object sender, EndEditEventArgs e)
    {
        if (ViewState["locationID"] != null)
        { 
            // update location
            UpdateLocation(ViewState["locationID"].ToString(), locationTitle.Text, e.Shape);            
        }
        else
        {
            // add new location            
            AddNewLocation(locationTitle.Text, e.Shape);
        }

        RestoreState();
    }

    protected void remove_Click(object sender, EventArgs e)
    {
        if (ViewState["locationID"] != null)
        { 
            RemoveLocation(ViewState["locationID"].ToString());
            RestoreState();
        }        
    }

    protected void cancel_Click(object sender, EventArgs e)
    {
        RestoreState();
    }

    protected void RestoreState()
    {
        locationPanel.Visible = false;
        ViewState["locationID"] = null;
        remove.Visible = false;
        operation.Text = "Add location:";
        map.MapTool = MapTool.Info;
        map.CancelEdit();
    }

    void AddNewLocation(string title, AspMap.Shape shape)
    {
        AspMap.Layer layer = map["locations"];

        AspMap.Recordset rs = layer.NewRecord();

        if (!rs.EOF)
        {
            rs["TITLE"] = title;
            rs.Shape = shape;
            rs.Update();
        }
    }

    void UpdateLocation(string id, string title, AspMap.Shape shape)
    {
        AspMap.Layer layer = map["locations"];
        layer.EnablePassthroughQuery = true;

        AspMap.Recordset rs = layer.SearchExpression("ID = " + id + "");

        if (!rs.EOF)
        {
            rs["TITLE"] = title;
            rs.Shape = shape;
            rs.Update();
        }
    }

    void RemoveLocation(string id)
    {
        AspMap.Layer layer = map["locations"];
        layer.EnablePassthroughQuery = true;

        AspMap.Recordset rs = layer.SearchExpression("ID = " + id + "");

        if (!rs.EOF)
        {
            rs.Delete();
        }        
    }

    void AddLocationsDatabase()
    {
        string connectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" + MapPath("DATA/locations.mdb");

        PointDataLayer pointData = new PointDataLayer("System.Data.OleDb", connectionString, "locations", "LONGITUDE", "LATITUDE");

        AspMap.Layer dbLayer = map.AddLayer(pointData);

        if (dbLayer == null)
            return;

        dbLayer.Name = "locations";
        dbLayer.Symbol.Size = 16;
        dbLayer.ShowLabels = true;
        dbLayer.LabelField = "TITLE";
        dbLayer.LabelFont.Size = 16;
        dbLayer.LabelFont.Bold = true;
        dbLayer.LabelFont.OutlineColor = Color.Yellow;
        dbLayer.LabelFont.Outline = true;       
        dbLayer.Symbol.Size = 11;
        dbLayer.Symbol.FillColor = Color.Yellow;                
    }

    protected void AddMapLayers()
    {
        string LayerFolder = MapPath("MAPS/WORLD/");

        AspMap.Layer layer = map.AddLayer(LayerFolder + "world.shp");
        layer.Symbol.LineColor = Color.Gray;
    }
}
