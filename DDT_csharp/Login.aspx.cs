using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDT2;
using System.Security.Cryptography;
using System.Text;

namespace DDT_csharp
{
    public partial class Login : System.Web.UI.Page
    {
        User Data = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {

            

            string Responsez = Data.login(txtPassword.Text, txtUser.Text);
            if (Responsez.Contains("Login Success"))
            {
                string[] variables = Responsez.Split(',');
                string type = variables[2];
                string teamfollow = variables[1];
                if (type == "a")
                {
                    Response.Redirect("/Admin.aspx");
                } else if (type == "u") 
                {
                    Response.Redirect("/TeamDescription.aspx?Team="+teamfollow);
                }else if (type == "m")
                {
                    Response.Redirect("/TeamDescription.aspx?Team=" + teamfollow);
                }
            }
            
            else { }
        }
    }
}