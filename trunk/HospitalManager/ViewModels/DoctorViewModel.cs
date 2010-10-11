using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.ViewModels
{
    /**
     * This is currently just a stub that will likely be useful in the future.
     */
    public class DoctorViewModel : UserViewModel
    {
        public int id { get; set;}
        public string FName { get; set; }
        public string LName { get; set; }
    }
}