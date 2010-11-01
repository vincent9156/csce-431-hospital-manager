using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class CurrentMedicalHistoryRepository
    {
        private CurrentMedicalHistoryDataContext currentMedDb;

        /**
         * Initialize the database context
         */
        public CurrentMedicalHistoryRepository()
        {
            currentMedDb = new CurrentMedicalHistoryDataContext();
        }  

        /**
         * Get a user by their userID
         */
        public IQueryable<CurrentMedicalHistory> GetCurrentMedicalHistoryByUser(User user)
        {
            var result = from CurrentMedicalHistory in currentMedDb.CurrentMedicalHistories
                         where CurrentMedicalHistory.UserID == user.UserID
                         orderby CurrentMedicalHistory.Day ascending
                         orderby CurrentMedicalHistory.Month ascending
                         orderby CurrentMedicalHistory.Year ascending
                         select CurrentMedicalHistory;
                         
            return result;
        }

        public int AddCurrentMedicalHistory(CurrentMedicalHistory mh)
        {
            // make sure a visit has not been added this day 
            var result = from CurrentMedicalHistory in currentMedDb.CurrentMedicalHistories
                         where CurrentMedicalHistory.UserID == mh.UserID
                         where CurrentMedicalHistory.Day == mh.Day
                         where CurrentMedicalHistory.Month == mh.Month
                         where CurrentMedicalHistory.Year == mh.Year
                         select CurrentMedicalHistory;
            if(result.Count() == 0)
                return -1;

            currentMedDb.CurrentMedicalHistories.InsertOnSubmit(mh);
            currentMedDb.SubmitChanges();

            return 0;
        }
    }
}