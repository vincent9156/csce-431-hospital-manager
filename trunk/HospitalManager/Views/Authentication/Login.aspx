<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>

    <% using (Html.BeginForm())
       { %>
    
    <fieldset>
        <p>
            <%= Html.LabelFor(Model => Model.Username)%>
            <%= Html.TextBoxFor(Model => Model.Username)%>
            <%= Html.ValidationMessageFor(Model => Model.Username)%>
        </p>
        <p>
            <%= Html.LabelFor(Model => Model.Password)%>
            <%= Html.PasswordFor(Model => Model.Password)%>
            <%= Html.ValidationMessageFor(Model => Model.Password)%>
        </p>
        <p>
            <input type="submit" value="Login" />
        </p>
    </fieldset>

    <% } %>

</asp:Content>
