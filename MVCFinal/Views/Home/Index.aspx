<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication3.Models.Blog>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<p>

  <label for="UserName">Filter by User:</label>

 <%= Html.DropDownList("UserName", (IEnumerable<SelectListItem>)ViewData["UserName"], "All Users")%>


  <%= Html.ValidationMessage("UserName") %>

</p>

    <h2><%: ViewData["Message"] %></h2>
 
 <h2>Blogs</h2>

<%: Html.ActionLink("Better Manage Roles", "Index", "Roles")%>
<%: Html.ActionLink("Better Manage Users", "Index", "Users")%>
    <p>
 <h3><%: Html.ActionLink("Create a new Blog", "Create")%></h3>

    </p>
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
               <%using (Html.BeginForm("AddResponse","Home"))
             {%>
                <fieldset>
                <% MvcApplication3.Models.BlogResponse newresponse = new MvcApplication3.Models.BlogResponse(); %>
                Response:   <%= Html.TextBox("response") %>
                <%= Html.Hidden("blogid",blog.BlogID) %>
                <input type="submit" value="Add Response"/>
                </fieldset>
             <%} %>
 
               
    <% foreach (var response in blog.BlogResponses) { %>
        Response <%:response.BlogResponseID.ToString() %>
        Created on <%: String.Format("{0:g}", response.RecCreation) %> ||  User:       <%: response.UserName %> <br />
        Response:   <%: response.Response %> <br /><br /><br />
  
    <% } %>
    <% } %>
 
</asp:Content>