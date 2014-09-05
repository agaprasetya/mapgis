<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="ZoomInOut.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Zoom In and Out</h4>
<aspmap:MapToolButton id="zoomInTool" runat="server" ImageUrl="tools/zoomin.gif" Map="map" ToolTip="Zoom In"></aspmap:MapToolButton>
<aspmap:MapToolButton id="zoomOutTool" runat="server" ImageUrl="tools/zoomout.gif" ToolTip="Zoom Out"
Map="map" MapTool="ZoomOut"></aspmap:MapToolButton></br>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right"><p>Select one of the map tool buttons above the map and click on the map.</p>
<p>Use the mouse wheel to zoom in and out.</p>
<p>iOS/Android: You can pinch to zoom in and out, or double tap to zoom in.</p>
<button onclick="zoomIn()" type="button">Zoom In</button><br/>
<button onclick="zoomOut()" type="button">Zoom Out</button><br/>
<button onclick="zoomFull()" type="button">Zoom Full</button><br/>
</div>
</form>

	<script>	
	
	var map = AspMap.getMap('<%=map.ClientID%>');
     
	function zoomIn()
	{
	    map.zoomIn();
	}
	
	function zoomOut()
    {
        map.zoomOut();
    }
    
    function zoomFull()
    {
        map.zoomFull();
    }    
	</script>

</body>
</html>
