using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.Models
{
    public partial class Prescription
    {
        public decimal GetCost()
        {
            return Quantity * mgPerPill * Medication.PricePerMg;
        }
    }
}