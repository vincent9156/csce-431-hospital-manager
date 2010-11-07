<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Schedule
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#Date").datepicker();
        });

    </script>
    <div id="main_body">
    <div id="body">
    <h2>Schedule</h2>
    <form id="form1" runat="server">
        
        <asp:TextBox id="Date" ClientIDMode="Static" runat="server"></asp:TextBox>
        
    </form>
    </div>
    </div>
</asp:Content>
