<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.CurrentMedicalHistoriesViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Current Medical History
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main_body">
    <div id="body">
    <style type = "text/css">
        td {margin:5 5 5 5}
    </style>
    <h2>Current Medical History</h2>
    <% if (Model.CurrentMedicalHistoryList.First() == null)
       { %>
     <p>No Current Medical History Found For User</p>
    <% } %>
       
       <%else
        {%>
        <fieldset>
        <table cellpadding = "5">
            <tr>
                <th>UserID</th>
                <th>Day</th>
                <th>Month</th>
                <th>Year</th>
                <th>Reason For Visit</th>
                <th>Blood Pressure</th>
                <th>Diagnosis</th>
            </tr> 
           <%foreach(CurrentMedicalHistory c in Model.CurrentMedicalHistoryList)
            {%> 
            <tr>
                <td><%: c.UserID %></td>
                <td><%: c.Day %></td>
                <td><%: c.Month %></td>
                <td><%: c.Year %></td>
                <td><%: c.ReasonForVisit %></td>
                <td><%: c.BloodPressure %></td>
                <td><%: c.Diagnosis %></td>
            </tr>

        
        

        <%  } %>
        </table>
        </fieldset>
        <%}%>

 </div>
 </div>

</asp:Content>
