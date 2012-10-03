using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration.Provider;
using System.Web.Security;
using IITBlog.Classes;

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
            get
            {
                LoadProviders();
                return _provider;
            }
        }

        public BlogProviderCollection Providers
        {
            get { return _providers; }
        }

        public static void AddBlog(Blog blog)
        {
            LoadProviders();
            _provider.AddBlog(blog);
        }

        public static void DeleteBlog(Blog blog)
        {
            LoadProviders();
            _provider.DeleteBlog(blog);
        }

        public static void UpdateBlog(Blog blog)
        {
            LoadProviders();
            _provider.UpdateBlog(blog);
        }

        public static Blog GetBlog(int BlogID)
        {
            LoadProviders();
            return _provider.GetBlog(BlogID);
        }

        public static List<Blog> GetUserBlogs(MembershipUser User)
        {
            LoadProviders();
            return _provider.GetUserBlogs(User);
        }

        public static List<Blog> GetBlogs()
        {
            LoadProviders();
            return _provider.GetBlogs();
        }

        public static List<Blog> GetUserSpecificBlogs(string userName)
        {
            LoadProviders();
            return _provider.GetSelectedUserBlogs(userName);
        }

        public static List<string> GetNamesOfAllUser()
        {
            LoadProviders();
            return _provider.GetNamesOfAllUser();
        }

        public static void PostBlogResponse(BlogResponse blogResponse)
        {
            LoadProviders();
            _provider.PostBlogResponse(blogResponse);
        }

        public static bool DeleteBlogResponse(BlogResponse blogResponse)
        {
            LoadProviders();
            return _provider.DeleteBlogResponse(blogResponse);
        }

        public static List<BlogResponse> GetBlogResponses(int blogId)
        {
            LoadProviders();
            return _provider.GetBlogResponses(blogId);
        }

        public static BlogResponse GetBlogResponse(int blogResponseId)
        {
            LoadProviders();
            return _provider.GetBlogResponse(blogResponseId);
        }

        //Tag


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
