<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
<div id="body">
    <h2>Search</h2>
    <% using (Html.BeginForm("SearchUser", "Search", FormMethod.Get))
       { %>
    
    <fieldset>
    <table>
        <tr>
            <td>
                <%= Html.Label("First Name")%>
            </td>
            <td>
                <%= Html.TextBox("firstname")%>
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.Label("Last Name")%>
            </td>
            <td>
                <%= Html.TextBox("lastname")%>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <input type="submit" value="Search" />
            </td>
        </tr>
    </table>
    </fieldset>

    <% } %>

    
    <% if (Model != null) { %>

    <h3>Results</h3>
    <% /* TODO: Use css.... */ %>
    <table cellpadding="10">
    <% if (Model.SearchResults.Count != 0) { %>

        <% foreach (var item in Model.SearchResults) { %>
    
            <tr>
                <td>
                    <%= item.FirstName%>
                    <%= item.LastName%>
                </td>
                <% /* TODO: Check permissions of user before 
                    * displaying these links (and make the links correct) */ %>
                <td>
                    <a href="#">Medical Record</a>
                 </td>
                <td>
                    <%=Html.ActionLink("Hospital Visits", "Index", "CurrentMedicalHistory", new { UserId = item.UserID }, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("Add Hospital Visit", "AddVisit", "CurrentMedicalHistory", new { UserId = item.UserID }, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("Bill Patient", "Create", "Billing", new { id = item.UserID }, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("Write Prescription", "WritePrescription", "Prescription", new { id = item.UserID }, null)%>
                </td>
                <td>
                    <%=Html.ActionLink("View Prescriptions", "UserPrescriptions", "Prescription", new { id = item.UserID }, null)%>
                </td>
            </tr>

        <% } %>

    <% } else { %>
        
        <tr><td>No user found by that name.</td></tr>

    <% } %>

    <% } %>
    
    </table>
    </div>
    </div>
</asp:Content>
