<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.AppointmentViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Appointments
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
<div id = "body">
    <h2>Current Appointments</h2>

   

    <table border="1" cellpadding="5" cellspacing="0" style="border-color:White;" width="100%">
     <%if (Model != null)
       {%>
    <tr align="center" style="font-weight:bold; font-size:large; background-color:Gray;">
        <td>Patient</td><td>Doctor</td><td>Date</td><td>Time</td>
    </tr>
    <%foreach (var item in Model.appointments)
      { %>
        <tr align="center">
            <td><%: item.PatientFirstName + " " + item.PatientLastName%></td>
            <td><%: item.DoctorFirstName + " " + item.DoctorLastName%></td>
            <td><%: item.Date.Date.ToString("d")%></td>
            <td><%: item.AppointmentTime%></td>
        </tr>
        <% } %>

      <%} %>
    
    <%else
      { %>
    <tr><td><%: "You currently have no scheduled appointments!"%></td></tr>
    <% } %>
    </table>

    <br />
    
    <ul style="margin:0;">
        <li>To Schedule an appointment click <%:Html.ActionLink("here","Schedule","Appointment") %></li>
        <li>To cancel an appointment <%: Html.ActionLink("here","Schedule","Cancel") %></li> 
    </ul>   

    <br />
   
</div>
</div>

</asp:Content>
