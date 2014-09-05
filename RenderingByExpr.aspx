<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingByExpr.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Features by an Expression</h4>

<table border="0">
<tr><td>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif" Enabled="false">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="List1" />
    </Triggers>
</asp:UpdatePanel>
</td>
<td  valign="top">
This sample renders features by expressions by using attribute data associated with each feature.<br />
    <br />

Select an expression in the list. Features that meet the expression will be highlighted.<br />
    <br/>
<asp:ListBox ID="List1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List1_SelectedIndexChanged" Height="271px" Width="319px">
    <asp:ListItem>STATE_NAME = &quot;Texas&quot;</asp:ListItem>
    <asp:ListItem>SUB_REGION = &quot;Pacific&quot;</asp:ListItem>
    <asp:ListItem>POPULATION &gt; 3000000</asp:ListItem>
    <asp:ListItem>STATE_ABBR=&quot;CA&quot; OR STATE_ABBR=&quot;OR&quot;</asp:ListItem>
    <asp:ListItem>LIKE(STATE_NAME, &quot;North*&quot;)</asp:ListItem>
</asp:ListBox><br />
</td>
</tr>
</table>
</form>
</body>
</html>
