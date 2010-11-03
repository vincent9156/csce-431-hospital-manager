<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.BillingViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>Create Bill</h2>
    <% using (Html.BeginForm("CreateBill", "Billing")) { %>
      <fieldset>
      <table>
        <tr><td>Patient Name</td><td><%= Html.ViewData["pname"] %></td></tr>
        <tr><td>Diagnosis</td><td><%: Html.TextBoxFor(Model => Model.Diagnosis) %></td></tr>
        <tr><td>Reason For Visit</td><td><%: Html.TextBoxFor(Model => Model.ReasonForVisit) %></td></tr>
        <tr><td>Bill Amount</td><td><%:Html.TextBoxFor(Model => Model.Amount) %></td></tr>
        <tr><td colspan="3"><input type="submit" value="Create Bill" /></td></tr>
        </table>
      </fieldset>

     <% } %>

    </div>
    </div>
</asp:Content>
