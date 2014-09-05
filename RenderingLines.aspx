<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingLines.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Lines</h4>

<table border="0">
<tr><td>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="Ivory" ImageFormat="Gif" Enabled="False" MapUnit="Meter">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lineStyle" />
        <asp:AsyncPostBackTrigger ControlID="lineSize" />
        <asp:AsyncPostBackTrigger ControlID="FontName" />
        <asp:AsyncPostBackTrigger ControlID="fontSize" />
    </Triggers>
</asp:UpdatePanel>
</td>
<td valign="top">
This sample renders lines and their associated labels.
    <br /><br />
    Line Style:<br />
    <asp:DropDownList ID="lineStyle" runat="server" OnSelectedIndexChanged="lineStyle_SelectedIndexChanged" AutoPostBack="True">        
        <asp:ListItem Selected="True">Road</asp:ListItem>
        <asp:ListItem>DualRoad</asp:ListItem>
        <asp:ListItem>DotRoad</asp:ListItem>
        <asp:ListItem>DashDotRoad</asp:ListItem>        
        <asp:ListItem>Solid</asp:ListItem>
        <asp:ListItem>Dash</asp:ListItem>
        <asp:ListItem>Dot</asp:ListItem>
        <asp:ListItem>DashDot</asp:ListItem>                       
        <asp:ListItem>Invisible</asp:ListItem>
    </asp:DropDownList><br />
    Line Size:<br />
    <asp:DropDownList ID="lineSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lineSize_SelectedIndexChanged">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem Selected="True">14</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
    </asp:DropDownList><br />
    Font Name:<br />
    <asp:DropDownList ID="FontName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FontName_SelectedIndexChanged">
        <asp:ListItem>Arial</asp:ListItem>
        <asp:ListItem>Verdana</asp:ListItem>
        <asp:ListItem>Times New Roman</asp:ListItem>
        <asp:ListItem  Selected="True">Calibri</asp:ListItem>
    </asp:DropDownList><br />
    Font Size:<br />
    <asp:DropDownList ID="fontSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="fontSize_SelectedIndexChanged">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem Selected="True">16</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
    </asp:DropDownList><br />
</td>
</tr>
</table>
</form>
</body>
</html>
