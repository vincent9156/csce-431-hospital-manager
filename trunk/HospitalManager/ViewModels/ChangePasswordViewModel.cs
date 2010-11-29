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
    /// ViewModel containing old and new password info
    /// </summary>
    [PropertiesMustMatch("Password", "PasswordRepeat", ErrorMessage = "Password and repeated password must match")]
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// The user's old password
        /// </summary>
        [Required(ErrorMessage="Required")]
        public string OldPassword { get; set; }

        /// <summary>
        /// The user's new password
        /// </summary>
        [Required(ErrorMessage="Required")]
        [StringLength(Int32.MaxValue, MinimumLength = 6, ErrorMessage = "Must be at least 6 characters")]
        public string Password { get; set; }

        /// <summary>
        /// The user's new password repeated
        /// </summary>
        [Required(ErrorMessage="Required")]
        public string PasswordRepeat { get; set; }
    }
}