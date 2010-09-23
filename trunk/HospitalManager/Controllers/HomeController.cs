using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Models;
using HospitalManager.Repositories;
using HospitalManager.ViewModels;

namespace HospitalManager.Controllers
{
    public class HomeController : Controller
    {
        /**
         * Our default action for when the user visits /Home/
         */
        public ActionResult Index()
        {
            // Pull the information for person "Robert Paulson" from the repository
            var personRepository = new PersonRepository();
            Person p = personRepository.GetPersonByName("Robert", "Paulson");

            // Re-wrap the information for the person
            // The view doesn't need the person's credit card information
            var robert = new PersonViewModel()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Message = p.Message
            };

            // Give the PersonViewModel to the View (in this case, /Views/Home/Index)
            return View(robert);
        }

    }
}
