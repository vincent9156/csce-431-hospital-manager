<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.Models.CurrentMedicalHistory>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add Visit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
<div id="body">
    <h2>Add Visit</h2>
    <table>
    <tr>
    <td style="vertical-align: top; padding-right: 30px">

    <h3>Add Visit</h3>
    
    <% using (Html.BeginForm()) {%>
        <p>
            Reason For Visit<br />
            <%: Html.TextBoxFor(model => model.ReasonForVisit) %>
        </p>

        <p>
            Blood Pressure<br />
            <%: Html.TextBoxFor(model => model.BloodPressure) %>
        </p>

        <p>
            Diagnosis<br />
            <%: Html.TextBoxFor(model => model.Diagnosis) %>
        </p>


        <p>
            Tests Run<br />
            <%: Html.TextBoxFor(model => model.TestsRUN) %>
        </p>

        <p>
            Total Fee Amount ($$) <br />
            <%: Html.TextBoxFor(model => model.TotalFeeAmount) %>
        </p>



        <p>
            <input type="submit" value="Add Visit" />
        </p>

    <% } %>
    </td>
    </tr>
    </table>
    
    
</div>
</div>

</asp:Content>
