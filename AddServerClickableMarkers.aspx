<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddServerClickableMarkers.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Add Clickable Markers (server-side)</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png" OnMarkerClick="map_MarkerClick">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right">
Click on a marker to display information about the marker in the 'Marker info' field.<br />
    <br />
    Marker info:<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:TextBox id="markerInfo" runat="server" Height="150px" TextMode="MultiLine" Width="140px"></asp:TextBox>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="map" />
    </Triggers>
</asp:UpdatePanel>
</div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		

</form>
</body>
</html>
