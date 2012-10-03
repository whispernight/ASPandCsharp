<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="assigment2.aspx.cs" Inherits="_564_Assigments_assigment2" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2>ASSIGNMENT 2!</h2>
        <h1>DAL</h1>
        <asp:GridView ID="GV1" runat="server">
        </asp:GridView>
        <h1>MSL</h1>
        <asp:GridView ID="GV2" runat="server">
        </asp:GridView>
        <h1>Did it manually: Dataset</h1>
        <asp:GridView ID="GV3" runat="server">
        </asp:GridView>
        <h1>Did it manually: Datatable</h1>
        <asp:GridView ID="GV4" runat="server">
        </asp:GridView>
</asp:Content>