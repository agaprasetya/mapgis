<%@ Page AutoEventWireup="true" language="c#" Inherits="LocationEditorApp" CodeFile="LocationEditorApp.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
		<title>Location Editor</title>
<link rel="stylesheet" type="text/css" href="styles.css">
	</HEAD>	
	<body>
		<form id="Form1" method="post" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server" />
			<TABLE id="Table1" style="WIDTH: 850" cellSpacing="6" cellPadding="1"
				border="0">
				<TR>
					<TD align="left" colspan="2">
                        <ul>
                            <li>Click anywhere on the map to add a location. Click the 'Save' button to save it into the database.</li>
                            <li>Select a location to move its vertex position, edit its attributes or remove it. 
                                Click the 'Save' button to save it into the database.</li>
                            <li>Click the 'Cancel' button to return to the add/select mode. </li>
                        </ul>
                        </TD>
				</TR>
				<TR>
					<TD><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:map id="map" runat="server" Height="500px" Width="750px" BackColor="#F0F8FF"
							ImageFormat="Gif" MapTool=Info OnInfoTool="map_InfoTool" OnEndEdit="map_EndEdit" FontQuality="ClearType" SmoothingMode="AntiAlias"></aspmap:map>
				
				</ContentTemplate></asp:UpdatePanel></TD>
				<td valign=top>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><p>
            <asp:Panel ID="locationPanel" runat="server" style="margin: 3px" Visible="False" BackColor="#FFFFC0" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <asp:Label ID="operation" runat="server" Text="Add location:"></asp:Label><br/>
                <asp:TextBox ID="locationTitle" runat="server" style="font-style: italic" EnableViewState="False">Title</asp:TextBox><br/>
                <button onclick="endEdit()" type="button">Save</button>
                <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Text="cancel" />
                <asp:Button ID="remove" runat="server" Text="remove" Visible="False" OnClick="remove_Click" /><br/>            
            </asp:Panel>
                            &nbsp;</p></ContentTemplate></asp:UpdatePanel>
            
				</td>
				</TR>
			</TABLE>
			<aspmap:ZoomBar ID="zoomBar" runat="server" Map="map" Position=TopLeft/>
            &nbsp;
		</form>
	<script>
	    function endEdit()
	    {
	        var map = AspMap.getMap('<%=map.ClientID%>');
	        map.endEdit();
	    }
    </script>

	</body>
</HTML>
