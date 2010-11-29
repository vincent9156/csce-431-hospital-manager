using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Repositories;
using HospitalManager.Models;
using HospitalManager.ViewModels;
using HospitalManager.Libraries;
using AutoMapper;


namespace HospitalManager.Controllers
{
    /// <summary>
    /// Handles the user homepage and editing the user profile information
    /// </summary>
    public class HomeController : Controller
    {
        UserRepository repository;
        SessionRepository sessRep;

        public HomeController()
        {
            repository = new UserRepository();
            sessRep = new SessionRepository();
        }

        /// <summary>
        /// Redirect to the user's homepage or the login page
        /// </summary>
        /// <returns>Redirect to the correct page</returns>
        public ActionResult Index()
        {
            if (sessRep.IsLoggedIn())
                return Redirect("/Home/UserLog");
            return Redirect("/Authentication/Login");
        }

        // does the following need to exist? probably not...
        /*public ActionResult EditMedicalHistory()
        {
            if (sessRep.IsLoggedIn())
            return View();
            return Redirect("/Authentication/Login/");
        }*/

        /// <summary>
        /// Allow the user to edit their profile information
        /// </summary>
        /// <param name="usermodel">ViewModel containing data from the form</param>
        /// <returns>The same page, but containing the updated information or error messages</returns>
        [HttpPost]
        public ActionResult EditProfile(UserRegistrationViewModel usermodel)
        {
            User user = sessRep.GetUser();
            usermodel.Permissions = repository.GetUserTypeByID(user.TypeID).Permissions;

            var u = repository.GetUserByUsername(usermodel.Username);
            if ((u != null) && (u.UserID != user.UserID))
            {
                ModelState.AddModelError("Username", "Requested username already in use");
                return View("ViewProfile", usermodel);
            }

            user.FirstName = usermodel.FirstName;
            user.LastName = usermodel.LastName;
            user.Email = usermodel.Email;
            if (!user.HasAccess(AccessOptions.RegisterWithoutStaffID))
            {
                user.Speciality = usermodel.Speciality;
            }
            repository.EditUserByUsername(usermodel.Username, user);
            user.Username = usermodel.Username;
            sessRep.Logout();
            sessRep.Login(user);
            return Redirect("/Home/ViewProfile");
        }

        /// <summary>
        /// Show the user their profile information and allow them to edit it.
        /// </summary>
        /// <returns>View allowing a user to edit their profile</returns>
        public ActionResult ViewProfile()
        {
            if (sessRep.IsLoggedIn())
            {
                var vm = new UserRegistrationViewModel();
                User user = sessRep.GetUser();
                vm.FirstName = user.FirstName;
                vm.LastName = user.LastName;
                vm.Username = user.Username;
                vm.Email = user.Email;
                vm.Permissions = repository.GetUserTypeByID(user.TypeID).Permissions;
                if (!user.HasAccess(AccessOptions.RegisterWithoutStaffID))
                {
                    vm.Speciality = user.Speciality;
                }
                ViewData["UType"] = user;
                return View(vm);
            }
            else
            {
                return Redirect("/Authentication/Login/");
            }
        }

        /// <summary>
        /// Display the user's home page
        /// </summary>
        /// <returns>View which has all the options available to a user</returns>
        public ActionResult UserLog()
        {
            if (sessRep.IsLoggedIn())
            {
                User user = sessRep.GetUser();
                UserViewModel userVm = Mapper.Map<User, UserViewModel>(user);
                return View(userVm);
            }
            else
            {
                return Redirect("/Authentication/Login/");
            }
        }
    }
}
