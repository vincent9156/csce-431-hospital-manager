<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.AppointmentViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cancel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
<div id = "body">
    <h2>Cancel Appointment</h2>

    <form action="CancelApp" method="post">

    <select name="AppointmentID" id="AppointmentID">
    <% foreach(var item in Model.appointments){ %>
    <option value="<%:item.AppointmentID %>"><%: item.DoctorFirstName + " " + item.DoctorLastName + " " + item.Date.Date.ToString("d") + item.Time.ToString("t") %></option>
    <%} %>
    </select>

    <br /><br />
    <input type="submit" name="Submit" />

</div>
</div>

</asp:Content>
