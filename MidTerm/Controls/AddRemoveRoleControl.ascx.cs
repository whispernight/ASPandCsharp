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

public partial class Controls_AddRemoveRoleControl : System.Web.UI.UserControl
{
    string ApplicationName;

    protected void Page_Load(object sender, EventArgs e)
    {
        ApplicationName = Membership.Provider.ApplicationName;
        if (!(Page.IsPostBack))
        {
            BindRoleGrid();
        }
    }

    protected void BindRoleGrid()
    {
        GVRoles.DataSource = Roles.GetAllRoles();
        GVRoles.DataBind();
    }

    protected void ButtonAddRole_Click(object sender, EventArgs e)
    {
        string RoleName = AddRole.Text.Replace("'", "''");
        Roles.CreateRole(RoleName);
        BindRoleGrid();
    }
    protected void ButtonDeleteRole_Click(object sender, EventArgs e)
    {
        string RoleName = DeleteRole.Text.Replace("'", "''");
        Roles.DeleteRole(RoleName);
        BindRoleGrid();
    }
}