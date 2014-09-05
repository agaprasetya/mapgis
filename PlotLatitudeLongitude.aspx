<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlotLatitudeLongitude.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">    
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Plot a Point Using Latitude/Longitude</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Png">
</aspmap:map>
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div  class="right">
Click the button to plot a point at the coordinates in the text boxes.<br />
    <br />
    Latitude: &nbsp;<asp:TextBox ID="latitude" runat="server" Width="108px">2.35099</asp:TextBox><br />
    Longitude:
    <asp:TextBox ID="longitude" runat="server" Width="106px">48.85676</asp:TextBox><br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Plot a Point" /></div>
<aspmap:ZoomBar runat=server Map="map" ID="zoomBar" Position="TopLeft" />		

</form>
</body>
</html>
