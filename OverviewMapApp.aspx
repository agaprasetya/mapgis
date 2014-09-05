<%@ Page language="c#" AutoEventWireup="true" Inherits="OverviewMapApp" CodeFile="OverviewMapApp.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body bgColor="lavender">
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4>Overview Map</H4>
				<TABLE id="Table1" cellSpacing="4" cellPadding="1" border="0">
					<TR>
						<TD>
							<asp:ImageButton id="zoomFull" runat="server" ImageUrl="tools/zoomfull.gif" BorderStyle="Outset"
								BorderWidth="1px" ToolTip="Zoom All" BorderColor="White" OnClick="zoomFull_Click"></asp:ImageButton>
							<aspmap:MapToolButton id="zoomInTool" runat="server" ImageUrl="tools/zoomin.gif" Map="map" ToolTip="Zoom In"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="zoomOutTool" runat="server" ImageUrl="tools/zoomout.gif" ToolTip="Zoom Out"
								Map="map" MapTool="ZoomOut"></aspmap:MapToolButton>
							<aspmap:MapToolButton id="panTool" runat="server" ImageUrl="tools/pan.gif" ToolTip="Pan" Map="map" MapTool="Pan"></aspmap:MapToolButton>
</TD>
						<td rowspan="2" valign="top">
<p>This sample demonstrates how to implement the overview map feature and allows the user to toggle layer visibility.</p>                                                    
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:Map id="overviewMap" runat="server" Width="150px" Height="150px" BackColor="#E6E6FA" ImageFormat="Gif" SmoothingMode="None"
								FontQuality="ClearType" ClientScript="NoScript" MapTool="Point" OnPointTool="overviewMap_PointTool"></aspmap:Map>
				</ContentTemplate></asp:UpdatePanel>
                            <asp:CheckBoxList ID="layerList" runat="server" AutoPostBack="True">
                            </asp:CheckBoxList>
                            </td>
					</TR>
					<TR>
						<TD valign="top"><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
							<aspmap:Map id="map" runat="server" Width="600px" Height="400px" BackColor="#E6E6FA" ImageFormat="Gif" SmoothingMode="AntiAlias"
								FontQuality="ClearType" MapTool="Pan"></aspmap:Map>
					</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="zoomFull" />
                                <asp:AsyncPostBackTrigger ControlID="overviewMap" />
                                <asp:AsyncPostBackTrigger ControlID="layerList" />
                            </Triggers>
                        </asp:UpdatePanel>
                            <asp:Label ID="status" runat="server"></asp:Label></TD>
					</TR>
				</TABLE><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
			<asp:DataGrid id="identifyGrid" runat="server" HorizontalAlign="Center"></asp:DataGrid>
			</ContentTemplate></asp:UpdatePanel>	
		</form>
	</body>
</HTML>
