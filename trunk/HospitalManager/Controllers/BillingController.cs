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
            if (bill == null)
                return View();

            BillingViewModel bvm = Mapper.Map<Bill, BillingViewModel>(bill);
            
            //display the doctor name
            User doc = UserRep.GetUserByUserID(bill.DocUserID);
            bvm.DoctorName = doc.FirstName + " " + doc.LastName;

            //display the patient name
            User patient = UserRep.GetUserByUserID(bill.PatientUserID);
            bvm.PatientName = patient.FirstName + " " + patient.LastName;

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
            bvm.PatientName = Patient.FirstName + " " + Patient.LastName;
            bvm.PatientUserID = id;

            return View(bvm);
        }

        [HttpPost]
        public ActionResult CreateBill(BillingViewModel BVM)
        {
            Bill NewBill = new Bill();

            //get doctr userID
            User doc = SessionRep.GetUser();
            BVM.DocUserID = doc.UserID;
            BVM.DoctorName = doc.FirstName + " " + doc.LastName;
            
            //initialize bill to not paid for
            BVM.Paid = 0;

            //get date of bill
            DateTime Billdate = DateTime.Now;
            BVM.BillDate = Billdate;

            //map all BVM to a new bill
            NewBill = Mapper.Map<BillingViewModel, Bill>(BVM);

            //bill the patient and return the BillID
            BVM.BillID = BillRep.BillPatient(NewBill);

            //get patient based on ID
            User p = UserRep.GetUserByUserID(BillRep.GetBillByID(BVM.BillID).PatientUserID);
            BVM.PatientName = p.FirstName + " " + p.LastName;

            if (BVM.Paid == 0)
                ViewData["paid"] = "Not Paid";
            else ViewData["paid"] = "Paid";

            
            return View("ViewBill",BVM);
        }

        public ActionResult DeleteBill(int id)
        {
            BillRep.RemoveBillByID(id);

            return Redirect("/Billing/Index/");
        }

    }
}
