using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using IITBlog.Classes;

namespace IITCourse.Blog
{
/// <summary>
/// Summary description for SQLBlogProvider
/// </summary>
public class SQLBlogProvider : BlogProvider
{
    BlogDataClassesDataContext db;
    
    public SQLBlogProvider()
	{
		//
		// TODO: Add constructor logic here
		//
        db = new BlogDataClassesDataContext();
	}

    public override bool CanAnonPostReply
    {
        get { throw new NotImplementedException(); }
    }

    public override void CreateNewBlog(Blog blog)
    {
        IITBlog.Classes.Blog newBlog = new IITBlog.Classes.Blog
        {
            UserName = blog.Author,
            BlogText = blog.Text,
            Mood = blog.Mood,
            RecCreationTime = DateTime.Now
        };
        db.Blogs.InsertOnSubmit(newBlog);
        db.SubmitChanges();
    }

    public override void DeleteBlog(Blog blog)
    {
        var blogToDelete = (from b in db.Blogs
                            where (b.UserName == blog.Author && b.Mood == blog.Mood && b.BlogText == blog.Text)
                            select b).FirstOrDefault();
        db.Blogs.DeleteOnSubmit(blogToDelete);
        db.SubmitChanges();
    }

    public override void UpdateBlog(Blog blog)
    {
        var blogToUpdate = (from b in db.Blogs
                            where (b.UserName == blog.Author && b.Mood == blog.Mood && b.BlogText == blog.Text)
                            select b).FirstOrDefault();
        db.Blogs.DeleteOnSubmit(blogToUpdate);
        db.SubmitChanges();
    }


    public override List<Blog> GetUserBlogs(MembershipUser User)
    {

        var dataBlog = from b in db.Blogs
                       where (b.UserName == User.UserName)
                       select b;

        var BlogList = new List<Blog>();
        foreach (var blg in dataBlog)
        {
            var newBlog = new IITCourse.Blog.Blog
            {
                Author = blg.UserName,
                Text = blg.BlogText,
                Mood = blg.Mood
            };
            BlogList.Add(newBlog);
        }
        return BlogList;
    }
    public override Blog GetBlog(int BlogID)
    {
        var dataBlog = from b in db.Blogs
                       select b;
        var blog = dataBlog.First();
        return new Blog
        {
            Author = blog.UserName,
            Text = blog.BlogText,
            Mood = blog.Mood
        };
    }

    public override List<Blog> GetBlogs()
    {
        var dataBlog = from b in db.Blogs
                       select b;
        var BlogList = new List<Blog>();
        foreach (var blg in dataBlog)
        {
            var newBlog = new IITCourse.Blog.Blog
            {
                Author = blg.UserName,
                Text = blg.BlogText,
                Mood = blg.Mood
            };

            BlogList.Add(newBlog);
        }
        return BlogList;
    }
}
}
