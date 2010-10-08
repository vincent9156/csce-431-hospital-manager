using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HospitalManager.Libraries
{
    public static class AuthenticationChecker
    {
        /**
         * If the user is authenticated, return their username, else return null
         * */
        public static string AuthenticatedUser()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
                return null;
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            return ticket.Name;
        }

        public static bool IsAuthenticated()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
                return false;
            else
                return true;
        }
    }
}