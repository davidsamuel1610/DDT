using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDT2;

namespace DDT_csharp
{
    public partial class League : System.Web.UI.Page
    {
        User Data = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            ltNotify.Text = Data.Log();
            // This Is To Verify That Everything Works
        }
    }
}
