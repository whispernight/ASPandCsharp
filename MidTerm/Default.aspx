<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to my MidTerm Proyect!!
    </h2>
    <br />
    <p>Only users with admin role can access the "Roles Admin page"</p>
    <p>Actually the only user with that role is user:"aalfere1" pass:"uG>xROkBahn8?M"</p>
    <p><a href="Roles.aspx">Roles Admin page</a></p>
    <br />
    <p>Blogs Page is accessible for everyone</p>
    <p><a href="Blogg.aspx">Blogs page</a></p>
</asp:Content>
