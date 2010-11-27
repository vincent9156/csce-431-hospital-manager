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

        public BillingRepository()
        {
            _Billdb = new BillingDataContext();
        }

        public int BillPatient(Bill Bill)
        {
            _Billdb.Bills.InsertOnSubmit(Bill);
            _Billdb.SubmitChanges();

            return Bill.BillID;
        }

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

        public IQueryable<Bill> GetAllBillsByUser(int UserID)
        {
            var result = from b in _Billdb.Bills
                         where b.PatientUserID == UserID
                         select b;

            if (result.Count() == 0)
                return null;

            return result;
        }

        public IQueryable<Bill> GetAllBillsByDoctor(int DocUserID)
        {
            var result = from b in _Billdb.Bills
                         where b.DocUserID == DocUserID
                         select b;

            if (result.Count() == 0)
                return null;

            return result;
        }

        public IQueryable<Bill> GetAllBillsByDate(DateTime date)
        {
            var result = from b in _Billdb.Bills
                         where b.BillDate == date
                         select b;

            if (result.Count() == 0)
                return null;

            return result;
        }

        public int BillPrescription(PrescriptionBill bill)
        {
            _Billdb.PrescriptionBills.InsertOnSubmit(bill);
            _Billdb.SubmitChanges();

            return bill.BillID;
        }

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

        public void BillCancellation(CancellationBill bill)
        {
            _Billdb.CancellationBills.InsertOnSubmit(bill);
            _Billdb.SubmitChanges();
        }

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

        public IQueryable<CancellationBill> GetAllCancellationBillsByDoctor(int DoctorID)
        {


            var result = from b in _Billdb.CancellationBills
                     where b.DoctorID == DoctorID
                     select b;
            

            if (result.Count() == 0)
                return null;

            return result;
        }

        public IQueryable<CancellationBill> GetAllCancellationBillsByUser(int UserID)
        {

            var result = from b in _Billdb.CancellationBills
                         where b.DoctorID == UserID
                         select b;

            if (result.Count() == 0)
                return null;

            return result;
        }

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