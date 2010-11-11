<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.PrescriptionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Assign
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <% using (Html.BeginForm("AssignPrescription", "Prescription"))
       { %>
        
        <fieldset>
    <table>
    <tr><td>Choose Pharmacist to Assign Prescription</td></tr>
    <tr><td><%= Html.DropDownListFor(m => m.PharmacistID, new SelectList(Model.Pharmacists,"UserID", "LastName")) %></td></tr>
    <tr>
            <td><%= Html.HiddenFor(m => m.PrescriptionID) %></td>
            </tr>
            <tr>
                <td colspan="3">
                    <input type="submit" value="Assign" />
                </td>
            </tr>
    </table>
       </fieldset>
    <% } %>
    </div>
    </div>
</asp:Content>
