<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<String>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        People in the role
        <%= Html.Encode(ViewData["RoleId"])%></h2>
    <ul>
        <%foreach (String roles in Model)
          { %>
        <li><a href="../../Users/Details/<%= Html.Encode(roles) %>">
            <%= Html.Encode(roles) %></a></li>
        <%  } %>
    </ul>
    <p>
        <%=Html.ActionLink("Back to Roles", "Index") %>
        |
        <%=Html.ActionLink("Delete Role","Delete", new { id=ViewData["RoleId"]})%>
    </p>
</asp:Content>
