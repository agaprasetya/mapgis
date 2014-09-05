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

public partial class ShapeEditorApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {        
        AddMapLayers();
        AddDatabaseLayer();

        if (!IsPostBack)
        {
            // sets the default shape type for the DrawShape tool
            map.NewShapeType = ShapeType.Polygon;
            RestoreState();
        }
    }

    // select a shape for editing
    protected void map_InfoTool(object sender, InfoToolEventArgs e)
    {
        RestoreState();

        Recordset rs = map.Identify(e.InfoPoint, 10);
        
        if (rs.EOF || rs.Layer.Name != "polygons") return;

        // start editing of the shape
        map.EditShape(rs.Shape);          
   
        // save the shape ID
        ViewState["shapeID"] = rs["ID"];

        shapeTitle.Text = rs["TITLE"].ToString();

        // update the user interface
        remove.Visible = true;
        cancel.Visible = true;
        operation.Text = "Edit shape:";
    }

    // saves the shape
    protected void map_EndEdit(object sender, EndEditEventArgs e)
    {
        if (ViewState["shapeID"] != null)
        { 
            // update shape
            string shapeID = ViewState["shapeID"].ToString();

            UpdateShape(shapeID, shapeTitle.Text, e.Shape);
        }
        else
        {
            // add new shape           
            AddNewShape(shapeTitle.Text, e.Shape);
        }

        RestoreState();
    }

    protected void remove_Click(object sender, EventArgs e)
    {
        if (ViewState["shapeID"] != null)
        {
            string shapeID = ViewState["shapeID"].ToString();

            RemoveShape(shapeID);
            RestoreState();
        }        
    }

    protected void cancel_Click(object sender, EventArgs e)
    {
        RestoreState();
    }

    // restore the application state
    protected void RestoreState()
    {
        ViewState["shapeID"] = null;
        remove.Visible = false;
        cancel.Visible = false;
        operation.Text = "Add shape:";
        map.MapTool = MapTool.Info;
        map.CancelEdit();
    }

    void AddNewShape(string title, AspMap.Shape shape)
    {
        AspMap.Layer layer = map["polygons"];

        AspMap.Recordset rs = layer.NewRecord();

        if (!rs.EOF)
        {
            rs["TITLE"] = title;
            rs.Shape = shape;
            rs.Update();
        }
    }

    void UpdateShape(string id, string title, Shape shape)
    {
        AspMap.Layer layer = map["polygons"];
        layer.EnablePassthroughQuery = true;

        AspMap.Recordset rs = layer.SearchExpression("ID = " + id + "");

        if (!rs.EOF)
        {
            rs["TITLE"] = title;
            rs.Shape = shape;
            rs.Update();
        }
    }

    void RemoveShape(string id)
    {
        AspMap.Layer layer = map["polygons"];
        layer.EnablePassthroughQuery = true;

        AspMap.Recordset rs = layer.SearchExpression("ID = " + id + "");

        if (!rs.EOF)
        {
            rs.Delete();
        }        
    }

    void AddDatabaseLayer()
    {
        string connectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" + MapPath("DATA/shapes.mdb");

        AspMap.Data.WkbDataLayer wkbDataLayer = new WkbDataLayer("System.Data.OleDb", connectionString, "polygons", "WKBDATA");
        wkbDataLayer.FieldList = "ID, TITLE";
        wkbDataLayer.ShapeType = ShapeType.Polygon;

        AspMap.Layer layer = map.AddLayer(wkbDataLayer);

        if (layer == null)
            return;

        layer.Name = "polygons";
        layer.Opacity = 0.4;
        layer.ShowLabels = true;
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelField = "TITLE";
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Color = Color.White;
        layer.LabelFont.OutlineColor = Color.Black;
        layer.LabelFont.Outline = true;
        layer.Symbol.Size = 1;
        layer.Symbol.FillColor = Color.LightGreen;
        layer.Symbol.LineColor = Color.Green;
    }

    protected void AddMapLayers()
    {
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));       

        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 13;
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.Symbol.FillColor = Color.WhiteSmoke;
        layer.Symbol.LineColor = Color.LightGray;
    }
}
