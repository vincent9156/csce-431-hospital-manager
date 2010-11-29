using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    /// <summary>
    /// ViewModel used when updating the user's past medical history
    /// </summary>
    public class UpdateMedicalHistoryViewModel
    {
        /// <summary>
        /// The user's past medical history
        /// </summary>
        public PastMedicalHistory UserHistory { get; set; }

        /// <summary>
        /// List of medical conditions
        /// </summary>
        public IList<MedicalCondition> AllMedicalConditions { get; set; }

        /// <summary>
        /// List of family members
        /// </summary>
        public IList<FamilyMember> AllFamilyMembers { get; set; }
    }
}