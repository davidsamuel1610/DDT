using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDT2;

namespace DDT_csharp
{
    public partial class Register : System.Web.UI.Page
    {

        User Data = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdRegister_Click(object sender, EventArgs e)
        {
            //Data.singup(txtUser.Text, txtPassword.Text, txtEmail.Text, txtTeam.Text);
            
            Data.singup(txtUser.Text, txtPassword.Text, txtEmail.Text, txtTeam.Text);
            Response.Redirect("/Login.aspx");
        }
    }
}