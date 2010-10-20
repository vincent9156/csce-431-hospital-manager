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

    ***** Removed to free up permissions *****

<%
     if (Model.HasAccess(AccessOptions.EditMedicalHistory))
   { %>
        <li> <%:Html.ActionLink ("Edit Medical History"," ") %> </li>  
   <% } %> 

<% if (Model.HasAccess(AccessOptions.EditAppointments))
   { %>
        <li> <%:Html.ActionLink ("Edit Appointments"," ") %> </li>  
   <% } %> 

<% if (Model.HasAccess(AccessOptions.ViewPrescriptions))
   { %>
        <li> <%:Html.ActionLink("View Prescriptions", " ")%> </li>  
   <% } %> 

<% if (Model.HasAccess(AccessOptions.EditPrescriptions))
   { %>
        <li> <%:Html.ActionLink("Edit Prescriptions", " ")%> </li>  
   <% } %> 

<% if (Model.HasAccess(AccessOptions.ViewCurrentBill))
   { %>
        <li> <%:Html.ActionLink("View Current Bill", " ")%> </li>  
   <% } %> 

   -->


</ul>


</asp:Content>


   
    
