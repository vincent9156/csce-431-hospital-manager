<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserRegistrationViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>Edit Profile</h2>
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <%-- this should probably have it's own permissions, but this works for now --%>
    <% if (Model.HasAccess(AccessOptions.RegisterWithoutStaffID))
       { %>
        <%= Html.ActionLink("Change Billing Information", "BillingInfo", "Authentication")%>
    <% } %>
    <%= Html.ActionLink("Change Password", "ChangePassword", "Authentication") %>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("EditProfile", "Home")) { %>
        
        <fieldset>
        <table>
            <tr><td>Username</td><td><%= Html.TextBoxFor(m => m.Username) %></td><td><%= Html.ValidationMessageFor(m => m.Username) %></td></tr>
            <tr><td>Email</td><td><%= Html.TextBoxFor(m => m.Email) %></td><td><%= Html.ValidationMessageFor(m => m.Email) %></td></tr>
            <tr><td>First Name</td><td><%= Html.TextBoxFor(m => m.FirstName) %></td><td><%= Html.ValidationMessageFor(m => m.FirstName) %></td></tr>
            <tr><td>Last Name</td><td><%= Html.TextBoxFor(m => m.LastName) %></td><td><%= Html.ValidationMessageFor(m => m.LastName) %></td></tr>
            <% if (!Model.HasAccess(AccessOptions.RegisterWithoutStaffID))
               { %>
                <tr>
                    <td>
                        Speciality
                    </td>
                    <td>
                        <%= Html.TextBoxFor(m => m.Speciality) %>
                    </td>
                    <td>
                        <%= Html.ValidationMessageFor(m => m.Speciality) %>
                    </td>
                </tr>
            <% } %>
            <tr><td colspan="3"><%= Html.ValidationSummary(true) %></td></tr>
            <tr><td colspan="3"><%= Html.HiddenFor(m => m.TypeID) %><input type="submit" value="Save" /></td></tr>
        </table>
        </fieldset>

    <% } %>

    </div></div>
</asp:Content>
