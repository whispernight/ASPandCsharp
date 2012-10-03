<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Role</h2>
    
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <p>
            <label for="CreateRole">
                Create a new role:</label>
            <%= Html.TextBox("CreateRole")%>
            <%= Html.ValidationMessage("CreateRole", "*")%>
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
