<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="SimpleMapApp" CodeFile="MapToolButtonControl.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>MapToolButton Control</h4>
<aspmap:MapToolButton id="zoomInTool" runat="server" ImageUrl="tools/zoomin.gif" Map="map" ToolTip="Zoom In"></aspmap:MapToolButton>
<aspmap:MapToolButton id="zoomOutTool" runat="server" ImageUrl="tools/zoomout.gif" ToolTip="Zoom Out"
Map="map" MapTool="ZoomOut"></aspmap:MapToolButton>
<aspmap:MapToolButton id="panTool" runat="server" ImageUrl="tools/pan.gif" ToolTip="Pan" Map="map" MapTool="Pan"></aspmap:MapToolButton>
<aspmap:MapToolButton ID="distanceTool" runat="server" ImageUrl="TOOLS/distance.gif"
Map="map" MapTool="Distance" ToolTip="Measure Distance" />
<br/>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right">The MapToolButton controls let users select various map tools from the associated Map control.<br/>
The MapToolButton controls track the current map tool and update themselves automatically.
</div>
</form>
</body>
</html>
