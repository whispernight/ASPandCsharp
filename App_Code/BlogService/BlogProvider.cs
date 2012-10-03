using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;
using System.Web.Security;

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
        public abstract void CreateNewBlog(Blog blog);
        public abstract void DeleteBlog(Blog blog);
        public abstract void UpdateBlog(Blog blog);
        public abstract List<Blog> GetUserBlogs(MembershipUser User);
        
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
        public string Text { get; set; }
        public string Author { get; set; }
        public string Mood { get; set; }
    }
}
