<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="VehicleDirectionStatic.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</head>
	<body>
		<h4>Vehicle Direction (static image)</h4>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<table id="Table2" cellSpacing="2" cellPadding="1" border="0">
				<tr>
					<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:map id="map" runat="server" BackColor="#FEFCED" Width="607px" Height="500px" ImageFormat="Gif" 
							MapTool="Pan" ClientScript="StandardScript" AnimationInterval="1500" OnRefreshAnimationLayer="map_RefreshAnimationLayer" FontQuality="ClearType" SmoothingMode="AntiAlias"></aspmap:map>
				</ContentTemplate>
                    </asp:UpdatePanel></td>
                    <td valign=top>This sample uses a PNG image to display the vehicle direction.
                        <br />
                    <aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />
                    </td>
				</tr>
			</table>
		</form>
	</body>
</html>
