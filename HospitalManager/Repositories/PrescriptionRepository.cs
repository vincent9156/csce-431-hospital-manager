using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class PrescriptionRepository
    {
        private PrescriptionsDatabase prescriptionDb = new PrescriptionsDatabase();

        public int AddPrescription(Prescription prescription)
        {
            return 0;
        }

        public IQueryable<Medication> GetAllMedications()
        {
            return from script in prescriptionDb.Medications
                   orderby script.MedicationName ascending
                   select script;
        }

        public bool MedicationExists(int medID)
        {
            return true;
        }
    }
}