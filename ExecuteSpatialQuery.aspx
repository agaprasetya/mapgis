<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="ExecuteSpatialQuery.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Execute a Spatial Query</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif" Enabled="False">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDownList1" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right">
    Select a search method from the list.
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Inside</asp:ListItem>
        <asp:ListItem>Intersect</asp:ListItem>
    </asp:DropDownList><br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:ListBox ID="ListBox1" runat="server" Height="310px" Rows="10" Width="200px"></asp:ListBox>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</div>
</form>
</body>
</html>
