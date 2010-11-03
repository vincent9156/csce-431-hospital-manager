<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.BillingViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View Bill
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>View Bill</h2>

    <table>
    <tr><td><%:Html.LabelFor(Model => Model.BillID) %>        </td><td><%: Html.DisplayTextFor(Model => Model.BillID) %></td></tr>
    <tr><td>Doctor Name                                       </td><td><%= Html.ViewData["docname"]                    %></td></tr>
    <tr><td>Patient Name                                      </td><td><%= Html.ViewData["pname"]                        %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.ReasonForVisit) %></td><td><%: Html.DisplayTextFor(Model => Model.ReasonForVisit) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.Diagnosis) %>     </td><td><%: Html.DisplayTextFor(Model => Model.Diagnosis) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.BillDate) %>      </td><td><%: Html.DisplayTextFor(Model => Model.BillDate) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.Amount) %>        </td><td><%: Html.DisplayTextFor(Model => Model.Amount) %></td></tr>
    <tr><td><%:Html.LabelFor(Model => Model.Paid) %>          </td><td><%= Html.ViewData["paid"]                      %></td></tr>
    <tr><td></td><td></td></tr>
    <tr><td></td><td></td></tr>
    </table>

    </div>
    </div>
</asp:Content>
