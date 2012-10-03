<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Page3.aspx.cs" Inherits="_564_Assigment4_Page3" Debug="true"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>  
        <h1>Reset Password</h1> 
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Back to Home Page" onclick="Button1_Click" Visible="false" />
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
        </asp:PasswordRecovery>
    </div>
</asp:Content>
