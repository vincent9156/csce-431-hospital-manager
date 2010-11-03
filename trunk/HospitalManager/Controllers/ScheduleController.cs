using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Models;
using HospitalManager.ViewModels;
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
            User user = SessionRep.GetUser();

            if (SessionRep.IsLoggedIn())
            {
                if (user.TypeID == UserType.DoctorTypeID)
                    return Redirect("/Schedule/Doctor/");
                else
                    return Redirect("/Schedule/Patient/");
            }

            else
                return Redirect("/Authentication/Login/");
        }

        public ActionResult Months(int id)
        {
            User user = UserRep.GetUserByUserID(id);
            return View(user);
            //return View();
        }

        public ActionResult Doctor()
        {
            return View();
        }

        public ActionResult Patient()
        {
            User user = SessionRep.GetUser();

            var sched = SchdRep.ListDoctors();

            return View(new ScheduleViewModel(user,user.UserID,sched));
        }

        public ActionResult Jan(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "January", 2010);
            return View(sched);
        }

        public ActionResult Feb(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "Feburary", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Mar(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "March", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Apr(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "April", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult May(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "May", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Jun(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "June", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Jul(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "July", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Aug(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "August", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Sep(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "September", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Oct(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "October", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Nov(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "November", DateTime.Today.Year);
            return View(sched);
        }

        public ActionResult Dec(int id)
        {
            User user = SessionRep.GetUser();
            var sched = SchdRep.ListDoctorSchedule(id, "December", DateTime.Today.Year);
            return View(sched);
        }
    }
}
