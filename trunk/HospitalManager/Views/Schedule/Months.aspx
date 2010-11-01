<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Patient Scheduling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="main_body">
    <div id="body">
        
    <h2>Input Date You Wish to Schedule Appointment:</h2>
    <form runat="server">
    <asp:Calendar DayNameFormat="Full" SelectionMode="Day" runat="server">
        <SelectorStyle BackColor="#f5f5f5"/>
    </asp:Calendar>
    </form>
    </div>
    </div>
    

</asp:Content>
