<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HospitalManager.Models.Schedule>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	February
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>February</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Month
            </th>
            <th>
                Day
            </th>
            <th>
                Year
            </th>
            <th>
                _0900
            </th>
            <th>
                _0930
            </th>
            <th>
                _1000
            </th>
            <th>
                _1030
            </th>
            <th>
                _1100
            </th>
            <th>
                _1130
            </th>
            <th>
                _1200
            </th>
            <th>
                _1230
            </th>
            <th>
                _1300
            </th>
            <th>
                _1330
            </th>
            <th>
                _1400
            </th>
            <th>
                _1430
            </th>
            <th>
                _1500
            </th>
            <th>
                _1530
            </th>
            <th>
                _1600
            </th>
            <th>
                _1630
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.UserID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.UserID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.UserID })%>
            </td>
            <td>
                <%: item.Month %>
            </td>
            <td>
                <%: item.Day %>
            </td>
            <td>
                <%: item.Year %>
            </td>
            <td>
                <%: item._0900 %>
            </td>
            <td>
                <%: item._0930 %>
            </td>
            <td>
                <%: item._1000 %>
            </td>
            <td>
                <%: item._1030 %>
            </td>
            <td>
                <%: item._1100 %>
            </td>
            <td>
                <%: item._1130 %>
            </td>
            <td>
                <%: item._1200 %>
            </td>
            <td>
                <%: item._1230 %>
            </td>
            <td>
                <%: item._1300 %>
            </td>
            <td>
                <%: item._1330 %>
            </td>
            <td>
                <%: item._1400 %>
            </td>
            <td>
                <%: item._1430 %>
            </td>
            <td>
                <%: item._1500 %>
            </td>
            <td>
                <%: item._1530 %>
            </td>
            <td>
                <%: item._1600 %>
            </td>
            <td>
                <%: item._1630 %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

