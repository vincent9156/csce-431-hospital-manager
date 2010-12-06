using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;
using System.ComponentModel.DataAnnotations;


namespace HospitalManager.ViewModels
{
    /// <summary>
    /// View model used by Appointment Controller to view and edit appointments
    /// </summary>
    public class AppointmentViewModel
    {

        /// <summary>
        /// Used for deleting appointments
        /// </summary>
        public int AppointmentID { get; set; }

        /// <summary>
        /// Used for deleting, adding, and displaying appointments
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Used for deleting, adding appointments
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Used for deleting, adding appointments
        /// </summary>
        public int DoctorID { get; set; }

        /// <summary>
        /// Used for deleting, adding, and displaying appointments
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Used for displaying appointments
        /// </summary>
        public string PatientFirstName { get; set; }

        /// <summary>
        /// Used for displaying appointments
        /// </summary>
        public string PatientLastName { get; set; }

        /// <summary>
        /// Used for displaying appointments
        /// </summary>
        public string DoctorFirstName { get; set; }

        /// <summary>
        /// Used for displaying appointments
        /// </summary>
        public string DoctorLastName { get; set; }

        /// <summary>
        /// Used for displaying appointments
        /// </summary>
        public IList<AppointmentViewModel> appointments;

        /// <summary>
        /// Used for displaying doctors when scheduling appointments
        /// </summary>
        public List<User> Doctors { get; set; }

        /// <summary>
        /// Used for displaying times when scheduling appointments
        /// </summary>
        public List<TimeSpan> Times { get; set; }

        /// <summary>
        /// Used for displaying messages to the user
        /// </summary>
        public string Message { get; set; }
    }
}