<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="MapSession.aspx.cs"%>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
	<h4>Using Map Sessions</h4>
		<form id="Form1" method="post" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="4" cellPadding="2" border="0">
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:Map id="map" runat="server" Width="700px" BackColor="#F0F8FF" SmoothingMode="AntiAlias"
					FontQuality="ClearType" ImageFormat="Gif" 
					EnableSession="true" MapTool="Pan" Height="500px"></aspmap:Map>
					</ContentTemplate>
                    </asp:UpdatePanel></TD>
                    <TD valign="top">This sample enables session support for the Map control to avoid adding map layers on each postback.<br/><br/>
                    This sample renders roads depending on the road class and zoom level(scale).</TD>
				</TR>
			</TABLE>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position=TopLeft />		
		</form>
	</body>
</HTML>
