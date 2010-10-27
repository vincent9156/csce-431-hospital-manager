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
    public class CurrentMedicalHistoryController : Controller
    {
        CurrentMedicalHistoryRepository histRep = new CurrentMedicalHistoryRepository();
        SessionRepository sessRep = new SessionRepository();

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
                CurrentMedicalHistoryList = histRep.GetCurrentMedicalHistoryByUser(sessRep.GetUser())
            };
            
            return View(vm);
        }

    }
}
