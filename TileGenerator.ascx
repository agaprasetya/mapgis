<%@ Control Language="C#" ClassName="TileGenerator" %>

<%@ Import Namespace="AspMap" %>
<%@ Import Namespace="AspMap.Web" %>

<script runat="server">
    
    // Add the following lines into an ASPX page: 
    //
    // @ Register TagPrefix="aspmap" TagName="TileGenerator"  Src="TileGenerator.ascx"
    //
    // aspmap:TileGenerator id="tileGenerator" runat="server" MapID="map" TileLayerID="Tiles" TileCacheDirectory="~/TileCache" Timeout="60"
    //
    // The TileGenerator control supports the following properties:
    // MapID - the ID of a Map control
    // TileLayerID - the ID of a TileLayer
    // TileCacheDirectory - virtual path to a tile cache directory
    // Timeout - timeout in minutes
    
    private String  tileLayerID;

    public String  TileLayerID
    {
        get { return tileLayerID; }
        set { tileLayerID = value; }
    }

    private string tileCacheDirectory;

    public string TileCacheDirectory
    {
        get { return tileCacheDirectory; }
        set { tileCacheDirectory = value; }
    }

    private String mapID;

    public String MapID
    {
        get { return mapID; }
        set { mapID = value; }
    }

    private int timeout = 60;

    public int Timeout
    {
        get { return timeout; }
        set { timeout = value; }
    }
	

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Visible)
        {
            System.Web.UI.ScriptManager manager = (System.Web.UI.ScriptManager)Parent.FindControl("ScriptManager1");
            if (manager != null)
            {
                manager.AsyncPostBackTimeout = timeout * 60;
            }            
        }
    }    		
    
    protected void generateTiles_Click(object sender, EventArgs e)
    {
        AspMap.Web.TileLayer tileLayer = TileLayer.Find(TileLayerID);
        if (tileLayer != null)
        {
            AspMap.Web.Map map = (AspMap.Web.Map)Parent.FindControl(mapID);
            if (map == null) return;

            Server.ScriptTimeout = timeout * 60;
            
            string tileFolder = MapPath(TileCacheDirectory);
            double currentScale = map.ZoomToScale(map.ZoomLevel);
            tileLayer.GenerateTiles(currentScale, tileFolder);            
        }
    }    
</script>
    <!-- TILE GENERATOR -->
    <style>
    #<%=tileGenerator.ClientID%> { position:absolute; right:10px; z-index: 2000;}
    #<%=tileProgress.ClientID%> { position:absolute; left:50%; top:50%; z-index: 2000; background-color:yellow; border: solid 1px; }
    </style>
    <asp:UpdatePanel ID="tileGenerator" runat="server">
	<ContentTemplate>    
        <asp:button id="generateTiles" text="Generate tiles&#13;&#10;for the current&#13;&#10;zoom level&#13;&#10;" runat="server" OnClick="generateTiles_Click"></asp:button>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="tileProgress" AssociatedUpdatePanelID="tileGenerator" runat="server" DisplayAfter="0">
    <ProgressTemplate>
          <marquee><h3>Generating tiles...</h3></marquee>          
    </ProgressTemplate>
    </asp:UpdateProgress>
    <!-------------------->