﻿using System;
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
    // TODO: validation!!
    public class UserBillingInfoViewModel
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public int SecurityCode { get; set; }

        public IEnumerable<CardProvider> CardProvider { get; set; }

        [Required]
        public int CardProviderID { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage="Invalid Month")]
        public int ExpMonth { get; set; }

        [Required]
        [Range(2010, Int32.MaxValue, ErrorMessage="Invalid Year")]
        public int ExpYear { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PolicyNum { get; set; }

        [Required]
        public string ProviderName { get; set; }
    }
}