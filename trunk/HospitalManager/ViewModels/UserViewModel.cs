using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Libraries;

namespace HospitalManager.ViewModels
{
    /// <summary>
    /// ViewModel containing user data
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The type of the user (doctor, patient, etc)
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// The user's permissions
        /// </summary>
        public int Permissions { get; set; }

        /// <summary>
        /// Check whether the user has access to the given option(s)
        /// </summary>
        /// <param name="options">Options to test</param>
        /// <returns>True if the user has access, false otherwise</returns>
        public bool HasAccess(AccessOptions options)
        {
            return PermissionsManager.HasAccess(Permissions, options);
        }
    }
}