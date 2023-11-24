using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
using Comun;
using McSoftware.View;
using Newtonsoft.Json;

namespace McSoftware
{
    public partial class WebForm_Principal : System.Web.UI.Page
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
            string sTxtLogin = txtLogin.Text.ToUpper().Trim();
            string sTxtPas = txtPas.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(sTxtImagen))
            {

                strTexto = "Ingrese el texto de la imagen.";


                Funciones.GenerarMensaje("A", strTexto, lblMensaje);

                txtCaptcha.Focus();

                return;

            }
            if (string.IsNullOrEmpty(sTxtLogin))
            {

                strTexto = "Ingrese Usuario.";


                Funciones.GenerarMensaje("A", strTexto, lblMensaje);

                txtCaptcha.Focus();

                return;

            }
            if (string.IsNullOrEmpty(sTxtPas))
            {

                strTexto = "Ingrese Contraseña.";


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


                //Session["bPaginaIngreso"] = "1";
                ////Session["PersonaCita"] = oPersonaCitaBuscada;
                //Response.Redirect(ResolveUrl("~/Default.aspx"));

                Cls_SSCBL oUserBL = new Cls_SSCBL("");
                Cls_Usuario_X_Empleado_BE oUsuario = new Cls_Usuario_X_Empleado_BE();
                oUsuario.CARNE = sTxtLogin.Trim();
                oUsuario.Clave = sTxtPas.Trim();
                //INICIO ----------------- asignando valores al objeto usuario
                //oUsuario = oUserBL.InteraccionLee2();
                oUsuario = oUserBL.InteraccionLee3(oUsuario);

                oUsuario.IP = GET_IP.GetIPAddress();
                string Ip = oUsuario.IP;
                string[] Arreglo = Ip.Split('.');
                if (Arreglo[0] == "10" && Arreglo[1] == "101")
                {
                    oUsuario.Origen = "Local";
                    oUsuario.IP = oUsuario.IP;
                }
                else
                {
                    oUsuario.Origen = "Externo";
                    oUsuario.IP = oUsuario.IP;
                }
                //FIN ----------------- asignando valores al objeto usuario

                //logeo
                LoginUsuario(oUsuario);

            }
            else
            {
                sMensaje = "Aceptar la Declaración Jurada para continuar";
                Funciones.GenerarMensaje("A", sMensaje, lblMensaje);
                return;
            }
            return;

        }


        private void LoginUsuario(Cls_Usuario_X_Empleado_BE oUsuario)
        {
            //Cls_Auditoria_Eventos_BN objEventBE = new Cls_Auditoria_Eventos_BN();
            {
                if (oUsuario.CARNE != "")
                {
                    //==================================== TEMPORAL EN JSON =================================================
                    string json = JsonConvert.SerializeObject(oUsuario);
                    HttpContext.Current.Session["UserSession"] = json;
                    //=======================================================================================================

                    if (oUsuario.PATER != "")
                    {
                        FormsAuthentication.RedirectFromLoginPage(oUsuario.CARNE, false);
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.User.Identity.Name, false);
                    }
                    else
                    {
                        sMensaje = "Credenciales Incorrectas";
                        Funciones.GenerarMensaje("A", sMensaje, lblMensaje);
                        return;
                    }
                }
            }


        }
    }
}