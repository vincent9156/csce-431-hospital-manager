<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Registration Successful
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registration Successful</h2>

    <p>Welcome, <%: Model.Username %>.</p>
    <p>You may now log in with your username and password <%= Html.ActionLink("here", "/Login/") %>.</p>

</asp:Content>
