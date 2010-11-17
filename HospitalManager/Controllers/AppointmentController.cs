using System;
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
        private BillingRepository     billrep;


        public AppointmentController()
        {

            urep = new UserRepository();
            apprep = new AppointmentRepository();
            sessrep = new SessionRepository();
            billrep = new BillingRepository();
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

            User user = sessrep.GetUser();

            var times = apprep.GetDoctorAvaliablity(DoctorID, user.UserID, Date) ;
            AppointmentViewModel vm = new AppointmentViewModel { Times = times, Date = Date, DoctorID = DoctorID  };
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
                return Redirect("/Appointment/DocCancel");
            }

            return View();
        }

        public ActionResult DocCancel()
        {

            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }

            User user = sessrep.GetUser();

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

        public ActionResult CancelApp(int AppointmentID)
        {
            Appointment app = apprep.GetAppointmentByAppointmentID(AppointmentID);
            DateTime now = DateTime.Now;
            User user = sessrep.GetUser();

            int UID = app.UserID;
            int DID = app.DoctorID;
            float cost = (float)25.00;
            string reason = "Late Cancellation Fee";
            
            if(user.TypeID == UserType.PatientTypeID)
            if (app.Date.Year == now.Year)
            {
                int date1 = app.Date.DayOfYear;
                int date2 = now.DayOfYear;
                int diff = date1 - date2;

                if ((diff <= 2) && date1 > date2)
                {
                    CancellationBill bill = new CancellationBill {
                    DoctorID = DID,
                    UserID = UID,
                    Amount = cost,
                    AppDate = app.Date,
                    BillDate = now,
                    FeeType = reason,
                    Paid = false,
                    };

                    billrep.BillCancellation(bill);                    
                }
            }

            //handle cases for appointments in early January being canceled at the end of December
            if ((app.Date.Year > now.Year) && (app.Date.Year - now.Year == 1))
            {
                int date1 = app.Date.DayOfYear;
                int date2 = now.DayOfYear;
               
                //check for leap year
                if(!DateTime.IsLeapYear(now.Year))
                {
                    if(((date1 == 1) || (date1 == 2)) && ((date2 == 364) || (date2 == 365)))
                    {
                        CancellationBill bill = new CancellationBill {
                        DoctorID = DID,
                        UserID = UID,
                        Amount = cost,
                        AppDate = app.Date,
                        BillDate = now,
                        FeeType = reason,
                        Paid = false,
                        };

                        billrep.BillCancellation(bill);                
                    }                
                }
                else
                if(((date1 == 1) || (date1 == 2)) && ((date2 == 365) || (date2 == 366)))
                {
                    CancellationBill bill = new CancellationBill {
                    DoctorID = DID,
                    UserID = UID,
                    Amount = cost,
                    AppDate = app.Date,
                    BillDate = now,
                    FeeType = reason,
                    Paid = false,
                    };

                    billrep.BillCancellation(bill); 
                }            
            }


            if (user.TypeID == UserType.DoctorTypeID)
            { 
            
            
            }

            apprep.CancelAppointment(app);

            return Redirect("/Appointment/Index");
        }
    }
}
