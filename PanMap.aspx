<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="PanMap.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Pan the Map</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="panRight" />
        <asp:AsyncPostBackTrigger ControlID="panTop" />
        <asp:AsyncPostBackTrigger ControlID="panBottom" />
        <asp:AsyncPostBackTrigger ControlID="panLeft" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right"><p>Click one of the buttons to pan the map using either client or server side code.</p>
Client side:<br>
<button onclick="pan(0,100)" type="button">Pan Top</button><br>
<button onclick="pan(100,0)" type="button">
    Pan Left</button><button onclick="pan(-100,0)" type="button">
    Pan Right</button><br>        
<button onclick="pan(0,-100)" type="button">Pan Bottom</button>
</div>
    <br />
    Server side:<br />
    <asp:Button ID="panTop" runat="server" OnClick="panTop_Click" Text="Pan Top" /><br />
    <asp:Button ID="panLeft" runat="server" OnClick="panLeft_Click" Text="Pan Left" />
    <asp:Button ID="panRight" runat="server" OnClick="panRight_Click" Text="Pan Right" /><br />
    <asp:Button ID="panBottom" runat="server" OnClick="panBottom_Click" Text="Pan Bottom" /></form>

	<script>	
	
	var map = AspMap.getMap('<%=map.ClientID%>');
     
    function pan(dx, dy)
    {
        map.pan(dx, dy);
    }
    
    function zoomFull()
    {
        map.zoomFull();
    }    
	</script>

</body>
</html>
