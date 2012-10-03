using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public interface IBlogRepository
    {
        void AddBlog(Blog BlogToAdd);
        void DeleteBlog(Blog BlogToDelete);
        System.Linq.IQueryable<Blog> FindAllBlogs();
        Blog FindBlog(int id);
        void SaveChanges();
    }
}