<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingByZoomLevels.aspx.cs"%>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
	<h4>Rendering Features by Zoom Levels (scales)</h4>
		<form id="Form1" method="post" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="4" cellPadding="2" border="0">
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:Map id="map" runat="server" Width="700px" BackColor="Ivory" SmoothingMode="AntiAlias"
					FontQuality="ClearType" ImageFormat="Gif" 
					MapTool="Pan" Height="500px"></aspmap:Map>
					</ContentTemplate>
                    </asp:UpdatePanel></TD>
                    <TD valign="top">This sample renders roads depending on the zoom level(scale).<br/>
                    Zoom in to the map to see how the line width and label font are changed.</TD>
				</TR>
			</TABLE>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position=TopRight />		
		</form>
	</body>
</HTML>
