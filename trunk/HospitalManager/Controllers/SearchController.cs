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
        UserRepository UserRep = new UserRepository();
        SessionRepository SessRep = new SessionRepository();

        public ActionResult SearchUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindUser(string firstName, string lastName)
        {
            IQueryable<User> users = UserRep.GetUserByName(firstName, lastName);
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModels.Add(Mapper.Map<User, UserViewModel>(user));
            }

            var vm = new SearchViewModel
            {
                LoggedInUser = Mapper.Map<User, UserViewModel>(SessRep.GetUser()),
                SearchResults = userViewModels
            };
            return View(vm);
        }
    }
}
