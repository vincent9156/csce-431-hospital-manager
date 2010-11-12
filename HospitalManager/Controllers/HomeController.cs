using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Repositories;
using HospitalManager.Models;
using HospitalManager.ViewModels;
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
        public ActionResult EditProfile(String Username, String Password, String PasswordRepeat, String Firstname, String Lastname, String EMail)
        {
            User user = sessRep.GetUser();

            var u = repository.GetUserByUsername(Username);
            if ((u != null) && (u.UserID != user.UserID))
            {
                ModelState.AddModelError("Username", "Requested username already in use");
                return View("ViewProfile");
            }

            if(Password == PasswordRepeat);
            user.Password = Password;
            user.FirstName = Firstname;
            user.LastName = Lastname;
            user.Email = EMail;
            repository.EditUserByUsername(Username, user);
            user.Username = Username;
            sessRep.Logout();
            sessRep.Login(user);
            return Redirect("/Home/ViewProfile/");
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
