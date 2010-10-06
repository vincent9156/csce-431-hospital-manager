using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Libraries;
using System.Security.Cryptography;
using System.Text;

namespace HospitalManager.Models
{
    public partial class User
    {
        // Set a nice salt for our MD5 hash
        private const string HashSalt = "6]Xwdi)86k*$QnH[A>?@.teQxSQfbm";

        /**
         * Check whether the user has access to the given option(s)
         */
        public bool HasAccess(AccessOptions options)
        {
            return PermissionsManager.HasAccess(UserType.Permissions, options);
        }

        /**
         * Encrypts the submitted password and updates the private password.
         * Note that this is done separately here instead of the getters/setters in the
         * model since updating the auto-generated code causes it to no longer be updated
         * after editting the dbml file
         */
        public void encryptAndSetPassword(string password)
        {
            Password = MD5Encrypter.GetMD5Hash(password + HashSalt);
        }

        /**
         * Sees if the stored password is equal to the passed password
         */
        public bool encryptedPasswordEquals(string password)
        {
            return Password == MD5Encrypter.GetMD5Hash(password + HashSalt);
        }
    }
}