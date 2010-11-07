﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.PrescriptionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Write Presceiption
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>Write Presceiption</h2>

    <%= Html.ActionLink("Back", "/Search/SearchUser") %>

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("WritePrescription", "Prescription")) { %>
        
        <!--
        
        public int quantity; //int
        public int numRefills; //int
        public int mgPerPill; // int
        public string instruction; //bigga text field
        public string medName; //drop down bx
        !-->

        <fieldset>
        <table>
            <tr>
                 <td>
                    <%= Html.Label("Medication")%>
                </td>
                <td>
                    <%= Html.DropDownListFor(m => m.MedicationID, new SelectList(Model.Medications, "MedicationID", "MedicationName")) %> 
                </td>
             </tr>
             <tr>
                <td>
                    <%= Html.Label("Quantity")%>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.Quantity) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.Quantity) %> <!-- Will this work ?? !-->
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Number of Refills") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.NumRefills) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.NumRefills)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Miligram Per Pill") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.mgPerPill) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.mgPerPill)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Instruction")%>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.Instructions)%>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="3">
                    <input type="submit" value="Submit" />
                </td>
            </tr>
        </table>
        </fieldset>

    <% } %>
    </div>
    </div>
</asp:Content>
