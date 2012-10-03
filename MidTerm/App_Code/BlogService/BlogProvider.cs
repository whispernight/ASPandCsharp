using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;
using System.Web.Security;
using IITBlog.Classes;


namespace IITCourse.Blog
{
    /// <summary>
    /// Summary description for BlogProvider
    /// </summary>
    public abstract class BlogProvider : ProviderBase
    {
        //Properties
        public abstract bool CanAnonPostReply { get; }

        //Methods
        public abstract Blog GetBlog(int BlogID);
        public abstract List<Blog> GetBlogs();
        public abstract void AddBlog(Blog blog);
        public abstract void DeleteBlog(Blog blog);
        public abstract void UpdateBlog(Blog blog);
        public abstract List<Blog> GetUserBlogs(MembershipUser User);
        public abstract List<Blog> GetSelectedUserBlogs(string userName);
        public abstract List<string> GetNamesOfAllUser();
        public abstract void PostBlogResponse(BlogResponse blogResponse);
        public abstract bool DeleteBlogResponse(BlogResponse blogResponse);
        public abstract List<BlogResponse> GetBlogResponses(int blogId);
        public abstract BlogResponse GetBlogResponse(int blogResponseId);

 
        public BlogProvider()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    public class BlogProviderCollection : ProviderCollection
    {
        public new BlogProvider this[string name]
        {
            get { return (BlogProvider)base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is BlogProvider))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }
    }

    public class Blog
    {
        //TODO
        public int BlogID { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Mood { get; set; }
        public DateTime TimeOfCreation { get; set; }

        public Blog()
        {

            if (Membership.GetUser() != null)
            {
                Author = Membership.GetUser().UserName;
            }
            else
            {
                Author = "";
            }
            TimeOfCreation = DateTime.Now;

        }
    }
}