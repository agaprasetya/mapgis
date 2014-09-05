<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewcode.aspx.cs" Inherits="viewcode" %>
<!DOCTYPE HTML>
<html>
<head>
<script type="text/javascript" src="js/sh_csharp.min.js"></script>
<script type="text/javascript" src="js/sh_html.min.js"></script>
<script type="text/javascript" src="js/sh_javascript.min.js"></script>
<script type="text/javascript" src="js/sh_main.min.js"></script>
<link type="text/css" rel="stylesheet" href="js/sh_style.min.css">
<style>body { font-family: "Arial"; font-size: 11pt; }</style>
</head>
<body onload="sh_highlightDocument();">
<p><b><%=file%></b></p>
<code>
<pre class="<%=lang%>">
<%=code%>
</pre>
</code>
<code>
<pre class="<%=lang%>">
<%=wms%>
</pre>
</code>
</body>
</html>
