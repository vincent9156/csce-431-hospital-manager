using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.ViewModels
{
    /// <summary>
    /// ViewModel used by SearchController to store results of searching for Users in the database
    /// </summary>
    public class SearchViewModel
    {
        public UserViewModel LoggedInUser; //used for checking permissions on seacrching
        public IList<UserViewModel> SearchResults; 
    }
}