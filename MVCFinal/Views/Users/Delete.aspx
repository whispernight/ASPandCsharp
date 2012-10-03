<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete Confirmation</h2>
    <div>
        <p>
            Please confirm you want to delete the user: <i>
                <%=Html.Encode(Model.UserName)%>? </i>
        </p>
    </div>
    <% using (Html.BeginForm())
       {  %>
    <input name="confirmButton" type="submit" value="Delete" />
    <% } %>
</asp:Content>
