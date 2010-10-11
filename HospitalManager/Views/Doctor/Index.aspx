<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.DoctorViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Doctor Dashboard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Doctor DashBoard</h2>
    <br />
    <p>
        Welcome <%= Model.FName %> <%= Model.LName %>
    </p>

    <h2>Click on Link to Check Schedule</h2>
    <%Html.ActionLink("Janurary",""); %>
</asp:Content>
