<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication3.Models.Blog>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
 
 <h2>Blogs</h2>
 <h3><%: Html.ActionLink("Create a new Blog", "Create") %></h3>
 
    <% foreach (var blog in Model) { %>
    <fieldset>
    <legend>Blog <%:blog.BlogID.ToString() %> #<%: Html.ActionLink("Details", "Details", new { id=blog.BlogID })%></legend>
        <h4>Created on <%: String.Format("{0:g}", blog.RecCreationTime) %> ||
        User: <%: blog.UserName %> ||
        Mood: <%: blog.Mood %></h4>
          
                <%: blog.BlogText %> <br /><br />
                   
                        
                            <%: Html.ActionLink("Edit", "Edit", new { id=blog.BlogID }) %> |
                            
                            <%: Html.ActionLink("Delete", "Delete", new { id=blog.BlogID })%>
                      
    </fieldset>
    <% } %>
 
</asp:Content>