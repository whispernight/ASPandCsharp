using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;

namespace MvcApplication3.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IBlogRepository BlogRepo;

        public HomeController()
        {
            BlogRepo = new BlogRepository();
        }

        public HomeController(IBlogRepository repository)
        {
            BlogRepo = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
       //     string time = DateTime.Now.ToLongTimeString();
         //   ViewData["time"] = time;

       //     ViewBag.time = DateTime.Now;

            var AllBlogs = BlogRepo.FindAllBlogs();
            return View(AllBlogs);
        }

        public ActionResult Details(int id)
        {
            //Response.Write("<h1>Details DinnerID: " + id + "</h1>");
            Blog blog = BlogRepo.FindBlog(id);
            if (blog == null)
                return View("NotFound");

            return View(BlogRepo.FindBlog(id));
        }


                public ActionResult Delete(int id)
        {
            ViewData["Message"] = "Are you sere you want to delete this blog?";
            Blog blog = BlogRepo.FindBlog(id);
            return View(blog);
        }
 
        public ActionResult Create()
        {
            Blog blog = new Blog {UserName = "aalferez",RecCreationTime = DateTime.Now,ApplicationName = "/aalferez" };
            return View(blog);
        }
 
        [HttpPost]
        public ActionResult Create(FormCollection formValues)
        {
            Blog blog = new Blog { UserName = "aalferez", RecCreationTime = DateTime.Now, ApplicationName = "/aalferez" };
            if (TryUpdateModel(blog))
            {
                BlogRepo.AddBlog(blog);
                BlogRepo.SaveChanges();
                return RedirectToAction("Details", new { id = blog.BlogID });
            }
            return View();
        }
 
        [HttpPost]
        public ActionResult Delete(int id, string confirm)
        {
            Blog blog = BlogRepo.FindBlog(id);
            BlogRepo.DeleteBlog(blog);
            BlogRepo.SaveChanges();
            return View("Deleted");
        }
 
        //EDIT WITH GET ACTION
        public ActionResult Edit(int id)
        {
            return View(BlogRepo.FindBlog(id));
        }
 
        //EDIT WITH POST ACTION
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Blog blog = BlogRepo.FindBlog(id);
            if (TryUpdateModel(blog))
            {
                UpdateModel(blog);
                BlogRepo.SaveChanges();
                return RedirectToAction("Details", new { id = blog.BlogID });
            }
            return View(blog);
        }
    

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Angel()
        {
            return View();
        }
        public ActionResult AngelRazor()
        {
            return View();
        }
        public string Broken()
        {
            return "Hello Meeee";
        }
    }
}
