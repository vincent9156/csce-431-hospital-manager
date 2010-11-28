using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HospitalManager.Models;
using HospitalManager.Libraries;

namespace HospitalManager.ViewModels
{
    /// <summary>
    /// View Model for the Appointment Bills
    /// </summary>
    public class BillingViewModel
    {
        public int BillID { get; set; }

        [DisplayName("Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")] // format amt as $x,xxx.xx
        public float Amount { get; set; }

        [DisplayName("Diagnosis")]
        public string Diagnosis { get; set; }

        [DisplayName("Reason for Visit")]
        public string ReasonForVisit { get; set; }

        public int PatientUserID { get; set; }
        public int DocUserID { get; set; }

        [DisplayName("Bill Date")]
        [DisplayFormat(DataFormatString = "{0:d}")] // format date as MM/DD/YYYY
        public DateTime BillDate { get; set; }

        [DisplayName("Status")]
        public byte Paid { get; set; }

        [DisplayName("Patient")]
        public string PatientName { get; set; }

        [DisplayName("Doctor")]
        public string DoctorName { get; set; }

        public IList<BillingViewModel> SearchResults;

        public int Permissions { get; set; }

        /**
       * Check whether the user has access to the given option(s)
       */
        public bool HasAccess(AccessOptions options)
        {
            return PermissionsManager.HasAccess(Permissions, options);
        }

    }
    /// <summary>
    /// View Model for the Prescrition Bills
    /// </summary>
    public class PrescriptionBillingViewModel
    {
        public int BillID { get; set; }
        public float AMount { get; set; }
        public int PrescriptionID { get; set; }
        public byte Paid { get; set; }

        public IList<PrescriptionBillingViewModel> SearchResults;

        public int Permissions { get; set; }

        /**
       * Check whether the user has access to the given option(s)
       */
        public bool HasAccess(AccessOptions options)
        {
            return PermissionsManager.HasAccess(Permissions, options);
        }
    }

    /// <summary>
    /// view Model for the Cancellation Bills
    /// </summary>
    public class CancellationViewModel
    {
        public int BillID { get; set; }
        public float Amount { get; set; }
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime AppDate { get; set; }
        public string FeeType { get; set; }
        public byte Paid { get; set; }

    }
}