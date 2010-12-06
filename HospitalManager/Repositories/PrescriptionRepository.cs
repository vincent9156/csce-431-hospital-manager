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
        private BillingRepository BillRep;

        /// <summary>
        /// Initialize the repository
        /// </summary>
        public PrescriptionRepository()
        {
            // Use dependency injection to avoid the circular creation
            BillRep = new BillingRepository(this);
        }

        /// <summary>
        /// add prescription to DB
        /// </summary>
        /// <param name="prescription">prescription to add</param>
        /// <returns>
        /// Returns the ID for the new prescription
        /// </returns>
        public int AddPrescription(Prescription prescription)
        {
            prescriptionDb.Prescriptions.InsertOnSubmit(prescription);
            prescriptionDb.SubmitChanges();
            return prescription.PrescriptionID;
        }

        /// <summary>
        /// returns all medications from DB
        /// </summary>
        /// <returns>
        /// returns a list containing all possible medication
        /// </returns>
        public IQueryable<Medication> GetAllMedications()
        {
            return from script in prescriptionDb.Medications
                   orderby script.MedicationName ascending
                   select script;
        }

        /// <summary>
        /// return med name based on id given
        /// </summary>
        /// <param name="MedID"> Medicine ID</param>
        /// <returns>
        /// returns the first result for the name of a medication based on the given medication ID
        /// </returns>
        public string GetMedicationNameByID(int MedID)
        {
            var result = from m in prescriptionDb.Medications
                         where m.MedicationID == MedID
                         select m.MedicationName;

            if (result.Count() == 0)
                return null;

            return result.First();
        }

        /// <summary>
        /// gets all prescriptions doctor has written
        /// </summary>
        /// <param name="DocUserID">Doctor user ID</param>
        /// <returns>
        /// Returns a list containing all prescriptions that the given doctor has issued.
        /// </returns>
        public IQueryable<Prescription> GetAllPrescriptionsByDoctorID(int DocUserID)
        {
            var result = from script in prescriptionDb.Prescriptions
                         where script.DoctorUserID == DocUserID
                         select script;

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// gets all patients prescriptions based on patient ID
        /// </summary>
        /// <param name="UserID">Id of the user</param>
        /// <returns>
        /// Returns a list of all prescription that have been issued to the given user.
        /// </returns>
        public IQueryable<Prescription> GetAllPrescriptionsByUserID(int UserID)
        {
            var result = from script in prescriptionDb.Prescriptions
                         where script.UserID == UserID
                         select script;

            if (result.Count() == 0)
                return null;

            return result;
        }
        
        /// <summary>
        /// gets all prescriptions that pharmacist has filled
        /// </summary>
        /// <param name="PharmacistID">Id of the Pharmacist</param>
        /// <returns>
        /// Returns a list of all prescriptions that the given pharmacist has filled.
        /// </returns>
        public IQueryable<Prescription> GetAllPrescriptionsByPharmacistID(int PharmacistID)
        {
            var result = from script in prescriptionDb.Prescriptions
                         where script.PharmacistID == PharmacistID
                         select script;

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// calculates price based on the prescription amounts
        /// </summary>
        /// <param name="prescriptionID">presction ID to get price of</param>
        /// <returns>
        /// Returns the price of a prescription based on the prescription ID
        /// </returns>
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

        /// <summary>
        /// gets a prescription by its ID number
        /// </summary>
        /// <param name="PresID">prescription ID</param>
        /// <returns>
        /// Returns the first result based on the prescription ID
        /// </returns>
        public Prescription GetPrescriptionByID(int PresID)
        {
            var result = from p in prescriptionDb.Prescriptions
                         where p.PrescriptionID == PresID
                         select p;

            if (result.Count() == 0)
                return null;

            return result.First();

        }

        /// <summary>
        /// changes status of fill status to filled and bills the patient, returns presBillID
        /// </summary>
        /// <param name="PharmacistID">ID of Pharmacist</param>
        /// <param name="PrescriptionID">ID of Prescription</param>
        /// <returns>
        /// Returns a 0 if the prescription does not exist, returns a 1 if otherwise
        /// </returns>
        public int FillPrescription(int PharmacistID,int PrescriptionID)
        {
            //get prescription to fill and bill
            var result = from p in prescriptionDb.Prescriptions
                         where p.PrescriptionID == PrescriptionID
                         select p;

            //if non then retun 0
            if (result.Count() == 0)
                return 0;

            //bill patient for prescription since pharmacist is filling it
            //PrescriptionBill PresBill = new PrescriptionBill();
            //PresBill.Amount = result.First().GetCost();
            //PresBill.PrescriptionID = PrescriptionID;
            //PresBill.Paid = 0;
            //int BillID = BillRep.BillPrescription(PresBill);

            //change status of prescription to filled
            result.First().FillStatus = 1;
            result.First().PharmacistID = PharmacistID;
            prescriptionDb.SubmitChanges();

            //return BillID;
            return 1;
        }

        /// <summary>
        /// delete a prescription from the database
        /// </summary>
        /// <param name="PrescID">prescription ID</param>
        /// <returns>
        /// Returns false if the prescription does not exist, returns true if otherwise.
        /// </returns>
        public bool RemovePrescriptionByID(int PrescID)
        {
            Prescription pres = GetPrescriptionByID(PrescID);
            if (pres == null)
                return false;
            prescriptionDb.Prescriptions.DeleteOnSubmit(pres);
            prescriptionDb.SubmitChanges();

            return true;
        }
  }
}