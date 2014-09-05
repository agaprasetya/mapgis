<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingAreas.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Areas</h4>

<table border="0">
<tr><td>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif" Enabled="False">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="fillStyle" />
        <asp:AsyncPostBackTrigger ControlID="lineSize" />
        <asp:AsyncPostBackTrigger ControlID="lineStyle" />
        <asp:AsyncPostBackTrigger ControlID="FontName" />
        <asp:AsyncPostBackTrigger ControlID="fontSize" />
        <asp:AsyncPostBackTrigger ControlID="fillColor" />
    </Triggers>
</asp:UpdatePanel>
</td>
<td valign="top">
This sample renders areas and their associated labels.
    <br /><br />
    Fill Style:<br />
    <asp:DropDownList ID="fillStyle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="fillStyle_SelectedIndexChanged">
        <asp:ListItem Selected="True">Solid</asp:ListItem>
        <asp:ListItem>Vertical</asp:ListItem>
        <asp:ListItem>Horizontal</asp:ListItem>
        <asp:ListItem>Bitmap</asp:ListItem>
        <asp:ListItem>UpwardDiagonal</asp:ListItem>
        <asp:ListItem>DownwardDiagonal</asp:ListItem>
        <asp:ListItem>DiagonalCross</asp:ListItem>
        <asp:ListItem>Cross</asp:ListItem>
        <asp:ListItem>DarkGray</asp:ListItem>
        <asp:ListItem>Gray</asp:ListItem>
        <asp:ListItem>LightGray</asp:ListItem>
        <asp:ListItem>Invisible</asp:ListItem>
    </asp:DropDownList><br />
    Fill Color:<br />
    <asp:DropDownList ID="fillColor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="fillColor_SelectedIndexChanged">
        <asp:ListItem Selected="True">Ivory</asp:ListItem>
        <asp:ListItem>LightBlue</asp:ListItem>
        <asp:ListItem>LightYellow</asp:ListItem>
        <asp:ListItem>Silver</asp:ListItem>
    </asp:DropDownList><br />    
    Outline Style:<br />
    <asp:DropDownList ID="lineStyle" runat="server" OnSelectedIndexChanged="lineStyle_SelectedIndexChanged" AutoPostBack="True">        
        <asp:ListItem Selected="True">Solid</asp:ListItem>
        <asp:ListItem>Dash</asp:ListItem>
        <asp:ListItem>Dot</asp:ListItem>
        <asp:ListItem>DashDot</asp:ListItem>                       
        <asp:ListItem>Invisible</asp:ListItem>
    </asp:DropDownList><br />    
    Outline Size:<br />
    <asp:DropDownList ID="lineSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lineSize_SelectedIndexChanged">
        <asp:ListItem Selected="True">1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList><br />
    Font Name:<br />
    <asp:DropDownList ID="FontName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FontName_SelectedIndexChanged">
        <asp:ListItem>Arial</asp:ListItem>
        <asp:ListItem Selected="True">Verdana</asp:ListItem>
        <asp:ListItem>Times New Roman</asp:ListItem>
        <asp:ListItem>Calibri</asp:ListItem>
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
