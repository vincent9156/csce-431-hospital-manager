<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	HM-Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div id="main_body">
<div id="body">

  <p>Thank you for choosing BLAH Medical Hopsital for your health care provider. We are here to server you. Please log on using your username and password or whatever. First time user? Please click on Register. </p>
 
<br/><br/>
<%: Html.ActionLink("Login", "Login", "Authentication") %><br />
<%: Html.ActionLink("Register", "Register", "Authentication") %><br /><br />



    </div>
    </div>
</asp:Content>

