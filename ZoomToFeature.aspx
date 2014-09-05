<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZoomToFeature.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h4>Zoom to a Feature You Clicked</h4>
<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png" OnInfoTool="map_InfoTool">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right">
Click on a country to zoom into it. 
</div>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Full Extent" />
	

</form>
</body>
</html>
