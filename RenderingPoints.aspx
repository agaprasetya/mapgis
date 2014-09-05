<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingPoints.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Points</h4>

<table border="0">
<tr><td>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif" Enabled="False">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="pointStyle" />
        <asp:AsyncPostBackTrigger ControlID="pointSize" />
        <asp:AsyncPostBackTrigger ControlID="FontName" />
        <asp:AsyncPostBackTrigger ControlID="fontSize" />
    </Triggers>
</asp:UpdatePanel>
</td>
<td valign="top">
This sample renders points and their associated labels.
    <br /><br />
    Point Style:<br />
    <asp:DropDownList ID="pointStyle" runat="server" OnSelectedIndexChanged="pointStyle_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>SquareWithLargeCenter</asp:ListItem>
        <asp:ListItem>SquareWithSmallCenter</asp:ListItem>
        <asp:ListItem Selected="True">CircleWithLargeCenter</asp:ListItem>
        <asp:ListItem>CircleWithSmallCenter</asp:ListItem>
        <asp:ListItem>Custom Bitmap</asp:ListItem>
        <asp:ListItem>Custom Font</asp:ListItem>
        <asp:ListItem>Circle</asp:ListItem>
        <asp:ListItem>Arrow</asp:ListItem>
        <asp:ListItem>Square</asp:ListItem>
        <asp:ListItem>Port</asp:ListItem>
        <asp:ListItem>Museum</asp:ListItem>
        <asp:ListItem>University</asp:ListItem>
        <asp:ListItem>Book</asp:ListItem>
        <asp:ListItem>Sailing</asp:ListItem>
        <asp:ListItem>Battlefield</asp:ListItem>
        <asp:ListItem>Photo</asp:ListItem>
    </asp:DropDownList><br />
    Point Size:<br />
    <asp:DropDownList ID="pointSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="pointSize_SelectedIndexChanged">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem Selected="True">16</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
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
