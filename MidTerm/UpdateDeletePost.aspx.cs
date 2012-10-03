using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IITCourse.Blog;
using System.Web.Security;
 
public partial class UpdateDeletePostaspx : System.Web.UI.Page
{
    int blogId;
    Blog blogToEdit;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        blogId = Int32.Parse(Request.QueryString["id"]);
        if (!(IsPostBack))
        {
            if (blogId != null)
            {
                blogToEdit = BlogService.GetBlog(blogId);
                textBlogMood.Text = blogToEdit.Mood;
                textBlogDescription.Text = blogToEdit.Description;
            }
        }
    }
 
    protected void buttonUpdateBlogg_Click(object sender, EventArgs e)
    {
        Blog blog = new Blog { Description = textBlogDescription.Text, Mood = textBlogMood.Text, BlogID = blogId, Author= Membership.GetUser().UserName  };
        BlogService.UpdateBlog(blog);
        Response.Redirect("~/Blogg.aspx");
    }
 
    protected void buttonDeleteBlogg_Click(object sender, EventArgs e)
    {
        Blog blog = new Blog { BlogID = blogId };
        BlogService.DeleteBlog(blog);
        Response.Redirect("~/Blogg.aspx");
    }
 
   
}