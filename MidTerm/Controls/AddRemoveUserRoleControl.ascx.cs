using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Controls_AddRemoveUserRoleControl : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(Page.IsPostBack))
        {
            BindUsers(DropDownListUsers);
            BindRoleCheckBoxes();
        }
    }

    protected void BindUsers(ListControl lc)
    {
        MembershipUserCollection muc = Membership.GetAllUsers();
        lc.DataSource = muc;
        lc.DataValueField = "UserName";
        lc.DataBind();
    }

    protected void BindRoleCheckBoxes()
    {
        CheckBoxListRemoveRoles.Items.Clear();
        CheckBoxListAddRoles.Items.Clear();

        string[] roles = Roles.GetAllRoles();
        string[] userRoles = Roles.GetRolesForUser(DropDownListUsers.SelectedValue);

        Response.Write(DropDownListUsers.SelectedValue);


        foreach (string roleName in roles)
        {
            ListItem li = new ListItem(roleName);
            if (userRoles.Contains(roleName))
            {
                CheckBoxListRemoveRoles.Items.Add(li);
            }
            else
            {
                CheckBoxListAddRoles.Items.Add(li);
            }
        }
    }

    protected void CheckBoxListAddRoles_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList cbl = (CheckBoxList)sender;
        foreach (ListItem li in cbl.Items)
        {
            //Add role
            if (li.Selected)
            {
                Roles.AddUserToRole(DropDownListUsers.SelectedValue, li.Value);
            }
        }

        BindRoleCheckBoxes();
    }

    protected void CheckBoxListRemoveRoles_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList cbl = (CheckBoxList)sender;
        foreach (ListItem li in cbl.Items)
        {
            //remove role
            if (li.Selected)
            {
                Roles.RemoveUserFromRole(DropDownListUsers.SelectedValue, li.Value);
            }
        }

        BindRoleCheckBoxes();
    }

    protected void btnAddUserToRole_OnClick(Object sender, EventArgs e)
    {
       
    }
}