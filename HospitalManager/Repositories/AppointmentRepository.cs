using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{

    public class AppointmentRepository
    {
        private AppointmentDataContext _Appdb;

        public AppointmentRepository()
        {
            _Appdb = new AppointmentDataContext();
        }

        //Return a queryable list of appointments for a user
        public IQueryable<VWAppointments> GetUserAppointments(int UserID)
        {
            var result = from a in _Appdb.VWAppointments
                         where a.UserID == UserID
                         select a;

            if (result == null)
                return null;

            else
                return result;
        }

        //Return a queryable list of doctor appointments
        public IQueryable<VWAppointments> GetDoctorAppointments(int DoctorID)
        {
            var result = from d in _Appdb.VWAppointments
                         where d.DoctorID == DoctorID
                         select d;

            if (result == null)
                return null;

            else
                return result;
        }

        public Appointment GetAppointmentByAppointmentID(int id)
        {
            var result = from d in _Appdb.Appointments
                         where d.AppointmentID == id
                         select d;
            if (result.Count() == 0)
                return null;

            return result.First();
        }

        public void InsertAppointment(Appointment app)
        {
            _Appdb.Appointments.InsertOnSubmit(app);
            _Appdb.SubmitChanges();
        }

        public void CancelAppointment(Appointment app)
        {

            _Appdb.Appointments.DeleteOnSubmit(app);
            _Appdb.SubmitChanges();
        }

        public List<TimeSpan> GetDoctorAvaliablity(int DoctorID, int UserID, DateTime Date)
        {
            var res1 = from f in _Appdb.Appointments
                       where f.UserID == UserID && f.Date == Date
                       select f.Time;

            List<TimeSpan> userTimes = res1.ToList();


            var result = from d in _Appdb.Appointments
                         where d.DoctorID == DoctorID && d.Date == Date || res1.Contains(d.Time)
                         select d.Time;

            return result.ToList();
        }

        //Return a queryable list of doctor appointments
        public IQueryable<VWPatientsByDoctor> GetDoctorPatients(int DoctorID)
        {
            var result = from d in _Appdb.VWPatientsByDoctors
                         where d.DoctorID == DoctorID
                         select d;

            return result;
        }

        public bool isDoctorsPatient(int DoctorID, int PatientID)
        {
            IQueryable<VWAppointments> appointments = GetDoctorPatients(DoctorID);
            
            // check each appointment and see if it is our user
            foreach (var temp in appointments)
            {
                // if you found the user, return, otherwise, keep searching
                if (temp.UserID == PatientID)
                    return true;
            }
    }
}