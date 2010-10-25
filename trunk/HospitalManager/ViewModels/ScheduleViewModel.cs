using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;
using HospitalManager.Repositories;

namespace HospitalManager.ViewModels
{
    public class ScheduleViewModel
    {

        public ScheduleViewModel(User u, int d, IList<ScheduleUsers> dlist)
        {
            // TODO: Complete member initialization
            this.user = u;
            this.Docid = d;
            this.docs = dlist;
        }

        public ScheduleViewModel(User u, int d, string m, IList<ScheduleUsers> dlist)
        {
            this.user = u;
            this.Docid = d;
            this.month = m;
            this.docs = dlist;
        }

        public User user { get; set;}
        public int Docid { get; set;}
        public string month { get; set;}
        public IList<ScheduleUsers> docs { get; set;}
    }
}