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

    <%
        // based on code from:
        // http://weblogs.asp.net/jeffwids/archive/2009/09/08/credit-card-expiration-date-dropdownlist-sample-code.aspx
        List<SelectListItem> months = new List<SelectListItem>();
        List<SelectListItem> years = new List<SelectListItem>();
        for (int i = 1; i <= 12; i++)
        {
            DateTime m = new DateTime(2010, i, 1);
            SelectListItem li = new SelectListItem
            {
                Text = m.ToString("MMM"),
                Value = m.ToString("MM")
            };
            if (Model.ExpMonth == i)
                li.Selected = true;
            months.Add(li);
        }
        for (int i = 0; i < 12; i++)
        {
            String year = (DateTime.Today.Year + i).ToString();
            SelectListItem li = new SelectListItem
            {
                Text = year,
                Value = year
            };
            if (DateTime.Today.Year + i == Model.ExpYear)
                li.Selected = true;
            years.Add(li);
        }
         %>

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
                    <td>Expiration Date</td>
                    <td><%= Html.DropDownList("ExpMonth", months) %> <%= Html.DropDownList("ExpYear", years) %></td>
                    <td><%= Html.ValidationMessageFor(m => m.ExpMonth) %> <%= Html.ValidationMessageFor(m => m.ExpYear) %></td>
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
