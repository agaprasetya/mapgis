<%@ Page language="c#" AutoEventWireup="true" Inherits="MapToolsApp" CodeFile="MapToolsApp.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<HTML>
	<HEAD>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4>Map Tools</H4>
				<TABLE cellSpacing="1" cellPadding="1" border="0">
					<TR>
						<TD colSpan="2">
							<asp:ImageButton id="zoomFull" runat="server" ImageUrl="tools/zoomfull.gif" BorderStyle="Outset"
								BorderWidth="1px" ToolTip="Zoom All" BorderColor="White" OnClick="zoomFull_Click"></asp:ImageButton>
							<aspmap:MapToolButton id="zoomInTool" runat="server" ImageUrl="tools/zoomin.gif" Map="map" ToolTip="Zoom In"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="zoomOutTool" runat="server" ImageUrl="tools/zoomout.gif" ToolTip="Zoom Out"
								Map="map" MapTool="ZoomOut"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="panTool" runat="server" ImageUrl="tools/pan.gif" ToolTip="Pan" Map="map" MapTool="Pan"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="centerTool" runat="server" ImageUrl="tools/center.gif" ToolTip="Center" Map="map"
								MapTool="Center"></aspmap:MapToolButton>
                            <aspmap:MapToolButton ID="distanceTool" runat="server" ImageUrl="TOOLS/distance.gif"
                                Map="map" MapTool="Distance" ToolTip="Measure Distance" />
							<aspmap:MapToolButton id="infoTool" runat="server" ImageUrl="tools/info.gif" ToolTip="Identify" Map="map"
								MapTool="Info"></aspmap:MapToolButton>&nbsp;<aspmap:MapToolButton id="infoWindowTool" runat="server" ImageUrl="tools/infowindow.gif" ToolTip="Info Window" Map="map"
								MapTool="InfoWindow"></aspmap:MapToolButton>
                            &nbsp;&nbsp; &nbsp;
							<aspmap:MapToolButton id="pointTool" runat="server" ToolTip="Point Tool" ImageUrl="tools/point.gif" Map="map"
								MapTool="Point"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="lineTool" runat="server" ToolTip="Line Tool" ImageUrl="tools/line.gif" Map="map"
								MapTool="Line"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="polylineTool" runat="server" ToolTip="Polyline Tool" ImageUrl="tools/polyline.gif"
								Map="map" MapTool="Polyline"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="rectangleTool" runat="server" ToolTip="Rectangle Tool" ImageUrl="tools/rectangle.gif"
								Map="map" MapTool="Rectangle"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="circleTool" runat="server" ToolTip="Circle Tool" ImageUrl="tools/circle.gif"
								Map="map" MapTool="Circle"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="polygonTool" runat="server" ToolTip="Polygon Tool" ImageUrl="tools/polygon.gif"
								Map="map" MapTool="Polygon"></aspmap:MapToolButton>&nbsp;&nbsp; Active Layer:
							<asp:DropDownList id="layerList" runat="server"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD valign="top" colSpan="1"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
							<aspmap:Map id="map" runat="server" FontQuality="ClearType" SmoothingMode="AntiAlias" ImageFormat="Gif"
								BackColor="#E6E6FA" Width="700px" Height="500px" OnCircleTool="map_CircleTool" OnInfoTool="map_InfoTool" OnLineTool="map_LineTool" OnPointTool="map_PointTool" OnPolygonTool="map_PolygonTool" OnPolylineTool="map_PolylineTool" OnRectangleTool="map_RectangleTool" OnInfoWindowTool="map_InfoWindowTool"></aspmap:Map>
				</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="zoomFull" />
                            </Triggers>
                        </asp:UpdatePanel> </TD>
                        <td valign=top>This sample demonstrates the built-in map tools and allows users to select map features by drawing points, lines, circles, rectangles or polygons directly on the map.<br/>
                        See also the <a href="ShapeEditorApp.aspx">ShapeEditor</a> sample on how to use the DrawShape and EditShape tools.</td>
					</TR>
                    <tr>
                        <td colspan="2" valign="top">
                            <asp:Label ID="status" runat="server"></asp:Label></td>
                    </tr>
				</TABLE><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
			<asp:DataGrid id="dataGrid" runat="server"></asp:DataGrid>
		     </ContentTemplate></asp:UpdatePanel>
		
		</form>
	</body>
</HTML>
