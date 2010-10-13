using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.ViewModels;
using AutoMapper;
using HospitalManager.Models;
using HospitalManager.Repositories;

namespace HospitalManager.Controllers
{
    public class SearchController : Controller
    {
        [HttpPost]
        public ActionResult FindUser(string firstName, string lastName)
        {
            IQueryable<User> users = new UserRepository().GetUserByName(firstName, lastName);
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModels.Add(Mapper.Map<User, UserViewModel>(user));
            }

            var vm = new SearchViewModel
            {
                LoggedInUser = new SessionRepository().GetUser(),
                SearchResults = userViewModels
            };
            return View(vm);
        }
    }
}
