<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapControl.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Map Control</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	ImageFormat="Png" Cursor="default">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ListBox1" />
    </Triggers>
</asp:UpdatePanel>
</div>
<div  class="right">
<p>The Map control displays collections of layers, markers, map shapes, callouts.</p>
<p>Select one of the files from the list. The file will be added as a map layer.</p>
    <asp:ListBox ID="ListBox1" runat="server" Height="127px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True">
        <asp:ListItem Selected="True">WORLD/world.shp</asp:ListItem>        
        <asp:ListItem>USA/usa.shp</asp:ListItem>
        <asp:ListItem>PARCELS/aerialphoto.tif</asp:ListItem>
        <asp:ListItem>STREETS/street.shp</asp:ListItem>        
    </asp:ListBox>    
    </div>
</form>
</body>
</html>
