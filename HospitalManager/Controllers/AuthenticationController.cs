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
        BillingInformationRepository BillInfoRep;

        public AuthenticationController()
        {
            UserRep = new UserRepository();
            SessionRep = new SessionRepository();
            BillInfoRep = new BillingInformationRepository();
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

                // redirect to billing info if a Patient, else go to the homepage
                if (newUser.TypeID == UserType.PatientTypeID)
                    return Redirect("/Authentication/BillingInfo");
                else
                    return Redirect("/Home/UserLog");
            
        }

        /**
         * Start collecting the billing information for a user.
         * Only Patients should be able to access this.
         * Handles adding and editing.
         */
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

        /**
         * Finish adding/editing billing info for a user
         */
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

            // if the billing info already exists, edit it and show the results on the same page
            // otherwise, create it and go to the user's homepage
            if (BillInfoRep.GetCreditCardInfo(SessionRep.GetUser().UserID) != null)
            {
                BillInfoRep.EditBillingInfo(info);
                return View(billinfo);
            }
            else
            {
                BillInfoRep.CreateBillingInfo(info);
                return Redirect("/Home/Userlog");
            }
        }

        /**
         * Start changing a user's password
         */
        public ActionResult ChangePassword()
        {
            if (!SessionRep.IsLoggedIn())
                return Redirect("/Authentication/Login");
            var pass = new ChangePasswordViewModel();
            return View("ChangePassword", pass);
        }

        /**
         * Validate and change the user's password
         */
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
