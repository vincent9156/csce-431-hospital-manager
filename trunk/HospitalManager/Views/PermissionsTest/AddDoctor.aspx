<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.Models.Doctor>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add Doctor
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add Doctor</h2>

        <% using (Html.BeginForm()) { %>

            <fieldset>
       
                <p>
                    <%= Html.LabelFor(Model => Model.Username) %>
                    <%= Html.TextBoxFor(Model => Model.Username) %>
                    <%= Html.ValidationMessageFor(Model => Model.Username) %>
                </p>
                <p>
                    <%= Html.LabelFor(Model => Model.Password) %>
                    <%= Html.PasswordFor(Model => Model.Password) %>
                    <%= Html.ValidationMessageFor(Model => Model.Password) %>
                </p>
                <p>
                    <%= Html.LabelFor(Model => Model.FirstName) %>
                    <%= Html.TextBoxFor(Model => Model.FirstName) %>
                    <%= Html.ValidationMessageFor(Model => Model.FirstName) %>
                </p>
                <p>
                    <%= Html.LabelFor(Model => Model.LastName) %>
                    <%= Html.TextBoxFor(Model => Model.LastName) %>
                    <%= Html.ValidationMessageFor(Model => Model.LastName) %>
                </p>
                <p>
                    <input type="submit" value="Add Doctor" />
                </p>
       
            </fieldset>

        <% } %>

</asp:Content>
