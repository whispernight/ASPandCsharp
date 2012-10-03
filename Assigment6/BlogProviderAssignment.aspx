<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="BlogProviderAssignment.aspx.cs" Inherits="_564_Assigment6_BlogProviderAssignment" Debug="true"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h1>Hello Cheese Service</h1>
        <asp:GridView ID="gv1" runat="server">
        </asp:GridView>
                <table border="1" style="border-collapse: collapse;">
            <tr>
                <th>
                    Description
                </th>
                <th>
                    Author
                </th>
                <th>
                    Mood
                </th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Post" runat="server" Text="PostBlog" OnClick="PostNewBlog" />
        <asp:Button ID="Delete" runat="server" Text="DeleteBlog" OnClick="DeleteBlog" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
        <asp:Button ID="GetAll" runat="server" Text="Get mines" OnClick="GetUserBlogs" />
    </div>
</asp:Content>