<%@ WebHandler Language="C#" Class="WmsServiceHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
using AspMap;
using AspMap.Web;

public class WmsServiceHandler : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)     
    {
        // create a WmsService object
        AspMap.Web.WmsService wms = new AspMap.Web.WmsService();

        // check if the current request conforms to the OpenGIS WMS specification
        if (wms.IsWmsRequest)
        {
            // create a Map object
            AspMap.Web.Map map = new AspMap.Web.Map();
        
            // add layers to the Map object
            AddMapLayers(map);

	    map.FullExtent = new AspMap.Rectangle(-180, 90, 180, -90);
	    map.ZoomFull();	    
	    map.Extent  = new AspMap.Rectangle(-180, 90, 180, -90);
	    //map.ZoomFull();	
	    

            // process the request
            wms.ProcessRequest(map);
        }

    }

    protected void AddMapLayers(AspMap.Web.Map map)
    {
        string LayerFolder = HttpContext.Current.Server.MapPath("MAPS/WORLD/");

        map.AddLayer(LayerFolder + "earth.ecw");
        map.AddLayer(LayerFolder + "world.shp");
        map.AddLayer(LayerFolder + "lakes.shp");
        map.AddLayer(LayerFolder + "capitals.shp");

        AspMap.Layer layer;

        // world
        layer = map["world"];
        layer.ShowLabels = true;
        layer.LabelField = "CODE";
        layer.LabelFont.Name = "Verdana";
        layer.LabelFont.Size = 12;
        layer.LabelStyle = LabelStyle.PolygonCenter;
        layer.Opacity = 0.6;

        // lakes
        layer = map["lakes"];
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelFont.Size = 10;
        layer.LabelFont.Outline = true;
        layer.Symbol.FillColor = Color.Blue;
        layer.Symbol.LineColor = layer.Symbol.FillColor;
        layer.LabelStyle = LabelStyle.PolygonCenter;

        // capitals
        layer = map["capitals"];
        layer.ShowLabels = true;
        layer.LabelField = "NAME";
        layer.LabelFont.Bold = true;
        layer.LabelFont.Size = 11;
        layer.LabelFont.Outline = true;
        layer.Symbol.PointStyle = PointStyle.CircleWithLargeCenter;
        layer.Symbol.Size = 8;
        layer.Symbol.FillColor = Color.White;
    }
    
    public bool IsReusable { get { return false; }  }
}
