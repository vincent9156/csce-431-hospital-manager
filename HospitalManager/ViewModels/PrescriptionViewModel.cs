using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.ViewModels
{
    public class PrescriptionViewModel
    {
        public int userId;
        public int docId;
        public int quantity;
        public int numRefills;
        public int mgPerPill;
        public string instruction;
        public string medName;
    }
}