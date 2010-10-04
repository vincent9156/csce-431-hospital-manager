<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	HM-Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div id="main_body">
<div id="body">

  <p>Thank you for choosing BLAH Medical Hopsital for your health care provider. We are here to server you. Please log on using your username and password or whatever. First time user? Please click on Register. </p>
 
<br/><br/>
<form action="" method="get">
<input name="Search" type="text" value="Username" maxlength="20" />
</form>


<form action="" method="get">
<input name="Search" type="text" value="Password" maxlength="20" />
</form>


<form>
<input type="submit" value="Submit" />
<input type="submit" value="Register" />
</form>



    </div>
    </div>
</asp:Content>

