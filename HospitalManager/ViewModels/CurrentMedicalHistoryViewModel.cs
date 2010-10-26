using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Libraries;

namespace HospitalManager.ViewModels
{
    public class CurrentMedicalHistoryViewModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string ReasonForVisit { get; set; }
        public string BloodPressure { get; set; }
        public string Diagnosis { get; set; }
        public int UserID { get; set; }

    }
}