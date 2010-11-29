<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Reschedule
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <script type="text/javascript">
       $(document).ready(function () {
           $("#Date").datepicker({ minDate: '+0', maxDate: '+7d' });
       });

    </script>
    <div id="main_body">
    <div id="body">
    <h2>Reschedule Appointment</h2>
    <form action="/Appointment/RescheduleTime" method="post">


    <table width="100%">
    <tr valign="top">
    <td>
        Please Input a Date [mm/dd/yyyy]:<br /> <input type="text" id="Date" maxlength="10" name="Date" readonly />
        <br /><br />
        <input type="hidden" name="DoctorID" id="DoctorID" value="<%: Model.DoctorID %>" /> 
        <input type="hidden" name="UserID" id="UserID" value="<%: Model.UserID %>" /> 
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

