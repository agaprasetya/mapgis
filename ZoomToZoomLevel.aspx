<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="ZoomToZoomLevel.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Zoom To a Zoom Level</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ListBox1" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right"><p>Click the list items to zoom to different levels. New layers will appear depending on the zoom level.</p>

    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="78px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
    </asp:ListBox><br />
</div>    
    <br />
    <br />
</form>
</body>
</html>
