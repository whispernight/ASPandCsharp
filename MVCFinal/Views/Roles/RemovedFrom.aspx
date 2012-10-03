<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RemovedFrom
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Role Removed</h2>
    <div>
        <p>
            The role was successfully removed.</p>
    </div>
    <div>
        <p>
            <%= Html.ActionLink("Back to Users", "Index", "Users")%>
    </div>
</asp:Content>
