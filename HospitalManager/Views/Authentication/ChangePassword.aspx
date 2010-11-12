<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.ChangePasswordViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Change Password
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main_body">
<div id="body">
    <h2>Change Password</h2>

    <%= Html.ActionLink("Back", "ViewProfile", "Home") %>

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("ChangePassword", "Authentication"))
       { %>

        <fieldset>
        <table>
            <tr>
                <td>
                    <%= Html.Label("Old Password")%>
                </td>
                <td>
                    <%= Html.PasswordFor(m => m.OldPassword)%>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.OldPassword)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("New Password")%>
                </td>
                <td>
                    <%= Html.PasswordFor(m => m.Password)%>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.Password)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Confirm New Password")%>
                </td>
                <td>
                    <%= Html.PasswordFor(m => m.PasswordRepeat)%>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(m => m.PasswordRepeat)%>
                </td>
            </tr>
        </table>
        <%= Html.ValidationSummary(true)%>
        <input type="submit" value="Change Password" />
        </fieldset>

        <% } %>
        </div></div>
</asp:Content>
