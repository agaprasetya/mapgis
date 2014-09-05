<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="GeneratingStaticTiles.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">   <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600" />
			<H4>Generating Static Tiles</H4>
				<TABLE id="Table1" cellSpacing="4" cellPadding="1" border="0">
					<TR>
						<TD valign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
							<aspmap:Map id="map" runat="server" Width="700px" ImageFormat="Png" SmoothingMode="AntiAlias"
								FontQuality="ClearType" BackColor="#99B3CC" Cursor="" Height="500px" MapTool="Pan"></aspmap:Map>
                            </ContentTemplate></asp:UpdatePanel></TD>
                            <td valign="top">This sample demonstrates how to generate static tiles for a TileLayer. Static tiles
                                will be stored in the /TileCache/WorldMap directory.<br />
                                <br/>
                                Select a zoom level and click the 'Generate' button.<br/><br/>
    <!-- TILE GENERATOR CODE -->
    <asp:UpdatePanel ID="tileGenerator" runat="server">
	<ContentTemplate>    
        <asp:button id="generateTiles" text="Generate" runat="server" OnClick="generateTiles_Click"></asp:button>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="tileProgress" AssociatedUpdatePanelID="tileGenerator" runat="server" DisplayAfter="0">
    <ProgressTemplate>
          <div style="position:absolute; left:50%; top:50%; z-index: 2000; background-color:yellow; border: solid 1px;">
          <marquee><h3>Generating tiles...</h3></marquee>          
          </div>
    </ProgressTemplate>
    </asp:UpdateProgress>
    <!-- TILE GENERATOR CODE -->
</td>
					</TR>
				</TABLE>
		
		</form>
        <aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position="TopLeft" />
	</body>
</HTML>
