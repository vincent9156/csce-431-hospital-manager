using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using HospitalManager.Models;
using HospitalManager.ViewModels;
using HospitalManager.Repositories;
using HospitalManager.Libraries;

namespace HospitalManager.Controllers
{
    public class BillingController : Controller
    {
        private BillingRepository BillRep;
        private SessionRepository SessionRep;
        private UserRepository UserRep;

        // GET: /Billing/

        public BillingController()
        {
            BillRep = new BillingRepository();
            SessionRep = new SessionRepository();
            UserRep = new UserRepository();
        }

        //the index should show all bills for the user logged in only
        public ActionResult Index()
        {
            User user = SessionRep.GetUser();
            if (SessionRep.IsLoggedIn())
            {
                //if user is doctor then search bills by docUserID
                if (user.TypeID == UserType.DoctorTypeID)
                {
                    IQueryable<Bill> bills = BillRep.GetAllBillsByDoctor(user.UserID);
                    List<BillingViewModel> BillingViewModels = new List<BillingViewModel>();
                    foreach (var bill in bills)
                    {
                        BillingViewModels.Add(Mapper.Map<Bill, BillingViewModel>(bill));//mapping is not working yet
                    }
                    var vm = new BillingViewModel
                    {
                        SearchResults = BillingViewModels
                    };

                    return View(vm);
                }
                //if logged in user is Patient then search bill by PatientUserID
                if (user.TypeID == UserType.PatientTypeID)
                {
                    IQueryable<Bill> bills = BillRep.GetAllBillsByUser(user.UserID);
                    List<BillingViewModel> BillingViewModels = new List<BillingViewModel>();
                    foreach (var bill in bills)
                    {
                       BillingViewModels.Add(Mapper.Map<Bill, BillingViewModel>(bill));//mapping is not working yet
                        
                    }
                    var vm = new BillingViewModel
                    {
                        SearchResults = BillingViewModels
                    };

                    return View(vm);
                }

                //if not patient or doctor is null then return null viewmodel
                return View((BillingViewModel)null);

            }//if user is not logged in then redirect to login page
            else return Redirect("/Authentication/Login/");
        }

        //view one bill based on the billview model or billID in the future
        public ActionResult ViewBill(BillingViewModel bvm)
        {
            return View(bvm);
        }

        public ActionResult Create()
        {
            if (!SessionRep.IsLoggedIn() || !SessionRep.GetUser().HasAccess(AccessOptions.SearchUsers))
                return Redirect("/");

            BillingViewModel bvm = new BillingViewModel();

            User Patient = UserRep.GetUserByUsername("fothick");
            ViewData["pname"] = Patient.FirstName + " " + Patient.LastName;

            return View(bvm);
        }


        [HttpPost]
        public ActionResult CreateBill(BillingViewModel BVM)
        {
            Bill NewBill = new Bill();

            //get doctr userID
            User doc = SessionRep.GetUser();
            NewBill.DocUserID = doc.UserID;
            BVM.DocUserID = doc.UserID;

            //get patient based on username
            //I would like this to use userID instead of username and be passing the value from the search patient results
            User Patient = UserRep.GetUserByUsername("fothick");
            NewBill.PatientUserID = Patient.UserID;
            BVM.PatientUserID = Patient.UserID;
            

            //initialize bill to not paid for
            NewBill.Paid = 0;
            BVM.Paid = 0;

            //get date of bill
            DateTime Billdate = DateTime.Now;
            NewBill.BillDate = Billdate;
            BVM.BillDate = Billdate;

            //assign Diagnosis
            NewBill.Diagnosis = BVM.Diagnosis;
            
            //assign reason
            NewBill.ReasonForVisit = BVM.ReasonForVisit;

            //assign amount
            NewBill.Amount = BVM.Amount;

            int ID = BillRep.BillPatient(NewBill);
            BVM.BillID = ID;

            return View("ViewBill",BVM);
        }

    }
}
