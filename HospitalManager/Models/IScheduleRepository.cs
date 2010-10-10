using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManager.Models
{
    public interface IScheduleRepository
    {
        IList<Doctors> ListAll();

        IList<Doctors> ListDoctorSchedule();
    }
}
