<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMultipleMarkers.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
    <title>Add a Marker</title>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Add Multiple Markers</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="button1" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right">
Click the button to add all capitals within the 300 miles distance from Paris.<br /><br />
    <asp:Button ID="button1" runat="server" OnClick="button1_Click" Text="Add Markers" /><br/>
</div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		

</form>
</body>
</html>
