<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="RenderingByValues.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Rendering Features by a Value</h4>

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
This sample renders features by values by using attribute data associated with each feature.<br />
    <br />

Select one or more states from the list. The states will be highlighted by their names.<br />
    <br/>
<asp:ListBox ID="List1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="List1_SelectedIndexChanged" Height="271px" Width="126px" SelectionMode="Multiple">
</asp:ListBox><br />

</div>

</form>
</body>
</html>
