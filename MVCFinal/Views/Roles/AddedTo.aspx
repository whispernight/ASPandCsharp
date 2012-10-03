<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddedTo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Added To</h2>
    <div>
        <p>
            The role was successfully added.</p>
    </div>
    <div>
        <p>
            <%= Html.ActionLink("Back to Users", "Index", "Users") %>
    </div>
</asp:Content>
