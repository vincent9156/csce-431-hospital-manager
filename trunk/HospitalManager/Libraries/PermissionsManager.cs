using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Libraries
{
    /**
     * Represents the options for the access control list bitmasks
     */
    [FlagsAttribute]
    public enum AccessOptions
    {

        // Does this role need a staff ID to register?
        RegisterWithoutStaffID = 0x01,

        // Can this user search other users?
        SearchUsers = 0x02,

        // Can this user view other user's past medical histories?
        ViewPastMedicalHistories = 0x04,

        // Can this user edit his own past medical history?
        EditOwnMedicalHistory = 0x08,

        // Can this user write prescriptions?
        CanWritePrescriptions = 0x10,

        // Can this user search all patients?
        SearchAllPatients = 0x40,

        // Can this user view a schedule?
        ViewSchedule = 0x00, // TODO: Should be editted to work in the future

        //can view prescriptions?
        ViewPrescriptions = 0x00,

        // Can this user view thier own bills
        ViewBills = 0x00, // TODO: Should be editted to work in the future

        // Can user bill a patient
        BillPatient = 0x02 // TODO: Should be editted to have its own permission in the future
    }

    public class PermissionsManager
    {
        /**
         * Checks the access control list to see if a user has a given option set.
         */
        public static bool HasAccess(int permissions, AccessOptions flags)
        {
            return flags.Equals((AccessOptions)((int)flags & permissions));
        }
    }
}