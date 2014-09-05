<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="AddAnimationLayer.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
	<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</head>
	<body>
			<h4>Display the AnimationLayer</h4>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<table id="Table2" cellSpacing="2" cellPadding="1"
				border="0">
				<tr>
					<td>
						<asp:CheckBox id="autoRefresh" runat="server" Text="Auto-refresh" Checked="True"></asp:CheckBox><br/>
						Interval:
						<asp:DropDownList id="trackingInterval" runat="server">
							<asp:ListItem Value="5000"  Selected="True">5 sec</asp:ListItem>
							<asp:ListItem Value="10000">10 sec</asp:ListItem>
						</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:Button id="refreshButton" runat="server" Text="Manual Refresh"></asp:Button>&nbsp; 
					</td>
					<td align="right"></td>
				</tr>
				<tr>
					<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:map id="map" runat="server" BackColor="#99B3CC" Width="607px" Height="500px" ImageFormat="Gif" 
							MapTool="Pan" AnimationInterval="1000" OnRefreshAnimationLayer="map_RefreshAnimationLayer" FontQuality="ClearType" SmoothingMode="AntiAlias"></aspmap:map>
				</ContentTemplate>
                    </asp:UpdatePanel></td>
                    <td valign=top>This sample displays earthquake data from earthquake.usgs.gov. The AnimationLayer is used to update the data every 5 seconds.<br/>
                    Click on a location for addtional information.<br/><br/>
                    <span id="label" style="font-weight:bold;"></span>
                    </td>
				</tr>
			</table>		
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopRight" />							
		</form>
<script>
function showLocation(string)
{
    document.getElementById("label").innerHTML = string;
}
</script>

	</body>
</html>
