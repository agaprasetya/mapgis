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
using AspMap.Web;

public partial class RouteTutorial : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        // create a Network Object
        AspMap.Network roadNetwork = new AspMap.Network();

        // load the road network
        roadNetwork.Open(MapPath("MAPS/ROUTING/streets.shp"), MapPath("MAPS/ROUTING/streets.rtn"));

        // create a Route Object
        AspMap.Route route;
        route = roadNetwork.CreateRoute();

        // start/end coordinates
        double StartX, StartY, EndX, EndY;
        StartX = -71.5591; // start longitude 
        StartY = 43.1851;  // start latitude
        EndX = -71.5227;   // end longitude 
        EndY = 43.2542;    // end latitude

        route.RouteType = RouteType.Quickest;

        // find the route
        if (!route.FindRoute(StartX, StartY, EndX, EndY))
        {
            Response.Write("Route not found.");
            Response.End();
        }

        // merge the road segments to streets
        route.MergeSegments("NAME;TYPE");

        // add the route to the map as a layer
        AspMap.Layer routeLayer = Map1.AddLayer(route);
        routeLayer.Symbol.LineColor = Color.FromArgb(198, 86, 245);
        routeLayer.Symbol.Size = 4;

        // add the streets.shp layer to the map
        Map1.AddLayer(MapPath("MAPS/ROUTING/streets.shp"));

        // set the extent of the route as the current extent of the map
        Map1.Extent = route.Extent;

        // add driving directions to Table1
        GenerateDirections(route);
    }

    void GenerateDirections(AspMap.Route route)
    {
        string direction, distance;

        Streets streets = route.Streets;

        TR(Table1, "Directions", "Distance(miles)");

        direction = "Start out going " + streets[0].Direction.ToString() + " on " + streets[0].Name;

        if (streets.Count > 1)
            direction += " towards " + streets[1].Name;

        distance = Convert.ToString(Math.Round(streets[0].Distance, 2));

        TR(Table1, direction, distance);

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

            distance = Convert.ToString(Math.Round(street.Distance, 2));

            TR(Table1, direction, distance);
        }

        direction = "Arrive " + streets[streets.Count - 1].Name;

        TR(Table1, direction, "");

        direction = "Total Estimated Time: " + Convert.ToString(Math.Round(route.RouteTime / 60.0, 1)) + " minutes<br>";
        direction += "Total Distance: " + Convert.ToString(Math.Round(route.RouteDistance, 2)) + " miles";

        TR(Table1, direction, "");
    }

    // generates a TR tag
    void TR(Table t, string text1, string text2)
    {
        TableRow row = new TableRow();

        TableCell cell = new TableCell();
        cell.Text = text1;

        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = text2;

        row.Cells.Add(cell);

        t.Rows.Add(row);
    }

}
