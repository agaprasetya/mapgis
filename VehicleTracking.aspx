<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="VehicleTracking.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
	<head>
		<title>Vehicle Tracking</title>
<link rel="stylesheet" type="text/css" href="styles.css">
	</head>
	<body>
			<h4>Vehicle Tracking </h4>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<table id="Table2" cellSpacing="2" cellpadding="1"
				border="0">
				<tr>
					<td>
						<asp:CheckBox id="autoRefresh" runat="server" Text="Auto-refresh" Checked="True"></asp:CheckBox><br/>
						Interval:
						<asp:DropDownList id="trackingInterval" runat="server">
							<asp:ListItem Value="500">0.5 sec</asp:ListItem>
							<asp:ListItem Value="1000" Selected="True">1 sec</asp:ListItem>
							<asp:ListItem Value="2000">2 sec</asp:ListItem>
							<asp:ListItem Value="3000">3 sec</asp:ListItem>
						</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:Button id="refreshButton" runat="server" Text="Manual Refresh"></asp:Button>&nbsp; 
					</td>
					<td align="right"></td>
				</tr>
				<tr>
					<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:map id="map" runat="server" BackColor="#FEFCED" Width="607px" Height="500px" ImageFormat="Gif" 
							MapTool="Pan" ClientScript="StandardScript" AnimationInterval="1000" OnRefreshAnimationLayer="map_RefreshAnimationLayer" FontQuality="ClearType" SmoothingMode="AntiAlias"></aspmap:map>
				</ContentTemplate>
                    </asp:UpdatePanel></td>
                    <td valign=top>Simulates a vehicle tracking application using real-time GPS coordinates.<br/>
                    <aspmap:ZoomBar runat="server" Map="map" ID="zoomBar" Position="TopRight" />
                    </td>
				</tr>
			</table>
		
		</form>
	</body>
</html>
