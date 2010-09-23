using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManager.ViewModels
{
    /**
     * A ViewModel containing only the data that a View would need
     */
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
    }
}