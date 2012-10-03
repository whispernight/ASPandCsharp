using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using IITCourse.Blog;
using IITCourse.Cheese;

public partial class _564_Assigment6_BlogProviderAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser muc = Membership.GetUser();
        List<IITCourse.Blog.Blog> blogs = new List<IITCourse.Blog.Blog>();
        if (muc != null)
        {blogs = BlogService.GetUserBlogs(Membership.GetUser());}
        else
            blogs = BlogService.GetBlogs();
        gv1.DataSource = blogs; //BlogService.GetBlogs ();
        gv1.DataBind();
    }


    protected void PostBlog(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text == "")
        {
            Label1.Text = "Error: Input Value is empty";
        }
        else
        {
            Label1.Text = "No error.";
            IITCourse.Blog.Blog blog = new Blog();
            blog.Text = TextBox1.Text;
            blog.Mood = TextBox3.Text;
            blog.Author = TextBox2.Text;
            BlogService.CreateNewBlog(blog);
            Display();
        }
    }

    protected void GetUserBlogs(object sender, EventArgs e)
    {
        MembershipUser muc = Membership.GetUser();
        List<IITCourse.Blog.Blog> blogs = new List<IITCourse.Blog.Blog>();
        if (muc != null)
        {
            blogs = BlogService.GetUserBlogs(muc);
        }
        gv1.DataSource = blogs;
        gv1.DataBind();

    }

    private void Display()
    {
        List<IITCourse.Blog.Blog> blogs = new List<IITCourse.Blog.Blog>();
        blogs = BlogService.GetBlogs();
        gv1.DataSource = blogs;
        gv1.DataBind();
    }

    protected void PostNewBlog(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text == "")
        {
            Label1.Text = "Error: Input Value is empty";
        }
        else
        {
            Label1.Text = "No error.";
            IITCourse.Blog.Blog blog = new Blog();
            blog.Text = TextBox1.Text;
            blog.Mood = TextBox3.Text;
            blog.Author = TextBox2.Text;
            BlogService.CreateNewBlog(blog);
            Display();
        }
    }

    protected void DeleteBlog(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text == "")
        {
            Label1.Text = "You have to write something";
        }
        else
        {
            Label1.Text = "Ok";
            Blog blog = new Blog();
            blog.Text = TextBox1.Text;
            blog.Mood = TextBox3.Text;
            blog.Author = TextBox2.Text;
            BlogService.DeleteBlog(blog);
            Display();
        }
    }
}