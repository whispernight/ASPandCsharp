<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Page1.aspx.cs" Inherits="_564_Assigment4_Page1" Debug="true"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>  
        <h1>Login using SQL MembershipProvider</h1> 
    </div>
    <div>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="http://brookfield.rice.iit.edu/aalferez/564/">
        </asp:Login>
    </div>
</asp:Content>
