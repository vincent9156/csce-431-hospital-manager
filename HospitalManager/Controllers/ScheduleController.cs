using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Models;
using HospitalManager.Repositories;

namespace HospitalManager.Controllers
{
    public class ScheduleController : Controller
    {
        private UserRepository UserRep;
        private SessionRepository SessionRep;
        private ScheduleRepository SchdRep;

        public ScheduleController()
        {
            UserRep = new UserRepository();
            SessionRep = new SessionRepository();
            SchdRep = new ScheduleRepository();
        }

        public ActionResult Index(int userid, string month, int year)
        {
            var sched = SchdRep.ListDoctorSchedule(userid,month,year);
            return View(sched);
        }

    }
}
