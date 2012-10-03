<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h2>Delete</h2>
    <%:ViewData["Message"]%><br />
      <% using (Html.BeginForm()) {%>
      
      <input type="submit" value="Delete" />
      <%: Html.ActionLink("Back to List", "Index") %>
      
      <% } %>
</asp:Content>