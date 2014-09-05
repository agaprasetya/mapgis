<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="ZoomToScale.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Zoom To a Scale</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button3" />
        <asp:AsyncPostBackTrigger ControlID="Button2" />
        <asp:AsyncPostBackTrigger ControlID="Button1" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right"><p>Click the buttons to zoom to different scales. New layers will appear depending on the scale.</p>
</div>
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="1 : 10,000,000" /><br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="1 : 1,000,000" /><br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="1 : 100,000" /><br />
    <br />
    <br />
</form>
</body>
</html>
