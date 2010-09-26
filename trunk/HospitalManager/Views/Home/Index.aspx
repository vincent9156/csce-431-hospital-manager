<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	HM-Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Hospital Manager</h2>
    
    <table width="800">
        <tr>
            <td>
                <p>
                    Welcome to the Hospital Manager!
                    <br />
                </p>
            </td>
        </tr>
        <tr>
            <td>
                <ul>
                    <li><a href="../Users/">List of Hospital Manager Users</a></li>
                </ul>
            </td>
        </tr>
    </table>

</asp:Content>
