// Coded my michael risley !! WOOooT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Repositories;
using HospitalManager.ViewModels;
using AutoMapper;
using HospitalManager.Models;
using HospitalManager.Libraries;

namespace HospitalManager.Controllers
{
    public class PrescriptionController : Controller
    {
        SessionRepository SessionRep = new SessionRepository();
        UserRepository user = new UserRepository();
        PrescriptionRepository presRep = new PrescriptionRepository();

        //by default the index of prescriptions displays all prescriptions for the user logged in
        public ActionResult Index()
        {
            User user = SessionRep.GetUser();
            if (SessionRep.IsLoggedIn())
            {
                //if user is doctor then search prescriptions by docUserID
                if (user.TypeID == UserType.DoctorTypeID)
                {
                    IQueryable<Prescription> pres = presRep.GetAllPrescriptionsByDoctorID(user.UserID);
                    List<PrescriptionViewModel> PrescriptionViewModels = new List<PrescriptionViewModel>();
                    if (pres == null)
                        return View();
                    foreach (var pre in pres)
                    {
                        PrescriptionViewModels.Add(Mapper.Map<Prescription, PrescriptionViewModel>(pre));
                    }
                    var vm = new PrescriptionViewModel
                    {
                        SearchResults = PrescriptionViewModels
                    };

                    return View(vm);
                }
                //if logged in user is Patient then search prescriptions by PatientUserID
                if (user.TypeID == UserType.PatientTypeID)
                {
                    IQueryable<Prescription> pres = presRep.GetAllPrescriptionsByUserID(user.UserID);
                    List<PrescriptionViewModel> PrescriptionViewModels = new List<PrescriptionViewModel>();
                    if (pres == null)
                        return View();
                    foreach (var pre in pres)
                    {
                       PrescriptionViewModels.Add(Mapper.Map<Prescription, PrescriptionViewModel>(pre));
                        
                    }
                    var vm = new PrescriptionViewModel
                    {
                        SearchResults = PrescriptionViewModels
                    };

                    return View(vm);
                }
                //if user is doctor then search prescriptions by docUserID
                if (user.TypeID == UserType.PharmacistTypeID)
                {
                    IQueryable<Prescription> pres = presRep.GetAllPrescriptionsByPharmacistID(user.UserID);
                    List<PrescriptionViewModel> PrescriptionViewModels = new List<PrescriptionViewModel>();
                    if (pres == null)
                        return View();
                    foreach (var pre in pres)
                    {
                        PrescriptionViewModels.Add(Mapper.Map<Prescription, PrescriptionViewModel>(pre));
                    }
                    var vm = new PrescriptionViewModel
                    {
                        SearchResults = PrescriptionViewModels
                    };
                    return View(vm);
                }
                //if not patient or doctor or pharmacist is null then return null viewmodel
                return View((PrescriptionViewModel)null);

            }//if user is not logged in then redirect to login page
            else return Redirect("/Authentication/Login/");
        }
     
        //view prescription based on prescriptionID
        public ActionResult ViewPrescription(int id)
        {
            if (!SessionRep.IsLoggedIn())
                return Redirect("/Authentication/Login/");

            //prevent frm other users viewing prescriptions that are not assigned to them
            Prescription pres = presRep.GetPrescriptionByID(id);
            if (pres == null)
                return View();
            if ((pres.PharmacistID != SessionRep.GetUser().UserID) && (pres.UserID != SessionRep.GetUser().UserID) && (pres.DoctorUserID != SessionRep.GetUser().UserID))
                return View();

            PrescriptionViewModel vm = Mapper.Map<Prescription, PrescriptionViewModel>(pres);
            
            //display the doctor name
            User doc = user.GetUserByUserID(pres.UserID);
            vm.PatientName = doc.FirstName + " " + doc.LastName;

            //display the patient name
            User patient = user.GetUserByUserID(pres.DoctorUserID);
            vm.DoctorName = patient.FirstName + " " + patient.LastName;

            vm.MedicationName = presRep.GetMedicationNameByID(pres.MedicationID);         

            return View(vm);
        }

        public ActionResult WritePrescription(int id)
        {
            if (!SessionRep.IsLoggedIn() || !SessionRep.GetUser().HasAccess(AccessOptions.CanWritePrescriptions))
                return Redirect("/");
           
            PrescriptionViewModel vm = new PrescriptionViewModel();

            User Patient = user.GetUserByUserID(id);//this needs to be from the search patient page
            vm.PatientName = Patient.FirstName + " " + Patient.LastName;

            vm.Medications = presRep.GetAllMedications();
            vm.UserID = id;

            
            return View(vm);
        }

        [HttpPost]
        public ActionResult WritePrescription(PrescriptionViewModel vm)
        {
            //get doctor information
            User doc = SessionRep.GetUser();
            vm.DoctorUserID = doc.UserID;
            vm.DoctorName = doc.FirstName + " " + doc.LastName;

            Prescription pres = Mapper.Map<PrescriptionViewModel, Prescription>(vm);
            vm.PrescriptionID = presRep.AddPrescription(pres);
            
            User p = user.GetUserByUserID(presRep.GetPrescriptionByID(vm.PrescriptionID).UserID);
            vm.PatientName = p.FirstName + " " + p.LastName;

            vm.MedicationName = presRep.GetMedicationNameByID(vm.MedicationID);

            return View("ViewPrescription", vm);
        }

        //remove a prescription
        public ActionResult DeletePrescription(int id)
        {
            if (!SessionRep.IsLoggedIn() || !SessionRep.GetUser().HasAccess(AccessOptions.CanWritePrescriptions))
                return Redirect("/");
            presRep.RemovePrescriptionByID(id);

            return Redirect("/Prescription/Index/");
        }


        //assign the prescription to a pharmacist
        public ActionResult Assign(int id)
        {
            
            PrescriptionViewModel vm = new PrescriptionViewModel();
            vm.Pharmacists = user.GetAllUsersBasedOnType(4);
            vm.PrescriptionID = id;

            return View(vm);
        }

        [HttpPost]
        public ActionResult AssignPrescription(PrescriptionViewModel vm)
        {
            Prescription presc = presRep.GetPrescriptionByID(vm.PrescriptionID);
            if (presc == null)
                return Redirect("/Home/UserLog/");
            bool result = presRep.AssignPrescriptionToPharmacist(vm.PharmacistID, presc);

            return Redirect("/Prescription/Index/");
        }

    }
}
