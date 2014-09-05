<%@ Page language="c#" AutoEventWireup="true" CodeFile="MapTutorial.aspx.cs" Inherits="MapTutorial" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body bgColor="lavender">
		<form id="Form1" method="post" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4 align="center">Map Tutorial</H4>
				<TABLE id="Table1" align="center" cellSpacing="4" cellPadding="1" width="491" border="0" style="WIDTH: 491px; HEIGHT: 338px">
					<TR>
						<TD colSpan="2">
							<asp:ImageButton id="zoomFull" runat="server" ImageUrl="tools/zoomfull.gif" BorderStyle="Outset"
								BorderWidth="1px" ToolTip="Zoom All" BorderColor="White" ></asp:ImageButton>
							<aspmap:MapToolButton id="zoomInTool" runat="server" ImageUrl="tools/zoomin.gif" Map="Map1" ToolTip="Zoom In"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="zoomOutTool" runat="server" ImageUrl="tools/zoomout.gif" ToolTip="Zoom Out"
								Map="Map1" MapTool="ZoomOut"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="panTool" runat="server" ImageUrl="tools/pan.gif" ToolTip="Pan" Map="Map1" MapTool="Pan"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="infoTool" runat="server" ImageUrl="tools/info.gif" ToolTip="Identify" Map="Map1"
								MapTool="Info"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="infoWindowTool" runat="server" ImageUrl="tools/infowindow.gif" ToolTip="Info Window" Map="Map1"
								MapTool="InfoWindow"></aspmap:MapToolButton>
</TD>
					</TR>
					<TR>
						<TD valign="top">
						<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
							<aspmap:Map id="Map1" runat="server" Width="700px" BackColor="#E6E6FA" Height="500px" ImageFormat="Gif" SmoothingMode="None"
								FontQuality="Default" OnInfoTool="Map1_InfoTool" OnInfoWindowTool="Map1_InfoWindowTool"></aspmap:Map></ContentTemplate></asp:UpdatePanel></TD>
					</TR>
				</TABLE>
			<asp:DataGrid id="DataGrid1" runat="server" HorizontalAlign="Center"></asp:DataGrid>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Map="Map1" Position=TopLeft />					
		</form>		
	</body>
</HTML>
