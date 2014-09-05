<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeCursorStyle.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Change the Cursor Style</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png" Cursor="default">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ListBox1" />
        <asp:AsyncPostBackTrigger ControlID="ListBox2" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right">
Select one of the styles and then move your mouse over the map to see the new cursor style.<br />
    <strong>Map cursor:</strong><br />
    <asp:ListBox ID="ListBox1" runat="server" Height="127px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>default</asp:ListItem>
        <asp:ListItem>crosshair</asp:ListItem>
        <asp:ListItem>move</asp:ListItem>
        <asp:ListItem>help</asp:ListItem>
        <asp:ListItem>pointer</asp:ListItem>
        <asp:ListItem>handover</asp:ListItem>
    </asp:ListBox><br/>
    Pan the map to see the panning cursor style.<br />
    <strong>Panning cursor:</strong><br />
    <asp:ListBox ID="ListBox2" runat="server" Height="127px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>move</asp:ListItem>
        <asp:ListItem>pointer</asp:ListItem>
        <asp:ListItem>handdrag</asp:ListItem>
    </asp:ListBox></div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" style="top: 0px" />		

</form>
</body>
</html>
