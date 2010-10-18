<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Doctor Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Schedule</h2>

    <%:Html.ActionLink("January", "Jan", "Schedule") %> <br />
    <%:Html.ActionLink("February", "Feb", "Schedule") %> <br />
    <%:Html.ActionLink("March", "Mar", "Schedule") %> <br />
    <%:Html.ActionLink("April", "Apr", "Schedule") %> <br />
    <%:Html.ActionLink("May", "May", "Schedule") %> <br />
    <%:Html.ActionLink("June", "Jun", "Schedule") %> <br />
    <%:Html.ActionLink("July", "Jul", "Schedule") %> <br />
    <%:Html.ActionLink("August", "Aug", "Schedule") %> <br />
    <%:Html.ActionLink("September", "Sep", "Schedule") %> <br />
    <%:Html.ActionLink("October", "Oct", "Schedule") %> <br />
    <%:Html.ActionLink("November", "Nov", "Schedule") %> <br />
    <%:Html.ActionLink("December", "Dec", "Schedule") %> <br />
    

</asp:Content>
