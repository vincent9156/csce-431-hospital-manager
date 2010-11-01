<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserRegistrationViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewProfile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>Your Profile</h2>
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("EditProfile", "Home")) { %>
        
        <fieldset>
        <table>
            <tr><td>UserType</td><td><%= Html.ViewData["UType"] %></td></tr>
            <tr><td>Username</td><td><%= Html.TextBoxFor(m => m.Username) %></td><td><%= Html.ValidationMessageFor(m => m.Username) %></td></tr>
            <tr><td>Email</td><td><%= Html.TextBoxFor(m => m.Email) %></td><td><%= Html.ValidationMessageFor(m => m.Email) %></td></tr>
            <tr><td>First Name</td><td><%= Html.TextBoxFor(m => m.FirstName) %></td><td><%= Html.ValidationMessageFor(m => m.FirstName) %></td></tr>
            <tr><td>Last Name</td><td><%= Html.TextBoxFor(m => m.LastName) %></td><td><%= Html.ValidationMessageFor(m => m.LastName) %></td></tr>
            <tr><td colspan="3"><%= Html.ValidationSummary(true) %></td></tr>
            <tr><td colspan="3"><%= Html.HiddenFor(m => m.TypeID) %><input type="submit" value="Save" /></td></tr>
        </table>
        </fieldset>

    <% } %>

    </div></div>
</asp:Content>
