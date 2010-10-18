<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HospitalManager.Models.ScheduleUsers>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Patient Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List of Current Doctors</h2>

    <table>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink(item.FirstName + " " + item.LastName, "Months", "Schedule", new { id = item.UserID})%>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

