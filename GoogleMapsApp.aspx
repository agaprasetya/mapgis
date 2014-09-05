<%@ Page language="c#" AutoEventWireup="true" Inherits="GoogleMapsApp" CodeFile="GoogleMapsApp.aspx.cs"%>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
		<title>Google Maps</title>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Google Maps</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right">
Demonstrates how to add a transparent shapefile over a satellite map from Google Maps. 
</div>
<aspmap:ZoomBar ID="ZoomBar1" runat=server Map="map" Position="TopLeft" ButtonStyle="Flat" />		

</form>
</body>
</html>
