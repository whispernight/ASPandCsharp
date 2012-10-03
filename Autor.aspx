<%@ Page Title="About me" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Autor.aspx.cs" Inherits="Autor" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About me
    </h2>
    <p>
        <p>Contact info:</p>
        <p>My name is Angel Alferez</p>
        <p>I'm from Spain</p>
        <p>I study Information Technology and Management in the Illinois Institute of Technology</p>
        <asp:ImageButton onclick="Click_Image" alt="mail" id="mail" runat="server" 
        src="./Images/MailBox-icon.png" Height="76px" Width="77px" />
        
    </p>
</asp:Content>
