<%@ Page language="c#" src="broswer.aspx.cs" Inherits="fileBrowser" Trace="false" %>


<html>
<head>
<title>Source Browser V 4.0</title>
<link rel="stylesheet" type="text/css" href="browser.css">
</head>


<div class="navigation">
&nbsp;<a class="nav_links" href="http://brookfield.rice.iit.edu/jmeyers">ITM564</a>
Source Browser 4.0
</div>

<form runat="server">
<table border=0 width="100%">
<tr>
<td valign="top" width = "200">
<asp:label id="Top" runat="server" />
<div id="folders" runat="server">Folders
<hr />
<asp:label id="lblDirectories" runat="server" /></div>
</td>
<td valign="top">
<div id="Files" runat="server">Files
<br />
<asp:label id="lblFiles" runat="server" /></div>
</td>
</tr>
</table>
</form>
<asp:label id="msg" runat="server" />
<hr>
<div align="center">
A simple source code browser. Need to be marked as a virtual directory in iis. Uses <a href="http://qbnz.com/highlighter/">GeSHi</a> for source code colorization.
<a href="mailto://jeff@iam.colum.edu">jeff@iam.colum.edu</a>
</div>
