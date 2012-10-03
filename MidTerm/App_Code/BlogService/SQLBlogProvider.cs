using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
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
        private Guid applicationID;
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

        public override Blog GetBlog(int BlogID)
        {
            var blog = (from b in db.Blogs
                        where (b.BlogID == BlogID)
                        select b).FirstOrDefault();
            return new Blog
            {
                BlogID = BlogID,
                Author = blog.UserName,
                Description = blog.BlogText,
                Mood = blog.Mood,
                TimeOfCreation = blog.RecCreationTime
            };
        }

        public override void AddBlog(Blog blog)
        {
            IITBlog.Classes.Blog newBlog = new IITBlog.Classes.Blog
            {
                UserName = blog.Author,
                BlogText = blog.Description,
                Mood = blog.Mood,
                RecCreationTime = DateTime.Now,
                //UserID = Membership.GetUser(blog.Author).ProviderUserKey
            };
            db.Blogs.InsertOnSubmit(newBlog);
            db.SubmitChanges();
        }

        public override void DeleteBlog(Blog blog)
        {
            var blogToDelete = (from b in db.Blogs
                                where (b.BlogID == blog.BlogID)
                                select b).FirstOrDefault();
            var blogResponses = (from b in db.BlogResponses
                                where (b.BlogID == blogToDelete.BlogID)
                                select b).ToList();
            var blogTags = (from b in db.BlogTags
                            where (b.BlogID == blogToDelete.BlogID)
                            select b).ToList();
            if (blogResponses.Count > 0)
                DeleteBlogResponses(blogResponses);
            if (blogTags.Count > 0)
                DeleteBlogTags(blogTags);
            db.Blogs.DeleteOnSubmit(blogToDelete);
            db.SubmitChanges();
        }

        protected void DeleteBlogResponses(List<IITBlog.Classes.BlogResponse> blogResponses)
        {
            db.BlogResponses.DeleteAllOnSubmit(blogResponses);
            db.SubmitChanges();
        }

        protected void DeleteBlogTags(List<IITBlog.Classes.BlogTag> blogTags)
        {
            db.BlogTags.DeleteAllOnSubmit(blogTags);
            db.SubmitChanges();
        }

 

        public override void UpdateBlog(Blog blog)
        {
            var blogToUpdate = (from b in db.Blogs
                                where (b.BlogID == blog.BlogID)
                                select b).FirstOrDefault();
            blogToUpdate.BlogText = blog.Description;
            blogToUpdate.Mood = blog.Mood;
            db.SubmitChanges();
        }

        public override void PostBlogResponse(BlogResponse blogResponse)
        {
            MembershipUser currentUser = Membership.GetUser(blogResponse.UserName);
            IITBlog.Classes.BlogResponse newBlogResponse = new IITBlog.Classes.BlogResponse
            {
                BlogID = blogResponse.BlogID,
                UserName = blogResponse.UserName,
                RecCreation = blogResponse.RecCreation,
                IP = blogResponse.IPAddress,
                Response = blogResponse.ResponseText
            };
            db.BlogResponses.InsertOnSubmit(newBlogResponse);
            db.SubmitChanges();
        }

        public override bool DeleteBlogResponse(BlogResponse blogResponse)
        {
            var blogResponseToDelete = (from b in db.BlogResponses
                                        where (b.BlogResponseID == blogResponse.BlogResponseID)
                                        select b).FirstOrDefault();

            if (blogResponseToDelete == null)
                return false;
            else
            {
                db.BlogResponses.DeleteOnSubmit(blogResponseToDelete);
                db.SubmitChanges();
                return true;
            }
        }

        public override List<BlogResponse> GetBlogResponses(int blogId)
        {
            var dataBlogResponses = from blogResponses in db.BlogResponses
                                    where (blogResponses.BlogID == blogId)
                                    select blogResponses;
            var BlogResponseList = new List<BlogResponse>();
            foreach (IITBlog.Classes.BlogResponse blgResponse in dataBlogResponses)
            {
                var newBlogResponse = new IITCourse.Blog.BlogResponse
                {
                    BlogResponseID = blgResponse.BlogResponseID,
                    BlogID = blgResponse.BlogID,
                    UserName = blgResponse.UserName,
                    RecCreation = blgResponse.RecCreation,
                    IPAddress = blgResponse.IP,
                    ResponseText = blgResponse.Response,
                };
                BlogResponseList.Add(newBlogResponse);
            }
            return BlogResponseList;
        }

        public override BlogResponse GetBlogResponse(int blogResponseId)
        {
            var blogResponse = (from b in db.BlogResponses
                                where (b.BlogResponseID == blogResponseId)
                                select b).FirstOrDefault();
            var blgResponse = new IITCourse.Blog.BlogResponse
            {
                BlogResponseID = blogResponse.BlogResponseID,
                BlogID = blogResponse.BlogID,
                UserName = blogResponse.UserName,
                RecCreation = blogResponse.RecCreation,
                IPAddress = blogResponse.IP,
                ResponseText = blogResponse.Response,
            };
            return blgResponse;
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
                    Description = blg.BlogText,
                    Mood = blg.Mood,
                    BlogID = blg.BlogID,
                    TimeOfCreation = blg.RecCreationTime
                };
                BlogList.Add(newBlog);
            }
            return BlogList;
        }

        public override List<Blog> GetBlogs()
        {
            var dataBlog = from b in db.Blogs
                           orderby b.RecCreationTime descending
                           select b;
            var BlogList = new List<Blog>();
            foreach (var blg in dataBlog)
            {
                var newBlog = new IITCourse.Blog.Blog
                {
                    BlogID = blg.BlogID,
                    Author = blg.UserName,
                    Description = blg.BlogText,
                    Mood = blg.Mood,
                    TimeOfCreation = blg.RecCreationTime
                };
                BlogList.Add(newBlog);
            }
            return BlogList;
        }

        public override List<Blog> GetSelectedUserBlogs(string userName)
        {
            var selectedUserBlogs = from b in db.Blogs
                                    where (b.UserName == userName)
                                    orderby b.RecCreationTime descending
                                    select b;

            List<Blog> blogs = new List<Blog>();
            foreach (IITBlog.Classes.Blog b in selectedUserBlogs)
            {
                blogs.Add(new Blog
                {
                    BlogID = b.BlogID,
                    Author = b.UserName,
                    Description = b.BlogText,
                    Mood = b.Mood,
                    TimeOfCreation = b.RecCreationTime
                });
            }
            return blogs;
        }

        public override List<string> GetNamesOfAllUser()
        {
  /*          return (from blogs in db.Blogs
                    join users in db.aspnet_Users on blogs.UserID equals users.UserId
                    join mem in db.aspnet_Memberships on users.UserId equals mem.UserId
                    join app in db.aspnet_Applications on mem.ApplicationId equals app.ApplicationId
                    where
                        blogs.ApplicationID == _applicationId
                    orderby
                        users.UserName
                    select new Author
                    {
                        UserName = users.UserName,
                        UserId = users.UserId
                    }).Distinct().ToList();
    
            MembershipUserCollection users = Membership.GetAllUsers();

            List<string> userNames = new List<string>();
            foreach (MembershipUser user in users)
            {
                userNames.Add(user.UserName);
            }
            return userNames;
   * */

            var users = from u in db.aspnet_Users
                       // where u.ApplicationId == applicationID
                        select u;
            List<string> userNames = new List<string>();

            foreach (IITBlog.Classes.aspnet_User u in users)
            {
                userNames.Add(u.UserName);
            }
            return userNames;
        }

        //Delete
    }
}
