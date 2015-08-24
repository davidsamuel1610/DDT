using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDT_csharp
{
    public partial class TeamDescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = String.Format("SELECT `Date`, `Time`, `Team A`, `VS`, `Team B`, `scoreA`, `scoreB`, `Winner` FROM `fixture` WHERE `Team A`='{0}' OR `Team B` = '{0}'", Request.QueryString["Team"]);
            
        }
    }
}