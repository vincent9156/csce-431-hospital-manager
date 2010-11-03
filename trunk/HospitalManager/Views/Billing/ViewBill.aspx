<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.BillingViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View Bill
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>View Bill</h2>

    <table>
    <tr><td><%:Html.LabelFor(Model => Model.BillID) %>       </td><td><%: Html.DisplayTextFor(Model => Model.BillID) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.DocUserID) %>    </td><td><%: Html.DisplayTextFor(Model => Model.DocUserID) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.PatientUserID) %> </td><td><%: Html.DisplayTextFor(Model => Model.PatientUserID) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.ReasonForVisit) %></td><td><%: Html.DisplayTextFor(Model => Model.ReasonForVisit) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.Diagnosis) %></td><td><%: Html.DisplayTextFor(Model => Model.Diagnosis) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.BillDate) %></td><td><%: Html.DisplayTextFor(Model => Model.BillDate) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.Amount) %></td><td><%: Html.DisplayTextFor(Model => Model.Amount) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.Paid) %></td><td><%: Html.DisplayTextFor(Model => Model.Paid) %></td></tr>
    <tr><td></td><td></td></tr>
    <tr><td></td><td></td></tr>
    </table>

    </div>
    </div>
</asp:Content>
