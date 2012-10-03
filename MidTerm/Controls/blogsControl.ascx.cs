using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using IITCourse.Blog;


public partial class MidTerm_Controls_blogs : System.Web.UI.UserControl
{
    string ApplicationName;

    protected void Page_Load(object sender, EventArgs e)
    {
        ApplicationName = Membership.Provider.ApplicationName;
        if (!(Page.IsPostBack))
        {
            MembershipUser muc = Membership.GetUser();
            List<IITCourse.Blog.Blog> blogs = new List<IITCourse.Blog.Blog>();
            blogs = BlogService.GetBlogs();
            
            
            GVBlogs.DataSource = blogs;
            GVBlogs.DataBind();
        }
    }
}