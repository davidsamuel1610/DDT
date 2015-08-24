using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDT2;

namespace DDT3_Web_Server
{
    public partial class Stop : System.Web.UI.Page
    {
        User MC = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 1)
            {
                Response.Write(MC.StopMatch(Request.QueryString["MatchId"], Request.QueryString["UserId"]));
            }
        }
    }
}