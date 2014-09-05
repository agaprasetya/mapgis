<%@ Page AutoEventWireup="true" language="c#" Inherits="ShapeEditorApp" CodeFile="ShapeEditorApp.aspx.cs" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<!DOCTYPE HTML>
<html>
<head>
<link rel="stylesheet" type="text/css" href="styles.css" />
	</head>	
	<body>
		<form id="Form1" method="post" runat="server">  <asp:ScriptManager ID="ScriptManager1" runat="server" />
<table border="0">	
<tr><td colspan="2">		
                            <aspmap:MapToolButton id="selectShape" runat="server" ToolTip="Select Shape" ImageUrl="tools/arrow.gif"
								Map="map" MapTool="Info" MapCursor="default" BorderWidth="1px"></aspmap:MapToolButton>
                            Click on the map to select a polygon in order to edit its vertices/attributes or remove it.<br />
						<aspmap:MapToolButton id="drawShapeTool" runat="server" ToolTip="DrawShape Tool" ImageUrl="tools/polygon.gif"
							Map="map" MapTool="DrawShape" BorderWidth="1px"></aspmap:MapToolButton>                        
                            Draw a new polygon. Click the 'Save' button to save the polygon. Click the 'Clear' button to remove any drawings.<br />
                        <aspmap:MapToolButton id="editShapeTool" runat="server" ToolTip="EditShape Tool" ImageUrl="tools/point.gif"
							Map="map" MapTool="EditShape" BorderWidth="1px" Argument="1"></aspmap:MapToolButton>                        
                            Edit the vertices of the current polygon. To remove a vertex, select it and click the 'Remove Vertex' button or Del / Backspace keys. Switch to the DrawShape tool to add new parts to the polygon. Click the 'Clear' button to remove any drawings.<br />
                            <aspmap:MapToolButton ID="panTool" runat="server" ImageUrl="tools/pan.gif" Map="map"
                                MapTool="Pan" ToolTip="Pan Tool" BorderWidth="1px" />
                            Pan/zoom the map.<br/>
</td></tr><tr><td  width="704px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
						<aspmap:map id="map" runat="server" Height="400px" Width="700px" BackColor="#F0F8FF"
							ImageFormat="Gif" MapTool="Info" FontQuality="ClearType" SmoothingMode="AntiAlias" OnEndEdit="map_EndEdit" OnInfoTool="map_InfoTool"></aspmap:map>
				       </ContentTemplate></asp:UpdatePanel>
</td><td valign="top" align="left">
<button onclick="removeVertex()" type="button">Remove Vertex</button> <button onclick="clearMap()" type="button">Clear</button><br/><br/>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
            <asp:Panel ID="shapePanel" runat="server" style="margin: 3px" Visible="True" BackColor="#FFFFC0" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <asp:Label ID="operation" runat="server" Text="Add shape:"></asp:Label><br/>
                	<asp:TextBox ID="shapeTitle" runat="server" style="font-style: italic" EnableViewState="False">Title</asp:TextBox><br/>
                <button onclick="endEdit()" type="button">Save</button>
                <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Text="Cancel" />
                <asp:Button ID="remove" runat="server" Text="Remove" Visible="False" OnClick="remove_Click" />        
            </asp:Panel></ContentTemplate></asp:UpdatePanel>
</td></tr></table>
		</form>

	<script>   
    function clearMap() {
        var map = AspMap.getMap('<%=map.ClientID%>');
        map.cancelEdit();
    }

    function removeVertex()
    {
        var map = AspMap.getMap('<%=map.ClientID%>');
        map.removeSelectedVertex();
    }

    function endEdit()
    {
        var map = AspMap.getMap('<%=map.ClientID%>');
        map.endEdit();
    }
    </script>
	</body>
</html>
