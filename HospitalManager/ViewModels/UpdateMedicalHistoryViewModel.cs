using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    public class UpdateMedicalHistoryViewModel
    {
        public PastMedicalHistory UserHistory { get; set; }
        public IList<MedicalCondition> AllMedicalConditions { get; set; }
        public IList<FamilyMember> AllFamilyMembers { get; set; }
    }
}