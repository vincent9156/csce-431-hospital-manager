<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.PrescriptionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View Prescription
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>View Prescription</h2>

  <table>
    <tr><td><%:Html.LabelFor(Model => Model.PrescriptionID) %></td><td><%: Html.DisplayTextFor(Model => Model.PrescriptionID) %></td></tr>
    <!-- <tr><td>Doctor Name                                       </td><td><% /* Html.ViewData["docName"] %></td></tr>
    <tr><td>Patient Name                                      </td><td><% Html.ViewData["pname"]  %></td></tr> 
    <tr><td><% Html.LabelFor(Model => Model.MedicationName) %>       </td><td><% Html.DisplayTextFor(Model => Model.MedicationName) */%></td></tr>-->
    <tr><td><%:Html.LabelFor(Model => Model.Instructions) %>   </td><td><%: Html.DisplayTextFor(Model => Model.Instructions) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.mgPerPill) %>     </td><td><%: Html.DisplayTextFor(Model => Model.mgPerPill) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.Quantity) %>      </td><td><%: Html.DisplayTextFor(Model => Model.Quantity) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.NumRefills) %>    </td><td><%= Html.DisplayTextFor(Model => Model.NumRefills)%></td></tr>
    <tr><td></td><td></td></tr>
    <tr><td></td><td></td></tr>
  </table>

    </div>
    </div>
</asp:Content>
