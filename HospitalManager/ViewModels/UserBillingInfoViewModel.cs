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
    /// ViewModel containing user billing information.
    /// Note that no validation of credit card information is done. This is intentional
    /// as we do not want to collect valid credit cards with our system.
    /// </summary>
    public class UserBillingInfoViewModel
    {
        /// <summary>
        /// Credit card number
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Credit card security code
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public int SecurityCode { get; set; }

        /// <summary>
        /// Credit card provider
        /// </summary>
        public IEnumerable<CardProvider> CardProvider { get; set; }

        /// <summary>
        /// Credit card provider id
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public int CardProviderID { get; set; }

        /// <summary>
        /// Credit card expiration month
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public int ExpMonth { get; set; }

        /// <summary>
        /// Credit card expiration year
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public int ExpYear { get; set; }

        /// <summary>
        /// Billing address
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        /// <summary>
        /// Health insurance policy number
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public string PolicyNum { get; set; }

        /// <summary>
        /// Health insurance provider name
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public string ProviderName { get; set; }
    }
}