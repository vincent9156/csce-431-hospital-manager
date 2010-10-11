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

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Jan()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "January", 2010);
            return View(sched);
        }

        public ActionResult Feb()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "Feburary", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Mar()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "March", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Apr()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "April", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult May()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "May", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Jun()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "June", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Jul()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "July", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Aug()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "August", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Sep()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "September", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Oct()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "October", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Nov()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "November", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Dec()
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(user.UserID, "December", DateTime.Today.Year);
            return View(sched);
        }
    }
}
