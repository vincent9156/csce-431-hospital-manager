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

        
        

        //
        // GET: /CurrentMedicalHistory/
        
        public ActionResult Index()
        {
            IQueryable<CurrentMedicalHistory> history = histRep.GetCurrentMedicalHistoryByUser(sessRep.GetUser()); 
            
            return View();
        }

    }
}
