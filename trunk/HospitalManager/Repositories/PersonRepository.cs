using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        // Our data context for our database
        private PersonDataContext personDb;

        public PersonRepository()
        {
            personDb = new PersonDataContext();
        }

        /**
         * Get a person from the database by name
         */
        public Person GetPersonByName(string firstName, string lastName)
        {
            // Return the first person with the requested name
            var person = from p in personDb.Persons
                         where p.FirstName == firstName && p.LastName == lastName
                         select p;
            return person.First();
        }
    }
}