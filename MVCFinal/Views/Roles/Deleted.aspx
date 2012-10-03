<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Deleted
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Role Deleted</h2>
    <div>
        <p>
            Your role was successfully deleted.</p>
    </div>
    <div>
        <p>
            <%= Html.ActionLink("Back to Roles", "Index", "Roles")%>
    </div>
</asp:Content>
