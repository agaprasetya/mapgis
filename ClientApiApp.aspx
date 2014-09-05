<%@ Page language="c#" AutoEventWireup="true" Inherits="ClientApiApp" CodeFile="ClientApiApp.aspx.cs"%>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server" />
        <b>Client API Demo</b><br>
        <button onclick="zoomIn()" type="button">Zoom In</button>
        <button onclick="zoomOut()" type="button">Zoom Out</button>
        <button onclick="zoomFull()" type="button">Zoom Full</button>
        <button onclick="printMap()" type="button">Print</button>&nbsp;|&nbsp;
        <button onclick="centerAt()" type="button">Center at</button> latitude:<input id="lat" size=5 type=text value="38"> 
            longitude:<input id="long" size=5 type=text value="-77">
        <table>
        <tr>
        <td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <aspmap:Map id="map" runat="server" Width="700px" BackColor="#F0F8FF" SmoothingMode="AntiAlias"
		FontQuality="ClearType" ImageFormat="Gif" MapTool="Pan" Height="500px"></aspmap:Map>
		</ContentTemplate></asp:UpdatePanel></td>
		<td valign=top>
		<p align="center">
		<button onclick="pan(0,100)" type="button">Top</button><br/>
        <button onclick="pan(-100,0)" type="button">Left</button>
        <button onclick="pan(100,0)" type="button">Right</button><br/>        
        <button onclick="pan(0,-100)" type="button">Bottom</button>        				
        </p>
<p>Demonstrates the AspMap JavaScript API.</p>		        
		</td>
		</table>
		<button onclick="setTool(AspMap.MapTool.Pan)" type="button">Set Pan Tool</button>
        <button onclick="setTool(AspMap.MapTool.ZoomIn)" type="button">Set ZoomIn Tool</button>
        <button onclick="setTool(AspMap.MapTool.Circle)" type="button">Set Circle Tool</button><br/>
		<span id="latlong"></span>
        <script>
            var map = AspMap.getMap('<%=map.ClientID%>');

            map.add_mouseMove(mouseMoveHandler);

            function mouseMoveHandler(sender, e)
            {
                var label = document.getElementById("latlong");
                label.innerHTML = "Latitude: " + e.latitude + " | Longitude: " + e.longitude;
            }

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

            function pan(dx, dy)
            {
                map.pan(dx, dy);
            }

            function setTool(tool)
            {
                map.set_mapTool(tool);
            }

            function printMap()
            {
                map.print();
            }

            function centerAt()
            {
                var latitude = parseFloat(document.getElementById("lat").value);
                var longitude = parseFloat(document.getElementById("long").value);
                map.centerAt(new AspMap.Point(longitude, latitude));
            }
        </script>
        </form>
	</body>
</HTML>
