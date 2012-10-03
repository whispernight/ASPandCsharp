<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h2>Details</h2>
 
 
        <fieldset>
        <legend><%: Model.BlogID %></legend><p>
        <strong>BlogText:</strong>&nbsp;<%: Model.BlogText %></p>
        <p>
        <strong>Mood:</strong>&nbsp;<%: Model.Mood %></p>
        <p>
        <strong>UserName:</strong>&nbsp;<%: Model.UserName %></p>
        <p>
        <strong>UserID:</strong>&nbsp;<%: Model.UserID %></p>
        <p>
        <strong>ApplicationID:</strong>&nbsp;<%: Model.ApplicationID %></p>
        <p>
        <strong>RecCreationTime:</strong>&nbsp;<%: String.Format("{0:g}", Model.RecCreationTime) %></p>
        <p>
        <strong>ApplicationName:</strong>&nbsp;<%: Model.ApplicationName %></p>
        <p>
        <strong>PeopleID:</strong>&nbsp;<%: Model.PeopleID %></p>
        </fieldset>
    <p>
 
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.BlogID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
 
</asp:Content>