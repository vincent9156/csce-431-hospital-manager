<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
<div id="body">
    <h2>Search</h2>
    <% using (Html.BeginForm("FindUser", "Search"))
       { %>
    
    <fieldset>
    <table>
        <tr>
            <td>
                <%= Html.Label("First Name")%>
            </td>
            <td>
                <%= Html.TextBox("firstname")%>
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.Label("Last Name")%>
            </td>
            <td>
                <%= Html.TextBox("lastname")%>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <input type="submit" value="Search" />
            </td>
        </tr>
    </table>
    </fieldset>

    <% } %>
    </div>
    </div>
</asp:Content>
