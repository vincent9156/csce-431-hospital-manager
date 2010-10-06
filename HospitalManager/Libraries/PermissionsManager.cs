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
        ViewSchedule = 0x02

    }

    public class PermissionsManager
    {
        /**
         * Checks the access control list to see if a user has a given option set.
         */
        public static bool HasAccess(int permissions, AccessOptions flags)
        {
            return flags.Equals(flags & (AccessOptions)permissions);
        }
    }
}