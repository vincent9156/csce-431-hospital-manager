<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% var Session = new HospitalManager.Repositories.SessionRepository(); %>


<%-- Default Links --%>
<% if (Session.GetUser() == null)
   { %>
   <%-- display no links if no user is logged in --%>
<%-- Get links based on user type --%>
<% }
   else
   {%>
    <%@ Import Namespace="HospitalManager.Models" %>
       <ul class="navi">

       <li> <%: Html.ActionLink("Home", "UserLog", "Home") %></li>

    <% if (Session.GetUser().HasAccess(AccessOptions.ViewSchedule))
       { %>
            <li> <%:Html.ActionLink("View Schedule", "Index", "Appointment")%></li> 
    <% } %>
    <% if (Session.GetUser().HasAccess(AccessOptions.SearchUsers))
       { %>
            <li> <%:Html.ActionLink("Search Users", "SearchUser", "Search")%></li>
    <% } %>
    <% if (Session.GetUser().HasAccess(AccessOptions.EditOwnMedicalHistory))
       { %>
            <li> <%:Html.ActionLink("View Medical History", "", "PastMedicalHistory")%></li>
            <li> <%:Html.ActionLink("Edit Medical History", "Edit", "PastMedicalHistory")%></li>
    <% } %>
    <% if (Session.GetUser().HasAccess(AccessOptions.ViewSchedule))
       { %>
            <li> <%:Html.ActionLink("View Profile", "ViewProfile", "Home")%></li> 
    <% } %>
    <% if (Session.GetUser().HasAccess(AccessOptions.ViewBills))
       { %>
            <li> <%:Html.ActionLink("View My Bills", "Index", "Billing")%></li> 
    <% } %>
    </ul>
<% } %>
