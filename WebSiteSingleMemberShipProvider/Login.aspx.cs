using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Write("Logged In Succesfully");
            Login1.Visible = false;
            Button1.Visible = true;
        }
        else
        {
            Response.Write("If you want to login: Username: aalferez and password: k=;Yvu86ttuUqE");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("http://brookfield.rice.iit.edu/aalferez/564/WebSiteSingleMemberShipProvider/Login.aspx");
    }
}