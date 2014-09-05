<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StreetMap.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Street Map</title>
    <style>
    /* these CSS styles expand the map to the full page */
    html, body { 	margin: 0px; 	padding: 0px; height: 100%;	 overflow:hidden; }    
    #UpdatePanel1 {    position:absolute; min-height: 100%; width: 100%; height: 100%;	 }
    </style>
</head>
<body>    
    <form id="form1" runat="server">    
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" AsyncPostBackTimeout="3600"/>    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>    
    <aspmap:map id="map" runat="server" Width="100%"  Height="100%" MapTool="Pan"	
       BackColor="#99B3CC" ImageFormat="Png" OnZoomFullExecuted="map_ZoomFullExecuted">
    </aspmap:map>
    </ContentTemplate>
    </asp:UpdatePanel>        
    </form>
<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position="TopRight" ButtonStyle="Flat"/>    
</body>
</html>
