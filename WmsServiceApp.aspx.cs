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

public partial class WmsServiceApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        // add the WmsService.ashx HTTP handler as a Web Map Service
        WmsLayer wms = new WmsLayer("WmsService.ashx", new AspMap.Rectangle(-180, 90, 180, -90));
        wms.BackColor = Color.LightSkyBlue;

        // add the WMS layer to the map
        AspMap.Layer wmsLayer = map.AddLayer(wms);

        // make the map image transparent to display background WMS layers
        map.ImageOpacity = 0;
        map.BackColor = Color.LightSkyBlue;
    }
}
