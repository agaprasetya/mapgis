<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPageArea.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">   
<style>
#UpdatePanel1
{
    position:relative; min-height: 100%; width: 100%; height: 100%;
}
.printArea
{
    position:relative;
}
</style>
</head>
<body>
<form id="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div>
    Page Size: 
    <asp:DropDownList ID="pageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="pageSize_SelectedIndexChanged">
        <asp:ListItem>A3</asp:ListItem>
        <asp:ListItem Selected="True">A4</asp:ListItem>
        <asp:ListItem>A5</asp:ListItem>
    </asp:DropDownList>
    Orienation: 
    <asp:DropDownList ID="orientation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="orientation_SelectedIndexChanged">
        <asp:ListItem Selected="True">Landscape</asp:ListItem>
        <asp:ListItem>Portrait</asp:ListItem>
    </asp:DropDownList>
    <button type="button" onclick="printMap()"> Print </button> This sample prints the map and HTML content within the ASP.NET Panel control.
</div>
<asp:Panel runat="server" cssclass="printArea" id="printArea">
<h4>World Map</h4>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="100%"  Height="100%" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        
    </Triggers>
</asp:UpdatePanel>
</asp:Panel>

</form>
<aspmap:ZoomBar runat=server Map="map" Position="TopLeft" ID="zoomBar" ButtonStyle="Flat"/>		
<script>

function printMap()
{
    var map = AspMap.getMap("<% =map.ClientID %>");
    map.printPageArea("printArea");
}
</script>

</body>
</html>
