<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.AppointmentViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Appointment Scheduler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div id="main_body">
    <div id="body">
    <h2>Select Time</h2>
    <form action="/Appointment/AddAppointment" method="post">
    <table width="100%">
    <tr valign="top">
    <td>
        <!---<input type="hidden" name="DoctorID" id="DoctorID" value="" />
        <input type="hidden" name="Date" id="Date" value="" />
        --->
        Please Select a Time:<br />
        <select name="Time" id="Time">
            <option value="9:00"  <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(9,00,00))){ %> <%:"disabled" %><%} %> >9:00</option>
            <option value="9:30"  <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(9,30,00))){ %> <%:"disabled" %><%} %> >9:30</option>
            <option value="10:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(10,00,00))){ %> <%:"disabled" %><%} %> >10:00</option>
            <option value="10:30" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(10,30,00))){ %> <%:"disabled" %><%} %> >10:30</option>
            <option value="11:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(11,00,00))){ %> <%:"disabled" %><%} %> >11:00</option>
            <option value="11:30" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(11,30,00))){ %> <%:"disabled" %><%} %> >11:30</option>
            <option value="12:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(12,00,00))){ %> <%:"disabled" %><%} %> >12:00</option>
            <option value="12:30" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(12,30,00))){ %> <%:"disabled" %><%} %> >12:30</option>
            <option value="1:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(1,00,00))){ %> <%:"disabled" %><%} %> >1:00</option>
            <option value="1:30" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(1,30,00))){ %> <%:"disabled" %><%} %> >1:30</option>
            <option value="2:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(2,00,00))){ %> <%:"disabled" %><%} %> >2:00</option>
            <option value="2:30" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(2,30,00))){ %> <%:"disabled" %><%} %> >2:30</option>
            <option value="3:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(3,00,00))){ %> <%:"disabled" %><%} %> >3:00</option>
            <option value="3:30" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(3,30,00))){ %> <%:"disabled" %><%} %> >3:30</option>
            <option value="4:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(4,00,00))){ %> <%:"disabled" %><%} %> >4:00</option>
            <option value="4:30" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(4,30,00))){ %> <%:"disabled" %><%} %> >4:30</option>
            <option value="5:00" <%if(Model.Times.Exists(TimeSpan t = new TimeSpan(5,00,00))){ %> <%:"disabled" %><%} %> >5:00</option>
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
