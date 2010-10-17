<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<% HttpSessionState Session = HttpContext.Current.Session; %>


<%-- Default Links --%>
<% if (Session["User"] == null)
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
    <% if (((User)Session["User"]).HasAccess(AccessOptions.ViewSchedule))
       { %>
            <li> <%:Html.ActionLink("View Schedule", "Index", "Schedule")%></li> 
       <% } %> 

    <% if (((User)Session["User"]).HasAccess(AccessOptions.EditMedicalHistory))
       { %>
            <li> <%:Html.ActionLink("Medical History", " ")%> </li>  
       <% } %> 

    <% if (((User)Session["User"]).HasAccess(AccessOptions.EditAppointments))
       { %>
            <li> <%:Html.ActionLink("Appointments", " ")%> </li>  
       <% } %> 

    <% if (((User)Session["User"]).HasAccess(AccessOptions.ViewPrescriptions))
       { %>
            <li> <%:Html.ActionLink("Prescriptions", " ")%> </li>  
       <% } %> 

    <% if (((User)Session["User"]).HasAccess(AccessOptions.EditPrescriptions))
       { %>
            <li> <%:Html.ActionLink("Prescriptions", " ")%> </li>  
       <% } %> 

    <% if (((User)Session["User"]).HasAccess(AccessOptions.ViewCurrentBill))
       { %>
            <li> <%:Html.ActionLink("Current Bill", " ")%> </li>  
   <% } %> 


</ul>
<% } %>
