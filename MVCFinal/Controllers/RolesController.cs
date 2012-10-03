using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using dotNetRoles = System.Web.Security.Roles;

namespace kmsWDW.Controllers
{
    public class RolesController : Controller
    {
        //
        // GET: /Roles/

        [Authorize]
        public ActionResult Index()
        {
            var roles = dotNetRoles.GetAllRoles().ToList();
            return View(roles);

        }

        //
        // GET: /Roles/Details/5

        [Authorize]
        public ActionResult Details(string id)
        {
            var roles = dotNetRoles.GetUsersInRole(id).ToList();

            if (roles == null)
                return View("NotFound");
            else
            {
                ViewData["RoleId"] = id;
                return View(roles);
            }
        }

        //
        // GET: /Roles/RolesForUser/5

        [Authorize]
        public ActionResult ForUser(string id)
        {
            var UserRoles = dotNetRoles.GetRolesForUser(id).ToList();
            var roles = dotNetRoles.GetAllRoles().ToList();

            if (UserRoles == null)
                return View("NotFound");
            else
            {
                ViewData["UserName"] = id;
                ViewData["roles"] = roles;
                return View(UserRoles);
            }
        }

        //
        // GET: /Roles/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Create(FormCollection collection)
        {

            try
            {

                if (!dotNetRoles.RoleExists(Request.Form["CreateRole"]))
                {
                    dotNetRoles.CreateRole(Request.Form["CreateRole"]);
                    dotNetRoles.AddUserToRole(User.Identity.Name, Request.Form["CreateRole"]);
                }

                //return View();

                return RedirectToAction("Index");
            }
            catch
            {

            }

            return View();

        }


        //
        // GET: /Roles/Edit/5

        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Roles/Edit/5

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // HTTP GET: /Roles/Delete/1

        [Authorize]
        public ActionResult Delete(string id)
        {

            if (!dotNetRoles.RoleExists(id))
                return View("NotFound");
            else
            {
                ViewData["RoleId"] = id;
                return View();
            }

        }


        //  
        // HTTP POST: /Roles/Delete/1 

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Delete(string id, string confirmButton)
        {

            var usersinrole = dotNetRoles.GetUsersInRole(id).ToList();

            if (!dotNetRoles.RoleExists(id))
                return View("NotFound");
            else if (usersinrole.Count != 0)
                return View("NotFound");
            else
            {
                dotNetRoles.DeleteRole(id);
                return View("Deleted");
            }

        }

        //
        // HTTP GET: /Roles/RemoveFrom/1

        [Authorize]
        public ActionResult RemoveFrom(string id, string role)
        {

            ViewData["RoleId"] = role;
            ViewData["Id"] = id;
            return View();

        }

        //  
        // HTTP POST: /Roles/RemoveFrom/1 

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult RemoveFrom(string id, string role, string confirmButton)
        {

            dotNetRoles.RemoveUserFromRole(id, role);

            return View("RemovedFrom");

        }

        //
        // HTTP GET: /Roles/AddTo/1

        [Authorize]
        public ActionResult AddTo(string id, string role)
        {

            ViewData["RoleId"] = role;
            ViewData["Id"] = id;
            return View();

        }

        //  
        // HTTP POST: /Roles/AddTo/1 

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult AddTo(string id, string role, string confirmButton)
        {

            dotNetRoles.AddUserToRole(id, role);

            return View("AddedTo");

        }

    }
}
