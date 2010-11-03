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
    public class CurrentMedicalHistoryController : Controller
    {
        CurrentMedicalHistoryRepository histRep = new CurrentMedicalHistoryRepository();
        SessionRepository sessRep = new SessionRepository();
        UserRepository userRep = new UserRepository();

        User user;

        /**
        * Make sure the user is authenticated (borrowed this from PastMedicalHistoryController)
        */
        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            if (!sessRep.IsLoggedIn() ||
                !sessRep.GetUser().HasAccess(AccessOptions.EditOwnMedicalHistory))
            {
                HttpContext.Response.Redirect("/");
                HttpContext.Response.End();
            }

            user = sessRep.GetUser();
        }
        

        //
        // GET: /CurrentMedicalHistory/
        
        public ActionResult Index()
        {

            if (!sessRep.IsLoggedIn())
                return Redirect("/Authentication/Login");

            var vm = new CurrentMedicalHistoriesViewModel
            {
                CurrentMedicalHistoryList = histRep.GetCurrentMedicalHistoryByUser(sessRep.GetUser()).ToList()
            };
            
            return View(vm);
        }
        /**
         * allow a doctor or nurse to add a visit record to a user who's UserID = UserId
         **/

        public ActionResult AddVisit(int UserId = -1)
        {
            // if they have not selected a user, send back to the home page
            if (UserId == -1)
                return Redirect("/Home");
            
            // make sure someone is logged in
            if (!sessRep.IsLoggedIn())
                return Redirect("/Authentication/Login");
            
            // check if doctor or nurse
            // do work here
            
            // get date
            DateTime dt = DateTime.Now; 
            

            // Fill in basic information about the Date and UserID (this is key for database)
            var vm = new CurrentMedicalHistory
            {
                UserID = UserId,
                Day = dt.Day,
                Month = dt.Month,
                Year = dt.Year,
                ReasonForVisit = "Reason For Visit",
                BloodPressure = "Blood Pressure",
                Diagnosis = "Diagnosis"
                
            };

            return View(vm);
        }

        /**
         * Allow the user to edit their general medical history information
         */
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
            return Redirect("/Home");
        }


    }
}
