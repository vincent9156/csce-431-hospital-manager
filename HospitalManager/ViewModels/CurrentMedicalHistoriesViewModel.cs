using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    public class CurrentMedicalHistoriesViewModel
    {
        public IList<CurrentMedicalHistory> CurrentMedicalHistoryList { get; set; }
    }
}