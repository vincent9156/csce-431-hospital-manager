using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Libraries
{
    /// <summary>
    /// Represents the options for the access control list bitmasks
    /// </summary>
    [FlagsAttribute]
    public enum AccessOptions
    {

        /// <summary>
        /// Does this role need a staff ID to register?
        /// </summary>
        RegisterWithoutStaffID = 0x01,

        /// <summary>
        /// Can this user search other users?
        /// </summary>
        SearchUsers = 0x02,

        /// <summary>
        /// Can this user view other user's past medical histories?
        /// </summary>
        ViewPastMedicalHistories = 0x04,

        /// <summary>
        /// Can this user edit his own past medical history?
        /// </summary>
        EditOwnMedicalHistory = 0x08,

        /// <summary>
        /// Can this user write prescriptions?
        /// </summary>
        CanWritePrescriptions = 0x10,

        /// <summary>
        /// Can this user fill prescriptions?
        /// </summary>
        FillPrescriptions = 0x20,

        /// <summary>
        /// Can this user search all patients?
        /// </summary>
        SearchAllPatients = 0x40,

        /// <summary>
        /// Can this user view a schedule?
        /// </summary>
        ViewSchedule = 0x00, // TODO: Should be editted to work in the future

        /// <summary>
        /// can view prescriptions?
        /// </summary>
        ViewPrescriptions = 0x00,

        /// <summary>
        /// Can this user view thier own bills
        /// </summary>
        ViewBills = 0x00, // TODO: Should be editted to work in the future

        /// <summary>
        /// Can user bill a patient
        /// </summary>
        BillPatient = 0x02 // TODO: Should be editted to have its own permission in the future
    }

    public class PermissionsManager
    {
        /// <summary>
        /// Checks the access control list to see if a user has a given option set.
        /// </summary>
        /// <param name="permissions">The user's permissions</param>
        /// <param name="flags">Flags to check</param>
        /// <returns>If the user has access</returns>
        public static bool HasAccess(int permissions, AccessOptions flags)
        {
            return flags.Equals((AccessOptions)((int)flags & permissions));
        }
    }
}