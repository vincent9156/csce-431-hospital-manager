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
            prescriptionDb.Prescriptions.InsertOnSubmit(prescription);
            prescriptionDb.SubmitChanges();
            return prescription.PrescriptionID;
        }

        public IQueryable<Medication> GetAllMedications()
        {
            return from script in prescriptionDb.Medications
                   orderby script.MedicationName ascending
                   select script;
        }

        public IQueryable<string> GetAllMedicationNames()
        {
            var result = from script in prescriptionDb.Medications
                         orderby script.MedicationName ascending
                         select script.MedicationName;

            if (result.Count() == 0)
                return null;

            return result;
                
        }

        public bool MedicationExists(int medID)
        {
            return prescriptionDb.Medications.Select(m => m.MedicationID == medID).Count() != 0;
        }

        public IQueryable<Prescription> GetAllPrescriptionsByDoctorID(int DocUserID)
        {
            var result = from script in prescriptionDb.Prescriptions
                         where script.DoctorUserID == DocUserID
                         select script;

            if (result.Count() == 0)
                return null;

            return result;
        }

        public IQueryable<Prescription> GetAllPrescriptionsByUserID(int UserID)
        {
            var result = from script in prescriptionDb.Prescriptions
                         where script.UserID == UserID
                         select script;

            if (result.Count() == 0)
                return null;

            return result;
        }

        public decimal GetPriceOfPresciption(int prescriptionID)
        {
            var prescription = (from p in prescriptionDb.Prescriptions
                                where p.PrescriptionID == prescriptionID
                                select p).First();

            decimal pricepermg = (from m in prescriptionDb.Medications
                       where m.MedicationID == prescription.MedicationID
                       select m).First().PricePerMg;


            decimal price = prescription.mgPerPill * prescription.Quantity * pricepermg;

            return price;
        }
    }
}