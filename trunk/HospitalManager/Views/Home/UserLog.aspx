<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="titlecontent" ContentPlaceHolderID="TitleContent" runat="server">
    HM-Home
</asp:Content>

<asp:Content ID = "linkcontent" ContentPlaceHolderID = "MainContent" runat= "server"> 
<div id="main_body">
<div id="body">

<ul> 
<% if (Model.HasAccess(AccessOptions.ViewSchedule))
   { %>
        <li> <%:Html.ActionLink ("Set Appointment","Index", "Appointment") %></li> 
   <% } %> 

<% if (Model.HasAccess(AccessOptions.EditOwnMedicalHistory)) { %>
    <li><%: Html.ActionLink("View Your Medical History", "Index", "PastMedicalHistory")%></li>
    <li><%: Html.ActionLink("Edit Your Medical History", "Edit", "PastMedicalHistory")%></li>
<% } %>

<% if (Model.HasAccess(AccessOptions.SearchUsers)) { %>
    <li><%: Html.ActionLink("Search Patients", "SearchUser", "Search")%></li>
<% } %>
   <% if (Model.HasAccess(AccessOptions.ViewPrescriptions))
       { %>
            <li> <%:Html.ActionLink("View My Prescriptions", "Index", "Prescription")%> </li>  
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

<br />
</div></div>
</asp:Content>


   
    
