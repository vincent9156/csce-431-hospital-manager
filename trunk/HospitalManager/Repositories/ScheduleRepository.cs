using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private SchedulesDataContext _db;

        public ScheduleRepository()
        {
            _db = new SchedulesDataContext();
        }

        //Return A List Of All Doctors
        public IList<Doctors> ListAll()
        {
            var docs = from d in _db.Doctors
                       select d;

            return docs.ToList();
        }
    }
}