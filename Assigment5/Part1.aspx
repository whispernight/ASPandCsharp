<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Part1.aspx.cs" Inherits="_564_Assigment5_Part1" Debug="true"%>

<%@ Register Src="~/Controls/AddRemoveRoleControl.ascx" TagName="AddRemoveRoles" TagPrefix="IIT564" %>
<%@ Register Src="~/Controls/AddRemoveUserRoleControl.ascx" TagName="AddRemoveUserRoles" TagPrefix="IIT564" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>  
        <h1>Add/remove roles for users similar to page I showed in class for roles in the role provider.</h1> 
    </div>
    <div>
    <IIT564:AddRemoveUserRoles ID="AddRemoveUserRoles1" runat="server" />
    <IIT564:AddRemoveRoles ID="AddRemoveRoles1" runat="server" />
    </div>
</asp:Content>