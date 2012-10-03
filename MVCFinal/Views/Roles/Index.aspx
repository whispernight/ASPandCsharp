<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<String>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Roles</h2>
    <ul>
        <%foreach (String roles in Model)
          { %>
        <li>
            <a href="./Roles/Details/<%=Html.Encode(roles) %>"><%= Html.Encode(roles) %></a></li>
        <% }%></ul>
 <% if (User.IsInRole("Admin")) {%> 
    <p>
        <%= Html.ActionLink("Create Role", "Create") %>
    </p>
    <% }%>
</asp:Content>
