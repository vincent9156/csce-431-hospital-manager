<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Login.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserRegistrationViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>Register</h2>

    <%= Html.ActionLink("Back", "/Register/") %>

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("RegisterUser", "Authentication")) { %>
        
        <fieldset>
        <table>
            <tr>
                <td>
                    <%= Html.Label("Username") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.Username) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.Username) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Password") %>
                </td>
                <td>
                    <%= Html.PasswordFor(m => m.Password) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.Password) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Repeat Password") %>
                </td>
                <td>
                    <%= Html.PasswordFor(m => m.PasswordRepeat) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.PasswordRepeat) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Email") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.Email) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.Email) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("First Name") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.FirstName) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.FirstName) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Last Name") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(m => m.LastName) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.LastName) %>
                </td>
            </tr>

            <% if(!Model.HasAccess(AccessOptions.RegisterWithoutStaffID)) { %>
            <tr>
                <td>
                    <%= Html.Label("Staff ID") %>
                </td>
                <td>
                    <%= Html.TextBox("StaffID") %>
                </td>
                <td></td>
            </tr>
            <% } %>
            
            <tr>
                <td colspan="3">
                    <%= Html.ValidationSummary(true) %>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <%= Html.HiddenFor(m => m.TypeID) %>
                    <input type="submit" value="Register" />
                </td>
            </tr>
        </table>
        </fieldset>

    <% } %>
    </div>
    </div>
</asp:Content>
