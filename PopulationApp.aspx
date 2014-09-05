<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page AutoEventWireup="true" language="c#" Inherits="PopulationApp" CodeFile="PopulationApp.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
		<title>Population by Cites</title>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="4" cellPadding="2" border="0">
				<TR>
					<TD align="left">&nbsp;
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 190px"><STRONG>Population by Cities</STRONG></TD>
								<TD style="WIDTH: 150px" align="right">
                                    &nbsp;</TD>
								<TD align="right">
									<FONT size="2">Zoom to a state:</FONT>
									<asp:DropDownList id="statesList" runat="server" AutoPostBack="True" onselectedindexchanged="statesList_SelectedIndexChanged"></asp:DropDownList>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD rowspan="3" valign="middle">
					<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:Legend id="legend" runat="server" ImageFormat="Gif"></aspmap:Legend>
					</ContentTemplate></asp:UpdatePanel>					
					</TD>
				</TR>
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
					<aspmap:Map id="map" runat="server" Width="700px" BackColor="#F0F8FF" SmoothingMode="AntiAlias" FontQuality="ClearType"
					ImageFormat="Gif" ClientScript="StandardScript"
					MapTool="Pan" Height="500px"></aspmap:Map>
					</ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel></TD>
				</TR>
			</TABLE>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position=TopLeft />
            &nbsp;
		
		</form>
	</body>
</HTML>
