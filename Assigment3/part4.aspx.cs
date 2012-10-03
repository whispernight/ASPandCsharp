using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

public partial class _564_Assigment3_part4 : System.Web.UI.Page
{
    Auth564Entities context;
    protected void Page_Load(object sender, EventArgs e)
    {
        context = new Auth564Entities();
        Label1.Text = string.Empty;
        Label2.Text = string.Empty;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var user = (from r in context.people
                    where r.logonName == TextBox1.Text
                    where r.passwd == TextBox2.Text
                    select r).FirstOrDefault();
        if (user != null)
        {
            var peopleID = (from r in context.people
                            where r.logonName == user.logonName
                            select r.peopleID).FirstOrDefault();


            var RoleTypeName = (from r in context.roles where r.PeopleID == peopleID select r.roleType.RoleTypeName).FirstOrDefault(); ;
            Label1.Text = "Hello " + user.logonName;
            Label2.Text = "You're logged as <b>" + RoleTypeName + "</b>";
        }
        else
        {
            Label1.Text = "User not found";
        }
    }
}