<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="ZoomRectangle.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Track Zoom in a Map</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="button1" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right">
<p>Click and drag on the map. </p>
<asp:Button id="button1" runat="server" Text="Return To Full Extent" OnClick="button1_Click" /><br/>
</div>
</form>

</body>
</html>
