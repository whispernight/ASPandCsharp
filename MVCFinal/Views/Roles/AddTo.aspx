<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddTo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Add To</h2>
    <div>
        <p>
            Please confirm you want to add the role <i>
                <%=Html.Encode(ViewData["RoleId"])%></i> to <i>
                    <%=Html.Encode(ViewData["Id"])%></i>?
        </p>
    </div>
    <% using (Html.BeginForm())
       {  %>
    <input name="confirmButton" type="submit" value="Add" />
    <% } %>
</asp:Content>
