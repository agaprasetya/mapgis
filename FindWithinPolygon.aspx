<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="FindWithinPolygon.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Find Features Within a Polygon</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif" OnPolygonTool="map_PolygonTool">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right">
    Draw a polygon to select features within it (double-click to finish the polygon).
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:ListBox ID="ListBox1" runat="server" Height="210px" Rows="10" Width="130px"></asp:ListBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

</form>
</body>
</html>
