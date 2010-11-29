using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    public class CurrentMedicalHistoriesViewModel
    {
        /// <summary>
        /// Get current medical history data from database
        /// </summary>
        public IQueryable<CurrentMedicalHistory> CurrentMedicalHistoryList { get; set; }
    }
}