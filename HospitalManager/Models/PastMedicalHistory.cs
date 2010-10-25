using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.Models
{
    public partial class PastMedicalHistory
    {
        public IList<PatientCondition> PatientConditions
        {
            get;
            private set;
        }

        public IList<OtherPatientCondition> OtherPatientConditions
        {
            get;
            private set;
        }

        public IList<FamilyCondition> FamilyConditions
        {
            get;
            private set;
        }

        public IList<OtherFamilyCondition> OtherFamilyConditions
        {
            get;
            private set;
        }

        public void LoadConditions()
        {
            var db = new PastMedicalHistoryDatabase();

            PatientConditions = (from condition in db.PatientConditions
                                 where condition.UserID == this.UserID
                                 select condition).ToList();

            OtherPatientConditions = (from condition in db.OtherPatientConditions
                                      where condition.UserID == this.UserID
                                      select condition).ToList();
        
            FamilyConditions = (from condition in db.FamilyConditions
                                where condition.UserID == this.UserID
                                select condition).ToList();

            OtherFamilyConditions = (from condition in db.OtherFamilyConditions
                                     where condition.UserID == this.UserID
                                     select condition).ToList();
        }
    }
}