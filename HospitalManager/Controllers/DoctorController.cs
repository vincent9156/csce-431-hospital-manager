using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Models;
using HospitalManager.Repositories;
using HospitalManager.ViewModels;

namespace HospitalManager.Controllers
{
    public class DoctorController : Controller
    {
        private UserRepository usrRep;
        private SessionRepository sessRep;
        private ScheduleRepository schedRep;

        public DoctorController()
        {
            usrRep = new UserRepository();
            sessRep = new SessionRepository();
            schedRep = new ScheduleRepository();
        }

        public ActionResult Index(DoctorViewModel dModel)
        {
            return View(dModel);
        }

    }
}
