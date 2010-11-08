using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

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

        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public IList<BillingViewModel> SearchResults;
    }
    public class PrescriptionBillingViewModel
    {
        public int BillID { get; set; }
        public float AMount { get; set; }
        public int PrescriptionID { get; set; }
        public byte Paid { get; set; }

        public IList<PrescriptionBillingViewModel> SearchResults;
    }
}