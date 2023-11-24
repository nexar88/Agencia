using Comun;
using McSoftware.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace McSoftware
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        private string strTexto;
        string sMensaje = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/"));
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/"));
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            IngresarOpcion();
        }

        private void IngresarOpcion()
        {
            string sTxtImagen = txtCaptcha.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(sTxtImagen))
            {

                strTexto = "Ingrese el texto de la imagen.";


                Funciones.GenerarMensaje("A", strTexto, lblMensaje);

                txtCaptcha.Focus();

                return;

            }

            if (!Funciones.EsCaptcha(ccEnvia, sTxtImagen))
            {

                strTexto = "El código de imagen es incorrecto.";

                Funciones.GenerarMensaje("A", strTexto, lblMensaje);

                txtCaptcha.Focus();

                return;

            }
            
            //sMensaje = Convert.ToString(Session["Message"]);
            Funciones.GenerarMensaje("A", sMensaje, lblMensaje);
            //DecJur.Visible = true;
            txtCaptcha.Text = "";

            if (chkDecJur.Checked)
            {
                //if (oPersonaCitaBuscada.sResolucion == Session["nIdResolucion"].ToString())
                //{
                //    //tiene resolucion
                //    Session["RESOLUCION"] = "CON_RESOL";
                //}
                //else
                //{
                //    //no tiene resolucion
                //    oPersonaCitaBuscada.sResolucion = Convert.ToString(Session["nIdResolucion"]);
                //    Session["RESOLUCION"] = "SIN_RESOL";
                //}

                Session["bPaginaIngreso"] = "1";
                //Session["PersonaCita"] = oPersonaCitaBuscada;
                Response.Redirect(ResolveUrl("~/Default.aspx"));

            }
            else
            {
                sMensaje = "Aceptar la Declaración Jurada para continuar";
                Funciones.GenerarMensaje("A", sMensaje, lblMensaje);
                return;
            }
            return;

        }
    }
}