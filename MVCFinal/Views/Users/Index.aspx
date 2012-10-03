<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUserCollection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Users</h2>
    <ul>
        <%foreach (MembershipUser user in Model)
          { %>
        <li>
            <%= Html.ActionLink(user.UserName, "Details", new { id = user.UserName}) %>
            <% }%></ul>
 <% if (User.IsInRole("Admin")) {%> 
    <p>
        <%= Html.ActionLink("Create User", "Create") %>
    </p>
    <% }%>
</asp:Content>
