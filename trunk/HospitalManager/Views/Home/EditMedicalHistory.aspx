<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
	HM-Home
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">


<div id="main_body">
<div id="body">
 <h2>Edit Current Medical History</h2>

  <p>This is where the doctor will be coming to edit the Patients Current history </p>
 
<br/><br/>


<Form>
 Age : <INPUT type="text" name="Age"><br />
 Height : <INPUT type="text" name="Height"><br />
 Weight : <INPUT type="text" name="Weight"><br />
 Diagnosis : <INPUT type="text" name="Diagnosis"><br />
 Percriptions added: <INPUT type="text" name="Percriptions added"><br /> 

 <label for="male">Male</label>
 <input type="radio" name="sex" id="male" />
 <br />
 <label for="female">Female</label>
 <input type="radio" name="sex" id="female" />

 <br /> 
 <br />
   
  <INPUT type="submit" value="Send"> <INPUT type="reset"> <br /> <br />
  
</Form>

    </div>
    </div>
</asp:Content>
