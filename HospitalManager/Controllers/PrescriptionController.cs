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

namespace HospitalManager.Controllers
{
    public class PrescriptionController : Controller
    {
        SessionRepository session = new SessionRepository();
        UserRepository user = new UserRepository();

        public ActionResult WritePrescription(int id)
        {
            var vm = new PrescriptionViewModel
            {
                userId = id,
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult FillPrescription(PrescriptionViewModel vm)
        {
            vm.docId = session.GetUser().UserID;
            Mapper.Map<PrescriptionViewModel, Prescription>(vm);
            return View(vm);
        }

    }
}
