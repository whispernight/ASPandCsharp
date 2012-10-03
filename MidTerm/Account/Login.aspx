<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
        <p><a href="Register.aspx">Register</a></p>
        if you don't have an account.
    </p>
    <div style="float: left;width: 500px;">
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx">
        </asp:Login>
    </div>
</asp:Content>