using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MvcApplication3.Models
{

 
    public class BlogRepository : IBlogRepository
    {
        private Auth564Entities db = new Auth564Entities();
        public IQueryable<Blog> FindAllBlogs()
        {
            return db.Blogs;
        }
 
        public Blog FindBlog(int id)
        {
            return db.Blogs.FirstOrDefault(b => b.BlogID  == id);
        }
 
        public void DeleteBlog(Blog BlogToDelete)
        {
            db.Blogs.DeleteObject(BlogToDelete);
            //db.Blogs.DeleteOnSubmit(BlogToDelete);    //LINQ
            //db.SubmitChanges();
        }
 
        public void AddBlog(Blog BlogToAdd)
        {
            db.Blogs.AddObject(BlogToAdd);
            //db.Blogs.InsertOnSubmit(BlogToAdd);
            //db.SubmitChanges();
        }
 
        public void SaveChanges()
        {
            db.SaveChanges();
        }
 
    }
}