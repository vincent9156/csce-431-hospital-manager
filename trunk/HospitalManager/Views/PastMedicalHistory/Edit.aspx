<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UpdateMedicalHistoryViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
    <div id="body">

    <h2>Edit Medical History</h2>

    <table>
    <tr>
    <td style="vertical-align: top; padding-right: 30px">

    <h3>General</h3>

    <% using (Html.BeginForm()) {%>
        <p>
            Height (in)<br />
            <%: Html.TextBoxFor(model => model.UserHistory.Height) %>
        </p>

        <p>
            Weight (lb)<br />
            <%: Html.TextBoxFor(model => model.UserHistory.Weight) %>
        </p>

        <p>
            Age (years)<br />
            <%: Html.TextBoxFor(model => model.UserHistory.Age) %>
        </p>
            
        <p>
            Gender<br />
            <%: Html.TextBoxFor(model => model.UserHistory.Gender) %>
        </p>

        <p>
            Ethnicity<br />
            <%: Html.TextBoxFor(model => model.UserHistory.Ethnicity) %>
        </p>

        <p>
            Allergies<br />
            <%: Html.TextBoxFor(model => model.UserHistory.Allergies) %>
        </p>

        <p>
            Operations<br />
            <%: Html.TextBoxFor(model => model.UserHistory.Operations) %>
        </p>
            
        <p>
            <input type="submit" value="Save" />
        </p>

    <% } %>

    </td>

    <td style="vertical-align: top; padding-right: 30px">

    <h3>Medical Conditions</h3>
    <p>
    <% 
        foreach (PatientCondition pCond in Model.UserHistory.PatientConditions) 
        { 
            foreach (MedicalCondition cond in pCond.MedicalConditions.ToList()) 
            { 
    %>
                <%= cond.ConditionName %> 
                [<a href="/PastMedicalHistory/RemoveCondition/<%= cond.ConditionID %>">Remove</a>]
                <br />
    <% 
            }
        }
    %>
    <% 
        foreach (OtherPatientCondition cond in Model.UserHistory.OtherPatientConditions) 
        { 
    %>
            <%= cond.Condition %> 
            [<a href="/PastMedicalHistory/RemoveOtherCondition/<%= cond.OtherConditionID %>">Remove</a>]
            <br />
    <% 
        }
    %>
    </p>
    <br />
    <h4>Add Condition</h4>
    <% using (Html.BeginForm("AddCondition", "PastMedicalHistory")) { %>

        <select name="medicalCondition">
            <option value="-1" selected="selected">Medical Condition</option>
            <option value="-1">--</option>
            <% foreach (MedicalCondition cond in Model.AllMedicalConditions) { %>
                <option value="<%= cond.ConditionID %>"><%= cond.ConditionName %></option>
            <% } %>
        </select>
        <input type="submit" value="Add" />

    <% } %>
            <br />
        <h4>Add Other Condition</h4>
        <% using (Html.BeginForm("AddOtherCondition", "PastMedicalHistory")) { %>

            <input type="text" name="condition" value="Condition" onfocus="this.value == this.defaultValue ? this.value = '' : null" />

            <input type="submit" value="Add" />

        <% } %>
    </td>

    <td style="vertical-align:top">
        <h3>Family Medical Conditions</h3>

        <% foreach (FamilyCondition fCond in Model.UserHistory.FamilyConditions) { %>

            <b><%= fCond.FamilyMembers.MemberName %></b>

            <% foreach (MedicalCondition cond in fCond.MedicalConditions.ToList()) { %>

                - <%= cond.ConditionName %>
                [<a href="/PastMedicalHistory/RemoveFamilyCondition/<%= fCond.FamilyMembers.FamilyMemberID %>/<%= cond.ConditionID %>">Remove</a>]
                <br />

            <% } %>

        <% } %>
        <br />

        <h3>Other Family Conditions</h3>
        <% foreach(OtherFamilyCondition cond in Model.UserHistory.OtherFamilyConditions) { %>
            <b><%= cond.FamilyMembers.MemberName %></b> - <%= cond.Condition %>
            [<a href="/PastMedicalHistory/RemoveOtherFamilyCondition/<%= cond.OtherConditionID %>">Remove</a>]
            <br />
        <% } %>

        <br />


        <h4>Add Family Condition</h4>
        <% using (Html.BeginForm("AddFamilyCondition", "PastMedicalHistory")) { %>

            <select name="member">
                <option value="-1" selected="selected">Family Member</option>
                <option value="-1">--</option>
                <% foreach (FamilyMember member in Model.AllFamilyMembers) { %>
                    <option value="<%= member.FamilyMemberID %>"><%= member.MemberName %></option>
                <% } %>
            </select>
            <br />
            <select name="condition">
                <option value="-1" selected="selected">Medical Condition</option>
                <option value="-1">--</option>
                <% foreach (MedicalCondition cond in Model.AllMedicalConditions) { %>
                    <option value="<%= cond.ConditionID %>"><%= cond.ConditionName %></option>
                <% } %>
            </select>

            <input type="submit" value="Add" />

        <% } %>

        <br />
        <h4>Add Other Family Condition</h4>
        <% using (Html.BeginForm("AddOtherFamilyCondition", "PastMedicalHistory")) { %>

            <select name="member">
                <option value="-1" selected="selected">Family Member</option>
                <option value="-1">--</option>
                <% foreach (FamilyMember member in Model.AllFamilyMembers) { %>
                    <option value="<%= member.FamilyMemberID %>"><%= member.MemberName %></option>
                <% } %>
            </select>
            <br />
            <input type="text" name="condition" value="Condition" onfocus="this.value == this.defaultValue ? this.value = '' : null" />

            <input type="submit" value="Add" />

        <% } %>
    </td>

    </tr>
    </table>
    
    </div>
</div>

</asp:Content>

