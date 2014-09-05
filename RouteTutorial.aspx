<%@ Page language="C#" AutoEventWireup="true" CodeFile="RouteTutorial.aspx.cs" Inherits="RouteTutorial" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<H4>Routing Tutorial</H4>
			<P>
				<aspmap:Map id="Map1" runat="server" Width="600px" Height="500px"></aspmap:Map></P>
			<P>
				<asp:Table id="Table1" runat="server" Caption="Driving Directions" BorderStyle="Solid" BorderWidth="1px"
					BorderColor="Silver" CellPadding="4" CellSpacing="3" GridLines="Both"></asp:Table></P>
		</form>
	</body>
</HTML>
