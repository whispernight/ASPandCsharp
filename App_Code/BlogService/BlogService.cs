using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration.Provider;
using System.Web.Security;

namespace IITCourse.Blog
{
    /// <summary>
    /// Summary description for BlogService
    /// </summary>
    public class BlogService
    {
        private static BlogProvider _provider = null;
        private static BlogProviderCollection _providers = null;
        private static object _lock = new object();

        public BlogProvider Provider
        {
            get { return _provider; }
        }

        public BlogProviderCollection Providers
        {
            get { return _providers; }
        }
        public static void CreateNewBlog(Blog blog)
        {
            LoadProviders();
            _provider.CreateNewBlog(blog);
        }

        public static void DeleteBlog(Blog blog)
        {
            LoadProviders();
            _provider.DeleteBlog(blog);
        }

        public static List<Blog> GetUserBlogs(MembershipUser User)
        {
            LoadProviders();
            return _provider.GetUserBlogs(User);
        }

        public static Blog GetBlog(int BlogID)
        {
            LoadProviders();
            return _provider.GetBlog(BlogID);
        }

        public static List<Blog> GetBlogs()
        {
            LoadProviders();
            return _provider.GetBlogs();
        }
        
        private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (_lock)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Get a reference to the <imageService> section
                        BlogServiceSection section = (BlogServiceSection)
                            WebConfigurationManager.GetSection
                            ("system.web/BlogService");

                        // Load registered providers and point _provider
                        // to the default provider
                        _providers = new BlogProviderCollection();
                        ProvidersHelper.InstantiateProviders
                            (section.Providers, _providers,
                            typeof(BlogProvider));
                        _provider = _providers[section.DefaultProvider];

                        if (_provider == null)
                            throw new ProviderException
                                ("Unable to load default ImageProvider");
                    }
                }
            }
        }

    }
}
