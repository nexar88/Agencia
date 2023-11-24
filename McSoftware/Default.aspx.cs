using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace McSoftware
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["UserSession"]))
            {
                Response.Redirect(ResolveUrl("~/CerrarSession.aspx"), false);
                return;
            }

        }

        [WebMethod]
        public static string ValidarSession()
        {
            string Rpta = "SESSION";
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["UserSession"]))
            {
                HttpContext.Current.Response.Redirect("~/CerrarSession.aspx", false);
                Rpta = "";
            }
            return Rpta;
        }

    }
}