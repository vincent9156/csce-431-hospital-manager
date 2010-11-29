using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    /// <summary>
    /// Handles adding to and modifying a user's current medical history
    /// </summary>
    public class CurrentMedicalHistoryRepository
    {
        private CurrentMedicalHistoryDataContext currentMedDb;

        /// <summary>
        /// Initialize the database context
        /// </summary>
        public CurrentMedicalHistoryRepository()
        {
            currentMedDb = new CurrentMedicalHistoryDataContext();
        }  

        /// <summary>
        /// Get a user's medical history
        /// </summary>
        /// <param name="user">The user to get medical history for</param>
        /// <returns>The user's current medical history</returns>
        public IQueryable<CurrentMedicalHistory> GetCurrentMedicalHistoryByUser(User user)
        {
            var result = from CurrentMedicalHistory in currentMedDb.CurrentMedicalHistories
                         where CurrentMedicalHistory.UserID == user.UserID
                         orderby CurrentMedicalHistory.Day ascending
                         orderby CurrentMedicalHistory.Month ascending
                         orderby CurrentMedicalHistory.Year ascending
                         select  CurrentMedicalHistory;
                             
            return result;
        }
        
        /// <summary>
        /// Add current medical history to the database
        /// </summary>
        /// <param name="mh">Current medical history to add</param>
        /// <returns></returns>
        public int AddCurrentMedicalHistory(CurrentMedicalHistory mh)
        {
            // make sure a visit has not been added this day 
            /*var result = from CurrentMedicalHistory in currentMedDb.CurrentMedicalHistories
                         where CurrentMedicalHistory.UserID == mh.UserID
                         where CurrentMedicalHistory.Day == mh.Day
                         where CurrentMedicalHistory.Month == mh.Month
                         where CurrentMedicalHistory.Year == mh.Year
                         select CurrentMedicalHistory;
            if(result.Count() == 0)
                return -1;
            */

            currentMedDb.CurrentMedicalHistories.InsertOnSubmit(mh);
            currentMedDb.SubmitChanges();

            return 0;
        }
    }
}