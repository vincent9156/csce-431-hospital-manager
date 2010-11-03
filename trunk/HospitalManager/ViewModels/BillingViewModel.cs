using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;
using HospitalManager.Libraries;

namespace HospitalManager.ViewModels
{
    public class BillingViewModel
    {
        public int BillID { get; set; }
        public float Amount { get; set; }
        public string Diagnosis { get; set; }
        public string ReasonForVisit { get; set; }
        public int PatientUserID { get; set; }
        public int DocUserID { get; set; }
        public DateTime BillDate { get; set; }
        public byte Paid { get; set; }

        public IList<BillingViewModel> SearchResults;
    }
}