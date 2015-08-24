<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DDT_csharp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<!doctype html>  
<head>
<meta charset="UTF-8">
<title>DDT</title>
<link rel="icon" href="images/favicon.gif" type="image/x-icon"/>
 <!--[if lt IE 9]>
 <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
  <![endif]-->

<link rel="shortcut icon" href="images/favicon.gif" type="image/x-icon"/> 
<link rel="stylesheet" type="text/css" href="css/styles.css"/>

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
	<script src="js/slides.min.jquery.js"></script>
	<script>
	    $(function () {
	        $('#slides').slides({
	            preload: true,
	            preloadImage: 'images/loading.gif',
	            play: 5000,
	            pause: 2500,
	            hoverPause: true
	        });
	    });
	</script>


    </head>
    <body>

        <form id="form1" runat="server">

    <!--start container-->
    <div id="container">

    <!--start header-->

    <header>
 
    <!--start logo-->
    <a href="#" id="logo"><img src="http://www.actionsoccersa.co.za/Images/NewBan.jpg"/></a>    

	<!--end logo-->
	
   <!--start menu-->
        
	<%--<nav>
    <ul>
    <li><a href="home.aspx">Home</a></li>
    <li><a href="Leagues.aspx">Leagues</a></li>
	<li><a href="Cups.aspx">Cups</a></li>
    <li><a href="Fixtures.aspx">Fixtures</a></li>
    <li><a href="Functions.aspx">Functions</a></li>
    <li><a href="Contactus.aspx">Contact Us</a></li>
    
    </ul>
    </nav>
	<!--end m--%>enu-->
	

    <!--end header-->
	</header>
        <header>
            <nav>
    <ul>
    <li><a href="home.aspx">Home</a></li>
    <li><a href="Leagues.aspx">Leagues</a></li>
	    <%--<li><a href="Cups.aspx">Cups</a></li>--%>
    <li><a href="Fixtures.aspx">Fixtures</a></li>
        <%--<li><a href="Functions.aspx">Functions</a></li>--%>
    <li><a href="Contactus.aspx">Contact Us</a></li>
        <li><a href="login.aspx">Login</a></li>
        <li><a href="Register.aspx">Register</a></li>
        <li><a href="TeamRegistration.aspx">Team Registration</a></li>

       

    </ul>
    </nav>
        </header>


   <!--start intro-->

   <section id="intro">
   <div id="slides">
   <div class="slides_container">
   <img src="images/IMG_0071.JPG" width="960" height="300" alt="baner">
   <img src="images/Images-kiddies.jpg" width="960" height="300" alt="baner">
   <img src="images/IMG_0073.jpg" width="960" height="300" alt="baner">


   </div>
   </div>
 
   </section>
   <!--end intro-->
   
   
   <!--start holder-->
   <div class="holder_content1">
   
   <section class="group5">
   <h1>
       Username: <asp:TextBox ID="txtUser" runat="server" Height="16px" Width="128px" style="margin-left: 7px"></asp:TextBox>
       <br />
       Password:<asp:TextBox ID="txtPassword" runat="server" Height="16px" Width="128px" style="margin-left: 24px"></asp:TextBox>
       <br />
       Email:<asp:TextBox ID="txtEmail" runat="server" Height="16px" Width="128px" style="margin-left: 66px"></asp:TextBox>
       <br />
       TeamName:<asp:TextBox ID="txtTeam" runat="server" Height="16px" Width="128px"></asp:TextBox>
       <br />
       <br />
       <asp:Button ID="cmdRegister" runat="server" style="margin-left: 7px" Text="Register" Width="258px" OnClick="cmdRegister_Click" />
       <br />
       </h1>

   <article>


   <h2></h2>
    <p>&nbsp;</p>
  
   </article> 
   
   </section>

   </div>
   <!--end holder-->
    </form>
</body>
</html>
