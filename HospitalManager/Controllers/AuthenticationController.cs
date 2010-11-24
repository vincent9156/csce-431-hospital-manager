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
    /// <summary>
    /// This controller handles all of the logic associated with registering,
    /// logging in and setting up a user.
    /// </summary>
    public class AuthenticationController : Controller
    {
        /// <summary>
        /// Used for registration, login, and changing passwords
        /// </summary>
        UserRepository UserRep = new UserRepository();

        /// <summary>
        /// Used for login, logout and authentication
        /// </summary>
        SessionRepository SessionRep = new SessionRepository();

        /// <summary>
        /// Used for setting up patient billing information at registration
        /// </summary>
        BillingInformationRepository BillInfoRep = new BillingInformationRepository();


        /// <summary>
        /// Redirects a user to their dashboard or the login screen depending
        /// upon if they are logged in
        /// </summary>
        /// <returns>A redirection view varying with their login state</returns>
        public ActionResult Index()
        {
            if (SessionRep.IsLoggedIn())
                return Redirect("/Home/UserLog/");
            return Redirect("/Authentication/Login/");
        }

        /// <summary>
        /// Creates the form for a user to login
        /// </summary>
        /// <returns>A login view</returns>
        public ActionResult Login()
        {
            // Do not allow logging in if the user is already logged in
            if (SessionRep.IsLoggedIn())
                return Redirect("/Home/UserLog/");
            User user = new User();
            return View(user);
        }

        /// <summary>
        /// Attempts to log a user into the system. If successful, redirect them to the
        /// dashboard, otherwise, return an error
        /// </summary>
        /// <param name="username">The user's inputted usename</param>
        /// <param name="password">The user's inputted password</param>
        /// <returns>A view varying with the login's success</returns>
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

                return Redirect("/Home/UserLog/");
            }
            else
            {
                // bad password or some other problem
                ModelState.AddModelError("username", "Username or password is incorrect");
                return View();
            }
        }

        /// <summary>
        /// Logs a user out of the system
        /// </summary>
        /// <returns>A redirection to the login screen</returns>
        public ActionResult Logoff()
        {
            SessionRep.Logout();
            return Redirect("/Authentication/Login/");
        }

        /// <summary>
        /// Begin registering a user by giving them a list of user types
        /// </summary>
        /// <returns>The registration view with a list of user types</returns>
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

        /// <summary>
        /// Continue registering a user with their submitted user type
        /// </summary>
        /// <param name="userTypes">The type of the user to be registered</param>
        /// <returns>The registration view with the input form</returns>
        [HttpPost]
        public ActionResult Register(UserTypesViewModel userTypes)
        {
            var newUser = new UserRegistrationViewModel();

            // Load the user's permissions
            newUser.Permissions = UserRep.GetUserTypeByID(userTypes.TypeID).Permissions;

            return View("RegisterUser", newUser);
        }

        
        /// <summary>
        /// Attempt to complete user registration by validating their input and either
        /// creating the user or returning an error
        /// </summary>
        /// <param name="user">The user to be registered</param>
        /// <returns>
        /// The view with errors or a redirection to the next step in the 
        /// registration process
        /// </returns>
        [HttpPost]
        public ActionResult RegisterUser(UserRegistrationViewModel user)
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

            // Check if the username is already in use
            if (UserRep.GetUserByUsername(user.Username) != null)
            {
                ModelState.AddModelError("Username", "Username already in use");
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

            // redirect to billing info if a Patient, else go to the homepage
            if (newUser.TypeID == UserType.PatientTypeID)
                return Redirect("/Authentication/BillingInfo");
            else
                return Redirect("/Home/UserLog");
            
        }

        /// <summary>
        /// Start collecting the billing information for a user.
        /// Only Patients should be able to access this.
        /// Handles adding and editing.
        /// </summary>
        /// <returns>The view for setting up the user's billing information</returns>
        public ActionResult BillingInfo()
        {
            if (!SessionRep.IsLoggedIn() || (SessionRep.GetUser().TypeID != UserType.PatientTypeID))
                return Redirect("/Authentication/Login");

            var billinfo = new UserBillingInfoViewModel
            {
                CardProvider = BillInfoRep.GetCardProviders()
            };
            var creditinfo = BillInfoRep.GetCreditCardInfo(SessionRep.GetUser().UserID);

            // billing info already exists, the user is trying to edit it
            // this means we need to load their data to pass to the view
            if (creditinfo != null)
            {
                billinfo.Address = creditinfo.BillingAddress;
                billinfo.CardNumber = creditinfo.CardNumber;
                billinfo.CardProviderID = creditinfo.CardProviderID;
                billinfo.ExpMonth = creditinfo.ExpirationMonth;
                billinfo.ExpYear = creditinfo.ExpirationYear;
                billinfo.PolicyNum = creditinfo.InsurancePolicyNumber;
                billinfo.ProviderName = creditinfo.InsuranceProviderName;
                billinfo.SecurityCode = creditinfo.SecurityCode;
            }

            return View(billinfo);
        }

        /// <summary>
        /// Finish adding or editting billing information for the user
        /// </summary>
        /// <param name="billinfo">The information to be added or editted</param>
        /// <returns>A redirection to their home or the view if an error occurs</returns>
        [HttpPost]
        public ActionResult BillingInfo(UserBillingInfoViewModel billinfo)
        {
            if (!SessionRep.IsLoggedIn() || (SessionRep.GetUser().TypeID != UserType.PatientTypeID))
                return Redirect("/Authentication/Login");
            billinfo.CardProvider = BillInfoRep.GetCardProviders();
            if (!ModelState.IsValid)
            {
                return View(billinfo);
            }

            var info = new CreditCardInformation();
            info.BillingAddress = billinfo.Address;
            info.CardNumber = billinfo.CardNumber;
            info.CardProviderID = billinfo.CardProviderID;
            info.ExpirationMonth = billinfo.ExpMonth;
            info.ExpirationYear = billinfo.ExpYear;
            info.InsurancePolicyNumber = billinfo.PolicyNum;
            info.InsuranceProviderName = billinfo.ProviderName;
            info.SecurityCode = billinfo.SecurityCode;
            info.UserID = SessionRep.GetUser().UserID;

            // if the billing info already exists, edit it and return to their profile edit page
            // otherwise, create it and go to the user's homepage
            if (BillInfoRep.GetCreditCardInfo(SessionRep.GetUser().UserID) != null)
            {
                BillInfoRep.EditBillingInfo(info);
                return Redirect("/Home/ViewProfile");
            }
            else
            {
                BillInfoRep.CreateBillingInfo(info);
                return Redirect("/Home/Userlog");
            }
        }

        /// <summary>
        /// Begin changing a user's password
        /// </summary>
        /// <returns>The view to change the password</returns>
        public ActionResult ChangePassword()
        {
            if (!SessionRep.IsLoggedIn())
                return Redirect("/Authentication/Login");
            var pass = new ChangePasswordViewModel();
            return View("ChangePassword", pass);
        }

        /// <summary>
        /// Attempt to validate and change the user's password
        /// </summary>
        /// <param name="pass">The password information to change</param>
        /// <returns>The resulting view</returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel pass)
        {
            if (!SessionRep.IsLoggedIn())
                return Redirect("/Authentication/Login");
            if (!SessionRep.GetUser().EncryptedPasswordEquals(pass.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "Incorrect password");
                return View();
            }
            if (!ModelState.IsValid)
                return View(pass);

            var user = SessionRep.GetUser();
            user = UserRep.ChangeUserPassword(user, pass.Password);
            SessionRep.Logout();
            SessionRep.Login(user);
            return Redirect("/Home/ViewProfile");
        }
    }
}
