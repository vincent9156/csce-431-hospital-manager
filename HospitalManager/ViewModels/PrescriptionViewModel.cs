using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    public class PrescriptionViewModel
    {
        public int userId { get; set; }
        public int docId { get; set; }
        public int quantity { get; set; }
        public int numRefills { get; set; }
        public int mgPerPill { get; set; }
        public string instruction { get; set; }
        public string medName { get; set; }
        public int MedID { get; set; }
        public IEnumerable<Medication> Medications { get; set; }
    }
}