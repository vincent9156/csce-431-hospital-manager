using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Repositories;
using HospitalManager.Models;
using System.Web.Routing;
using HospitalManager.Libraries;
using HospitalManager.ViewModels;
using System.Text.RegularExpressions;
using AutoMapper;


namespace HospitalManager.Controllers
{
    /// <summary>
    /// This controller handles creating, editing, and viewing the patient's current medical history.
    /// </summary>
    public class CurrentMedicalHistoryController : Controller
    {
        /// <summary>
        /// Used to view and edit a user's current medical history
        /// </summary>
        CurrentMedicalHistoryRepository histRep = new CurrentMedicalHistoryRepository();

        /// <summary>
        /// Used to get the current user
        /// </summary>
        SessionRepository sessRep = new SessionRepository();

        /// <summary>
        /// Used to look up requested users
        /// </summary>
        UserRepository userRep = new UserRepository();

        /// <summary>
        /// Used to add appointments
        /// </summary>
        AppointmentRepository apptRep = new AppointmentRepository();

        /// <summary>
        /// The current user
        /// </summary>
        User user;

        /// <summary>
        /// Make sure the user is authenticated (borrowed this from PastMedicalHistoryController)
        /// </summary>
        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            // (assumes that anyone who can view medical histories can also edit)
            if (!sessRep.IsLoggedIn())
            {
                HttpContext.Response.Redirect("/");
                HttpContext.Response.End();
            }

            user = sessRep.GetUser();
        }
        
        /// <summary>
        /// Checks if the user has access to the patient's history and redirects appropriately.
        /// </summary>
        /// <param name="UserId">User id of the patient's history to access</param>
        /// <returns>Redirection depending on user permissions</returns>
        public ActionResult Index(int UserId = -1)
        {
            // make sure they asked for a user or send to the homepage
            if (UserId == -1)
                return Redirect("/Home");
            
            // Checks if they are a doctor or if they are viewing their own history 
            if (!sessRep.GetUser().HasAccess(AccessOptions.ViewPastMedicalHistories) 
                || (sessRep.GetUser().TypeID == 1 && !(sessRep.GetUser().UserID == UserId)))
                return Redirect("/Home");

            // if the user is a doctor, check to make sure the doctor is looking at the doctor's patient
            if (sessRep.GetUser().TypeID == 2 && !apptRep.isDoctorsPatient(sessRep.GetUser().UserID, UserId))
            {
                return Redirect("/Home");
            }

            var vm = new CurrentMedicalHistoriesViewModel
            {
                CurrentMedicalHistoryList = histRep.GetCurrentMedicalHistoryByUser(userRep.GetUserByUserID(UserId))
            };
            
            return View(vm);
        }

        /// <summary>
        /// Allow a doctor or nurse to add a visit record to a user.
        /// </summary>
        /// <param name="UserId">Add the visit record to this user</param>
        /// <returns>The AddVisit view</returns>
        public ActionResult AddVisit(int UserId = -1)
        {
            // if they have not selected a user, send back to the home page
            if (UserId == -1)
                return Redirect("/Home");

            // make sure they have permission to add a visit then check to make sure doctor is looking at the doctor's patient
            if (!sessRep.GetUser().HasAccess(AccessOptions.ViewPastMedicalHistories) || !apptRep.isDoctorsPatient(sessRep.GetUser().UserID, UserId))
                return Redirect("/Home");
            
            // get date
            DateTime dt = DateTime.Now; 
            

            // Fill in basic information about the Date and UserID
            var vm = new CurrentMedicalHistory
            {
                UserID = UserId,
                Day = dt.Day,
                Month = dt.Month,
                Year = dt.Year,
                ReasonForVisit = "Reason For Visit",
                BloodPressure = "Blood Pressure",
                Diagnosis = "Diagnosis",
                TestsRUN = "Tests Run",
                TotalFeeAmount = 0
                
            };

            return View(vm);
        }

        /// <summary>
        /// Allow Doctor to edit a User's general medical history information
        /// </summary>
        /// <param name="m">Viewmodel containing info from the form</param>
        /// <returns>Appropriate redirect depending on validity of information</returns>
        [HttpPost]
        public ActionResult AddVisit(CurrentMedicalHistory m)
        {
            // Make sure a CurrentMedicalHistory model was passed
            if (m == null)
                return Redirect("/AddVisit");
            
            // update date
            DateTime dt = DateTime.Now; 
            m.Day = dt.Day;
            m.Month = dt.Month;
            m.Year = dt.Year;

            int added = histRep.AddCurrentMedicalHistory(m);
            if (added == -1)
                return Redirect("/CurrentMedicalHistory/AddVisitError");
 
            // Return them to home
            return Redirect("/CurrentMedicalHistory/Index?UserId="+m.UserID);
        }
    }
}
