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
using System.Text;
using AspMap;
using AspMap.Web;

public partial class RouteApp : System.Web.UI.Page, IPostBackEventHandler
{
    private int viewStreetIndex = -1;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        AddMapLayers();

        if (!IsPostBack)
        {
            startLocation.DataSource = map["locations"].Recordset;
            startLocation.DataTextField = "NAME";
            startLocation.DataValueField = "NAME";
            startLocation.DataBind();

            endLocation.DataSource = map["locations"].Recordset;
            endLocation.DataTextField = "NAME";
            endLocation.DataValueField = "NAME";
            endLocation.DataBind();

            startLocation.SelectedIndex = 1;
            endLocation.SelectedIndex = 3;
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        // restore the Route object from the Session 
        if (Session["RouteObj"] != null)
        {
            AspMap.Route route = Session["RouteObj"] as AspMap.Route;
            AddRouteLayer(route);
            GenerateDrivingDirections(directionsTable, route);

            // zoom to a street if required
            if (viewStreetIndex >= 0)
            {
                AspMap.Rectangle extent = route.Streets[viewStreetIndex].Shape.Extent;
                extent.Inflate(400, 400); // feet
                map.Extent = extent;
            }
        }
    }

    protected void map_Unload(object sender, System.EventArgs e)
    {
        // remove the Route object/layer from the Map object to prevent it from disposing,
        // because the Route object has been saved in a Session variable
        int index = map.GetLayerIndex("RouteLayer");
        if (index >= 0)
        {
            map.RemoveLayer(index);
        }
    }

    void AddMapLayers()
    {
        AspMap.Layer layer;
        string LayerFolder = MapPath("MAPS/ROUTING/");

        layer = map.AddLayer(LayerFolder + "climits.shp");
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.FromArgb(199, 172, 116);
        layer.Symbol.FillColor = Color.FromArgb(242, 236, 223);

        layer = map.AddLayer(LayerFolder + "roads.shp");
        layer.LabelField = "FNAME";
        layer.LabelFont.Name = "Calibri";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Size = 14;
        layer.ShowLabels = true;
        layer.Symbol.LineStyle = LineStyle.Road;
        layer.Symbol.LineColor = Color.FromArgb(220, 220, 220);
        layer.Symbol.InnerColor = Color.White;
        layer.Symbol.Size = 5;

        layer = map.AddLayer(LayerFolder + "locations.shp");
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 12;
        layer.LabelFont.Outline = true;
        layer.ShowLabels = true;
        layer.Symbol.Size = 16;
        layer.Symbol.PointStyle = PointStyle.School;
        layer.Symbol.LineColor = Color.White;
        layer.Symbol.FillColor = Color.FromArgb(0, 0, 200);
    }

    protected void findRoute_Click(object sender, System.EventArgs e)
    {
        AspMap.Point start, end;
        string roadNetworkFolder = MapPath("MAPS/ROUTING/");

        // find coordinates of start and end locations
        start = GetLocationCoordinate(startLocation.SelectedValue);
        if (start == null) return;
        end = GetLocationCoordinate(endLocation.SelectedValue);
        if (end == null) return;

        if (start.Equals(end))
        {
            errorMessage.Text = "Locations are equal.";
            return;
        }

        // load the road network 
        AspMap.Network roadNetwork;

        if (Application["RoadNetwork"] == null)
        {
            roadNetwork = new AspMap.Network();

            if (!roadNetwork.Open(roadNetworkFolder + "roads.shp", roadNetworkFolder + "roads.rtn"))
            {
                throw new Exception("Cannot load road network: " + MapPath("MAPS/ROUTING/roads.rtn"));
            }

            Application["RoadNetwork"] = roadNetwork;
        }
        else
            roadNetwork = Application["RoadNetwork"] as AspMap.Network;

        // create a Route object
        AspMap.Route route = roadNetwork.CreateRoute();

        // set the properties of the Route object
        if (unitsList.SelectedItem.Value == "Miles")
            route.DistanceUnit = MeasureUnit.Mile;
        else
            route.DistanceUnit = MeasureUnit.Kilometer;

        if (routeTypeList.SelectedItem.Value == "Quickest")
            route.RouteType = RouteType.Quickest;
        else
            route.RouteType = RouteType.Shortest;

        route.MaxDistance = 0.5;

        // find a route between two points
        if (route.FindRoute(start.X, start.Y, end.X, end.Y))
        {
            // remove previous route layer
            ClearRoute();

            // merge the Segment objects of the Route to Street objects, 
            // the Street objects will be used to generate driving directions
            route.MergeSegments("ADDRESS");

            // save the Route object to a session variable
            Session["RouteObj"] = route;

            // set the map extent to the route extent
            map.Extent = route.Extent;
        }
        else
        {
            route.Dispose();
            errorMessage.Text = "Route not found.";
        }
    }

    AspMap.Point GetLocationCoordinate(string locationName)
    {
        AspMap.Recordset rs;

        rs = map["locations"].SearchExpression("NAME = \"" + locationName.Trim() + "\"");

        if (rs.EOF)
        {
            errorMessage.Text = "Location not found.";
            return null;
        }

        return rs.Shape.GetPoint(0);
    }

