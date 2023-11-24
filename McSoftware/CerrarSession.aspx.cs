using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace McSoftware
{
    public partial class CerrarSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SESSIONES
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("~/WebForm_Principal.aspx", false);
        }
    }
}