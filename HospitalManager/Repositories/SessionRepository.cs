using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using HospitalManager.Models;
using HospitalManager.Libraries;

namespace HospitalManager.Repositories
{
    /// <summary>
    /// Handles logging in, logging out, and checking the state of users
    /// </summary>
    public class SessionRepository
    {
        /// <summary>
        /// A reference to the current session. Used for storing the user's
        /// information.
        /// </summary>
        private HttpSessionState Session;

        /// <summary>
        /// A reference to the current request. Used for getting informatin
        /// about the user for increased security.
        /// </summary>
        private HttpRequest Request;

        /// <summary>
        /// Initialize the context needed for session management
        /// </summary>
        public SessionRepository()
        {
            Session = HttpContext.Current.Session;
            Request = HttpContext.Current.Request;
        }

        /// <summary>
        /// Set a user as logged in
        /// </summary>
        /// <param name="user">The user to log in</param>
        public void Login(User user)
        {
            Session["User"] = user;
            Session["Username"] = user.Username;
            Session["AuthString"] = GetAuthString();
        }

        /// <summary>
        /// Set the current user as logged out
        /// </summary>
        public void Logout()
        {
            Session.Remove("User");
            Session.Remove("Username");
            Session.Remove("AuthString");
        }

        /// <summary>
        /// Check if a user is logged in
        /// </summary>
        /// <returns>True if logged in, false otherwise</returns>
        public bool IsLoggedIn()
        {
            return Session["User"] != null && Session["AuthString"].Equals(GetAuthString());
        }

        /// <summary>
        /// Get the currently logged in User
        /// </summary>
        /// <returns>The logged in User or null if no user is logged in</returns>
        public User GetUser()
        {
            return (Session["User"] != null) ? (User)Session["User"] : null;
        }

        /// <summary>
        /// Generates an authentication string to provide some defense against session hijacking
        /// </summary>
        /// <returns>The generated authentication string</returns>
        private string GetAuthString()
        {
            return MD5Encrypter.GetMD5Hash(Request.UserAgent + Request.UserHostAddress);
        }
    }
}