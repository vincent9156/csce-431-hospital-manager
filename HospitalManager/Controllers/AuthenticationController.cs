using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
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

        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User user = userRepository.GetUserByUsername(username);

            if (user == null)
            {
                // bad username
                ModelState.AddModelError("username", "Username or password is incorrect");
                return View();
            }
            else if (user.EncryptedPasswordEquals(password))
            {
                // success
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(username, false, 120);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                // TODO: redirect to user's home page (right now it just returns to the login form)
                ModelState.AddModelError("username", "Login success!");
                return View();
            }
            else
            {
                // bad password or some other problem
                ModelState.AddModelError("username", "Username or password is incorrect");
                return View();
            }
        }

        public ActionResult Logoff()
        {
            // set the cookie to expire yesterday
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookie);
            return Redirect("/");
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
            return View("RegisterUserType", newUser);
        }
        
        /*
        [HttpPost]
        public ActionResult Register(User user)
        {

        }
        */
    }
}
