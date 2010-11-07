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
    <form action="Schedule.aspx" method="post">
    <table width="100%">
    <tr>
    <td>
        Please Input a Date: <input type="text" id="Date" maxlength="10" name="date" />
    </td>
    <td>
        Please Select a Doctor:
        <select name="dropList">
        <% foreach(var item in Model.Doctors){ %>
        <option value="<%:item.UserID %>"><%: item.FirstName + " " + item.LastName + " " + item.Speciality %></option>
        <%} %>
        </select>
    </td>
    </tr>
    </table>
    </form>
    <br /><br /><br /><br /><br />
    <br /><br />
    </div>
    </div>
</asp:Content>
