using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDT2;

namespace DDT3_Web_Server
{
    public partial class Login : System.Web.UI.Page
    {
        User MC = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 1)
            {
                if (Request.QueryString["Type"] == "Login") 
                {
                    Response.ClearContent();
                   // Response.ContentType = "text/plain";
                    Response.Write(MC.login(Request.QueryString["Password"], Request.QueryString["Name"]));
                } 
                else if (Request.QueryString["Type"] == "Register") 
                {
                    Response.ClearContent();
                   // Response.ContentType = "text/plain"; 
                    Response.Write(MC.singup(Request.QueryString["Name"], Request.QueryString["Password"], Request.QueryString["email"], Request.QueryString["team"]));
                } 
                else 
                { 
                   // Response.ContentType = "text/plain";
                    Response.ClearContent();
                    Response.Write("<h1>Invalid Entry`</h1>");
                }
            }
            else { Response.ClearContent(); Response.Write("<h1>Invalid Entry`</h1>"); }
        }
    }
}