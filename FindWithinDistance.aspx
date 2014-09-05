<%@ Page language="c#" AutoEventWireup="true" Inherits="SearchByDistance" CodeFile="FindWithinDistance.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
	<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">   <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<H3>Find Features Within a Distance</H3>
				<TABLE id="Table1" cellSpacing="4" cellPadding="1" border="0" frame="void">
					<TR>
					<TD valign=middle colspan=2>
                        Town:
                        <asp:DropDownList ID="townsList" runat="server">
                        </asp:DropDownList>&nbsp; Distance:
                        <asp:DropDownList ID="distanceList" runat="server">
                            <asp:ListItem Value="5">5 miles</asp:ListItem>
                            <asp:ListItem Value="10">10 miles</asp:ListItem>
                            <asp:ListItem Value="20">20 miles</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="searchButton" runat="server" Text="Find" OnClick="searchButton_Click" />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline"><ContentTemplate><asp:Label ID="errorMsg" runat="server" ForeColor="Red"></asp:Label></ContentTemplate></asp:UpdatePanel></TD>
					</TR>				
					<TR>
						<TD valign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
							<aspmap:Map id="map" runat="server" Width="696px" BackColor="#E6E6FA" ImageFormat="Gif" SmoothingMode="AntiAlias"
								FontQuality="ClearType" Cursor="" Height="524px" MapTool="Pan"></aspmap:Map>
                            </ContentTemplate></asp:UpdatePanel></TD>                            
                            <TD valign="top">Click the 'Find' button to find features within the specified distance. The features
                                will be sorted by the distance from the town.<br />
                                <br />
                                Features:<br />
                                <asp:ListBox ID="ListBox1" runat="server" Height="236px" Rows="10"></asp:ListBox></TD>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></ContentTemplate></asp:UpdatePanel>
					</TR>
				</TABLE>
		
		</form>

        <aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position="TopLeft" />

	</body>
</HTML>
