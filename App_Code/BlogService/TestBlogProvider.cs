using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IITCourse.Blog
{
    /// <summary>
    /// Summary description for TestBlogProvider
    /// </summary>
    public class TestBlogProvider  : BlogProvider
    {
	    public TestBlogProvider()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
            Console.WriteLine("Hello!!!");
	    }

        public override bool CanAnonPostReply
        {
            get { return false; }
        }

        public override Blog GetBlog(int BlogID)
        {
            return GetSingleFakeBlog(BlogID);
        }

        private Blog GetSingleFakeBlog(int BlogID)
        {
            return new Blog { Author = "Test Author" + BlogID,
                Text = "Test Blog", Mood = "Happy" };

        }

        public override List<Blog> GetBlogs()
        {
            return GetTenTestBlogs();
        }
        public override void CreateNewBlog(Blog blog)
        {
            var BlogList = new List<Blog>();
            BlogList.Add(blog);
        }

        public override void UpdateBlog(Blog blog)
        {
            var BlogList = new List<Blog>();
            BlogList.Add(blog);
        }

        public override void DeleteBlog(Blog blog)
        {
            var BlogList = new List<Blog>();
            BlogList.Remove(blog);
        }

        public override List<Blog> GetUserBlogs(MembershipUser User)
        {
            //return GetTenTestBlogs();
            throw new NotImplementedException();
        }

        private List<Blog> GetTenTestBlogs()
        {

            List<Blog> blogs = new List<Blog>();
            for (int i = 0; i < 10; i++)
            {
                blogs.Add(GetSingleFakeBlog(i));
            }
            return blogs;
        }
    }
}
