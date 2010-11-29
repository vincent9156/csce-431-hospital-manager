using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    /// <summary>
    /// Handles adding users and viewing users
    /// </summary>
    public class UserRepository
    {
        private UsersDatabase usersDb;

        /// <summary>
        /// Initialize the database context
        /// </summary>
        public UserRepository()
        {
            usersDb = new UsersDatabase();
        }

        /// <summary>
        /// Get a user by their username
        /// </summary>
        /// <param name="username">Username to query</param>
        /// <returns>User or null if username is not in database</returns>
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

        /// <summary>
        /// Get a user by their UserID
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User or null if user id is not in database</returns>
        public User GetUserByUserID(int id)
        {
            var result = from user in usersDb.Users
                         where user.UserID == id
                         select user;
            if (result.Count() == 0)
                return null;
            return result.First();
        }

        /// <summary>
        /// Get a queryable collection of users by their first and last names
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <returns></returns>
        public IQueryable<User> GetUserByName(string firstName, string lastName)
        {
            var result = from user in usersDb.Users
                         where user.FirstName == firstName
                            && user.LastName == lastName
                         select user;

            // Return a queryable collection of users with the given names
            return result;
        }

        /// <summary>
        /// Get a queryable collection of users by their first, last name and user type
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="userTypeID">User's type id</param>
        /// <returns>IQueryable of users that fit the parameters or null if none exist</returns>
        public IQueryable<User> GetUserByName(string firstName, string lastName, int userTypeID)
        {
            var result = from user in usersDb.Users
                         where user.FirstName == firstName
                            && user.LastName == lastName
                            && user.UserType.TypeID == userTypeID
                         select user;

            // Return a queryable collection of users with the given names
            return result;
        }

        /// <summary>
        /// Add a user to the database, returning their user id
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns>The new user's user id</returns>
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

        /// <summary>
        /// Get a queryable collection of all the user types
        /// </summary>
        /// <returns>IQueryable of user types</returns>
        public IQueryable<UserType> GetUserTypes()
        {
            var result = from userType in usersDb.UserTypes
                         select userType;

            return result;
        }

        /// <summary>
        /// Get a user type by its type id
        /// </summary>
        /// <param name="typeID">Type id to look up</param>
        /// <returns>The UserType or null if none exists</returns>
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

        /// <summary>
        /// Get a staff member record based upon the staff id
        /// </summary>
        /// <param name="staffID">Staff id to check</param>
        /// <returns>StaffMember or null if none exists</returns>
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

        /// <summary>
        /// changes database info for user based on username
        /// </summary>
        /// <param name="NewUserName">The user's new username</param>
        /// <param name="u">Other new user info</param>
        public void EditUserByUsername(String NewUserName, User u)
        {
            var result = (from user in usersDb.Users
                          where user.Username == u.Username
                          select user).First();

            result.FirstName = u.FirstName;
            result.LastName = u.LastName;
            result.Email = u.Email;
            result.Username = NewUserName;
            if (!result.HasAccess(Libraries.AccessOptions.RegisterWithoutStaffID))
            {
                result.Speciality = u.Speciality;
            }
            usersDb.SubmitChanges();
        }

        /// <summary>
        /// change the password of user u to pass
        /// </summary>
        /// <param name="u">User to edit</param>
        /// <param name="pass">New user password</param>
        /// <returns>Edited user</returns>
        public User ChangeUserPassword(User u, String pass)
        {
            var result = (from user in usersDb.Users
                          where user.UserID == u.UserID
                          select user).First();
            result.EncryptAndSetPassword(pass);
            usersDb.SubmitChanges();
            return result;
        }
        
        /// <summary>
        /// returns all users based on the type searched for example: get all doctors
        /// </summary>
        /// <param name="userType">User type to query</param>
        /// <returns>IQueryable of all users of a certain type</returns>
        public IQueryable<User> GetAllUsersBasedOnType(int userType)
        {
            var result = from user in usersDb.Users
                         where user.UserType.TypeID == userType
                         select user;

            return result;
        }

        /// <summary>
        /// Returns patients under a given doctor
        /// </summary>
        /// <param name="doctorID">ID of the doctor</param>
        /// <param name="firstName">First name of the patient</param>
        /// <param name="lastName">Last name of the patient</param>
        /// <returns>All patients that match the given parameters</returns>
        public IQueryable<VWPatientsByDoctor> GetPatientByDoctor(int doctorID, string firstName, string lastName)
        {
            var apptRep = new AppointmentRepository();
            return from patient in apptRep.GetDoctorPatients(doctorID)
                       where patient.PatientFirstName == firstName
                            && patient.PatientLastName == lastName
                       select patient;
        }
    }
}