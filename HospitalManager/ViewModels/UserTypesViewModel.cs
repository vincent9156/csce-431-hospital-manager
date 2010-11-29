using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    /// <summary>
    /// ViewModel for user types (Patient, doctor, etc)
    /// </summary>
    public class UserTypesViewModel
    {
        /// <summary>
        /// IEnumerable of user types
        /// </summary>
        public IEnumerable<UserType> UserTypes { get; set; }

        /// <summary>
        /// The id of the user's type
        /// </summary>
        public int TypeID { get; set; }
    }
}