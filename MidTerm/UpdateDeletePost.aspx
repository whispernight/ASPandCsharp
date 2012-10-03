<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="UpdateDeletePost.aspx.cs" Inherits="UpdateDeletePostaspx" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h1>Edit/Delete Blog </h1>
    <div ID="pnlEditBlog" runat="server" >  
            <fieldset>
            <p>
                <asp:Label ID="labelBlogMood" runat="server" AssociatedControlID="textBlogMood">Your Mood:</asp:Label>
                <asp:TextBox ID="textBlogMood" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMood" ControlToValidate="textBlogMood" runat="server" 
                            ErrorMessage="Mood text cannot be empty" ForeColor="red" ValidationGroup="Mood" />
            </p>
            <p>
                <asp:Label ID="labelBlogDescription" runat="server" AssociatedControlID="textBlogDescription">Your Description:</asp:Label>
                <asp:TextBox ID="textBlogDescription" runat="server" CssClass="textEntry" Rows="6" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="buttonUpdateBlog" runat="server" Text="Update" onclick="buttonUpdateBlogg_Click" ValidationGroup="Mood"/>&nbsp;
            </p>
            </fieldset> 
            <p>
                <asp:Button ID="buttonDeleteBlog" runat="server" Text="Delete" onclick="buttonDeleteBlogg_Click" />&nbsp;
            </p>
    </div>
</asp:Content>