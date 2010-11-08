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

        public void InsertAppointment(Appointment app)
        {
            _Appdb.Appointments.InsertOnSubmit(app);
            _Appdb.SubmitChanges();
        }
    }
}