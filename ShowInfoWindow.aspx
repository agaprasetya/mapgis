<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowInfoWindow.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
    <title>Show an InfoWindow</title>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Show an InfoWindow</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="callout" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right">
Click the button to show an information window on the map.<br /><br />
    <asp:Button ID="callout" runat="server" OnClick="callout_Click" Text="Show an InfoWindow" /><br/>
</div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		

</form>
</body>
</html>
