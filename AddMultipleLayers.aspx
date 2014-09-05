<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="AddMultipleLayers.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">   <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4>Add Multiple Layers</H4>
				<TABLE id="Table1" cellSpacing="4" cellPadding="1" border="0" frame="void">
					<TR>
						<TD valign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
							<aspmap:Map id="map" runat="server" Width="700px" Height="500px" BackColor="#E6E6FA" ImageFormat="Gif" SmoothingMode="AntiAlias"
								FontQuality="ClearType" MapTool="Pan"></aspmap:Map>
                            </ContentTemplate>
                        </asp:UpdatePanel></TD>
						<TD valign="top">This sample adds multiple shapefiles as map layers.</TD>
					</TR>
				</TABLE>		
		</form>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		
	</body>
</HTML>
