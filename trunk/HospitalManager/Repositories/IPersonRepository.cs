using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    interface IPersonRepository
    {
        /**
         * Get a person from the database by name
         */
        Person GetPersonByName(string firstName, string lastName);
    }
}
