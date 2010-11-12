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
    [PropertiesMustMatch("Password", "PasswordRepeat", ErrorMessage = "Password and repeated password must match")]
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage="Required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage="Required")]
        [StringLength(Int32.MaxValue, MinimumLength = 6, ErrorMessage = "Must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage="Required")]
        public string PasswordRepeat { get; set; }
    }
}