<%@ Register  TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page AutoEventWireup="true" language="c#" Inherits="_Default" CodeFile="TransformCoordinates.aspx.cs" %>
<!DOCTYPE HTML>
<html>   

<head>
	<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">   <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="1" cellPadding="1"
				border="0">
				<TR>
					<TD colSpan="2" align="center" style="width: 702px">
						<STRONG>Transform Coordinates Between Different Projections</STRONG>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:map id="map" runat="server" Height="500px" Width="756px"
							ImageFormat="Gif" MapTool="InfoWindow" SmoothingMode="AntiAlias" BackColor="#99B3CC" OnInfoWindowTool="map_InfoWindowTool"></aspmap:map>
					</ContentTemplate></asp:UpdatePanel></TD>
					<td valign="top">Click on the map to transform the coordinates of the click between different projections.</td>
				</TR>
			</TABLE>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Position=TopLeft Map="map"/>
			<br>
		
		</form>
	</body>
</HTML>
