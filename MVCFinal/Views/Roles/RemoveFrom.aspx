<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RemoveFrom
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Remove From</h2>
    <div>
        <p>
            Please confirm you want to remove the role <i>
                <%=Html.Encode(ViewData["RoleId"])%></i> from <i>
                    <%=Html.Encode(ViewData["Id"])%></i>?
        </p>
    </div>
    <% using (Html.BeginForm())
       {  %>
    <input name="confirmButton" type="submit" value="Remove" />
    <% } %>
</asp:Content>
