<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HospitalManager.Models.USER>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table width="800">
        <tr>
            <th></th>
            <th>
                User Id
            </th>
            <th>
                First Name
            </th>
            <th>
                Last Name
            </th>
            <th>
                Security Id
            </th>
            <th>
                User Type
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr align="center">
            <td></td>
            <td>
                <%: item.USER_ID %>
            </td>
            <td>
                <%: item.FIRST_NAME %>
            </td>
            <td>
                <%: item.LAST_NAME %>
            </td>
            <td>
                <%: item.SECURITY_ID %>
            </td>
            <td>
                <%: item.USER_TYPE %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

