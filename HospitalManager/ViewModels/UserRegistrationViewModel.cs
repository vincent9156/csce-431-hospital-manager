using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Libraries;
using System.ComponentModel.DataAnnotations;
using HospitalManager.Models;
using System.Globalization;
using System.ComponentModel;
using HospitalManager.Repositories;

namespace HospitalManager.ViewModels
{
    /// <summary>
    /// Contains the validation properties for registration
    /// </summary>
    [PropertiesMustMatch("Password", "PasswordRepeat", 
                         ErrorMessage = "The password and repeated passwords did not match")]
    [StaffIDValid("TypeID", "StaffID",
                  ErrorMessage = "Invalid staff ID")]
    public class UserRegistrationViewModel
    {
        /// <summary>
        /// User type id
        /// </summary>
        [Required]
        [Range(UserType.MinUserTypeID, UserType.MaxUserTypeID)]
        public int TypeID { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [StringLength(16, ErrorMessage = "Must be under 16 characters")]
        public string Username { get; set; }

        /// <summary>
        /// Password (in plaintext)
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [StringLength(Int32.MaxValue, MinimumLength = 6, ErrorMessage = "Must be at least 6 characters")]
        public string Password { get; set; }

        /// <summary>
        /// The user's repeated password
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public string PasswordRepeat { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Must be under 16 characters")]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$",
                           ErrorMessage="Not a valid email address")]
        public string Email { get; set; }

        /// <summary>
        /// Speciality (doctors only)
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Staff ID (staff only, not for patients)
        /// </summary>
        public int StaffID { get; set; }

        public int Permissions { get; set; }


        /// <summary>
        /// Check whether the user has access to the given option(s)
        /// </summary>
        /// <param name="options">Options to test</param>
        /// <returns>True if they have access, false otherwise</returns>
        public bool HasAccess(AccessOptions options)
        {
            return PermissionsManager.HasAccess(Permissions, options);
        }
    }

    /// <summary>
    /// A StaffID validator to check to see if a staff ID is valid
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class StaffIDValid : ValidationAttribute
    {
        private const string _defaultErrorMessage = "Invalid Staff ID";

        private readonly object _typeId = new object();

        public StaffIDValid(string typeIDProperty, string staffIDProperty)
            : base(_defaultErrorMessage)
        {
            TypeIDProperty = typeIDProperty;
            StaffIDProperty = staffIDProperty;
        }

        public string TypeIDProperty
        {
            get;
            private set;
        }

        public string StaffIDProperty
        {
            get;
            private set;
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            int typeID = (int) properties.Find(TypeIDProperty, true).GetValue(value);
            int staffID = (int) properties.Find(StaffIDProperty, true).GetValue(value);
            
            // Patients are always valid
            if(typeID == UserType.PatientTypeID) {
                return true;
            }

            // Validate staff
            var userRep = new UserRepository();
            var result = userRep.GetStaffMemberByID(staffID);
            return result != null && result.TypeID == typeID;
        }
    }

    /// <summary>
    /// A PropertiesMustMatchAttribute (Code sample from Microsoft) to ensure two data attributes match
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' and '{1}' do not match.";

        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty
        {
            get;
            private set;
        }

        public string OriginalProperty
        {
            get;
            private set;
        }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }
}