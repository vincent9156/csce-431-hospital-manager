using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.Models
{
    public partial class UserType
    {
        // Set type ID ranges for validating user types
        public const int MinUserTypeID = 1;
        public const int MaxUserTypeID = 4;

        // Define type IDs
        public const int PatientTypeID = 1;
        public const int DoctorTypeID = 2;
        public const int NurseTypeID = 3;
        public const int PharmacistTypeID = 4;
    }
}