<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserRegistrationViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register</h2>

    <p><%= Html.ActionLink("Back", "/Register/") %></p>

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("RegisterUser", "Authentication")) { %>
        
        <fieldset>
            <p>
                <%= Html.Label("Username") %>
                <%= Html.TextBoxFor(m => m.Username) %>
                <%= Html.ValidationMessageFor(m => m.Username) %>
            </p>
            <p>
                <%= Html.Label("Password") %>
                <%= Html.PasswordFor(m => m.Password) %>
                <%= Html.ValidationMessageFor(m => m.Password) %>
            </p>
            <p>
                <%= Html.Label("Repeat Password") %>
                <%= Html.PasswordFor(m => m.PasswordRepeat) %>
                <%= Html.ValidationMessageFor(m => m.PasswordRepeat) %>
            </p>
            <p>
                <%= Html.Label("Email") %>
                <%= Html.TextBoxFor(m => m.Email) %>
                <%= Html.ValidationMessageFor(m => m.Email) %>
            </p>
            <p>
                <%= Html.Label("First Name") %>
                <%= Html.TextBoxFor(m => m.FirstName) %>
                <%= Html.ValidationMessageFor(m => m.FirstName) %>
            </p>
            <p>
                <%= Html.Label("Last Name") %>
                <%= Html.TextBoxFor(m => m.LastName) %>
                <%= Html.ValidationMessageFor(m => m.LastName) %>
            </p>

            <% if(!Model.HasAccess(AccessOptions.RegisterWithoutStaffID)) { %>
            <p>
                <%= Html.Label("Staff ID") %>
                <%= Html.TextBox("StaffID") %>
            </p>
            <% } %>
            
            <p>
                <%= Html.ValidationSummary(true) %>
            </p>
            <p>
                <%= Html.HiddenFor(m => m.TypeID) %>
                <input type="submit" value="Register" />
            </p>

        </fieldset>

    <% } %>

</asp:Content>
