<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingSelectedFeatures.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Only Selected Features</h4>

<div class="left">
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
</div>
<div  class="right">
Select one or more states from the list. Only the selected states will be displayed.<br />
    <br/>
<asp:ListBox ID="List1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List1_SelectedIndexChanged" Height="271px" Width="126px" SelectionMode="Multiple">
</asp:ListBox><br />

</div>

</form>
</body>
</html>
