﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;
using HospitalManager.Repositories;

namespace HospitalManager.Repositories
{
    public class BillingRepository
    {
        
        private BillingDataContext _Billdb;
        private PrescriptionRepository PresRep;

        /// <summary>
        ///initialize repository 
        /// </summary>
        public BillingRepository()
        {
            _Billdb = new BillingDataContext();
            PresRep = new PrescriptionRepository();
        }

        /// <summary>
        /// create bill from appointment
        /// </summary>
        /// <param name="Bill">Bill to add to DB</param>
        /// <returns></returns>
        public int BillPatient(Bill Bill)
        {
            _Billdb.Bills.InsertOnSubmit(Bill);
            _Billdb.SubmitChanges();

            return Bill.BillID;
        }

        /// <summary>
        /// return a bill based on id
        /// </summary>
        /// <param name="BillID">ID of the Bill</param>
        /// <returns></returns>
        public Bill GetBillByID(int BillID)
        {
            var result = from b in _Billdb.Bills
                         where b.BillID == BillID
                         select b;
            // Just return null if we get no results
            if (result.Count() == 0)
                return null;

            return (result.First());
        }

        /// <summary>
        /// returns all bills from user
        /// </summary>
        /// <param name="UserID">ID of User</param>
        /// <returns></returns>
        public IQueryable<Bill> GetAllBillsByUser(int UserID)
        {
            var result = from b in _Billdb.Bills
                         where b.PatientUserID == UserID
                         select b;

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// returns all bill from doctorID
        /// </summary>
        /// <param name="DocUserID">ID of Doctor</param>
        /// <returns></returns>
        public IQueryable<Bill> GetAllBillsByDoctor(int DocUserID)
        {
            var result = from b in _Billdb.Bills
                         where b.DocUserID == DocUserID
                         select b;

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// create bill from prescription
        /// </summary>
        /// <param name="bill">Prescription Bill to Add</param>
        /// <returns></returns>
        public int BillPrescription(PrescriptionBill bill)
        {
            _Billdb.PrescriptionBills.InsertOnSubmit(bill);
            _Billdb.SubmitChanges();

            return bill.BillID;
        }

        /// <summary>
        /// return prescription bill by ID inputed
        /// </summary>
        /// <param name="BillID">ID of Bill</param>
        /// <returns></returns>
        public PrescriptionBill GetPrescriptionBillByID(int BillID)
        {
            var result = from b in _Billdb.PrescriptionBills
                         where b.BillID == BillID
                         select b;
            // Just return null if we get no results
            if (result.Count() == 0)
                return null;

            return (result.First());

        }

        /// <summary>
        /// get prescription bills by doctor ID
        /// </summary>
        /// <param name="DocUserID">ID of The doctor</param>
        /// <returns></returns>
        public IQueryable<PrescriptionBill> GetAllPrescriptionBillsByDoctor(int DocUserID)
        {
            IQueryable<PrescriptionBill> result = null;
            IQueryable<Prescription> PrescriptionsByDoc = PresRep.GetAllPrescriptionsByDoctorID(DocUserID);
            foreach (var pres in PrescriptionsByDoc)
            {
                 result = from b in _Billdb.PrescriptionBills
                             where b.PrescriptionID == pres.PrescriptionID
                             select b;
            }

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// gets all prescription bills by user
        /// </summary>
        /// <param name="UserID">ID of the user</param>
        /// <returns></returns>
        public IQueryable<PrescriptionBill> GetAllPrescriptionBillsByUser(int UserID)
        {
            IQueryable<PrescriptionBill> result = null;
            IQueryable<Prescription> PrescriptionsByUser = PresRep.GetAllPrescriptionsByUserID(UserID);
            foreach (var pres in PrescriptionsByUser)
            {
                result = from b in _Billdb.PrescriptionBills
                         where b.PrescriptionID == pres.PrescriptionID
                         select b;
            }

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// billed for canceling an appointment
        /// </summary>
        /// <param name="bill">Cancellation Bill</param>
        public void BillCancellation(CancellationBill bill)
        {
            _Billdb.CancellationBills.InsertOnSubmit(bill);
            _Billdb.SubmitChanges();
        }

        /// <summary>
        /// return cancellation bill by the billID input
        /// </summary>
        /// <param name="BillID">ID of the Bill</param>
        /// <returns></returns>
        public CancellationBill GetCancellationBillByID(int BillID)
        {
            var result = from b in _Billdb.CancellationBills
                         where b.BillID == BillID
                         select b;
            // Just return null if we get no results
            if (result.Count() == 0)
                return null;

            return (result.First());

        }

        /// <summary>
        /// returns cancellation bills by doctor
        /// </summary>
        /// <param name="DoctorID">ID of the Doctor</param>
        /// <returns></returns>
        public IQueryable<CancellationBill> GetAllCancellationBillsByDoctor(int DoctorID)
        {


            var result = from b in _Billdb.CancellationBills
                     where b.DoctorID == DoctorID
                     select b;
            

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// returns cancellation bills by user
        /// </summary>
        /// <param name="UserID">ID of the User</param>
        /// <returns></returns>
        public IQueryable<CancellationBill> GetAllCancellationBillsByUser(int UserID)
        {

            var result = from b in _Billdb.CancellationBills
                         where b.DoctorID == UserID
                         select b;

            if (result.Count() == 0)
                return null;

            return result;
        }

        /// <summary>
        /// remove a bill from DB based on billID
        /// </summary>
        /// <param name="BillID">ID of the Bill</param>
        /// <returns></returns>
        public bool RemoveBillByID(int BillID)
        {
            Bill bill = GetBillByID(BillID);
            if (bill == null)
                return false;
            _Billdb.Bills.DeleteOnSubmit(bill);
            _Billdb.SubmitChanges();

            return true;
        }

        public void PayPrescriptionBill()
        {
        }

        public void PayBill()
        {
        }
    }
}