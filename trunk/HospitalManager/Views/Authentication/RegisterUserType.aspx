<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.ViewModels.UserTypesViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register</h2>
    
    <% using (Html.BeginForm()) {%>
    
        <fieldset>
        
            <p>
                <%= Html.Label("Register as a") %> 
                <%= Html.DropDownListFor(m => m.TypeID, new SelectList(Model.UserTypes, "TypeID", "TypeName")) %> 
                <input type="submit" value="Submit" />
            </p>

        </fieldset>

    <% } %>

</asp:Content>
