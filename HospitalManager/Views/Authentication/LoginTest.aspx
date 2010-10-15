<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Login.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LoginTest
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>LoginTest</h2>

    Message<br />
    <%: ViewData["Message"] %><br /><br />
    User<br />
    <%: ViewData["User"] ?? "None" %>

</asp:Content>
