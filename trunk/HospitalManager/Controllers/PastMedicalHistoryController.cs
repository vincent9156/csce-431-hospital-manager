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
    /// <summary>
    /// This controller handles viewing and editing a patient's past medical history.
    /// </summary>
    public class PastMedicalHistoryController : Controller
    {
        /// <summary>
        /// Used to access and edit the current user's past medical history
        /// </summary>
        PastMedicalHistoryRepository histRep = new PastMedicalHistoryRepository();

        /// <summary>
        /// Used to get the current user
        /// </summary>
        SessionRepository sessRep = new SessionRepository();

        /// <summary>
        /// The current user
        /// </summary>
        User user;

        /// <summary>
        /// Make sure the user is authenticated.
        /// </summary>
        /// <param name="context">Context to initialize</param>
        protected override void Initialize(RequestContext context)
        {
            base.Initialize(context);

            if (!sessRep.IsLoggedIn())
            {
                HttpContext.Response.Redirect("/");
                HttpContext.Response.End();
            }

            user = sessRep.GetUser();
        }

        /// <summary>
        /// Show the user their own medical history
        /// </summary>
        /// <returns>A view containing the user's medical history</returns>
        public ActionResult Index()
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

            PastMedicalHistory history = histRep.GetPastMedicalHistory(user);
            return View(history);
        }

        /// <summary>
        /// Show the user their own medical history
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A view containing the user's medical history</returns>
        public ActionResult ViewUserHistory(int id)
        {
            if (!user.HasAccess(AccessOptions.ViewPastMedicalHistories))
                return Redirect("/");

            PastMedicalHistory history = histRep.GetPastMedicalHistory(new User { UserID = id });
            return View("Index", history);
        }

        /// <summary>
        /// Allow the user to edit their medical history
        /// </summary>
        /// <returns>View which contains a form to edit the user's medical history</returns>
        public ActionResult Edit()
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

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


        /// <summary>
        /// Allow the user to edit their general medical history information
        /// </summary>
        /// <param name="vm">Viewmodel containing data from the edit history form</param>
        /// <returns>Redirect to the past medical history edit page (which contains their updated info)</returns>
        [HttpPost]
        public ActionResult Edit(UpdateMedicalHistoryViewModel vm)
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

            // Make sure they submitted a history
            if (vm == null)
                return Redirect("/PastMedicalHistory/Edit");

            vm.UserHistory.UserID = user.UserID;
            histRep.SetPastMedicalHistory(vm.UserHistory);

            // Return them to the edit page
            return Redirect("/PastMedicalHistory/Edit");
        }

        /// <summary>
        /// Allow the user to remove medical conditions
        /// </summary>
        /// <param name="id">ID of the condition to remove</param>
        /// <returns>Redirect to the past medical history edit page</returns>
        public ActionResult RemoveCondition(int id = -1)
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

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

        /// <summary>
        /// Allow the user to add medical conditions
        /// </summary>
        /// <param name="medicalCondition">ID of the medical condition to add</param>
        /// <returns>Redirect to the past medical history edit page</returns>
        [HttpPost]
        public ActionResult AddCondition(int medicalCondition = -1)
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

            if (medicalCondition == -1)
                Redirect("/PastMedicalHistory/Edit");

            histRep.AddPatientMedicalCondition(user, medicalCondition);

            return Redirect("/PastMedicalHistory/Edit");
        }

        /// <summary>
        /// Allow the user to remove medical conditions
        /// </summary>
        /// <param name="id">ID of the medical condition to remove</param>
        /// <returns>Redirect to the past medical history edit page</returns>
        public ActionResult RemoveOtherCondition(int id = -1)
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

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

        /// <summary>
        /// Allow the user to add medical conditions
        /// </summary>
        /// <param name="condition">The condition to add</param>
        /// <returns>Redirect to the past medical history edit page</returns>
        [HttpPost]
        public ActionResult AddOtherCondition(string condition = "")
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

            if (condition == "")
                Redirect("/PastMedicalHistory/Edit");

            condition = Regex.Replace(condition, "<.*?>", string.Empty);
            histRep.AddOtherPatientMedicalCondition(user, condition);

            return Redirect("/PastMedicalHistory/Edit");
        }

        /// <summary>
        /// Allow the user to remove family medical conditions
        /// </summary>
        /// <param name="member">ID of family member</param>
        /// <param name="condition">ID of condition</param>
        /// <returns>Redirect to past medical history edit page</returns>
        public ActionResult RemoveFamilyCondition(int member = -1, int condition = -1)
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

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


        /// <summary>
        /// Allow the user to add family medical conditions
        /// </summary>
        /// <param name="member">ID of family member</param>
        /// <param name="condition">ID of condition</param>
        /// <returns>Redirect to past medical history edit page</returns>
        [HttpPost]
        public ActionResult AddFamilyCondition(int member = -1, int condition = -1)
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

            if (member == -1 || condition == -1)
                Redirect("/PastMedicalHistory/Edit");

            histRep.AddFamilyMedicalCondition(user, member, condition);

            return Redirect("/PastMedicalHistory/Edit");
        }

        /// <summary>
        /// Allow the user to remove other family medical conditions
        /// </summary>
        /// <param name="id">ID of condition</param>
        /// <returns>Redirect to past medical history edit page</returns>
        public ActionResult RemoveOtherFamilyCondition(int id = -1)
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

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

        /// <summary>
        /// Allow the user to add other family medical conditions
        /// </summary>
        /// <param name="member">ID of family member</param>
        /// <param name="condition">Condition to add</param>
        /// <returns>Redirect to past medical history edit page</returns>
        [HttpPost]
        public ActionResult AddOtherFamilyCondition(int member = -1, string condition = "")
        {
            if (!user.HasAccess(AccessOptions.EditOwnMedicalHistory))
                return Redirect("/");

            if (member == -1 || condition == "")
                Redirect("/PastMedicalHistory/Edit");

            condition = Regex.Replace(condition, "<.*?>", string.Empty);
            histRep.AddOtherFamilyMedicalCondition(user, member, condition);

            return Redirect("/PastMedicalHistory/Edit");
        }
    }
}
