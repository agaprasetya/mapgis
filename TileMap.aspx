<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="TileMap.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">   <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4>Display a Tile Map</H4>
				<TABLE id="Table1" cellSpacing="4" cellPadding="1" border="0">
					<TR>
						<TD valign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
							<aspmap:Map id="map" runat="server" Width="700px" ImageFormat="Png" SmoothingMode="AntiAlias"
								FontQuality="ClearType" BackColor="#99B3CC" Cursor="" Height="500px" MapTool="Pan"></aspmap:Map>
                            </ContentTemplate></asp:UpdatePanel></TD>
                            <td valign="top">This sample demonstrates how to use the TileLayer class to speed up pan and zoom operations.<br/>The TileLayer class gives your server a performance boost by caching map images on the client and server side.<br/><br/>
                            </td>
					</TR>
				</TABLE>
		
		</form>
        <aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position="TopLeft" />
	</body>
</HTML>
