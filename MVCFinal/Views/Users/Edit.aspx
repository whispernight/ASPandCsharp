<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit User</h2>
    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <p>
            <label for="UserName">
                Username:</label>
            <%= Html.TextBox("UserName", Model.UserName)%>
            <%= Html.ValidationMessage("UserName", "*")%>
        </p>
        <p>
            <label for="Email">
                Email:</label>
            <%= Html.TextBox("Email", Model.Email)%>
            <%= Html.ValidationMessage("Email", "*")%>
        </p>
                <p>
            <label for="Roles">
                Roles:</label>
            <%= Html.ListBox("Roles")%>
            <%= Html.ValidationMessage("Roles")%>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to Users", "Index") %>
    </div>
</asp:Content>
