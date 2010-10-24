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
        UserRepository UserRep;
        SessionRepository SessionRep;

        public AuthenticationController()
        {
            UserRep = new UserRepository();
            SessionRep = new SessionRepository();
        }

        // GET: /Authentication/
        public ActionResult Index()
        {
            if (SessionRep.IsLoggedIn())
                return Redirect("/Home/UserLog/");
            return Redirect("/Authentication/Login/");
        }

        public ActionResult Login()
        {
            // do not allow logging in if the user is already logged in
            if (SessionRep.IsLoggedIn())
                return Redirect("/Home/UserLog/");
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // do not allow logging in if the user is already logged in
            if (SessionRep.IsLoggedIn())
                return Redirect("/Home/UserLog/");

            User user = UserRep.GetUserByUsername(username);

            if (user == null)
            {
                // bad username
                ModelState.AddModelError("username", "Username or password is incorrect");
                return View();
            }
            else if (user.EncryptedPasswordEquals(password))
            {
                // success
                SessionRep.Login(user);

                // TODO: redirect to user's home page (right now it just returns to the login form)
                ModelState.AddModelError("username", "Login success!");

                return Redirect("/Home/UserLog/");
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
            SessionRep.Logout();
            return Redirect("/Authentication/Login/");
        }

        /**
         * Begin registering a user.
         */
        public ActionResult Register()
        {
            if (SessionRep.IsLoggedIn())
                return Redirect("/Home/UserLog/");

                var types = new UserTypesViewModel
                {
                    UserTypes = UserRep.GetUserTypes()
                };
                return View("RegisterUserType", types);
        }

        /**
         * After we have their user type in registration, get their user information.
         */
        [HttpPost]
        public ActionResult Register(UserTypesViewModel userTypes)
        {
            var newUser = new UserRegistrationViewModel();

            // Load the user's permissions
            newUser.Permissions = UserRep.GetUserTypeByID(userTypes.TypeID).Permissions;

            return View("RegisterUser", newUser);
        }

        
        /**
         * Complete user registration and validate all of their information.
         */
        [HttpPost]
        public ActionResult RegisterUser(UserRegistrationViewModel user, int staffID = -1)
        {
            if (SessionRep.IsLoggedIn())
                return Redirect("/Home/UserLog/");
                // Load the user's permissions
                user.Permissions = UserRep.GetUserTypeByID(user.TypeID).Permissions;

                // Validate their input
                if (!ModelState.IsValid)
                {
                    return View(user);
                }

                // Register the user
                User newUser;
                switch (user.TypeID)
                {
                    case UserType.DoctorTypeID:
                        newUser = Mapper.Map<UserRegistrationViewModel, Doctor>(user);
                        break;
                    case UserType.NurseTypeID:
                        newUser = Mapper.Map<UserRegistrationViewModel, Nurse>(user);
                        break;
                    case UserType.PharmacistTypeID:
                        newUser = Mapper.Map<UserRegistrationViewModel, Pharmacist>(user);
                        break;
                    default:
                        newUser = Mapper.Map<UserRegistrationViewModel, Patient>(user);
                        break;
                }

                newUser.EncryptAndSetPassword(newUser.Password);
                UserRep.AddUser(newUser);

                // Log the user into their new account
                SessionRep.Login(newUser);

                // redirect to homepage
                return Redirect("/Home/UserLog/");
            
        }
    }
}
