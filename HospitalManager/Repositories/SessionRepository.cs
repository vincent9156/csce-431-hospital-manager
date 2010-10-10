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
    public class SessionRepository
    {
        private HttpSessionState Session;
        private HttpRequest Request;

        public SessionRepository()
        {
            // Initialize the context needed for session management
            Session = HttpContext.Current.Session;
            Request = HttpContext.Current.Request;
        }

        /**
         * Set a user as logged in
         */
        public void Login(User user)
        {
            Session["User"] = user;
            Session["Username"] = user.Username;
            Session["AuthString"] = GetAuthString();
        }

        /**
         * Set a user as logged out
         */
        public void Logout()
        {
            Session.Remove("User");
            Session.Remove("Username");
            Session.Remove("AuthString");
        }

        /**
         * Returns if a user is logged in
         */
        public bool IsLoggedIn()
        {
            return Session["User"] != null && Session["AuthString"].Equals(GetAuthString());
        }

        /**
         * Get the currently logged in User, or null if the user is not logged in
         */
        public User GetUser()
        {
            return (Session["User"] != null) ? (User)Session["User"] : null;
        }

        /**
         * Generates an authentication string to provide some defense against session hijacking
         */
        private string GetAuthString()
        {
            return MD5Encrypter.GetMD5Hash(Request.UserAgent + Request.UserHostAddress);
        }
    }
}