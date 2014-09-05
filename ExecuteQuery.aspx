<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="_Default" CodeFile="ExecuteQuery.aspx.cs" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
<form id="Form1" method="post" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<h4>Execute a Query</h4>

<div class="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<aspmap:map id="map" runat="server" SmoothingMode="AntiAlias" FontQuality="ClearType" 
    Width="700px"  Height="500px" MapTool="Pan"	BackColor="#99B3CC" ImageFormat="Gif">
</aspmap:map>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" />
    </Triggers>
</asp:UpdatePanel>
</div>

<div  class="right"><asp:Label ID="Label1" runat="server" BackColor="White" BorderStyle="Inset"
        BorderWidth="1px" Height="83px" Text="POPULATION > 50000000" Width="172px"></asp:Label><br/>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Execute" />
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:ListBox ID="ListBox1" runat="server" Height="280px" Rows="10" Width="152px"></asp:ListBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</form>
</body>
</html>
