using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    public class SearchViewModel
    {
        public User LoggedInUser;
        public IList<UserViewModel> SearchResults;
    }
}