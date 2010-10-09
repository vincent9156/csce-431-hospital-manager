using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    public class UserTypesViewModel
    {
        public IEnumerable<UserType> UserTypes { get; set; }
        public int TypeID { get; set; }
    }
}