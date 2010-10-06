using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Repositories;
using HospitalManager.Models;
using HospitalManager.ViewModels;
using AutoMapper;

namespace HospitalManager.Controllers
{
    public class HomeController : Controller
    {
        UserRepository repository;

        public HomeController()
        {
            repository = new UserRepository();
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult UserLog(String id)
        {
            User user = repository.GetUserByUsername(id);
            UserViewModel userVm = Mapper.Map<User, UserViewModel>(user);
            return View(userVm);

        }

    }
}
