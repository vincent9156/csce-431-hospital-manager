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

        public void CreateDateEntry(int id, int date, string month, int year)
        {
            Schedule sched = new Schedule();

            sched.Month = month;
            sched.UserID = id;
            sched.Year = year;
            sched.Day = date;

            sched._0900 = 0;
            sched._0930 = 0;
            sched._1000 = 0;
            sched._1030 = 0;
            sched._1100 = 0;
            sched._1130 = 0;
            sched._1200 = 0;
            sched._1230 = 0;
            sched._1300 = 0;
            sched._1330 = 0;
            sched._1400 = 0;
            sched._1430 = 0;
            sched._1500 = 0;
            sched._1530 = 0;
            sched._1600 = 0;
            sched._1630 = 0;

            _dbSched.Schedules.InsertOnSubmit(sched);
        }

    }
}