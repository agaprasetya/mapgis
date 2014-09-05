<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddClickableMarkers.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Add Clickable Markers</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right">
Click on a marker to display a JavaScript message box.<br /><br />
<br/>
</div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		

<script type="text/javascript">

var map = AspMap.getMap('<%=map.ClientID%>');

function onMarkerClick(sender, e /* MarkerClickEventArgs */)
{
	alert(e.argument);
	return true;
}
map.add_markerClick(onMarkerClick);

</script>  

</form>
</body>
</html>
