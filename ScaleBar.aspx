<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScaleBar.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>
    ScaleBar Class</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png" Cursor="default">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ListBox1" />
    </Triggers>
</asp:UpdatePanel>
</div>
<div  class="right">
<p>The ScaleBar class indicates the distance units on a map.</p>
Select the distance units:<br/>
    <asp:ListBox ID="ListBox1" runat="server" Height="127px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True">
        <asp:ListItem>Imperial</asp:ListItem>
        <asp:ListItem>Metric</asp:ListItem>
    </asp:ListBox>    
</div>    
</form>
</body>
</html>
