<%@ Page language="c#" AutoEventWireup="true" Inherits="ParcelMapApp" CodeFile="ParcelMapApp.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4>Parcel Map</H4>
				<TABLE id="Table1" cellSpacing="4" cellPadding="1" border="0">
					<TR>
						<TD align="left" colSpan="2"><asp:imagebutton id="zoomFull" runat="server" BorderColor="White" ToolTip="Zoom All" BorderWidth="1px"
								BorderStyle="Outset" ImageUrl="tools/zoomfull.gif" OnClick="zoomFull_Click"></asp:imagebutton><aspmap:maptoolbutton id="zoomInTool" runat="server" ToolTip="Zoom In" ImageUrl="tools/zoomin.gif" Map="map"></aspmap:maptoolbutton><aspmap:maptoolbutton id="zoomOutTool" runat="server" ToolTip="Zoom Out" ImageUrl="tools/zoomout.gif"
								Map="map" MapTool="ZoomOut"></aspmap:maptoolbutton><aspmap:maptoolbutton id="panTool" runat="server" ToolTip="Pan" ImageUrl="tools/pan.gif" Map="map" MapTool="Pan"></aspmap:maptoolbutton><aspmap:maptoolbutton id="centerTool" runat="server" ToolTip="Center" ImageUrl="tools/center.gif" Map="map"
								MapTool="Center"></aspmap:maptoolbutton><aspmap:maptoolbutton id="infoTool" runat="server" ToolTip="Identify" ImageUrl="tools/info.gif" Map="map"
								MapTool="Info"></aspmap:maptoolbutton></TD>
					</TR>
					<TR>
						<TD vAlign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:map id="map" runat="server" MapUnit="Foot" Height="500px" FontQuality="ClearType" SmoothingMode="AntiAlias"
								ImageFormat="PNG" BackColor="Gray" Width="700px" OnInfoTool="map_InfoTool"></aspmap:map>						
						</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="zoomFull" />
                                <asp:AsyncPostBackTrigger ControlID="searchAddress" />
                                <asp:AsyncPostBackTrigger ControlID="searchOwner" />
                                <asp:AsyncPostBackTrigger ControlID="searchParcel" />
                            </Triggers>
                        </asp:UpdatePanel></TD>
						<TD vAlign="top" align="left">
						<asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
			        <asp:Label ID=label runat="server" ForeColor="Red"></asp:Label>
			</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="searchParcel" />
                                <asp:AsyncPostBackTrigger ControlID="searchOwner" />
                                <asp:AsyncPostBackTrigger ControlID="searchAddress" />
                            </Triggers>
                        </asp:UpdatePanel><br>
						<STRONG>Search by:<BR>
								&nbsp;<BR>
							</STRONG>
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD align="right"><STRONG>Address:</STRONG>
										<asp:textbox id="addressTextBox" runat="server">110 Shady Lane</asp:textbox><BR>
										<asp:button id="searchAddress" runat="server" Text="Search" onclick="searchAddress_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="right"><STRONG>Parcel #:</STRONG>
										<asp:textbox id="parcelTextBox" runat="server">15082036A</asp:textbox><BR>
										<asp:button id="searchParcel" runat="server" Text="Search" onclick="searchParcel_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="right"><STRONG>Owner:</STRONG>
										<asp:textbox id="ownerTextBox" runat="server">Bruno</asp:textbox><BR>
										<asp:button id="searchOwner" runat="server" Text="Search" onclick="searchOwner_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
			<asp:datagrid id="identifyGrid" runat="server">
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="RoyalBlue"></HeaderStyle>
			</asp:datagrid>
			</ContentTemplate></asp:UpdatePanel>
                
		</form>
	</body>
</HTML>
