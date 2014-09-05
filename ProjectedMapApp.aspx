<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page AutoEventWireup="true" language="c#" Inherits="ProjectedMapApp" CodeFile="ProjectedMapApp.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"> <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H4>Using A Different Projection for a Layer</H4>
			Projection:
			<asp:DropDownList id="coordSystemList" runat="server" AutoPostBack="True" onselectedindexchanged="coordSystemList_SelectedIndexChanged"></asp:DropDownList>
<div class="left">					
			<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>			
			<aspmap:map id="map" runat="server" ClientScript="StandardScript" SmoothingMode="AntiAlias" Width="700px"
					BackColor="#99B3CC" Height="500px" Enabled="False" ImageFormat="Gif"></aspmap:map>
                        </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="coordSystemList" />
                </Triggers>
            </asp:UpdatePanel>
</div><div class="right">This sample uses a CoordSystem object to project a world map into various coordinate systems.
</div>
		</form>
	</body>
</HTML>
