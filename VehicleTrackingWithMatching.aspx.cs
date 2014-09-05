using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using AspMap;
using AspMap.Web;

// 
// This sample uses an AnimationLayer to refresh vehicle 
// locations without reloading the entire page.
// 
public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        map.MapUnit = MeasureUnit.Degree;

        AddMapLayers();

        if (!IsPostBack)
        {
            map.EnableAnimation = true;            
            map.MapScale = 8500;
        }
    }

    protected void map_RefreshAnimationLayer(object sender, AspMap.Web.RefreshAnimationLayerArgs e)
    {
        e.NeedRefreshMap = TrackVehicles();
    }    

    bool TrackVehicles()
    {
        AspMap.Point gpsLocation = GetVehicleCoordinates();

        AspMap.Point matchedLocation = GetMatchedVehicleLocation(gpsLocation);

        // add matched GPS location
        GeoEvent matchedEvent = new GeoEvent();
        matchedEvent.Location = matchedLocation;
        matchedEvent.ImageUrl = "SYMBOLS/vehicle.gif";
        matchedEvent.ImageWidth = 20;
        matchedEvent.ImageHeight = 20;
        map.AnimationLayer.Add(matchedEvent);

        // add original GPS location
        GeoEvent gpsEvent = new GeoEvent();
        gpsEvent.Location = gpsLocation;
        gpsEvent.ImageUrl = "SYMBOLS/pixel.gif";
        gpsEvent.ImageWidth = 10;
        gpsEvent.ImageHeight = 10;
        gpsEvent.ImageStyle.BackColor = Color.Red;
        gpsEvent.ImageStyle.BorderColor = Color.Red;
        map.AnimationLayer.Add(gpsEvent);

        // move the map if the vehicle is outside of the map
        if (!map.Extent.IsPointIn(matchedLocation))
        {
            map.CenterAt(matchedLocation);
            return true; // refresh map
        }

        return false;
    }

    AspMap.Point GetMatchedVehicleLocation(AspMap.Point gpsLocation)
    {
        double distance = map.ConvertDistance(200, MeasureUnit.Meter, MeasureUnit.Degree);

        // search for nearest roads within a 200-meter distance
        AspMap.Recordset nearestRoads = map["street"].SearchNearest(gpsLocation, distance);

        if (nearestRoads.EOF) return gpsLocation;

        AspMap.Shape nearestRoadSegment = nearestRoads.Shape;

        // return the nearest point
        return nearestRoadSegment.FindNearestPoint(gpsLocation);
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        TrackVehicles();

        // toggles auto refreshing on/off
        autoRefresh.Attributes.Add("onclick", "AspMap.getMap('" + map.ClientID + "').set_enableAnimation(this.checked)");
        // performs manual refreshing of the AnimationLayer
        refreshButton.Attributes.Add("onclick", "AspMap.getMap('" + map.ClientID + "').refreshAnimationLayer(); return false;");
        // sets the refresh interval
        trackingInterval.Attributes.Add("onchange", "AspMap.getMap('" + map.ClientID + "').set_animationInterval(parseInt(this.value))");
    }

    void AddMapLayers()
    {
        string LayerFolder = MapPath("MAPS/STREETS/");

        AspMap.Layer layer = map.AddLayer(LayerFolder + "street.shp");
        layer.LabelField = "NAME";
        layer.LabelMaxScale = 70000;
        layer.ShowLabels = true;
        layer.DuplicateLabels = false;
        layer.Symbol.LineStyle = LineStyle.Road;
        layer.Symbol.LineColor = Color.FromArgb(171, 158, 137);
        layer.Symbol.InnerColor = Color.White;
        layer.Symbol.Size = 3;

        Feature feature = layer.Renderer.Add(-1, 70000);
        feature.LabelFont.Name = "Calibri";
        feature.LabelFont.Size = 14;
        feature.LabelFont.Quality = FontQuality.AntiAlias;
        feature.Symbol.LineStyle = LineStyle.Road;
        feature.Symbol.LineColor = Color.FromArgb(230, 230, 230);
        feature.Symbol.InnerColor = Color.White;
        feature.Symbol.Size = 10;
    }

    // For demostration purposes, the GPS coordinates (latitude/longitude) are stored in a text file.
    AspMap.Point GetVehicleCoordinates()
    {
        StreamReader reader = File.OpenText(MapPath("DATA/vehicle_points.txt"));

        string line;
        AspMap.Points points = new AspMap.Points();

        while ((line = reader.ReadLine()) != null)
        {
            string[] coords = line.Split(' ');
            points.Add(Convert.ToDouble(coords[0], NumberFormatInfo.InvariantInfo), Convert.ToDouble(coords[1], NumberFormatInfo.InvariantInfo));
        }

        reader.Close();

        int position = 0;
        if (Session["position"] != null)
            position = Convert.ToInt32(Session["position"]);

        if (position >= points.Count)
            position = 0;

        Session["position"] = Convert.ToString(position + 1);

        AspMap.Point currentLocation = points[position];               

        // remove unnecesary points
        for (int i = points.Count - 1; i > position; i--) points.Remove(i);

        return currentLocation;
    }
}
