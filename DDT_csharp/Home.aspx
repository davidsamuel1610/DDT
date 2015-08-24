<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DDT_csharp.Home" %>





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
    <ul style="width: 906px">
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
   <h1></h1>

   <article>


   <h2></h2>
    <p></p>
  
   </article> 
   
   </section>

   </div>
   <!--end holder-->

   
   <!--start holder-->

   <div class="holder_content">

   <section class="group1">
   <h3>Action Soccer</h3>

   <a class="photo_hover3" href="#"><img src="images/actionsoccer1.jpg" width="190" height="126" alt="picture" /></a>

   <p>Action soccer is one of the fastest growing sports in SA. Action Soccer Edenvale boasts 3 Astro turfs 6-aside fields, 2 indoor and 1 outdoor flood-lit field, and 2 standard outdoor soccer fields. Their facilities also boast 2 beach volleyball courts. </p>
    </section>

   
   <section class="group2">
   <h3>Action Soccer Leagues</h3>

   <a class="photo_hover3" href="#"><img src="images/actionsoccer5.jpg" width="190" height="126" alt="picture" /></a>

   <p>We host 27 adult leagues, mens and ladies, and 5 Junior leagues starting from Under 7s.</p>
   </section>
   
   <section class="group3">
   <h3>Action Soccer Centre</h3>

   <a class="photo_hover3" href="#"><img src="images/actionsoccer2.jpg" width="190" height="126" alt="picture" /></a>

   <p>We're centrally situated at Edenvale Sports Club and have games every day. If you're not a member of a team, come talk to us. We can find a team that suits your skill level.</p>
</section>
   
   <section class="group4">
   <h3>Edenvale Action Soccer where FITNESS is FUN!</h3>

   <a class="photo_hover3" href="#"><img src="images/actionsoccer3.jpg" width="190" height="126" alt="picture" /></a>

   <p>Looking for some fun action this summer?<br />
           
           Come join us for an exciting and fun beach volleyball, we have openings for Monday and Thursday nights. parties interested please contact Jacob on 011 453 9400 </p>
  
   
    
   </section>
  
 
   </div>
   <!--end holder-->
   
   <!--start holder-->

   <div class="holder_content2">
      <section class="group6">
   <h3>News</h3>
   <a class="photo_hover3" href="#"><img src="images/Renovations-img1.jpg" width="190" height="105" alt="picture" /></a>
   <p>Just a heads up for the upcoming quiz night on the 25th of April. It will be at Edenvale Action Soccer. From 7 p.m.

Booking will be essential. Six in a team. R50 per person.
Send me a mail or call me on 082 851 4983.

"We apologise for any inconvenience caused by the renovations that are going on outside the bar area. It will be ongoing for the next few weeks and we ask for your patience in this matter. We know that once we are done you will be pleased with the upgrades we have made to the facilities for you."</p>
    
   </section>

   
   
   </div>
   <!--end holder-->

   
   
   </div>
   <!--end container-->
   
   <!--start footer-->
   <footer>
   <div class="container">
   <aside class="footer_left">
   
   </aside> 
   
   <aside class="footer_left">
   
   </aside> 

   
   <aside class="footer_left">
   
   </aside> 


   
 
   <div id="FooterTwo"> © 2015 Digital Dream Team </div>
   </div>
   </footer>
   <!--end footer-->
<!-- Free template distributed by http://freehtml5templates.com -->   
        </form>
   </body>
</html>



