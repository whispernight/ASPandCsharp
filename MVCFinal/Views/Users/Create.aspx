<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create New User</h2>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <p>
            <label for="Username">
                User name:</label>
            <%= Html.TextBox("Username")%>
            <%= Html.ValidationMessage("Username", "*")%>
        </p>
        <p>
            <label for="Password">
                Password:</label>
            <%= Html.TextBox("Password", null, new { Type = "Password" })%>
            <%= Html.ValidationMessage("Password", "*")%>
        </p>
        <p>
            <label for="Email">
                Email:</label>
            <%= Html.TextBox("Email")%>
            <%= Html.ValidationMessage("Email", "*")%>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
