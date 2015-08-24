<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamDescription.aspx.cs" Inherits="DDT_csharp.TeamDescription" %>

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
       Fixtures<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
           <Columns>
               <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
               <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
               <asp:BoundField DataField="Team A" HeaderText="Team A" SortExpression="Team A" />
               <asp:BoundField DataField="VS" HeaderText="VS" SortExpression="VS" />
               <asp:BoundField DataField="Team B" HeaderText="Team B" SortExpression="Team B" />
               <asp:BoundField DataField="scoreA" HeaderText="scoreA" SortExpression="scoreA" />
               <asp:BoundField DataField="scoreB" HeaderText="scoreB" SortExpression="scoreB" />
               <asp:BoundField DataField="Winner" HeaderText="Winner" SortExpression="Winner" />
           </Columns>
       </asp:GridView>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ddt_dataConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ddt_dataConnectionString2.ProviderName %>" SelectCommand="SELECT `Date`, `Time`, `Team A`, `VS`, `Team B`, `scoreA`, `scoreB`, `Winner` FROM `fixture` WHERE `Team A`='6 Pack' OR `Team B` = '6 Pack'"></asp:SqlDataSource>
       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ddt_dataConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ddt_dataConnectionString2.ProviderName %>" SelectCommand="SELECT `NAME`, `PLD`, `W`, `D`, `L`, `GF`, `GA`, `GD`, `PTS`, `YellowC`, `RedC`  FROM `league` ORDER BY `PTS` DESC,  `GD` DESC"></asp:SqlDataSource>
      </br> League <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="NAME">
           <Columns>
               <asp:BoundField DataField="NAME" HeaderText="NAME" ReadOnly="True" SortExpression="NAME" />
               <asp:BoundField DataField="PLD" HeaderText="PLD" SortExpression="PLD" />
               <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
               <asp:BoundField DataField="D" HeaderText="D" SortExpression="D" />
               <asp:BoundField DataField="L" HeaderText="L" SortExpression="L" />
               <asp:BoundField DataField="GF" HeaderText="GF" SortExpression="GF" />
               <asp:BoundField DataField="GA" HeaderText="GA" SortExpression="GA" />
               <asp:BoundField DataField="GD" HeaderText="GD" SortExpression="GD" />
               <asp:BoundField DataField="PTS" HeaderText="PTS" SortExpression="PTS" />
               <asp:BoundField DataField="YellowC" HeaderText="YellowC" SortExpression="YellowC" />
               <asp:BoundField DataField="RedC" HeaderText="RedC" SortExpression="RedC" />
           </Columns>
       </asp:GridView>
       </h1>

   <article>


   <h2></h2>
    <p></p>
  
   </article> 
   
   </section>

   </div>
   <!--end holder-->
        <asp:HiddenField ID="Team" runat="server" />
    </form>
</body>
</html>
