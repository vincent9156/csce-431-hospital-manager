<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HospitalManager.ViewModels.UserViewModel>" %>

<p>
    Name:
    <%: Model.FirstName %> <%: Model.LastName %> <br />

    User ID: 
    <%: Model.UserID %> <br />

    Username:
    <%: Model.Username %> <br />
        
    User type:
    <%: Model.TypeName %> <br />

    Could register without staff ID:
    <%: Model.HasAccess(AccessOptions.RegisterWithoutStaffID).ToString() %>
</p>