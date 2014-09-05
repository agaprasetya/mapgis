using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Net;
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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            // enables the RefreshAnimationLayer event
            map.EnableAnimation = true;
            map.AnimationInterval = 5000; // 5 seconds
        }
        map.CoordinateSystem = CoordSystem.WGS1984;
        AddLayers();
    }

    protected void map_RefreshAnimationLayer(object sender, AspMap.Web.RefreshAnimationLayerArgs e)
    {
        map.AnimationLayer.CoordinateSystem = CoordSystem.WGS1984;

        try
        {
            // download earthquake data from earthquake.usgs.gov
            WebClient wc = new WebClient();
            string line = wc.DownloadString("http://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/2.5_day.csv");
            StringReader sr = new StringReader(line);
            sr.ReadLine();

            // parse the data
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = Split(line);

                double lat = Convert.ToDouble(parts[1]);
                double lon = Convert.ToDouble(parts[2]);
                double magn = Convert.ToDouble(parts[4]);
                string region = parts[13];

                // add a GeoEvent
                AddGeoEvent(lon, lat, region, magn);
            }
        }
        catch { }
    }

    void AddGeoEvent(double longitude, double latitude, string region, double magnitude)
    {
        GeoEvent geoEvent = new GeoEvent();

        geoEvent.Location = new AspMap.Point(longitude, latitude);

        // display different images for different magnitude values
        if (magnitude >= 7)
        {
            geoEvent.ImageUrl = "symbols/70.gif";
            geoEvent.ImageWidth = 14;
            geoEvent.ImageHeight = 14;
        }
        else if (magnitude >= 5)
        {
            geoEvent.ImageUrl = "symbols/50.gif";
            geoEvent.ImageWidth = 12;
            geoEvent.ImageHeight = 12;
        }
        else
        {
            geoEvent.ImageUrl = "symbols/25.gif";
            geoEvent.ImageWidth = 10;
            geoEvent.ImageHeight = 10;
        }

        geoEvent.Tooltip = region.Replace("\"", "") + "<br>Magnitude: " + magnitude.ToString();
        geoEvent.NavigateUrl = "javascript:showLocation('" + geoEvent.Tooltip + "')";

        map.AnimationLayer.Add(geoEvent);                   
    }

    string[] Split(string str)
    {
        bool p = false;
        string s = String.Empty;
        for (int i = 0; i < str.Length; i++)
        {
            if (!p && str[i] == ',')
            {
                s += '|';
                continue;
            }

            if (str[i] == '"') p = !p;

            s += str[i];
        }

        return s.Split(new char[] { '|' });
    }

    void AddLayers()
    {
        // add the world.shp shapefile as a map layer
        AspMap.Layer layer = map.AddLayer(MapPath("MAPS/WORLD/world.shp"));

        // labels
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 14;
        layer.LabelFont.Outline = true;

        // line size and color
        layer.Symbol.Size = 1;
        layer.Symbol.LineColor = Color.LightGray;

        // fill color
        layer.Symbol.FillColor = Color.Ivory;
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        map_RefreshAnimationLayer(null, null);

        // toggles auto refreshing on/off
        autoRefresh.Attributes.Add("onclick", "AspMap.getMap('" + map.ClientID + "').set_enableAnimation(this.checked)");
        // performs manual refreshing of the AnimationLayer
        refreshButton.Attributes.Add("onclick", "AspMap.getMap('" + map.ClientID + "').refreshAnimationLayer(); return false;");
        // sets the refresh interval
        trackingInterval.Attributes.Add("onchange", "AspMap.getMap('" + map.ClientID + "').set_animationInterval(parseInt(this.value))");
    }
}
