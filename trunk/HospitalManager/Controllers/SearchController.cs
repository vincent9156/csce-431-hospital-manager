using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.ViewModels;
using AutoMapper;
using HospitalManager.Models;
using HospitalManager.Repositories;
using HospitalManager.Libraries;

namespace HospitalManager.Controllers
{
    /// <summary>
    /// This controller handles the logic for searching for patients by users with permissions to find patients
    /// </summary>
    public class SearchController : Controller
    {
        /// <summary>
        /// Used for querying
        /// </summary>
        UserRepository UserRep = new UserRepository();

        /// <summary>
        /// Used to get logged in user for permissions
        /// </summary>
        SessionRepository SessRep = new SessionRepository();

        /// <summary>
        /// Gets users from database based on first and last name query
        /// </summary>
        /// <param name="firstName">The patient's firstname</param>
        /// <param name="lastName">The patient's lastname</param>
        /// <returns>SearchViewModel that contains patients matching search and logged in user</returns>
        public ActionResult SearchUser(string firstName = "", string lastName = "")
        {
            if (!SessRep.IsLoggedIn() || !SessRep.GetUser().HasAccess(AccessOptions.SearchUsers))
                return Redirect("/");

            //else return NULL SearchViewModel
            if (firstName != "" && lastName != "")
            {
                User loggedInUser = SessRep.GetUser();

                List<UserViewModel> userViewModels = new List<UserViewModel>();

                // Get the list of users based on the permission of the person searching
                if(loggedInUser.HasAccess(AccessOptions.SearchAllPatients))
                {
                    IQueryable<User> users = UserRep.GetUserByName(firstName, lastName, UserType.PatientTypeID);
                    foreach (var user in users)
                    {
                        userViewModels.Add(Mapper.Map<User, UserViewModel>(user));
                    }
                }

                //without permissions, Logged in user (Doctor) can only search for users (Patients) that have appointments with that Doctor
                else {
                    var users = UserRep.GetPatientByDoctor(loggedInUser.UserID, firstName, lastName);
                    foreach (var user in users)
                    {
                        userViewModels.Add(
                            new UserViewModel
                            {
                                UserID = user.UserID,
                                FirstName = user.PatientFirstName,
                                LastName = user.PatientLastName
                            }
                        );
                    }
                }

                // Load it all into a search view model
                var vm = new SearchViewModel
                {
                    LoggedInUser = Mapper.Map<User, UserViewModel>(loggedInUser),
                    SearchResults = userViewModels
                };
               return View(vm);
            }

            //Blank search page awaiting query
            return View((SearchViewModel)null);
        }
    }
}
