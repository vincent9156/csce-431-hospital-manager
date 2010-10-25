<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.ScheduleViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Patient
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Patient</h2>

    <% foreach (var item in Model.docs)
       { %>
     
        <%: Html.ActionLink(item.FirstName + " " + item.LastName, "Months", "Schedule", (Int32)(item.UserID))%><br />
        <a href="/Schedule/Months/<%= item.UserID %>"><%= item.FirstName + " " + item.LastName%></a>
     
     
    <% } %>

</asp:Content>
