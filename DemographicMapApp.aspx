<%@ Page AutoEventWireup="true" language="c#" Inherits="DemographicMapApp" CodeFile="DemographicMapApp.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">   <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" cellSpacing="4" cellPadding="2" width="566" align="center" border="0"
				style="WIDTH: 566px; HEIGHT: 407px">
				<TR>
					<TD align="left" style="WIDTH: 545px">&nbsp;
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><STRONG>Demographic Map</STRONG></TD>
								<TD align="right"><FONT face="Arial"><FONT size="2">Thematic</FONT> <FONT size="2">Field</FONT>:</FONT>
									<asp:DropDownList id="thematicFields" runat="server" AutoPostBack="True"></asp:DropDownList>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD align="left"></TD>
				</TR>
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:Map id="map" runat="server" Width="700px" BackColor="#F0F8FF" SmoothingMode="AntiAlias"
							FontQuality="ClearType" ImageFormat="Gif" 
							Height="500px"></aspmap:Map>
					</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="thematicFields" />
                        </Triggers>
                    </asp:UpdatePanel></TD>
					<TD><p>Displays demographic data stored in a database.</p>
					<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
						<aspmap:Legend id="legend" runat="server"></aspmap:Legend>
					</ContentTemplate></asp:UpdatePanel></TD>
				</TR>
			</TABLE>
		
		</form>
	</body>
</HTML>
