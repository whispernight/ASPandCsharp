<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <%--<legend></legend>--%>
        <p>
            <strong>Username:</strong>
            <%= Html.Encode(Model.UserName)%>
        </p>
        <p>
            <strong>Email:</strong>
            <%= Html.Encode(Model.Email) %>
        </p>
        <p>
            <%= Html.ActionLink("View the roles for this user", "ForUser", "Roles", new { id = Model.UserName }, null)%>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit User", "Edit", new { id = Model.UserName })%>
        |
        <%=Html.ActionLink("Delete User", "Delete", new { id = Model.UserName })%>
        |
        <%=Html.ActionLink("Back to Users", "Index") %>
    </p>
</asp:Content>
