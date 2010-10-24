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
            <li> <%:Html.ActionLink("View Schedule", "Index", "Schedule")%></li> 
       <% } %> 
<% if (Session.GetUser().HasAccess(AccessOptions.ViewSchedule))
       { %>
            <li> <%:Html.ActionLink("View Profile", "ViewProfile", "Home")%></li> 
       <% } %> 

    <!--

    *********** Removed to free up permissions ************

    <% /* if (Session.GetUser().HasAccess(AccessOptions.EditMedicalHistory))
       { %>
            <li> <%:Html.ActionLink("Medical History", " ")%> </li>  
       <% } %> 

    <% if (Session.GetUser().HasAccess(AccessOptions.EditAppointments))
       { %>
            <li> <%:Html.ActionLink("Appointments", " ")%> </li>  
       <% } %> 

    <% if (Session.GetUser().HasAccess(AccessOptions.ViewPrescriptions))
       { %>
            <li> <%:Html.ActionLink("Prescriptions", " ")%> </li>  
       <% } %> 

    <% if (Session.GetUser().HasAccess(AccessOptions.EditPrescriptions))
       { %>
            <li> <%:Html.ActionLink("Prescriptions", " ")%> </li>  
       <% } %> 

    <% if (Session.GetUser().HasAccess(AccessOptions.ViewCurrentBill))
       { %>
            <li> <%:Html.ActionLink("Current Bill", " ")%> </li>  
   <% } */ %> 
   -->

</ul>
<% } %>
