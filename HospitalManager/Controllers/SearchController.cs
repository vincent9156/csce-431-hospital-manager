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
    public class SearchController : Controller
    {
        UserRepository UserRep = new UserRepository();
        SessionRepository SessRep = new SessionRepository();

        public ActionResult SearchUser(string firstName = "", string lastName = "")
        {
            if (!SessRep.IsLoggedIn() || !SessRep.GetUser().HasAccess(AccessOptions.SearchUsers))
                return Redirect("/");

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

            return View((SearchViewModel)null);
        }
    }
}
