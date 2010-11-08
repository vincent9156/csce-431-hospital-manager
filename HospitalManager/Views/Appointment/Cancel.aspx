<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.AppointmentViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cancel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
<div id = "body">
    <h2>Cancel Appointment</h2>

    <form action="CancelApp" method="post">

    <select name="AppointmenID" id="AppointmenID">
    <% foreach(var item in Model.appointments){ %>
    <option value="<%:item %>"><%: item.DoctorFirstName + " " + item.DoctorLastName + " " + item.Date.Date.ToString("d") + item.Time.ToString("t") %></option>
    <%} %>
    </select>

    <br /><br />
    <input type="submit" name="Submit" />

    <!--<table border="1" cellpadding="5" cellspacing="0" style="border-color:White;" width="100%">
     <%if (Model != null)
       {%>
    <tr align="center" style="font-weight:bold; font-size:large; background-color:Gray;">
        <td>Cancel</td><td>Patient</td><td>Doctor</td><td>Date</td><td>Time</td>
    </tr>
    <%foreach (var item in Model.appointments)
      { %>
        <tr align="center">
            
            <td><%: Html.ActionLink("Cancel","CancelApp","Appointment", item) %></td>
            <td><%: item.PatientFirstName + " " + item.PatientLastName%></td>
            <td><%: item.DoctorFirstName + " " + item.DoctorLastName%></td>
            <td><%: item.Date.Date.ToString("d")%></td>
            <td><%: item.Time.ToString("t")%></td>
        </tr>
        <% } %>

      <%} %>
    
    <%else
      { %>
    <tr><td><%: "You currently have no scheduled appointments!"%></td></tr>
    <% } %>

    </table> -->



       


</div>
</div>

</asp:Content>
