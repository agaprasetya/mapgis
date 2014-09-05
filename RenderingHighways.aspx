<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingHighways.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Highway Labels</h4>

<table border="0">
<tr><td>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="Ivory" ImageFormat="Gif" EnableSession="True">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</td>
<td valign="top">
This sample renders highway labels.
<br />
</td>
</tr>
</table>
</form>
</body>
</html>
