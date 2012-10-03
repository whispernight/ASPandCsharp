<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddRemoveRoleControl.ascx.cs" Inherits="Controls_AddRemoveRoleControl" %>

<asp:Panel ID="pnlAddRemoveRoles" runat="server" GroupingText="With this panel you can add roles">
All Roles
<asp:GridView ID="GVRoles" runat="server" AutoGenerateColumns="true">
<EmptyDataTemplate>
No Roles
</EmptyDataTemplate>
</asp:GridView>
<br />
New/Add Role
<br />
<asp:TextBox ID="AddRole" runat="server"></asp:TextBox>
<asp:Button ID="ButtonAddRole" runat="server" Text="Add Role" onclick="ButtonAddRole_Click" />
<asp:TextBox ID="DeleteRole" runat="server"></asp:TextBox>
<asp:Button ID="ButtonDeleteRole" runat="server" Text="Delete Role" onclick="ButtonDeleteRole_Click" />
</asp:Panel>