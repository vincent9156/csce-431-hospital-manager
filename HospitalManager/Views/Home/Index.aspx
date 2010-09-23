<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Views/Shared/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.PersonViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>A message from <%: Model.FirstName %> <%: Model.LastName %></h2>
    <p><%: Model.Message %></p>
</asp:Content>
