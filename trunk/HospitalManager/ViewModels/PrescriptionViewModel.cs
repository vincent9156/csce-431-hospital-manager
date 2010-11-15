﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;
using HospitalManager.Libraries;

namespace HospitalManager.ViewModels
{
    public class PrescriptionViewModel
    {
        public int PrescriptionID { get; set; }
        public int UserID { get; set; }
        public int DoctorUserID { get; set; }
        public int MedicationID { get; set; }
        public int Quantity { get; set; }
        public int NumRefills { get; set; }
        public int mgPerPill { get; set; }
        public string Instructions { get; set; }

        public int PharmacistID { get; set; }
        public string FillStatus { get; set; }

        public string PharmacistName { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string MedicationName { get; set; }

        public IEnumerable<User> Pharmacists { get; set; }
        public IEnumerable<Medication> Medications { get; set; }
        public IList<PrescriptionViewModel> SearchResults;
        
        public UserViewModel LoggedInUser { get; set; }
    }
}