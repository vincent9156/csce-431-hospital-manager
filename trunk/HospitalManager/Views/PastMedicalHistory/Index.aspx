<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.Models.PastMedicalHistory>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Past Medical History
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="main_body">
    <div id="body">

    <h2>Past Medical History</h2>
    
    <% if (Model == null) { %>

    <p>
        You have not yet set up your medical history. You can do so 
        <a href="/PastMedicalHistory/Edit">here</a>.
    </p>

    <% } else { %>

    <br />
    <h3>General Information</h3>
    <p>
        Height -
        <%: Model.Height %> in
    </p>
    <p>
        Weight -
        <%: Model.Weight %> lb
    </p>
    <p>
        Age -
        <%: Model.Age %> years
    </p>
    <p>
        Gender -
        <%: Model.Gender %>
    </p>
    <p>
        Ethnicity -
        <%: Model.Ethnicity %>
    </p>
    <p>
        Allergies -
        <%: Model.Allergies %>
    </p>
    <p>
        Past Operations -
        <%: Model.Operations %>
    </p>
    
    <br />
    <h3>Patient Medical Conditions</h3>

    <h4>Conditions</h4>
    <ul>
        <% 
        foreach (PatientCondition pCond in Model.PatientConditions) 
        { 
            foreach (MedicalCondition cond in pCond.MedicalConditions.ToList()) 
            { 
        %>
                <li><%= cond.ConditionName %></li>
        <% 
            }
        }
        %>
    </ul>
    
    <h4>Other Conditions</h4>
    <ul>
        <% 
        foreach (OtherPatientCondition cond in Model.OtherPatientConditions) 
        { 
        %>
            <li><%= cond.Condition %></li>
        <% 
        }
        %>
    </ul>
    
    <br />
    <h3>Family Medical Conditions</h3>

    <h4>Family Conditions</h4>
    <ul>
        <% 
        foreach (FamilyCondition fCond in Model.FamilyConditions) 
        {
        %>
            <li>
                <%= fCond.FamilyMembers.MemberName %>
                <ul>
        <%
            foreach (MedicalCondition cond in fCond.MedicalConditions.ToList()) 
            { 
        %>
                    <li><%= cond.ConditionName %></li>
        <% 
            }
        %>
                </ul>
            </li>
        <%
        }
        %>
    </ul>

    <h4>Other Family Conditions</h4>
    <ul>
        <% 
        foreach(OtherFamilyCondition fCond in Model.OtherFamilyConditions) 
        {
        %>
            <li>
            <%= fCond.FamilyMembers.MemberName + " - " + fCond.Condition %>
            </li>
        <% 
        }
        %>
    </ul>

    <% } /* End else */ %>

    </div>
</div>
</asp:Content>