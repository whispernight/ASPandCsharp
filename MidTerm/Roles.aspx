<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Roles.aspx.cs" Inherits="MidTerm_Roles" %>

<%@ Register Src="~/Controls/AddRemoveRoleControl.ascx" TagName="AddRemoveRoles" TagPrefix="IIT564" %>
<%@ Register Src="~/Controls/AddRemoveUserRoleControl.ascx" TagName="AddRemoveUserRoles" TagPrefix="IIT564" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>  
        <h1>Admin can add/remove roles and set the user roles in this page!.</h1> 
    </div>
    <div>
    <IIT564:AddRemoveUserRoles ID="AddRemoveUserRoles1" runat="server" />
    <IIT564:AddRemoveRoles ID="AddRemoveRoles1" runat="server" />
    </div>
</asp:Content>