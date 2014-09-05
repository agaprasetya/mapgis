<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintMap.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Print a Map</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png">
</aspmap:map>
</ContentTemplate>
    <Triggers>
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right">
Click the 'Print' button to open a print dialog box.<br/>
<button type="button" onclick="printMap()">Print</button><br/><br />
This sample uses the AspMap JavaScript API.
</div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		
</form>

<script>
function printMap()
{
    var map = AspMap.getMap("<% =map.ClientID %>");
    map.print();
}
</script>

</body>
</html>
