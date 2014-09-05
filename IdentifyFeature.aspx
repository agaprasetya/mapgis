<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="IdentifyFeature.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4>Identify a Feature</H4>
				<TABLE border="0">
					<TR>
						<TD valign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
							<aspmap:Map id="map" runat="server" FontQuality="ClearType" SmoothingMode="AntiAlias" ImageFormat="Gif"
								BackColor="#E6E6FA" Width="700px" Height="500px" OnInfoWindowTool="map_InfoWindowTool"></aspmap:Map>
				</ContentTemplate>
                        </asp:UpdatePanel> </TD>
                        <td valign=top>Click on a feature. This sample identifies features among multiple map layers.</td>
					</TR>
				</TABLE>		
		</form>
	</body>
</HTML>
