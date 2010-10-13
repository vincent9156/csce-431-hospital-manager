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
        // Can this user view the schedule
        ViewSchedule = 0x00, 
        // Does this role need a staff ID to register?
        RegisterWithoutStaffID = 0x01,
        // Can this user ViewMedicalHistory
        ViewMedicalHistory = 0x02,
        // Can this user EditMedicalHistory
        EditMedicalHistory = 0x04,
        // Can this use ViewAppointments
        ViewAppointments = 0x08,
        // Can this user EditAppointments
        EditAppointments = 0x10,
        // Can this user ViewPrescriptions
        ViewPrescriptions = 0x20,
        // Can this user EditPrescriptions
        EditPrescriptions = 0x40,
        // Can this user ViewCurrentBilling
        ViewCurrentBill = 0x80

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