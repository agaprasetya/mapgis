<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page AutoEventWireup="true" language="c#" Inherits="ChartMapApp" CodeFile="ChartMapApp.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="4" cellPadding="2" border="0">
				<TR>
					<TD align="left" colspan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><STRONG>Population Change 1990-1997</STRONG></TD>
								<TD align="right">
									<FONT size="2">Chart Type:</FONT>
									<asp:DropDownList id="chartType" runat="server" AutoPostBack="True">
                                        <asp:ListItem>Bar</asp:ListItem>
                                        <asp:ListItem>Pie</asp:ListItem>
                                    </asp:DropDownList>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD rowspan="3" vAlign="top">
					<p>Displays bar/pie charts for each state: one bar/pie representing 1990 population, and the other representing 1997 population.</p>
						<aspmap:Legend id="legend" runat="server" ImageFormat="Gif"></aspmap:Legend>
					</TD>
				</TR>
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					<aspmap:Map id="map" runat="server" Width="744px" BackColor="#F0F8FF" SmoothingMode="AntiAlias" FontQuality="ClearType"
					ImageFormat="Gif" ClientScript="StandardScript"
					MapTool="Pan" Height="500px"></aspmap:Map>
					</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="chartType" />
                            <asp:AsyncPostBackTrigger ControlID="fullExtent" />
                        </Triggers>
                    </asp:UpdatePanel></TD>
				</TR>
				<TR>
					<TD>
						<asp:LinkButton id="fullExtent" runat="server" Font-Bold="True" onclick="fullExtent_Click">Return to Full Extent</asp:LinkButton></TD>
				</TR>
			</TABLE>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position=TopLeft />
			<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
			<asp:DataGrid id="cityInfoGrid" runat="server" HorizontalAlign="Center">
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="SteelBlue"></HeaderStyle>
			</asp:DataGrid>
			</ContentTemplate></asp:UpdatePanel>

		</form>
	</body>
</HTML>
