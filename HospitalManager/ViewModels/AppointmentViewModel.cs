using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;
using System.ComponentModel.DataAnnotations;


namespace HospitalManager.ViewModels
{

    public class AppointmentViewModel
    {

        public int AppointmenID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public TimeSpan Time { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }

        public IList<AppointmentViewModel> appointments;
        public List<User> Doctors { get; set; }
        public List<TimeSpan> Times { get; set; }
        public string Message { get; set; }
    }
}