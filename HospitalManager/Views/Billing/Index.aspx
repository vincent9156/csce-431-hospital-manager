<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewMyBills
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>View My Bills</h2>

    
    <% if (Model != null)
       { %>

    <h3>Results</h3>
    <% /* TODO: Use css.... */ %>
    <table cellpadding="10">
    <% if (Model.SearchResults.Count != 0)
       { %>
    <tr><td>BillID</td><td>Paid Status</td><td>Patient ID</td><td>Doctor ID</td></tr>
        <% foreach (var item in Model.SearchResults)
           { %>
            <tr><td><%= item.BillID%></td><td><%= Html.ViewData["paid"]%></td><td><%= item.PatientUserID%></td><td><%= item.DocUserID%></td>
                <% /* TODO: Check permissions of user before 
                    * displaying these links (and make the links correct) */ %>
                <td><%: Html.ActionLink("View Bill", "ViewBill", "Billing", new { id = item.BillID }, null)%></td>
                <td><%: Html.ActionLink("Delete Bill", "DeleteBill", "Billing", new { id = item.BillID }, null)%></td>
            </tr>
        <% } %>
    <% }
       else
       { %>
        
        <tr><td>No Bills found for this user.</td></tr>

    <% } %>

    <% }
       else
       { %>
            <p>No Bills found for this user.</p>
    <% } %>

    </table>
    </div>
    </div>
</asp:Content>
