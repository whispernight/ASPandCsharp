<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <b><h1>WELCOME TO MY MAIN PAGE! ITM 564 COURSE</h1></b>
    <ul>
    <h3>Assignment 1</h3>
    <li><a href="Assigments/assigment1.aspx">Link</a></li>
    <h3>Assignment 2</h3>
    <li><a href="Assigments/assigment2.aspx">Link</a></li>
    <h3>Assignment 3</h3>
    <asp:Panel ID="Assignment3" runat="server">
    <li><a href="Assigment3/part1.aspx">Link: Part 1</a></li>
    <li><a href="Assigment3/part2.aspx">Link: Part 2</a></li>
    <li><a href="Assigment3/part3.aspx">Link: Part 3</a></li>
    <li><a href="Assigment3/part4.aspx">Link: Part 4</a></li>
    </asp:Panel>
    <h3>Assignment 4</h3>
    <asp:Panel ID="Assignment4" runat="server" >
    <li>Link: <a href="Assigment4/Page1.aspx">Login using SQL MembershipProvider.</a></li>
    <li>Link: <a href="Assigment4/Page2.aspx">Create User with Wizard Steps.</a></li>
    <li>Link: <a href="Assigment4/Page3.aspx">Reset Password.</a></li>
    <li>Link: <a href="WebSiteSingleMemberShipProvider/Login.aspx">Web Site Single Member Ship Provider.</a></li>
    </asp:Panel>
    <h3>Assignment 5</h3>
    <asp:Panel ID="Panel1" runat="server" >
    <li>Link: <a href="Assigment5/Part2.aspx">Logon Page that can authenticate through the proxy membership provider.</a></li>
    <li>Link: <a href="Assigment5/Part1.aspx">Add/remove roles for users.</a></li>
    </asp:Panel>
    <h3>Assignment 6</h3>
    <li>Link: <a href="Assigment6/BlogProviderAssignment.aspx">Blog Provider.</a></li>
    <h3>Assignment 7</h3>
    <li>Link: <a href="Midterm">MidTerm!</a></li>
    <h3>Assignment 8</h3>
    <li>Link: <a href="MVCNerdDinner">MVCNerdDinner!</a></li>
    <h3>Assignment 9</h3>
    <li>Link: <a href="MVC">MVCBlogs!</a></li>
    <h3>Assignment 10</h3>
    <li>Link: <a href="TestZip/BlogMVC.Tests.rar">MVC Unit Testing</a></li>
    <h3>Assignment 11</h3>
    <li>Link: <a href="MVCFinal">Final MVC</a></li>

    </ul>
    <b><h2>This page belongs to Angel Alferez Aroca</h2></b>
    </div>
</asp:Content>