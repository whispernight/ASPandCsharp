using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

public partial class _564_Assigment3_part3 : System.Web.UI.Page
{
    Entity.Auth564Entities context;
    protected void Page_Load(object sender, EventArgs e)
    {
        context = new Auth564Entities();
    }
    protected void ButtonAddUser_Click(object sender, EventArgs e)
    {
        var user = context.people.CreateObject();
        user.salutationID = 1;
        user.firstName = "Angel";
        user.lastName = "Alferez";
        user.logonName = "aalferez";
        user.passwd = "12345";
        user.recCreationDate = System.DateTime.Now;

        context.people.AddObject(user);
        context.SaveChanges();
         var userID = (from r in context.people
                      where r.firstName == "Angel"
                      where r.lastName == "Alferez"
                      where r.logonName == "aalferez"
                      orderby r.peopleID descending
                      select r.peopleID).FirstOrDefault();

        var newrole = context.roles.CreateObject();
        newrole.PeopleID = userID;
        newrole.RoleTypeID = 1;
        newrole.roleActive = true;
        newrole.recCreationDate = DateTime.Now;
        context.roles.AddObject(newrole);
        context.SaveChanges();

        var allpeople = from r in context.people
                        orderby r.peopleID ascending
                        select r;

        GridViewUsers.DataSource = allpeople;
        GridViewUsers.DataBind();
    }
}