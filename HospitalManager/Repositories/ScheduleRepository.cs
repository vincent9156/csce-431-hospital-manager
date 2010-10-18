using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class ScheduleRepository
    {
        private ScheduleDataContext _dbSched;

        public ScheduleRepository()
        {
            _dbSched = new ScheduleDataContext();
        }

        //Return A List Of All Doctors
        public IList<ScheduleUsers> ListDoctors()
        {
            var docs = from d in _dbSched.ScheduleUsers
                       where d.TypeID == 2
                       select d;

            return docs.ToList();
        }

        //Return the schdule for a given user
        public IList<Schedule> ListUserSchedule(int id, string month, int year)
        {
            var schd = from s in _dbSched.Schedules
                       where s.UserID == id && s.Month == month && s.Year == year
                       select s;

            return schd.ToList();
        }

        //return a doctors schedule
        public IList<Schedule> ListDoctorSchedule(int id, string month, int year)
        { 
            var schd = from d in _dbSched.ScheduleUsers
                       join s in _dbSched.Schedules on d.UserID equals s.UserID
                       where (d.UserID==id) && (s.Month == month) && (s.Year == year)
                       select s;

            return schd.ToList();
        }

    }
}