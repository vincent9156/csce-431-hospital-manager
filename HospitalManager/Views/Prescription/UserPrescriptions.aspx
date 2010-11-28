<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UserPrescriptions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>View My Prescriptions</h2>

    
    <% if (Model != null) { %>

    <h3>Results</h3>
    <% /* TODO: Use css.... */ %>
    <table cellpadding="10">
    <% if (Model.SearchResults.Count != 0) { %>
    <tr><td>Prescription ID</td><td>Patient</td><td>Doctor</td><td>Fill Status</td><td>Pharmacist</td></tr>
        <% foreach (var item in Model.SearchResults) { %>
            <tr><td><%= item.PrescriptionID%></td><td><%= item.UserID %></td><td><%= item.DoctorUserID %></td><td><%= item.FillStatus %></td><td><%= item.PharmacistID %></td>
                <% /* TODO: Check permissions of user before 
                    * displaying these links (and make the links correct) */ %>

                <td><%: Html.ActionLink("View", "ViewPrescription", "Prescription", new { id = item.PrescriptionID }, null )%></td>

                 <%if (Model.LoggedInUser.HasAccess(AccessOptions.CanWritePrescriptions))
                  { %>
                <td><%: Html.ActionLink("Delete", "DeletePrescription", "Prescription", new { id = item.PrescriptionID },null) %></td>
                <% } %>

                <%if (Model.LoggedInUser.HasAccess(AccessOptions.FillPrescriptions))
                  { %>
                <td><%: Html.ActionLink("Fill", "Fill", "Prescription", new { id = item.PrescriptionID }, null)%></td>
                <% } %>

            </tr>
        <% } %>
    <% } else { %>
        
        <tr><td>No Prescriptions found for this user.</td></tr>

    <% } %>

    <% } %>

    </table>
    </div>
    </div>
</asp:Content>
