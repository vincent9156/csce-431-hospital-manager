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

namespace HospitalManager.Controllers
{
    public class PastMedicalHistoryController : Controller
    {
        PastMedicalHistoryRepository histRep = new PastMedicalHistoryRepository();
        SessionRepository sessRep = new SessionRepository();

        User user;

        /**
         * Make sure the user is authenticated
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

        /**
         * Show the user their own medical history
         */
        public ActionResult Index()
        {
            if (!sessRep.IsLoggedIn())
                return Redirect("/Authentication/Login");

            PastMedicalHistory history = histRep.GetPastMedicalHistory(user);
            return View(history);
        }

        /**
         * Show the user their own medical history
         */
        public ActionResult ViewUserHistory(int id)
        {
            if (!sessRep.IsLoggedIn())
                return Redirect("/Authentication/Login");

            if (!user.HasAccess(AccessOptions.ViewPastMedicalHistories))
                return Redirect("/");

            PastMedicalHistory history = histRep.GetPastMedicalHistory(new User { UserID = id });
            return View(history);
        }

        /**
         * Allow the user to edit their medical history
         */
        public ActionResult Edit()
        {
            var vm = new UpdateMedicalHistoryViewModel();

            vm.UserHistory = histRep.GetPastMedicalHistory(user);
            if (vm.UserHistory == null)
            {
                vm.UserHistory = new PastMedicalHistory();
                vm.UserHistory.UserID = user.UserID;
                vm.UserHistory.LoadConditions();
            }
            vm.AllMedicalConditions = histRep.GetAllMedicalConditions().ToList();
            vm.AllFamilyMembers = histRep.GetAllFamilyMembers().ToList();

            return View(vm);
        }


        /**
         * Allow the user to edit their general medical history information
         */
        [HttpPost]
        public ActionResult Edit(UpdateMedicalHistoryViewModel vm)
        {
            // Make sure they submitted a history
            if (vm == null)
                return Redirect("/PastMedicalHistory/Edit");

            vm.UserHistory.UserID = user.UserID;
            histRep.SetPastMedicalHistory(vm.UserHistory);

            // Return them to the edit page
            return Redirect("/PastMedicalHistory/Edit");
        }

        /**
         * Allow the user to remove medical conditions
         */
        public ActionResult RemoveCondition(int id = -1)
        {
            if (id == -1)
                Redirect("/PastMedicalHistory/Edit");

            try
            {
                histRep.DeletePatientMedicalCondition(user, id);
            }
            finally
            {
                // Ignore delete errors, it was either malicious or user error
            }

            return Redirect("/PastMedicalHistory/Edit");
        }

        /**
         * Allow the user to add medical conditions
         */
        [HttpPost]
        public ActionResult AddCondition(int medicalCondition = -1)
        {
            if (medicalCondition == -1)
                Redirect("/PastMedicalHistory/Edit");

            histRep.AddPatientMedicalCondition(user, medicalCondition);

            return Redirect("/PastMedicalHistory/Edit");
        }

        /**
         * Allow the user to remove medical conditions
         */
        public ActionResult RemoveOtherCondition(int id = -1)
        {
            if (id == -1)
                Redirect("/PastMedicalHistory/Edit");

            try
            {
                histRep.DeleteOtherPatientMedicalCondition(user, id);
            }
            finally
            {
                // Ignore delete errors, it was either malicious or user error
            }

            return Redirect("/PastMedicalHistory/Edit");
        }

        /**
         * Allow the user to add medical conditions
         */
        [HttpPost]
        public ActionResult AddOtherCondition(string condition = "")
        {
            if (condition == "")
                Redirect("/PastMedicalHistory/Edit");

            condition = Regex.Replace(condition, "<.*?>", string.Empty);
            histRep.AddOtherPatientMedicalCondition(user, condition);

            return Redirect("/PastMedicalHistory/Edit");
        }

        /**
         * Allow the user to remove family medical conditions
         */
        public ActionResult RemoveFamilyCondition(int member = -1, int condition = -1)
        {
            if (member == -1 || condition == -1)
                Redirect("/PastMedicalHistory/Edit");

            try
            {
                histRep.DeleteFamilyMedicalCondition(user, member, condition);
            }
            finally
            {
                // Ignore delete errors, it was either malicious or user error
            }

            return Redirect("/PastMedicalHistory/Edit");
        }


        /**
         * Allow the user to add family medical conditions
         */
        [HttpPost]
        public ActionResult AddFamilyCondition(int member = -1, int condition = -1)
        {
            if (member == -1 || condition == -1)
                Redirect("/PastMedicalHistory/Edit");

            histRep.AddFamilyMedicalCondition(user, member, condition);

            return Redirect("/PastMedicalHistory/Edit");
        }

        /**
         * Allow the user to remove other family medical conditions
         */
        public ActionResult RemoveOtherFamilyCondition(int id = -1)
        {
            if (id == -1)
                Redirect("/PastMedicalHistory/Edit");

            try
            {
                histRep.DeleteOtherFamilyMedicalCondition(user, id);
            }
            finally
            {
                // Ignore delete errors, it was either malicious or user error
            }

            return Redirect("/PastMedicalHistory/Edit");
        }

        /**
         * Allow the user to add other family medical conditions
         */
        [HttpPost]
        public ActionResult AddOtherFamilyCondition(int member = -1, string condition = "")
        {
            if (member == -1 || condition == "")
                Redirect("/PastMedicalHistory/Edit");

            condition = Regex.Replace(condition, "<.*?>", string.Empty);
            histRep.AddOtherFamilyMedicalCondition(user, member, condition);

            return Redirect("/PastMedicalHistory/Edit");
        }
    }
}
