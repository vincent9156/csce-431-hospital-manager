using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    /// <summary>
    /// Just contains a list of current medical histories
    /// </summary>
    public class CurrentMedicalHistoriesViewModel
    {
        /// <summary>
        /// Get current medical history data from database
        /// </summary>
        public IQueryable<CurrentMedicalHistory> CurrentMedicalHistoryList { get; set; }
    }
}