<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% HttpSessionState Session = HttpContext.Current.Session; %>

<% if (Session["User"] != null) { %>
<!-- TODO:
    Right now the username links to a status test page. Eventually make it link to either a view/modify medical history page
    or their personal home page.
-->
    Welcome <b><%: Html.ActionLink(Session["Username"].ToString(), "StatusTest", "Authentication") %></b>!
    [ <%: Html.ActionLink("Log off", "LogOff", "Authentication") %> ]
<% } else { %>
    [ <%: Html.ActionLink("Login", "Login", "Authentication") %> ] [ <%: Html.ActionLink("Register", "Register", "Authentication") %> ]
<% } %>