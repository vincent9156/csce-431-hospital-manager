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
                         select CurrentMedicalHistory;
            return result;
            
        }
    }
}