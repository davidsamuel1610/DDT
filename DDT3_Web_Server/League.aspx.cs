using DDT2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDT3_Web_Server
{
    public partial class League : System.Web.UI.Page
    {
        User MC = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(MC.Log());
        }
    }
}