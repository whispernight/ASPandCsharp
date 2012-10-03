<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddRemoveUserRoleControl.ascx.cs" Inherits="Controls_AddRemoveUserRoleControl" %>
 
<asp:Panel ID="pnlAddRemoveUserRoles" runat="server" GroupingText="Add Remove User Roles">
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
 
<asp:DropDownList ID="DropDownListUsers" runat="server" AutoPostBack="true">
</asp:DropDownList><br />
Add Roles<br />
<asp:CheckBoxList ID="CheckBoxListAddRoles" runat="server"  OnSelectedIndexChanged="CheckBoxListAddRoles_OnSelectedIndexChanged">
</asp:CheckBoxList>
 
Remove roles<br />
<asp:CheckBoxList ID="CheckBoxListRemoveRoles" runat="server" OnSelectedIndexChanged="CheckBoxListRemoveRoles_OnSelectedIndexChanged">
</asp:CheckBoxList>
 
<asp:Button ID="btnAddUserToRole" OnClick="btnAddUserToRole_OnClick" runat="server" Text="Add/Remove User Roles" />
</asp:Panel>