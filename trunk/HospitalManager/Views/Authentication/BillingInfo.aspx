<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserBillingInfoViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Billing Information
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>Billing Information</h2>

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("BillingInfo", "Authentication"))
       { %>
            <fieldset>
            <table>
                <tr>
                    <td>Card Provider</td>
                    <td><%= Html.DropDownListFor(m => m.CardProviderID, new SelectList(Model.CardProvider, "ProviderID", "ProviderName")) %></td>
                </tr>
                <tr>
                    <td>Card Number</td>
                    <td><%= Html.TextBoxFor(m => m.CardNumber) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.CardNumber) %></td>
                </tr>
                <tr>
                    <td>Security Code</td>
                    <td><%= Html.TextBoxFor(m => m.SecurityCode) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.SecurityCode) %></td>
                </tr>
                <tr>
                    <td>Expiration Month</td>
                    <td><%= Html.TextBoxFor(m => m.ExpMonth) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.ExpMonth) %></td>
                </tr>
                <tr>
                    <td>Expiration Year</td>
                    <td><%= Html.TextBoxFor(m => m.ExpYear) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.ExpYear) %></td>
                </tr>
                <tr>
                    <td>Billing Address</td>
                    <td><%= Html.TextBoxFor(m => m.Address) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.Address) %></td>
                </tr>
                <tr>
                    <td>Policy Number</td>
                    <td><%= Html.TextBoxFor(m => m.PolicyNum) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.PolicyNum) %></td>
                </tr>
                <tr>
                    <td>Provider</td>
                    <td><%= Html.TextBoxFor(m => m.ProviderName) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.ProviderName) %></td>
                </tr>
            </table>
            <input type="submit" value="Save" />
            </fieldset>

    <% } %>
    </div></div>
</asp:Content>
