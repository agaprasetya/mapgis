<%@ WebHandler Language="C#" Class="RotatedSymbol" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
using System.Web.UI.WebControls;
using AspMap;
using AspMap.Web;

public class RotatedSymbol : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)     
    {
        double angle = 0.0;
        
        if (!String.IsNullOrEmpty(context.Request["angle"]))
            angle = Convert.ToDouble(context.Request["angle"]);
       
        AspMap.Web.Map map = new Map();
        map.Width = Unit.Pixel(20);
        map.Height = Unit.Pixel(20);

        AspMap.Symbol rotatedSymbol = new Symbol();
        rotatedSymbol.PointStyle = PointStyle.Arrow;
        rotatedSymbol.Rotation = angle;
        rotatedSymbol.FillColor = Color.Red;
        rotatedSymbol.Size = (int)map.Width.Value - 6;               

        map.DrawingUnits = DrawingUnits.Pixels;
        map.DrawPoint(map.Width.Value / 2, map.Width.Value / 2, rotatedSymbol);

        map.SmoothingMode = SmoothingMode.AntiAlias;
        map.ImageFormat = ImageFormat.Png;
        map.ImageOpacity = 0.9;

        context.Response.ContentType = "image/png";
        context.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        context.Response.Cache.SetNoServerCaching();
        context.Response.Cache.SetNoStore();
        context.Response.BinaryWrite((byte[])map.Image);
    }
    
    public bool IsReusable { get { return true; }  }
}
