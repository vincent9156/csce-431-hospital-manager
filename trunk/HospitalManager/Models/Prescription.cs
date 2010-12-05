using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.Models
{
    public partial class Prescription
    {
        /// <summary>
        /// Get the cost of a given prescription per refill
        /// </summary>
        /// <returns>The cost of the refill</returns>
        public decimal GetCost()
        {
            return Quantity * mgPerPill * Medication.PricePerMg;
        }
    }
}