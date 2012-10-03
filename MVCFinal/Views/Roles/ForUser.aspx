<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<String>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ForUser
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Roles for
        <%= Html.Encode(ViewData["UserName"])%></h2>
    <ul>
        <%foreach (String UserRoles in Model)
          { %>
        <li>
            <%= Html.Encode(UserRoles)%>
            <a href="<%=  Url.Action("RemoveFrom", new { id = Html.Encode(ViewData["UserName"]), role = Html.Encode(UserRoles) }) %>">
                remove this role</a> </li>
        <%  } %>
    </ul>
    <p>
        <label>
            All roles:</label>
        <ul>
            <% foreach (var item in ViewData["Roles"] as List<String>)
               { %>
            <li>
                <%= Html.Encode(item)%>
                <a href="<%=  Url.Action("AddTo", new { id = Html.Encode(ViewData["UserName"]), role = Html.Encode(item) }) %>">
                    add this role</a> </li>
            <%  } %>
        </ul>
    </p>
    <p>
        <%= Html.ActionLink("Back to Users", "Index", "Users") %>
    </p>
</asp:Content>
