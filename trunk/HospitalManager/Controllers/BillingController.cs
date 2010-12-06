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

        /// <summary>
        /// the index should show all bills for the user logged in only
        /// </summary>
        /// <returns>
        /// If there are no bills for the user, returns a null view.
        /// If user is a doctor, return a view with a list of bills
        /// the doctor has issued.
        /// If the user is a patient, returns a list of bills issued
        /// to the patient.
        /// </returns>
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
                    if (bills == null)
                        return View((BillingViewModel)null);
                    foreach (var bill in bills)
                    {
                        BillingViewModels.Add(Mapper.Map<Bill, BillingViewModel>(bill));
                        User tmpuser = UserRep.GetUserByUserID(bill.DocUserID);
                        BillingViewModels[BillingViewModels.Count - 1].DoctorName = tmpuser.FirstName + " " + tmpuser.LastName;
                        tmpuser = UserRep.GetUserByUserID(bill.PatientUserID);
                        BillingViewModels[BillingViewModels.Count - 1].PatientName = tmpuser.FirstName + " " + tmpuser.LastName;
                    }
                    var vm = new BillingViewModel
                    {
                        SearchResults = BillingViewModels
                    };
                    
                    if (vm.Paid == 0)
                        ViewData["paid"] = "Not Paid";
                    else ViewData["paid"] = "Paid";
                    ViewData["utype"] = "Doctor";

                    return View(vm);
                }
                //if logged in user is Patient then search bill by PatientUserID
                if (user.TypeID == UserType.PatientTypeID)
                {
                    IQueryable<Bill> bills = BillRep.GetAllBillsByUser(user.UserID);
                    List<BillingViewModel> BillingViewModels = new List<BillingViewModel>();
                    if (bills == null)
                        return View((BillingViewModel)null);
                    foreach (var bill in bills)
                    {
                       BillingViewModels.Add(Mapper.Map<Bill, BillingViewModel>(bill));
                       User tmpuser = UserRep.GetUserByUserID(bill.DocUserID);
                       BillingViewModels[BillingViewModels.Count - 1].DoctorName = tmpuser.FirstName + " " + tmpuser.LastName;
                       tmpuser = UserRep.GetUserByUserID(bill.PatientUserID);
                       BillingViewModels[BillingViewModels.Count - 1].PatientName = tmpuser.FirstName + " " + tmpuser.LastName;
                    }
                    var vm = new BillingViewModel
                    {
                        SearchResults = BillingViewModels
                    };
                    if (vm.Paid == 0)
                        ViewData["paid"] = "Not Paid";
                    else ViewData["paid"] = "Paid";
                    ViewData["utype"] = "Patient";
                    return View(vm);
                }

                //if not patient or doctor is null then return null viewmodel
                return View((BillingViewModel)null);

            }//if user is not logged in then redirect to login page
            else return Redirect("/Authentication/Login/");
        }

        /// <summary>
        /// view one bill based on billID
        /// </summary>
        /// <param name="id">BillID</param>
        /// <returns>
        /// Returns a view to the requested bill
        /// </returns>
        public ActionResult ViewBill(int? id)
        {
            if (!SessionRep.IsLoggedIn())
                return Redirect("/Authentication/Login/");

            // make sure this function has received an id
            if (!id.HasValue)
                return Redirect("/Billing");

            Bill bill = BillRep.GetBillByID(id.Value);
            if (bill == null)
                return Redirect("/Billing");
            // do not allow users to view bills that are not theirs
            if((bill.PatientUserID != SessionRep.GetUser().UserID) && (bill.DocUserID != SessionRep.GetUser().UserID))
                return Redirect("/Billing");
            
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

        /// <summary>
        /// create bill for appointment
        /// </summary>
        /// <param name="id">UserID</param>
        /// <returns>
        /// returns data for the httpost CreateBill
        /// </returns>
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

        /// <summary>
        /// httpost to create a bill for an appointment
        /// </summary>
        /// <param name="BVM">Billing View Model</param>
        /// <returns>
        /// Returns a view to the newly created bill
        /// </returns>
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

        /// <summary>
        /// remove bill from DB
        /// </summary>
        /// <param name="id">BillID</param>
        /// <returns>
        /// Returns a redirect to the Billing index
        /// </returns>
        public ActionResult DeleteBill(int id)
        {
            BillRep.RemoveBillByID(id);
            return Redirect("/Billing/Index/");
        }

    }
}
