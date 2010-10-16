﻿using System;
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
            // Submit the user based on their type ID
            switch (user.TypeID)
            {
                case UserType.PatientTypeID:
                    usersDb.Users.InsertOnSubmit((Patient) user);
                    break;
                case UserType.DoctorTypeID:
                    usersDb.Users.InsertOnSubmit((Doctor) user);
                    break;
                case UserType.NurseTypeID:
                    usersDb.Users.InsertOnSubmit((Nurse) user);
                    break;
                case UserType.PharmacistTypeID:
                    usersDb.Users.InsertOnSubmit((Pharmacist) user);
                    break;
            }
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

        /**
         * Get a user type by its type id
         */
        public UserType GetUserTypeByID(int typeID)
        {
            var result = from userType in usersDb.UserTypes
                         where userType.TypeID == typeID
                         select userType;

            // Just return null if we get no results
            if (result.Count() == 0)
                return null;

            return result.First();
        }

        /**
         * Get a staff member record based upon the 
         */
        public StaffMember GetStaffMemberByID(int staffID)
        {
            var result = from staffMember in usersDb.StaffMembers
                         where staffMember.StaffID == staffID
                         select staffMember;

            // Just return null if we get no results
            if (result.Count() == 0)
                return null;

            return result.First();
        }
    }
}