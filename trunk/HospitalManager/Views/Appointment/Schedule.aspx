<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.AppointmentViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Appointment Scheduler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <script type="text/javascript">
       $(document).ready(function () {
           $("#Date").datepicker({ minDate: '+0', maxDate: '+2m' });
       });

    </script>
    <div id="main_body">
    <div id="body">
    <h2>Schedule Appointment</h2>
    <form action="/Appointment/AddAppointment" method="post">
    <table width="100%">
    <tr valign="top">
    <td>
        Please Input a Date [mm/dd/yyyy]:<br /> <input type="text" id="Date" maxlength="10" name="Date" readonly />
        <br /><br />
        Please Select a Doctor:<br />
        <select name="DoctorID" id="DoctorID">
        <% foreach(var item in Model.Doctors){ %>
        <option value="<%:item.UserID %>"><%: item.FirstName + " " + item.LastName + " " + "( " + item.Speciality + " )" %></option>
        <%} %>
        </select>

        <br /><br />
        Please Select a Time:<br />
        <select name="Time" id="Time">
            <option value="9:00">9:00</option>
            <option value="9:30">9:30</option>
            <option value="10:00">10:00</option>
            <option value="10:30">10:30</option>
            <option value="11:00">11:00</option>
            <option value="11:30">11:30</option>
            <option value="12:00">12:00</option>
            <option value="12:30">12:30</option>
            <option value="1:00">1:00</option>
            <option value="1:30">1:30</option>
            <option value="2:00">2:00</option>
            <option value="2:30">2:30</option>
            <option value="3:00">3:00</option>
            <option value="3:30">3:30</option>
            <option value="4:00">4:00</option>
            <option value="4:30">4:30</option>
            <option value="5:00">5:00</option>
        </select>
    </td>
    </tr>
    <tr>
    <td>
        <br /><br />
        <input type="submit" name="Submit" />
    </td>
    </tr>
    </table>
    </form>
    <br /><br /><br />
    </div>
    </div>
</asp:Content>
