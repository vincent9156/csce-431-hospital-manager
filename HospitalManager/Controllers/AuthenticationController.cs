using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Repositories;
using HospitalManager.ViewModels;
using HospitalManager.Models;

namespace HospitalManager.Controllers
{
    public class AuthenticationController : Controller
    {
        /**
         * Get an instance of the user repository
         */
        UserRepository userRepository;

        public AuthenticationController()
        {
            userRepository = new UserRepository();
        }

        //
        // GET: /Authentication/

        public ActionResult Index()
        {
            return Redirect("/Authentication/Login/");
        }

        public ActionResult Register()
        {
            var types = new UserTypesViewModel
            {
                UserTypes = userRepository.GetUserTypes()
            };
            return View(types);
        }

        [HttpPost]
        public ActionResult Register(UserType type)
        {
            User newUser = null;
            switch (type.TypeID)
            {
                case UserType.PatientTypeID:
                    newUser = new Patient();
                    break;
                case UserType.DoctorTypeID:
                    newUser = new Doctor();
                    break;
                case UserType.NurseTypeID:
                    newUser = new Nurse();
                    break;
                case UserType.PharmacistTypeID:
                    newUser = new Pharmacist();
                    break;
            }
            return View(newUser);
        }
        /*
        public ActionResult Register(User user)
        {

        }
        */
    }
}
