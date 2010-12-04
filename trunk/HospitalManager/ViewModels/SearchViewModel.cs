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
        /// <summary>
        /// Used for determining which options to show to the searching user.
        /// </summary>
        public UserViewModel LoggedInUser;

        /// <summary>
        /// The results of the search
        /// </summary>
        public IList<UserViewModel> SearchResults; 
    }
}