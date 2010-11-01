<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.ScheduleViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Scheduler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2 style="color:White">Doctors</h2>
    <ul>
        <% foreach (var item in Model.docs)
           { %>
            <li><a style="color:White" href="/Schedule/Months/<%= item.UserID %>"><%= item.FirstName + " " + item.LastName + " ( " + item.Speciality + " )"%></a><br /></li>
        <% } %>
    </ul>
</div>
</div>
</asp:Content>
