﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Models;
using HospitalManager.Repositories;
using HospitalManager.ViewModels;
using AutoMapper;

namespace HospitalManager.Controllers
{
    public class AppointmentController : Controller
    {
        private UserRepository        urep;
        private AppointmentRepository apprep;
        private SessionRepository     sessrep;


        public AppointmentController()
        {

            urep = new UserRepository();
            apprep = new AppointmentRepository();
            sessrep = new SessionRepository();
        }
        public ActionResult Index()
        {
            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }

            User user = sessrep.GetUser();

            //If user is a patient then list their appointments
            if (user.TypeID == UserType.PatientTypeID)
            {
                IQueryable<VWAppointments> appointments = apprep.GetUserAppointments(user.UserID);
                List<AppointmentViewModel> AppointmentViewModels = new List<AppointmentViewModel>();
                Mapper.CreateMap<VWAppointments,AppointmentViewModel>();

                foreach(var app in appointments)
                {
                    AppointmentViewModels.Add(Mapper.Map<VWAppointments,AppointmentViewModel>(app));
                }

                var am = new AppointmentViewModel { appointments = AppointmentViewModels};

                return View(am);
            }

            //If user is a doctor then list their appointments
            else if (user.TypeID == UserType.DoctorTypeID)
            {
                IQueryable<VWAppointments> appointments = apprep.GetDoctorAppointments(user.UserID);
                List<AppointmentViewModel> AppointmentViewModels = new List<AppointmentViewModel>();
                Mapper.CreateMap<VWAppointments, AppointmentViewModel>();

                foreach (var app in appointments)
                {
                    AppointmentViewModels.Add(Mapper.Map<VWAppointments, AppointmentViewModel>(app));
                }

                var am = new AppointmentViewModel { appointments = AppointmentViewModels};
                
                return View(am);
            }

            //Else just return a null viewmodel
            else
                return View((AppointmentViewModel)null);
        }

        public ActionResult Schedule()
        {
            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }

            var docs = urep.GetAllUsersBasedOnType(UserType.DoctorTypeID);
            AppointmentViewModel vm = new AppointmentViewModel { Doctors = docs.ToList()};
            return View(vm);
        }

        public ActionResult SelectTime(int DoctorID, DateTime Date)
        {
            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }

            var times = apprep.GetDoctorAvaliablity(DoctorID, Date) ;
            AppointmentViewModel vm = new AppointmentViewModel { Times = times  };
            return View(vm);
        }

        public ActionResult AddAppointment(int DoctorID, DateTime Date, TimeSpan Time)
        {
         
            User user = sessrep.GetUser();
            IQueryable<VWAppointments> appointments = apprep.GetUserAppointments(user.UserID);
            foreach (var checkapp in appointments)
            { 
                if(checkapp.Date == Date)
                {
                    if (checkapp.Time == Time)
                    {
                        return Redirect("/Appointment/Schedule");
                    }
                }
            }


            Appointment app = new Appointment { UserID = user.UserID, DoctorID = DoctorID, Date = Date.Date, Time = Time };
            apprep.InsertAppointment(app);

            return Redirect("/Appointment/Index");
        }

        public ActionResult Cancel()
        {

            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }

            User user = sessrep.GetUser();
            //If user is a patient then list their appointments
            if (user.TypeID == UserType.PatientTypeID)
            {
                IQueryable<VWAppointments> appointments = apprep.GetUserAppointments(user.UserID);
                List<AppointmentViewModel> AppointmentViewModels = new List<AppointmentViewModel>();
                Mapper.CreateMap<VWAppointments, AppointmentViewModel>();

                foreach (var app in appointments)
                {
                    AppointmentViewModels.Add(Mapper.Map<VWAppointments, AppointmentViewModel>(app));
                }

                var am = new AppointmentViewModel { appointments = AppointmentViewModels };

                return View(am);
            }

                        //If user is a doctor then list their appointments
            else if (user.TypeID == UserType.DoctorTypeID)
            {
                IQueryable<VWAppointments> appointments = apprep.GetDoctorAppointments(user.UserID);
                List<AppointmentViewModel> AppointmentViewModels = new List<AppointmentViewModel>();
                Mapper.CreateMap<VWAppointments, AppointmentViewModel>();

                foreach (var app in appointments)
                {
                    AppointmentViewModels.Add(Mapper.Map<VWAppointments, AppointmentViewModel>(app));
                }

                var am = new AppointmentViewModel { appointments = AppointmentViewModels };

                return View(am);
            }

            return View();
        }

        public ActionResult CancelApp(int AppointmentID)
        {
            Appointment app = apprep.GetAppointmentByAppointmentID(AppointmentID);

            apprep.CancelAppointment(app);

            return Redirect("/Appointment/Index");
        }
    }
}
