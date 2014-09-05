using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class viewcode : System.Web.UI.Page
{
    public string code = String.Empty;
    public string file = String.Empty;
    public string wms = String.Empty;
	public string lang = "sh_csharp";
    protected void Page_Load(object sender, EventArgs e)
    {
        code = MapPath(Request["path"]);
        if (Request["path"] != null && File.Exists(MapPath(Request["path"])))
        { 
            code = File.ReadAllText(MapPath(Request["path"]));
            code = code.Replace("<", "&lt;");
            code = code.Replace(">", "&gt;");
            file = Path.GetFileName(MapPath(Request["path"]));

            if (Request["path"].IndexOf("WmsServiceApp") > 0)
                wms = File.ReadAllText(MapPath("WmsService.ashx"));
        }

        if (Request["lang"] != null)
        { 
            lang = Request["lang"];
        }
    }
}
