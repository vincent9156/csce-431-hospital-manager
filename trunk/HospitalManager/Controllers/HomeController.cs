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

            if(Password == PasswordRepeat);
            user.Password = Password;
            user.FirstName = Firstname;
            user.LastName = Lastname;
            user.Email = EMail;
            repository.EditUserByUsername(Username, user);
            user.Username = Username;
            return Redirect("/Home/ViewProfile/");
        }

        public ActionResult ViewProfile()
        {
            if (sessRep.IsLoggedIn())
            {
                User user = sessRep.GetUser();
                String FName = user.FirstName;
                String LName = user.LastName;
                String UName = user.Username;
                String EMail = user.Email;
                ViewData["FName"] = FName;
                ViewData["LName"] = LName;
                ViewData["UName"] = UName;
                ViewData["EMail"] = EMail;
                ViewData["UType"] = user;
                return View();
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
