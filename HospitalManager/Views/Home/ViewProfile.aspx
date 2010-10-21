<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserRegistrationViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewProfile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewProfile</h2>
    <table>
        <tr><td><b>UserType </b>  </td><td> = </td><td><%= Html.ViewData["UType"] %></td></tr>
        <tr><td><b>E-Mail </b>    </td><td> = </td><td><%= Html.ViewData["EMail"] %></td></tr>
        <tr><td><b>First Name </b></td><td> = </td><td><%= Html.ViewData["FName"] %></td></tr>
        <tr><td><b>Last Name </b> </td><td> = </td><td><%= Html.ViewData["LName"] %></td></tr>
        <tr><td><b>UserName </b>  </td><td> = </td><td><%= Html.ViewData["UName"] %></td></tr>
    </table>
    
    <div>
    </div>
    <div>
    </div>
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("EditProfile", "Home")) { %>
        
        <fieldset>
        <table>
            <tr><td><%= Html.Label("Username") %></td><td><%= Html.TextBoxFor(m => m.Username) %></td><td><%= Html.ValidationMessageFor(m => m.Username) %></td></tr>
            <tr><td><%= Html.Label("Password") %></td><td><%= Html.PasswordFor(m => m.Password) %></td><td><%= Html.ValidationMessageFor(m => m.Password) %></td></tr>
            <tr><td><%= Html.Label("Repeat Password") %></td><td><%= Html.PasswordFor(m => m.PasswordRepeat) %></td><td><%= Html.ValidationMessageFor(m => m.PasswordRepeat) %></td></tr>
            <tr><td><%= Html.Label("Email") %></td><td><%= Html.TextBoxFor(m => m.Email) %></td><td><%= Html.ValidationMessageFor(m => m.Email) %></td></tr>
            <tr><td><%= Html.Label("First Name") %></td><td><%= Html.TextBoxFor(m => m.FirstName) %></td><td><%= Html.ValidationMessageFor(m => m.FirstName) %></td></tr>
            <tr><td><%= Html.Label("Last Name") %></td><td><%= Html.TextBoxFor(m => m.LastName) %></td><td><%= Html.ValidationMessageFor(m => m.LastName) %></td></tr>
            <tr><td colspan="3"><%= Html.ValidationSummary(true) %></td></tr>
            <tr><td colspan="3"><%= Html.HiddenFor(m => m.TypeID) %><input type="submit" value="Edit Info" /></td></tr>
        </table>
        </fieldset>

    <% } %>
</asp:Content>
