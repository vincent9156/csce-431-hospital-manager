using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class UserRepository
    {
        private UsersDatabase usersDb;

        /**
         * Initialize the database context
         */
        public UserRepository()
        {
            usersDb = new UsersDatabase();
        }

        /**
         * Get a user by their username
         */
        public User GetUserByUsername(string username)
        {
            var result = from user in usersDb.Users
                         where user.Username == username
                         select user;

            // Just return null if we get no results
            if (result.Count() == 0)
                return null;

            return result.First();
        }

        /**
         * Get a queryable collection of users by their first and last names
         */
        public IQueryable<User> GetUserByName(string firstName, string lastName)
        {
            var result = from user in usersDb.Users
                         where user.FirstName == firstName
                            && user.LastName == lastName
                         select user;

            // Return a queryable collection of users with the given names
            return result;
        }

        /**
         * Add a user to the database, returning their user id
         */
        public int AddUser(User user)
        {
            usersDb.Users.InsertOnSubmit(user);
            usersDb.SubmitChanges();
            return user.UserID;
        }

        /**
         * Get a queryable collection of all the user types
         */
        public IQueryable<UserType> GetUserTypes()
        {
            var result = from userType in usersDb.UserTypes
                         select userType;

            return result;
        }
    }
}