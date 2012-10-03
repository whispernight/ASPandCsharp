<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="part4.aspx.cs" Inherits="_564_Assigment3_part4" Debug="true"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    <asp:Label ID="Label2" runat="server" ></asp:Label>
    <br />
    <h1>User: </h1> 
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <h1>Password: </h1>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Log In" onclick="Button1_Click" />
    </div>
</asp:Content>