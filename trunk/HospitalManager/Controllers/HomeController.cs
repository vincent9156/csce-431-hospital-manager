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
            return Redirect("/Authentication/Login/");
        }

        public ActionResult EditMedicalHistory()
        {
            return View();
        }


        public ActionResult ViewProfile()
        {
            if (sessRep.IsLoggedIn())
            {
                User user = sessRep.GetUser();
                String FName = user.FirstName;
                String LName = user.LastName;
                String UName = user.Username;
                UserType UType = user.UserType;
                String EMail = user.Email;
                ViewData["FName"] = FName;
                ViewData["LName"] = LName;
                ViewData["UName"] = UName;
                ViewData["EMail"] = EMail;
            }
            return View();
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
