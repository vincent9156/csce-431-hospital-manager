using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.ViewModels
{
    // TODO: validation!!
    public class UserBillingInfoViewModel
    {
        public string CardNumber { get; set; }

        public int SecurityCode { get; set; }

        public string CardProv { get; set; }

        public int CardProvID { get; set; }

        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public string Address { get; set; }

        public string PolicyNum { get; set; }

        public string ProviderName { get; set; }
    }
}