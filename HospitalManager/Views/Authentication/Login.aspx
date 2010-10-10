<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
<div id="body">
    <h2>Login</h2>

    <% using (Html.BeginForm())
       { %>
    
    <fieldset>
    <table>
        <tr>
            <td>
                <%= Html.LabelFor(Model => Model.Username)%>
            </td>
            <td>
                <%= Html.TextBoxFor(Model => Model.Username)%>
            </td>
            <td>
                <%= Html.ValidationMessageFor(Model => Model.Username)%>
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.LabelFor(Model => Model.Password)%>
            </td>
            <td>
                <%= Html.PasswordFor(Model => Model.Password)%>
            </td>
            <td>
                <%= Html.ValidationMessageFor(Model => Model.Password)%>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <input type="submit" value="Login" />
            </td>
        </tr>
    </table>
    </fieldset>

    <% } %>
    </div>
    </div>
</asp:Content>
