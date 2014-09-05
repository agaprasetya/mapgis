<%@ Page Language="C#" AutoEventWireup="true" CodeFile="navbar.aspx.cs" Inherits="Navigation" %>
<!DOCTYPE HTML>
<html>
<head>
    <style>TD, body { font-family: "Arial"; font-size: 10pt; }
    .hdr { font-family: "Arial"; font-size: 12pt; font-weight:bold; }
    .bottomline { width:100%; border-bottom: solid 1px #E5E7E7;}
a {
    text-decoration: none;
}
a:link, a:visited {
    color: blue;
}
a:hover {
    color: red;
}
     </style>
</head>
<body style="background-color:#F0F8FF">
    <p class="hdr">AspMap Samples</p>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" NodeIndent="4" ExpandDepth="0" Font-Bold="False" NodeWrap="True">
            <Nodes>
                <asp:TreeNode Text="Getting Started" Value="Getting Started">
                    <asp:TreeNode NavigateUrl="SimpleMap.aspx" Target="c" Text="Simple Map"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="StreetMap.aspx" Target="c" Text="Street Map"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddMarker.aspx" Target="c" Text="Add a Marker" Value="Add a Marker"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="AddCallout.aspx" Target="c" Text="Add a Callout" Value="Add a Callout"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddClickEvent.aspx" Target="c" Text="Add a Click Event" Value="Add a Click Event"></asp:TreeNode>                                        
                    <asp:TreeNode NavigateUrl="ChangeCursorStyle.aspx" Target="c" Text="Change the Cursor Style" Value="Change the Cursor Style"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="FindFeature.aspx" Target="c" Text="Find the Feature the User Clicked" Value="Find the Feature the User Clicked"></asp:TreeNode>                                                            
                    <asp:TreeNode NavigateUrl="PlotLatitudeLongitude.aspx" Target="c" Text="Plot a Point Using Latitude/Longitude" Value="Plot a Point Using Latitude/Longitude"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="ParcelMapApp.aspx" Target="c" Text="Parcel Map" Value="Parcel Map"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="OverviewMapApp.aspx" Target="c" Text="Overview Map" Value="Overview Map"></asp:TreeNode>                    
                </asp:TreeNode>
                <asp:TreeNode Text="Controls" Value="Controls">
                    <asp:TreeNode NavigateUrl="MapControl.aspx" Target="c" Text="Map Control" Value="Map Control"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="MapToolButtonControl.aspx" Target="c" Text="MapToolButton Control" Value="MapToolButton Control"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomBarControl.aspx" Target="c" Text="ZoomBar Control" Value="ZoomBar Control"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="CustomZoomBar.aspx" Target="c" Text="Customizing a ZoomBar Control" Value="Customizing a ZoomBar Control"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ScaleBar.aspx" Target="c" Text="Scale Bar" Value="Scale Bar"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="LegendControl.aspx" Target="c" Text="Legend Control" Value="Legend Control"></asp:TreeNode>                    
                </asp:TreeNode>                                                                                                                                    
                <asp:TreeNode Text="Moving Around the Map" Value="Moving Around the Map">
                    <asp:TreeNode NavigateUrl="ZoomInOut.aspx" Target="c" Text="Zoom In and Out" Value="Zoom In and Out"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomRectangle.aspx" Target="c" Text="Track Zoom in a Map" Value="Track Zoom in a Map"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="PanMap.aspx" Target="c" Text="Pan the Map" Value="Pan the Map"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="ZoomToScale.aspx" Target="c" Text="Zoom to a Scale" Value="Zoom to a Scale"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomToFeature.aspx" Target="c" Text="Zoom to a Feature You Clicked" Value="Zoom to a Feature You Clicked"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomToListItem.aspx" Target="c" Text="Zoom to a Feature From a List" Value="Zoom to a Feature From a List"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="PlotLatitudeLongitude.aspx" Target="c" Text="Zoom to a Latitude/Longitude" Value="Zoom to a Latitude/Longitude"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomToZoomLevel.aspx" Target="c" Text="Zoom to a Zoom Level" Value="Zoom to a Zoom Level"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomBarControl.aspx" Target="c" Text="Using the ZoomBar Control" Value="Using the ZoomBar Control"></asp:TreeNode>                    
                </asp:TreeNode>
                <asp:TreeNode Text="Layers" Value="Layers">
                    <asp:TreeNode NavigateUrl="SimpleMap.aspx" Target="c" Text="Add a Shapefile" Value="Add a Shapefile"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="AddSpatialDatabaseLayer.aspx" Target="c" Text="Add a Spatial Database" Value="Add a Spatial Database"></asp:TreeNode>                                        
                    <asp:TreeNode NavigateUrl="TileMap.aspx" Target="c" Text="Add a Tile Layer" Value="Add a Tile Layer"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="AddLatLongPoints.aspx" Target="c" Text="Add Lat/Long points" Value="Add Lat/Long points"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddMultipleLayers.aspx" Target="c" Text="Add Multiple Layers" Value="Add Multiple Layers"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddRasterImageLayer.aspx" Target="c" Text="Add a Raster Image"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="AddSatelliteLayer.aspx" Target="c" Text="Add a Satellite Image"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="AddAnimationLayer.aspx" Target="c" Text="Display the AnimationLayer"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="WmsLayerApp.aspx" Target="c" Text="Add a Web Map Service As a Layer" Value="Add a Web Map Service As a Layer"></asp:TreeNode>                                                            
                    <asp:TreeNode NavigateUrl="BingMapsApp.aspx" Target="c" Text="Bing Maps" Value="Bing Maps"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="GoogleMapsApp.aspx" Target="c" Text="Google Maps" Value="Google Maps"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="VirtualEarthApp.aspx" Target="c" Text="Virtual Earth" Value="Virtual Earth"></asp:TreeNode>                                                            
                    <asp:TreeNode NavigateUrl="OpenStreetMapApp.aspx" Target="c" Text="Open Street Map" Value="Open Street Map"></asp:TreeNode>
                </asp:TreeNode>                                
                <asp:TreeNode Text="Querying Layers" Value="Querying Layers">
                    <asp:TreeNode NavigateUrl="ExecuteQuery.aspx" Target="c" Text="Execute a Query" Value="Execute a Query"></asp:TreeNode>                                                       
                    <asp:TreeNode NavigateUrl="ExecuteSpatialQuery.aspx" Target="c" Text="Execute a Spatial Query" Value="Execute a Spatial Query"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="FindFeature.aspx" Target="c" Text="Find the Feature the User Clicked" Value="Find the Feature the User Clicked"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="IdentifyFeature.aspx" Target="c" Text="Identify a Feature" Value="Identify a Feature"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="FindWithinCircle.aspx" Target="c" Text="Find Features Within a Circle" Value="Find Features Within a Circle"></asp:TreeNode>                                   
                    <asp:TreeNode NavigateUrl="FindWithinPolygon.aspx" Target="c" Text="Find Features Within a Polygon" Value="Find Features Within a Polygon"></asp:TreeNode>                                                       
                    <asp:TreeNode NavigateUrl="FindWithinBuffer.aspx" Target="c" Text="Find Features Within a Buffer" Value="Find Features Within a Buffer"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="FindWithinDistance.aspx" Target="c" Text="Find Features Within a Distance" Value="Find Features Within a Distance"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="FindByID.aspx" Target="c" Text="Find a Feature by ID" Value="Find a Feature by ID"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="FilterWithinShape.aspx" Target="c" Text="Filter Features Within a Shape"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="FilterByExpression.aspx" Target="c" Text="Filter Features by an Expression"></asp:TreeNode>                    
                </asp:TreeNode>                              
                <asp:TreeNode Text="Markers" Value="Markers">
                    <asp:TreeNode NavigateUrl="AddMarker.aspx" Target="c" Text="Add a Marker" Value="Add a Marker"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddMarkerHTML.aspx" Target="c" Text="Add a Marker With HTML Content" Value="Add a Marker With HTML Content"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddMarkerImage.aspx" Target="c" Text="Add a Marker With a Custom Image" Value="Add a Marker With a Custom Image"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddMultipleMarkers.aspx" Target="c" Text="Add Multiple Markers" Value="Add Multiple Markers"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddClickEvent.aspx" Target="c" Text="Add a Marker By Clicking on the Map" Value="Add a Marker By Clicking on the Map"></asp:TreeNode>                                        
                    <asp:TreeNode NavigateUrl="AddClickableMarkers.aspx" Target="c" Text="Add Clickable Markers (client-side)" Value="Add Clickable Markers (client-side)"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="AddServerClickableMarkers.aspx" Target="c" Text="Add Clickable Markers (server-side)" Value="Add Clickable Markers (server-side)"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="MarkerClusters.aspx" Target="c" Text="Marker Clusters" ></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Map Tools" Value="Map Tools">
                    <asp:TreeNode NavigateUrl="MapToolsApp.aspx" Target="c" Text="Map Tools" Value="Map Tools"></asp:TreeNode>
                </asp:TreeNode>                
                <asp:TreeNode Text="Editing Features" Value="Adding and Editing Features">
                    <asp:TreeNode NavigateUrl="LocationEditorApp.aspx" Target="c" Text="Location Editor" Value="Location Editor"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ShapeEditorApp.aspx" Target="c" Text="Shape Editor" Value="Shape Editor"></asp:TreeNode>
                </asp:TreeNode>                
                <asp:TreeNode Text="Rendering Features" Value="Rendering Features">
                    <asp:TreeNode NavigateUrl="RenderingPoints.aspx" Target="c" Text="Rendering Points" Value="Rendering Points"></asp:TreeNode>                
                    <asp:TreeNode NavigateUrl="RenderingLines.aspx" Target="c" Text="Rendering Lines" Value="Rendering Lines"></asp:TreeNode>                
                    <asp:TreeNode NavigateUrl="RenderingAreas.aspx" Target="c" Text="Rendering Areas" Value="Rendering Areas"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="RenderingHighways.aspx" Target="c" Text="Rendering Highways" Value="Rendering Highways"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="RenderingByValues.aspx" Target="c" Text="Rendering Features by a Value" Value="Rendering Features by a Value"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="RenderingByExpr.aspx" Target="c" Text="Rendering Features by an Expression" Value="Rendering Features by an Expression"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="RenderingSelectedFeatures.aspx" Target="c" Text="Rendering Only Selected Features" Value="Rendering Only Selected Features"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="RenderingByIDs.aspx" Target="c" Text="Rendering Features by IDs" Value="Rendering Features by IDs"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="RenderingByZoomLevels.aspx" Target="c" Text="Rendering Features by Zoom Levels" Value="Rendering Features by Zoom Levels"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="MapSession.aspx" Target="c" Text="Rendering Features by Values and Zoom Levels " Value="Rendering Features by Values and Zoom Levels "></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="RenderingLabelsByExpr.aspx" Target="c" Text="Rendering Labels by an Expression" Value="Rendering Labels by an Expression"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomToZoomLevel.aspx" Target="c" Text="Rendering Layers by Zoom Levels" Value="Rendering Layers by Zoom Levels (scales)"></asp:TreeNode>
                </asp:TreeNode>                
                <asp:TreeNode Text="Map Caching" Value="Map Caching">
                    <asp:TreeNode NavigateUrl="MapCaching.aspx" Target="c" Text="Map Caching by Using Tile Images"></asp:TreeNode>                
                    <asp:TreeNode NavigateUrl="TileMap.aspx" Target="c" Text="Display a Tile Map" Value="Display a Tile Map"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="StreetMap.aspx" Target="c" Text="Street Map"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="GeneratingStaticTiles.aspx" Target="c" Text="Generating Static Tiles"></asp:TreeNode>
                </asp:TreeNode>                                                
                <asp:TreeNode Text="Shapes" Value="Shapes">
                    <asp:TreeNode NavigateUrl="CreatePoint.aspx" Target="c" Text="Create a Point" Value="Create a Point"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="CreateLine.aspx" Target="c" Text="Create a Line" Value="Create a Line"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="CreatePolygon.aspx" Target="c" Text="Create a Polygon" Value="Create a Polygon"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="CreateCircle.aspx" Target="c" Text="Create a Circle"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ZoomToFeature.aspx" Target="c" Text="Zoom to a Shape You Clicked" Value="Zoom to a Shape You Clicked"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="DistanceBetweenPoints.aspx" Target="c" Text="Distance Between Two Points" Value="Distance Between Two Points"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="UnionTwoShapes.aspx" Target="c" Text="Union Two Shapes" Value="Union Two Shapes"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="BufferShape.aspx" Target="c" Text="Buffer a Shape" Value="Buffer a Shape"></asp:TreeNode>                                        
                </asp:TreeNode>                                                    
                <asp:TreeNode Text="Tooltips &amp; Information Windows">
                    <asp:TreeNode NavigateUrl="FindFeature.aspx" Target="c" Text="Display an InfoWindow on Click" Value="Display an InfoWindow on Click"></asp:TreeNode>                                                            
                    <asp:TreeNode NavigateUrl="AddTooltips.aspx" Target="c" Text="Add Tooltips to Points" Value="Airports"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="InfoWindowForPoints.aspx" Target="c" Text="Display an InfoWindow for Points" Value="Airports"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ShowInfoWindow.aspx" Target="c" Text="Show an InfoWindow" Value="Airports"></asp:TreeNode>
                </asp:TreeNode>                                
                <asp:TreeNode Text="Coorinate Systems">
                    <asp:TreeNode NavigateUrl="AddLayersWithDfferentProjections.aspx" Target="c" Text="Add Layers With Different Projections" Value="Add Layers With Different Projections"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="TransformCoordinates.aspx" Target="c" Text="Transform Coordinates Between Different Projections" Value="Transform Coordinates Between Different Projections"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="ProjectedMapApp.aspx" Target="c" Text="Using a Different Projection for a Layer" Value="Using a Different Projection for a Layer"></asp:TreeNode>                    
                </asp:TreeNode>
                <asp:TreeNode Text="Routing" Value="Routing">
                    <asp:TreeNode NavigateUrl="RouteApp.aspx" Target="c" Text="Finding a Route" Value="Finding a Route"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Thematic Mapping" Value="Thematic Mapping">
                    <asp:TreeNode NavigateUrl="ChartMapApp.aspx" Target="c" Text="Chart Map" Value="Chart Map"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="DemographicMapApp.aspx" Target="c" Text="Demographic Map" Value="Demographic Map"></asp:TreeNode>                    
                    <asp:TreeNode NavigateUrl="PopulationApp.aspx" Target="c" Text="Population by Cites" Value="Population by Cites"></asp:TreeNode>
                </asp:TreeNode>                                    
                <asp:TreeNode Text="Vehicle Tracking" Value="Vehicle Tracking">
                    <asp:TreeNode NavigateUrl="VehicleTracking.aspx" Target="c" Text="Vehicle Tracking" Value="Vehicle Tracking"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="VehicleTrackingWithMatching.aspx" Target="c" Text="Vehicle Tracking With Map-Matching" Value="Vehicle Tracking With Map-Matching"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="VehicleDirectionStatic.aspx" Target="c" Text="Vehicle Direction (static image)" Value="Vehicle Direction (static image)"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="VehicleDirectionDynamic.aspx" Target="c" Text="Vehicle Direction (dynamic image)" Value="Vehicle Direction (dynamic image)"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="VehicleTrackingWithCaching.aspx" Target="c" Text="Vehicle Tracking With Map Caching" Value="Vehicle Tracking With Map Caching"></asp:TreeNode>
                </asp:TreeNode>                                                    
                <asp:TreeNode Text="Printing">
                    <asp:TreeNode NavigateUrl="PrintMap.aspx" Target="c" Text="Print a Map" Value="Print a Map"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="PrintPageArea.aspx" Target="c" Text="Print a Page Area"></asp:TreeNode>
                </asp:TreeNode>                                                                                    
                <asp:TreeNode Text="JavaScript API">
                    <asp:TreeNode NavigateUrl="ClientApiApp.aspx" Target="c" Text="Client API Demo" Value="Client API Demo"></asp:TreeNode>                                                                                                                        
                </asp:TreeNode>                                                                    
                <asp:TreeNode Text="Performance Tips" Value="Performance Tips">
                    <asp:TreeNode NavigateUrl="ZoomToZoomLevel.aspx" Target="c" Text="Rendering Layers by Zoom Levels" Value="Rendering Layers by Zoom Levels"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="MapCaching.aspx" Target="c" Text="Map Caching Using Tile Images" Value="Map Caching Using Tile Images"></asp:TreeNode>                
                    <asp:TreeNode NavigateUrl="MapSession.aspx" Target="c" Text="Using Map Sessions" Value="Using Map Sessions"></asp:TreeNode>
                </asp:TreeNode>                                
                <asp:TreeNode Text="Web Map Service" Value="Web Map Service">
                    <asp:TreeNode NavigateUrl="WmsServiceApp.aspx" Target="c" Text="Creating a WMS service" Value="Creating a WMS service"></asp:TreeNode>
                </asp:TreeNode>                                                    
            </Nodes>
            <ParentNodeStyle Font-Bold="False" />
            <RootNodeStyle Font-Bold="True" />
            <LeafNodeStyle CssClass="bottomline" />
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
