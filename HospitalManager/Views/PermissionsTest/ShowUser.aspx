<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Show User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>User</h2>

    <% if (Model == null) { %>

        <p>No user found by that name.</p>

    <% } else { %>

        <% Html.RenderPartial("UserDisplay", Model); %>

    <% } %>

</asp:Content>
