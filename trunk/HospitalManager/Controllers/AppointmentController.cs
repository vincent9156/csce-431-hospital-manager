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


        /// <summary>
        /// Default constructor for the appoitnment controller class
        /// Creates several repositories for use later inside of the controller
        /// Logic
        /// </summary>
        public AppointmentController()
        {

            urep = new UserRepository();
            apprep = new AppointmentRepository();
            sessrep = new SessionRepository();
            billrep = new BillingRepository();
        }

        /// <summary>
        /// Default view for appointments.
        /// First makes sure that user is logged in, then determines if the user
        /// is a doctor or patient. Based on if the user is a doctor or patient
        /// determines what repository logic we use to grab the appointments for that
        /// user. These appointments are then mapped to an appointment view model which
        /// is returned to the view
        /// </summary>
        /// <returns>
        /// A appointment view model that contains all appointments for the user
        /// </returns>
        public ActionResult Index()
        {
            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }

            User user = sessrep.GetUser();

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

            else
                return View((AppointmentViewModel)null);
        }

        /// <summary>
        /// Creates a simple form where user can select from
        /// doctors that currently work at the hospital. 
        /// </summary>
        /// <returns>
        /// Returns a view model containing all doctors at the hospital.
        /// Allows us to list all doctors the user can schdule an appointment
        /// with.
        /// </returns>
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

        /// <summary>
        /// Allows user to select a time for an appointment with a specific
        /// doctor on a given date. Where the user has already selected the
        /// doctor and date from the schedule view above.
        /// </summary>
        /// <param name="DoctorID">Doctor ID selected by the user</param>
        /// <param name="Date">Date selected by the user</param>
        /// <returns>
        /// Returns a view model contianing the avaliable times for a selected
        /// doctor and a selected date to the view
        /// </returns>
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

        /// <summary>
        /// Adds appointment for user based on selected doctor, date, and time
        /// </summary>
        /// <param name="DoctorID">Doctor selected by user</param>
        /// <param name="Date">Date selected by user</param>
        /// <param name="Time">Time selected by user</param>
        /// <returns>
        /// Redirects user to the appoinment index view. So that they can see thier
        /// newly scheduled appointment
        /// </returns>
        public ActionResult AddAppointment(int DoctorID, DateTime Date, TimeSpan Time)
        {
         
            User user = sessrep.GetUser();
            IQueryable<VWAppointments> appointments = apprep.GetUserAppointments(user.UserID);
            
            //Make sure that the appointment the user is trying to schedule
            //is not already in the system.
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

        /// <summary>
        /// Allows user be it doctor or patient to cancel any of thier current appointments.
        /// </summary>
        /// <returns>
        /// For patients this logic returns a list of their appointmets to the view
        /// so that they may cancel one of their appointments. For doctors trying to
        /// cancel an appoitntmet they are redirected to the DocCancel logic located below
        /// </returns>
        public ActionResult Cancel()
        {

            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }

            User user = sessrep.GetUser();
           
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

            
            else if (user.TypeID == UserType.DoctorTypeID)
            {
                return Redirect("/Appointment/DocCancel");
            }

            return View();
        }


        /// <summary>
        /// Allows doctors to cancel thier appointments
        /// </summary>
        /// <returns>
        /// Returns a list of the doctor's appointments so that they can
        /// choose one to cancel
        /// </returns>
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

        /// <summary>
        /// Provides a way for doctors to reschedule appointments with patients
        /// </summary>
        /// <returns>
        /// Currently returns nothing to the view
        /// </returns>
        public ActionResult Reschedule(int ID)
        {
            User doctor = sessrep.GetUser();
            int DocID = doctor.UserID;
            string fname = doctor.FirstName;
            string lname = doctor.LastName;
            int PatientID = ID;

            var am = new AppointmentViewModel { UserID = PatientID, DoctorID = DocID, DoctorFirstName = fname, DoctorLastName = lname };

            return View(am);
        }

        public ActionResult RescheduleTime(int UserID, int DoctorID, DateTime Date)
        {
            if (!sessrep.IsLoggedIn())
            {
                return Redirect("/Authentication/Login");
            }
          
            var times = apprep.GetDoctorAvaliablity(DoctorID, UserID, Date);
            AppointmentViewModel vm = new AppointmentViewModel { Times = times, Date = Date, DoctorID = DoctorID, UserID = UserID};
            return View(vm);
        }


        public ActionResult RescheduleApp(int UserID, int DoctorID, DateTime Date, TimeSpan Time)
        {
            User user = sessrep.GetUser();
            IQueryable<VWAppointments> appointments = apprep.GetUserAppointments(user.UserID);

            //Make sure that the appointment the user is trying to schedule
            //is not already in the system.
            foreach (var checkapp in appointments)
            {
                if (checkapp.Date == Date)
                {
                    if (checkapp.Time == Time)
                    {
                        return Redirect("/Appointment/Schedule");
                    }
                }
            }

            Appointment app = new Appointment { UserID = UserID, DoctorID = DoctorID, Date = Date.Date, Time = Time };


            apprep.InsertAppointment(app);

            return Redirect("/Appointment/Index");        
        }
        /// <summary>
        /// Cancels a specfic appoitment selected by the user. 
        /// </summary>
        /// <param name="AppointmentID">Appointment selected by the user</param>
        /// <returns>
        /// Redirects user to either the appointment idex if a patient or the reschedule logic
        /// if a doctor
        /// </returns>
        public ActionResult CancelApp(int AppointmentID)
        {
            Appointment app = apprep.GetAppointmentByAppointmentID(AppointmentID);
            DateTime now = DateTime.Now;
            User user = sessrep.GetUser();
            bool reschedule = false;
            int reschedulePatient = 0;

            int UID = app.UserID;
            int DID = app.DoctorID;
            float cost = (float)25.00;
            string reason = "Late Cancellation Fee";
            
            //Charge user a cancellation fee if they have cancelled within 2 days of the
            //scheduled appointment
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

            // Force doctor to reschedule appointment they have cancelled
            if (user.TypeID == UserType.DoctorTypeID)
            {
                reschedulePatient = app.UserID;

                TempData["ID"] = reschedulePatient;

                if (app.Date.Year == now.Year)
                {
                    int date1 = app.Date.DayOfYear;
                    int date2 = now.DayOfYear;
                    int diff = date1 - date2;

                    if ((diff <= 2) && date1 > date2)
                    {
                        reschedule = true;
                    }
                }

            }

            reschedulePatient = app.UserID;
            apprep.CancelAppointment(app);

            if (reschedule)
            {
//                TempData["ID"] = reschedulePatient;
                return Redirect("/Appointment/Reschedule?ID="+reschedulePatient);
            }

            return Redirect("/Appointment/Index");
        }
    }
}
