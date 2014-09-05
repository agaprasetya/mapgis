<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LegendControl.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Legend Control</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="AntiAlias" 
    Width="700px"  Height="500px" MapTool="Pan"	ImageFormat="Png" Cursor="default">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>
<div  class="right">
<p>The Legend control displays a description and corresponding symbol for map layers or other features.</p>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<aspmap:Legend id="legend" runat="server" Width="150px"  ImageFormat="Png" />
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
