<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Part2.aspx.cs" Inherits="_564_Assigment5_Part2" Debug="true"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>  
        <h1>Logon Page that can authenticate through the proxy membership provider (to the ReadOnlyXMLRPovider and the SQLMemberShipProvider).</h1> 
    </div>
    <div>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="http://brookfield.rice.iit.edu/aalferez/564/">
        </asp:Login>
    </div>
</asp:Content>