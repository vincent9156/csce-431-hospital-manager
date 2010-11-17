using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Repositories;

namespace HospitalManager.Models
{
    public partial class PastMedicalHistory
    {
        public IList<PatientCondition> PatientConditions { get; set; }
        public IList<OtherPatientCondition> OtherPatientConditions { get; set; }
        public IList<FamilyCondition> FamilyConditions { get; set; }
        public IList<OtherFamilyCondition> OtherFamilyConditions { get; set; }

        public void LoadConditions()
        {
            var histRep = new PastMedicalHistoryRepository();
            PatientConditions = histRep.GetPatientConditions(this.UserID);
            OtherPatientConditions = histRep.GetOtherPatientConditions(this.UserID);
            FamilyConditions = histRep.GetFamilyConditions(this.UserID);
            OtherFamilyConditions = histRep.GetOtherFamilyConditions(this.UserID);
        }
    }
}