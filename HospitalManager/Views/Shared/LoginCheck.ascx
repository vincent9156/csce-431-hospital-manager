<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% if (AuthenticationChecker.IsAuthenticated()) { %>
Welcome <b><%: AuthenticationChecker.AuthenticatedUser() %></b>!
[ <%: Html.ActionLink("Log off", "LogOff", "Authentication") %> ]
<% } else { %>
[ <%: Html.ActionLink("Login", "Login", "Authentication") %> ]
<% } %>