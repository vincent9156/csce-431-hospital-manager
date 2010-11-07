using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;


namespace HospitalManager.ViewModels
{

    public class AppointmentViewModel
    {

        public int AppointmenID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }

        public IList<AppointmentViewModel> appointments;
        public List<User> Doctors { get; set; }
    }
}