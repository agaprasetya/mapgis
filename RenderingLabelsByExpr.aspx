<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingLabelsByExpr.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Labels by an Expression</h4>

<table border="0">
<tr><td>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="Ivory" ImageFormat="Gif" Enabled="false">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="List1" />
    </Triggers>
</asp:UpdatePanel>
</td>
<td  valign="top">
This sample renders labels by using an expression. The expression combines column names from attribute data associated with each feature.<br />
    <br />
Select an expression from the list.<br />
    <br/>
<asp:ListBox ID="List1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List1_SelectedIndexChanged" Height="271px" Width="319px">
    <asp:ListItem>NAME + " " + TYPE</asp:ListItem>
    <asp:ListItem>ZIPL + " " + NAME</asp:ListItem>
    <asp:ListItem>IIF(TYPE = "RD", "ROAD", "DRIVE")</asp:ListItem>
    <asp:ListItem>LCase(NAME)</asp:ListItem>
    <asp:ListItem>PCase(NAME)</asp:ListItem>
</asp:ListBox><br />
</td>
</tr>
</table>
</form>
</body>
</html>
