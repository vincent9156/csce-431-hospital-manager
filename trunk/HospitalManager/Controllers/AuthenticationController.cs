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
                // TODO: inform user of their mistake
                return Redirect("/Authentication/Login");
            }
            else if (user.EncryptedPasswordEquals(password))
            {
                // success
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(username, false, 120);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                // TODO: redirect to user's home page (right now it just returns to the login form)
                return View(user);
            }
            else
            {
                // bad password or some other problem
                // TODO: inform user of their mistake
                return Redirect("/Authentication/Login");
            }
        }

        public string Whoami()
        {
            // THIS CLASS IS JUST FOR TESTING AND WILL LIKELY DISAPPEAR
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            return ticket.Name;
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
