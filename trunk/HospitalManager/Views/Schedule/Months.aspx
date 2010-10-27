<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Patient Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Choose Month You Wish to Schedule Appointment</h2>

    <%:Html.ActionLink("January", "Jan", "Schedule", new { id = Model.UserID})%> <br />
    <%:Html.ActionLink("February", "Feb", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("March", "Mar", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("April", "Apr", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("May", "May", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("June", "Jun", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("July", "Jul", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("August", "Aug", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("September", "Sep", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("October", "Oct", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("November", "Nov", "Schedule", new { id = Model.UserID })%> <br />
    <%:Html.ActionLink("December", "Dec", "Schedule", new { id = Model.UserID })%> <br />
    

</asp:Content>
