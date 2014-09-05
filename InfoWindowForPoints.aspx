<%@ Page AutoEventWireup="true" language="c#" Inherits="_Default" CodeFile="InfoWindowForPoints.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
		<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="4" cellPadding="2"border="0">
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                <aspmap:map id="map" runat="server" ImageFormat="Gif" FontQuality="Default" SmoothingMode="None" BackColor="#F0F8FF" Width="700px" MapTool="Pan" Height="500px" OnHotspotInfoClick="map_HotspotInfoClick"></aspmap:map>
		
				</ContentTemplate>
                    </asp:UpdatePanel></TD>
							<TD vAlign="top">
							Demonstrates how to dispay in InfoWindow when the user clicks on a location.							
						</TD>		
				</TR>
			</TABLE>
<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position="TopLeft"/>			
		</form>
	</body>
</HTML>
