<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HospitalManager.Models.USER>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
           
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FIRST_NAME) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FIRST_NAME) %>
                <%: Html.ValidationMessageFor(model => model.FIRST_NAME) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LAST_NAME) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LAST_NAME) %>
                <%: Html.ValidationMessageFor(model => model.LAST_NAME) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SECURITY_ID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SECURITY_ID) %>
                <%: Html.ValidationMessageFor(model => model.SECURITY_ID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.USER_TYPE) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.USER_TYPE) %>
                <%: Html.ValidationMessageFor(model => model.USER_TYPE) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

