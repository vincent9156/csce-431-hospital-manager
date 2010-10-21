<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID = "linkcontent" ContentPlaceHolderID = "MainContent" runat= "server"> 


<ul> 
<% if (Model.HasAccess(AccessOptions.ViewSchedule))
   { %>
        <li> <%:Html.ActionLink ("Set Appointment","Index", "Schedule") %></li> 
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


</asp:Content>


   
    
