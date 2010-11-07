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
                Mapper.CreateMap<Bill, BillingViewModel>();
                //if user is doctor then search bills by docUserID
                if (user.TypeID == UserType.DoctorTypeID)
                {
                    IQueryable<Bill> bills = BillRep.GetAllBillsByDoctor(user.UserID);
                    List<BillingViewModel> BillingViewModels = new List<BillingViewModel>();
                    foreach (var bill in bills)
                    {
                        BillingViewModels.Add(Mapper.Map<Bill, BillingViewModel>(bill));
                    }
                    var vm = new BillingViewModel
                    {
                        SearchResults = BillingViewModels
                    };
                    
                    if (vm.Paid == 0)
                        ViewData["paid"] = "Not Paid";
                    else ViewData["paid"] = "Paid";

                    return View(vm);
                }
                //if logged in user is Patient then search bill by PatientUserID
                if (user.TypeID == UserType.PatientTypeID)
                {
                    IQueryable<Bill> bills = BillRep.GetAllBillsByUser(user.UserID);
                    List<BillingViewModel> BillingViewModels = new List<BillingViewModel>();
                    foreach (var bill in bills)
                    {
                       BillingViewModels.Add(Mapper.Map<Bill, BillingViewModel>(bill));
                        
                    }
                    var vm = new BillingViewModel
                    {
                        SearchResults = BillingViewModels
                    };
                    if (vm.Paid == 0)
                        ViewData["paid"] = "Not Paid";
                    else ViewData["paid"] = "Paid";
                    return View(vm);
                }

                //if not patient or doctor is null then return null viewmodel
                return View((BillingViewModel)null);

            }//if user is not logged in then redirect to login page
            else return Redirect("/Authentication/Login/");
        }

        //view one bill based on billID
        public ActionResult ViewBill(int id)
        {
            if (!SessionRep.IsLoggedIn())
                return Redirect("/Authentication/Login/");

            Bill bill = BillRep.GetBillByID(id);
            Mapper.CreateMap<Bill, BillingViewModel>();
            BillingViewModel bvm = Mapper.Map<Bill, BillingViewModel>(bill);
            
            //display the doctor name
            User doc = UserRep.GetUserByUserID(bill.DocUserID);
            ViewData["docname"] = doc.FirstName + " " + doc.LastName;
            //display the patient name
            User patient = UserRep.GetUserByUserID(bill.PatientUserID);
            ViewData["pname"] = patient.FirstName + " " + patient.LastName;

            if (bvm.Paid == 0)
                ViewData["paid"] = "Not Paid";
            else ViewData["paid"] = "Paid";

            return View(bvm);
        }

        public ActionResult Create(int id)
        {
            if (!SessionRep.IsLoggedIn() || !SessionRep.GetUser().HasAccess(AccessOptions.BillPatient))
                return Redirect("/");

            BillingViewModel bvm = new BillingViewModel();

            User Patient = UserRep.GetUserByUserID(id);//this needs to be from the search patient page
            ViewData["pname"] = Patient.FirstName + " " + Patient.LastName;
            bvm.PatientUserID = id;
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

            //get patient based on ID
            NewBill.PatientUserID = BVM.PatientUserID;
            

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

            //didn't know if this would work to replace code above
            //NewBill = Mapper.Map<BillingViewModel, Bill>(BVM);
            
            int ID = BillRep.BillPatient(NewBill);
            BVM.BillID = ID;

            return View("ViewBill",BVM);
        }

    }
}
