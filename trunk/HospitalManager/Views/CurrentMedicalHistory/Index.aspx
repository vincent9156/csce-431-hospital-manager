<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.CurrentMedicalHistoryViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Current Medical History
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Current Medical History</h2>

     <% if (Model == null)
        { %>
     <p> No Current Medical History Found</p>
    <% } else { %>

    <br />
    <h3>Most Recent Visit Information</h3>
    <p>
        Day -
        <%: Model.Day %>
    </p>
    <p>
        Month -
        <%: Model.Month %>
    </p>
    <p>
        Year -
        <%: Model.Year %>
    </p>
    
    <br />


</asp:Content>
