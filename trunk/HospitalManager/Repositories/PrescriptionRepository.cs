using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;
using HospitalManager.Repositories;

namespace HospitalManager.Repositories
{
    public class PrescriptionRepository
    {
        private PrescriptionsDatabase prescriptionDb = new PrescriptionsDatabase();
        private PrescriptionRepository presRep = new PrescriptionRepository();
        private BillingRepository BillRep = new BillingRepository();

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

        public string GetMedicationNameByID(int MedID)
        {
            var result = from m in prescriptionDb.Medications
                         where m.MedicationID == MedID
                         select m.MedicationName;

            if (result.Count() == 0)
                return null;

            return result.First();
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

        public Prescription GetPrescriptionByID(int PresID)
        {
            var result = from p in prescriptionDb.Prescriptions
                         where p.PrescriptionID == PresID
                         select p;

            if (result.Count() == 0)
                return null;

            return result.First();

        }

        public bool AssignPrescriptionToPharmacist(int PharmacistID,Prescription presc)
        {
            var result = from p in prescriptionDb.Prescriptions
                          where p.PrescriptionID == presc.PrescriptionID
                          select p;
            if (result.Count() == 0)
                return false;

            result.First().PharmacistID = PharmacistID;
            prescriptionDb.SubmitChanges();

            return true;
        }

        //changes status of fill status to filled and bills the patient, returns presBillID
        public int FillPrescription(int PrescriptionID)
        {
            //get prescription to fill and bill
            var result = from p in prescriptionDb.Prescriptions
                         where p.PrescriptionID == PrescriptionID
                         select p;

            //if non then retun 0
            if (result.Count() == 0)
                return 0;

            //the prescription is not assigned to a pharmacist
            if(result.First().PharmacistID == 0)
                return 0;

            //bill patient for prescription since pharmacist is filling it
            PrescriptionBill PresBill = new PrescriptionBill();
            PresBill.Amount = presRep.GetPriceOfPresciption(PrescriptionID);
            PresBill.PrescriptionID = PrescriptionID;
            PresBill.Paid = 0;
            int BillID = BillRep.BillPrescription(PresBill);

            //change status of prescription to filled
            result.First().FillStatus = 1;
            prescriptionDb.SubmitChanges();

            return BillID;
        }
    }
}