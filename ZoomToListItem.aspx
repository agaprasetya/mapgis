<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZoomToListItem.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Zoom to a Feature From a List</h4>
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
<p>Select a feature from the list.</p>
    <asp:ListBox ID="ListBox1" runat="server" Height="315px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Width="148px">
    </asp:ListBox>    
    </div>
</form>
</body>
</html>
