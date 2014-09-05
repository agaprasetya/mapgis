<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="VehicleTrackingWithCaching.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
	<head>
		<title>Vehicle Tracking</title>
<link rel="stylesheet" type="text/css" href="styles.css">
	</head>
	<body>
			<h4>Vehicle Tracking With Map Caching</h4>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<table id="Table2" cellSpacing="2" cellPadding="1"
				border="0">
				<tr>
					<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:map id="map" runat="server" BackColor="#FEFCED" Width="607px" Height="500px" ImageFormat="Gif" 
							MapTool="Pan" ClientScript="StandardScript" AnimationInterval="1500" OnRefreshAnimationLayer="map_RefreshAnimationLayer" FontQuality="ClearType" SmoothingMode="AntiAlias"></aspmap:map>
				</ContentTemplate>
                    </asp:UpdatePanel></td>
                    <td valign=top>Uses the TileLayer class to make your mapping application run faster.<br/>
                    <aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopRight" />
                    </td>
				</tr>
			</table>
		
		</form>
	</body>
</html>
