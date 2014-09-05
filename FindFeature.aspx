<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindFeature.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Find the Feature the User Clicked</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png" OnInfoWindowTool="map_InfoWindowTool">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right">
Click on a country for more information.
    <br /><br />
</div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		

</form>
</body>
</html>
