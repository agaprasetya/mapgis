<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page AutoEventWireup="true" language="c#" Inherits="RouteApp" CodeFile="RouteApp.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="3" cellPadding="0" border="0">
				<TR>
					<TD><FONT color="#ff0000">ROUTE START:</FONT>
						<asp:DropDownList id="startLocation" runat="server" Width="217"></asp:DropDownList><BR>
						<FONT color="#009900">ROUTE FINISH:</FONT>
						<asp:DropDownList id="endLocation" runat="server" Width="217"></asp:DropDownList>
						<BR>
						<asp:Label id="errorMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
						<asp:Button id="findRoute" runat="server" Text=" Find Route " onclick="findRoute_Click"></asp:Button><BR>
					</TD>
					<TD vAlign="top" align="right">Units: 
						<asp:RadioButtonList id="unitsList" runat="server"
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
							<asp:ListItem Value="Miles" Selected="True">Miles</asp:ListItem>
							<asp:ListItem Value="Kilometers">Kilometers</asp:ListItem>
						</asp:RadioButtonList><br/>Route Type:<asp:RadioButtonList 
                            id="routeTypeList" runat="server" RepeatDirection="Horizontal" 
                            RepeatLayout="Flow">
								<asp:ListItem Value="Quickest" Selected="True">Quickest</asp:ListItem>
								<asp:ListItem Value="Shortest">Shortest</asp:ListItem>
							</asp:RadioButtonList></TD>
					<TD vAlign="middle"><STRONG></STRONG>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="2" cellPadding="1" border="0">
					<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:Map id="map" runat="server" Width="600px" Height="500px" 
							BackColor="Ivory" ImageFormat="Gif" onunload="map_Unload" MapTool="Pan" FontQuality="AntiAlias" SmoothingMode="AntiAlias"></aspmap:Map>
					</ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="findRoute" EventName="Click" />
                    </Triggers>
</asp:UpdatePanel></TD>
<td valign="top"><p>This application calculates a route between two locations, plots the route on a map and displays driving directions.<p>
<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
				<asp:Panel id="Panel1" runat="server">
					<STRONG>Driving Directions</STRONG><BR>
					<asp:Table id="directionsTable" runat="server" BorderColor="Gold" BorderWidth="1px" BorderStyle="Solid"
						BackColor="#FEFCED" GridLines="Both" CellSpacing="0" CellPadding="4"></asp:Table>
				</asp:Panel>
			</ContentTemplate></asp:UpdatePanel>
</td>
				</TR>
				</TABLE>
				<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position=TopLeft />
		</form>
	</body>
</html>
