<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% HttpSessionState Session = HttpContext.Current.Session; %>

<% if (Session["User"] != null) { %>
    Welcome <b><%: Html.ActionLink(Session["Username"].ToString(), "ViewProfile", "Home") %></b>!
    [ <%: Html.ActionLink("Log off", "LogOff", "Authentication") %> ]
<% } else { %>
    [ <%: Html.ActionLink("Login", "Login", "Authentication") %> ] [ <%: Html.ActionLink("Register", "Register", "Authentication") %> ]
<% } %>