    void AddRouteLayer(AspMap.Route route)
    {
        AspMap.Layer routeLayer = map.AddLayer(route);

        routeLayer.Name = "RouteLayer";
        routeLayer.Symbol.LineColor = Color.FromArgb(198, 86, 245);
        routeLayer.Symbol.Size = 9;
        routeLayer.Opacity = 0.3;

        AspMap.DynamicLayer routeMarkers = new AspMap.DynamicLayer();

        // add a start marker
        AspMap.MapShape startMarker = routeMarkers.Add(route.StartPoint, "Start");
        startMarker.Symbol.Size = 10;
        startMarker.Symbol.FillColor = Color.FromArgb(0, 160, 0);
        startMarker.Symbol.LineColor = Color.White;
        startMarker.Font.Name = "Verdana";
        startMarker.Font.Size = 14;
        startMarker.Font.Bold = true;
        startMarker.Font.Color = Color.FromArgb(0, 160, 0);
        startMarker.Font.Outline = true;

        // add an end marker
        AspMap.MapShape endMarker = routeMarkers.Add(route.EndPoint, "End");
        endMarker.Symbol.FillColor = Color.FromArgb(230, 0, 0);
        endMarker.Symbol.LineColor = Color.White;
        endMarker.Font.Name = "Verdana";
        endMarker.Font.Size = 14;
        endMarker.Font.Bold = true;
        endMarker.Font.Color = Color.FromArgb(230, 0, 0);
        endMarker.Font.Outline = true;

        // add street markers
        for (int street = 1; street < route.Streets.Count; street++)
        {
            routeMarkers.Add(route.Streets[street].Start, Convert.ToString(street));
        }

        AspMap.Layer markerLayer = map.AddLayer(routeMarkers);
        markerLayer.LabelField = "LABEL";
        markerLayer.ShowLabels = true;

        // set attributes of the street markers as the default symbol/font of the marker layer
        markerLayer.LabelFont.Name = "Verdana";
        markerLayer.LabelFont.Size = 14;
        markerLayer.LabelFont.Bold = true;
        markerLayer.LabelFont.Color = Color.SteelBlue;
        markerLayer.LabelFont.Outline = true;
        markerLayer.Symbol.FillColor = Color.SteelBlue;
        markerLayer.Symbol.LineColor = Color.White;
        markerLayer.Symbol.Size = 8;
    }

    void ClearRoute()
    {
        if (Session["RouteObj"] != null)
        {
            AspMap.Route route = Session["RouteObj"] as AspMap.Route;
            route.Dispose();
            Session["RouteObj"] = null;
        }
    }

    public void RaisePostBackEvent(string eventArgument)
    {
        viewStreetIndex = Convert.ToInt32(eventArgument);
    }

    Table __table;

    void GenerateDrivingDirections(Table table, AspMap.Route route)
    {
        Streets streets = route.Streets;
        if (streets.Count == 0) return;

        string units;

        if (route.DistanceUnit == MeasureUnit.Mile)
            units = "miles";
        else
            units = "kilometers";

        string direction, distance;
        __table = table;

        TR("Directions", "Distance (" + units + ")");

        direction = "Start out going " + streets[0].Direction.ToString() + " on " + streets[0].Name;

        if (streets.Count > 1)
            direction += " towards " + streets[1].Name;

        direction += GetStreetHyperlink(0);

        distance = Convert.ToString(Math.Round(streets[0].Distance, 2));

        TR(direction, distance);

        for (int i = 1; i < streets.Count; i++)
        {
            Street street = streets[i];

            direction = i + ". ";

            if (street.TurnAngle > 30)
                direction += "Turn LEFT onto " + street.Name;
            else if (street.TurnAngle < -30)
                direction += "Turn RIGHT onto " + street.Name;
            else
                direction += "Road name changes to " + street.Name;

            direction += " (" + street.Direction.ToString() + ")";

            direction += GetStreetHyperlink(i);

            distance = Convert.ToString(Math.Round(street.Distance, 2));

            TR(direction, distance);
        }

        direction = "Arrive " + streets[streets.Count - 1].Name;

        TR(direction, "");

        direction = "Total Estimated Time: " + Convert.ToString(Math.Round(route.RouteTime / 60.0, 1)) + " minutes<br>";
        direction += "Total Distance: " + Convert.ToString(Math.Round(route.RouteDistance, 2)) + " " + units;

        TR(direction, "");
    }

    string GetStreetHyperlink(int street)
    {
        return " (<a href=\"" + ClientScript.GetPostBackClientHyperlink(this, street.ToString()) + "\">View</a>)";
    }

    // table utilities
    TableCell TD(string text)
    {
        TableCell cell = new TableCell();
        cell.Text = text;

        if (text != String.Empty)
            cell.BorderWidth = Unit.Pixel(1);

        return cell;
    }

    void TR(string text1, string text2)
    {
        TableRow row = new TableRow();
        row.Cells.Add(TD(text1));

        TableCell cell = TD(text2);
        cell.HorizontalAlign = HorizontalAlign.Center;
        row.Cells.Add(cell);

        __table.Rows.Add(row);
    }
}
