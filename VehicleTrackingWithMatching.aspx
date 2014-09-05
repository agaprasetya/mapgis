<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="VehicleTrackingWithMatching.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
	<head>
		<title>Vehicle Tracking</title>
<link rel="stylesheet" type="text/css" href="styles.css">
	</head>
	<body>
			<h4>Vehicle Tracking With Map-Matching</h4>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<table id="Table2" cellSpacing="2" cellPadding="1"
				border="0">
				<tr>
					<td>
						<asp:CheckBox id="autoRefresh" runat="server" Text="Auto-refresh" Checked="True"></asp:CheckBox><br/>
						Interval:
						<asp:DropDownList id="trackingInterval" runat="server">
							<asp:ListItem Value="500">0.5 sec</asp:ListItem>
							<asp:ListItem Value="1000">1 sec</asp:ListItem>
							<asp:ListItem Value="2000"  Selected="True">2 sec</asp:ListItem>
							<asp:ListItem Value="3000">3 sec</asp:ListItem>
						</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:Button id="refreshButton" runat="server" Text="Manual Refresh"></asp:Button>&nbsp; 
					</td>
					<td align="right"></td>
				</tr>
				<tr>
					<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:map id="map" runat="server" BackColor="#FEFCED" Width="607px" Height="500px" ImageFormat="Gif" 
							MapTool="Pan" ClientScript="StandardScript" AnimationInterval="2000" OnRefreshAnimationLayer="map_RefreshAnimationLayer" FontQuality="ClearType" SmoothingMode="AntiAlias"></aspmap:map>
				</ContentTemplate>
                    </asp:UpdatePanel></td>
                    <td valign=top>This sample uses a map-matching algorithm to display vehicles exactly on road segments.<br />
                        <br />
                        The red rectangle <img src="symbols/pixel.gif" style="background-color:Red;" width="10" height="10"> depicts the original GPS coordinate, whereas the vehicle image <img src="SYMBOLS/vehicle.gif" width="20" height="20">
                        depicts the matched coordinate.<br />
                        <br/>
                    <aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />
                    </td>
				</tr>
			</table>
		
		</form>
	</body>
</html>
