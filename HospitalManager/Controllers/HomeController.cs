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
    public class HomeController : Controller
    {
        UserRepository repository;
        SessionRepository sessRep;

        public HomeController()
        {
            repository = new UserRepository();
            sessRep = new SessionRepository();
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            if (sessRep.IsLoggedIn())
                return Redirect("/Home/UserLog");
            return Redirect("/Authentication/Login");
        }

        public ActionResult EditMedicalHistory()
        {
            if (sessRep.IsLoggedIn())
            return View();
            return Redirect("/Authentication/Login/");
        }

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
