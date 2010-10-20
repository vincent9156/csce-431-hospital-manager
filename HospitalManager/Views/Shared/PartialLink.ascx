<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% var Session = new HospitalManager.Repositories.SessionRepository(); %>


<%-- Default Links --%>
<% if (Session.GetUser() == null)
   { %>

<ul class="navi">
    <li><a href="#">Link 1</a></li>
    <li><a href="#">Link 2</a></li>
    <li><a href="#">Link 3</a></li>
    <li><a href="#">Oh look another link!</a></li>
    <li class="li1"><a href="#">And 1 more</a></li>
  </ul>-

<%-- Get links based on user type --%>
<% }
   else
   {%>
    <%@ Import Namespace="HospitalManager.Models" %>
       <ul class="navi"> 

    <% if (Session.GetUser().HasAccess(AccessOptions.ViewSchedule))
       { %>
            <li> <%:Html.ActionLink("View Schedule", "Index", "Schedule")%></li> 
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
