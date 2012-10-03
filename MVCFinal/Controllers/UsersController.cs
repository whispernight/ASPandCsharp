using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using dotNetMembership = System.Web.Security.Membership;
using dotNetRoles = System.Web.Security.Roles;

namespace kmsWDW.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        [Authorize]
        public ActionResult Index()
        {
            var users = dotNetMembership.GetAllUsers();
            return View(users);

        }

        //
        // GET: /Users/Details/5

        [Authorize]
        public ActionResult Details(string id)
        {
            var users = dotNetMembership.GetUser(id);

            if (users == null)
                return View("NotFound");
            else
                return View(users);

        }

        //
        // GET: /Users/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                dotNetMembership.CreateUser(Request.Form["Username"], Request.Form["Password"], Request.Form["Email"]);
                dotNetRoles.AddUserToRole(Request.Form["Username"], String.Join(",", dotNetRoles.GetRolesForUser()));

                return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }

            return View();
        }

        //
        // GET: /Users/Edit/5

        [Authorize]
        public ActionResult Edit(String id)
        {
            var users = dotNetMembership.GetUser(id);

            if (users == null)
                return View("NotFound");
            else
                ViewData["Roles"] = new SelectList(dotNetRoles.GetRolesForUser(), "Roles");
                return View(users);

        }

        //
        // POST: /Users/Edit/5

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Edit(String id, FormCollection collection)
        {
            try
            {
                var users = dotNetMembership.GetUser(id);

                users.Email = Request.Form["Email"];

                dotNetMembership.UpdateUser(users); 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // HTTP GET: /WDW/Delete/1
        
        [Authorize]
        public ActionResult Delete(string id)
        {

            var users = dotNetMembership.GetUser(id);

            if (users == null)
                return View("NotFound");
            else
                return View(users);


        }


        //  
        // HTTP POST: /WDW/Delete/1 

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Delete(string id, string confirmButton)
        {

            var users = dotNetMembership.GetUser(id);

            if (users == null)
                return View("NotFound");
            else
            {
                dotNetMembership.DeleteUser(id);
                return View("Deleted");
            }


        }

    }
}
