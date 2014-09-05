<%@ Page AutoEventWireup="true" language="c#" Inherits="_Default" CodeFile="AddTooltips.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
		<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="4" cellPadding="2"border="0">
				<TR>
					<TD align="left" colspan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="80%" border="0">
							<TR>
								<TD><IMG src="symbols/airport.bmp" align="middle">
									- open airports&nbsp;&nbsp;&nbsp; <IMG src="symbols/airport_closed.bmp" align="middle">
									- closed airports
									<BR>
									<FONT color="#0033ff">Point on an airport icon for more information</FONT>
								</TD>
								<TD align="right"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                <aspmap:map id="map" runat="server" ImageFormat="Gif" FontQuality="Default" SmoothingMode="None" BackColor="#F0F8FF" Width="700px" MapTool="Pan" Height="500px"></aspmap:map>
		
				</ContentTemplate>
                    </asp:UpdatePanel></TD>
							<TD vAlign="top">
							Demonstrates how to add tooltips to the locations.							
						</TD>		
				</TR>
			</TABLE>
<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position="TopLeft"/>			
		</form>
	</body>
</HTML>
