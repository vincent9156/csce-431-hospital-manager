using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    /// <summary>
    /// Handles adding and editing appointment information
    /// </summary>
    public class AppointmentRepository
    {
        private AppointmentDataContext _Appdb;

        /// <summary>
        /// Creates a new appointment data context for use with later functions
        /// </summary>
        public AppointmentRepository()
        {
            _Appdb = new AppointmentDataContext();
        }

        /// <summary>
        /// Finds all appointments for a gievn user
        /// </summary>
        /// <param name="UserID">User we need to find appointments for</param>
        /// <returns>
        /// An queryable list of appointments for a given user
        /// </returns>
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

        /// <summary>
        /// Find doctor appointments for a given doctor
        /// </summary>
        /// <param name="DoctorID">Doctor we need to find appointments for</param>
        /// <returns>
        /// A queryable list of appointments for a given doctor
        /// </returns>
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

        /// <summary>
        /// Grabs a specific appointment by appointment id
        /// </summary>
        /// <param name="id">Id of appointment we are looking for</param>
        /// <returns>
        /// A single appointment associted with the id
        /// </returns>
        public Appointment GetAppointmentByAppointmentID(int id)
        {
            var result = from d in _Appdb.Appointments
                         where d.AppointmentID == id
                         select d;
            if (result.Count() == 0)
                return null;

            return result.First();
        }

        /// <summary>
        /// Inserts an appointment variable into the appointments table
        /// </summary>
        /// <param name="app">Appointment we will insert into the appointment table</param>
        public void InsertAppointment(Appointment app)
        {
            _Appdb.Appointments.InsertOnSubmit(app);
            _Appdb.SubmitChanges();
        }

        /// <summary>
        /// Delete a given appointment from the appointment table
        /// </summary>
        /// <param name="app">Appointment you wish to delete from the appointment table</param>
        public void CancelAppointment(Appointment app)
        {

            _Appdb.Appointments.DeleteOnSubmit(app);
            _Appdb.SubmitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <param name="UserID"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
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
            IQueryable<VWPatientsByDoctor> appointments = GetDoctorPatients(DoctorID);

            // check each appointment and see if it is our user
            foreach (var temp in appointments)
            {
                // if you found the user, return, otherwise, keep searching
                if (temp.UserID == PatientID)
                    return true;
            }
            return false;
        }
    }
}