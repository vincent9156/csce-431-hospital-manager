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

                IQueryable<User> users;

                // Get the list of users based on the permission of the person searching
                if(loggedInUser.HasAccess(AccessOptions.SearchAllPatients))
                {
                    users = UserRep.GetUserByName(firstName, lastName, UserType.PatientTypeID);
                }
                else {
                    // Currently gets all patients. TODO: Get only patients under the logged in user.
                    users = UserRep.GetUserByName(firstName, lastName, UserType.PatientTypeID);
                }

                // Create a result list of (of UserViewModels) containing the found users
                List<UserViewModel> userViewModels = new List<UserViewModel>();
                foreach (var user in users)
                {
                    userViewModels.Add(Mapper.Map<User, UserViewModel>(user));
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
