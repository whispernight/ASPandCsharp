<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="part3.aspx.cs" Inherits="_564_Assigment3_part3" Debug="true"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>  
        <h1>Creation of new user using Entity Framework </h1> 
    </div>
    <div>
        <asp:GridView ID="GridViewUsers" runat="server">
        </asp:GridView>
    </div>
    <div>
        <asp:Button ID="AddUser" runat="server" Text="Add new User" onclick="ButtonAddUser_Click" />
    </div>
</asp:Content>