using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Libraries;

namespace HospitalManager.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TypeName { get; set; }
        public int Permissions { get; set; }

        /**
         * Check whether the user has access to the given option(s)
         */
        public bool HasAccess(AccessOptions options)
        {
            return PermissionsManager.HasAccess(Permissions, options);
        }
    }
}