using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class DinnersController : Controller
    {
        DinnerRepository dinnerRepository = new DinnerRepository();
        //
        // GET: /Dinners/

        public ActionResult Index()
        {
            var dinners = dinnerRepository.FindUpcomingDinners().ToList();
            return View(dinners);
        }

        //
        // GET: /Dinners/Details/2

        public ActionResult Details(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
                return View("NotFound");
            else
                return View(dinner);
        }

        //
        // GET: /Dinners/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);
            return View(new DinnerFormViewModel(dinner));
        }

        //
        // POST: /Dinners/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);
            if (TryUpdateModel(dinner))
            {
                dinnerRepository.Save();
                return RedirectToAction("Details", new { id = dinner.DinnerID });
            }

            return View(new DinnerFormViewModel(dinner));
        }

    //
    // GET: /Dinners/Create

        public ActionResult Create()
        {
            Dinner dinner = new Dinner()
            {
                EventDate = DateTime.Now.AddDays(7)
            };
            return View(new DinnerFormViewModel(dinner));
        }


        //
        // POST: /Dinners/Create

//        [HttpPost]
//        public ActionResult Create(FormCollection formValues)
//        {
//           Dinner dinner = new Dinner();
//            if (TryUpdateModel(dinner)) 
//            {
//                dinnerRepository.Add(dinner);
//                dinnerRepository.Save();
//                return RedirectToAction("Details", new { id = dinner.DinnerID });
//            }
//            return View(dinner);
//        }

        //
        // POST: /Dinners/Create

        [HttpPost]
        public ActionResult Create(Dinner dinner)
        {
            
            if (ModelState.IsValid)
            {
                dinner.HostedBy = "SomeUser";

                dinnerRepository.Add(dinner);
                dinnerRepository.Save();

                return RedirectToAction("Details", new { id = dinner.DinnerID });
            }
            return View(new DinnerFormViewModel(dinner));
        }



        //
        // GET: /Dinners/Delete/1

        
        public ActionResult Delete(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner ==null)
                return View("NotFound");
            else
                return View(dinner);
        }



        //
        // POST: /Dinners/Delete/1

        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
                return View("NotFound");

            dinnerRepository.Delete(dinner);
            dinnerRepository.Save();

            return View("Deleted");
        }
////-----------------------ONE WAY-----------------//
//            // Retrieve existing dinner
//            Dinner dinner = dinnerRepository.GetDinner(id);
//            //Update dinner with form posted values
//            dinner.Title = Request.Form["Title"];
//            dinner.Description =Request.Form["Description"];
//            dinner.EventDate = DateTime.Parse(Request.Form["EventDate"]);
//            dinner.Address = Request.Form["Address"];
//            dinner.Country = Request.Form["Country"];
//            dinner.ContactPhone =Request.Form["ContactPhone"];

//            // Persist changes back to database
//            dinnerRepository.Save();

//            // Perform HTTP redirect to details page for the saved Dinner
//            return RedirectToAction("Details", new { id = dinner.DinnerID });

}
}