<%@ Register  TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page AutoEventWireup="true" language="c#" Inherits="CoordSystemApp" CodeFile="AddLayersWithDfferentProjections.aspx.cs" %>
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
						<STRONG>Add Layers With Different Projections</STRONG>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:map id="map" runat="server" Height="500px" Width="756px"
							ImageFormat="Gif" MapTool="Pan" SmoothingMode="AntiAlias" BackColor="#99B3CC"></aspmap:map>
					</ContentTemplate></asp:UpdatePanel></TD>
					<td valign="top">This sample transforms map layers that have different coordinate systems (Geographic-WGS1984, Mercator, Miller Cylindrical) into a common coordinate system (Winkel I).</td>
				</TR>
			</TABLE>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Position=TopLeft Map="map"/>
			<br>
		
		</form>
	</body>
</HTML>
