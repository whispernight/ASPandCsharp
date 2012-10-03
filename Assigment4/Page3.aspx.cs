using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _564_Assigment4_Page3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            Button1.Visible = true;
        else
            Response.Write("You must be logged in first");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://brookfield.rice.iit.edu/aalferez/564/");
    }
}