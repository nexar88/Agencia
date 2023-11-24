using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace McSoftware.View
{
    public partial class Resultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["UserSession"]))
            {
                Response.Redirect(ResolveUrl("~/CerrarSession.aspx"), false);
                return;
            }

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                this.Session["xPersonal"] = "";
                
                string JS = HttpContext.Current.Session["UserSession"].ToString();
                Cls_Usuario_X_Empleado_BE objUser = JsonConvert.DeserializeObject<Cls_Usuario_X_Empleado_BE>(JS);

                //string FechaInicio = Request.QueryString["fechaInicio"].ToString();
                //string FechaTermino = Request.QueryString["fechaTermino"].ToString();
                
                string Operador = objUser.CARNE.ToString();
                //DataTable Data_Info = (DataTable) Request.QueryString["FECINI"].ToString();
                string OPS = Request.QueryString["OPS"].ToString();

                if (OPS == "REG_FAM")
                {
                    string Emi_Categoria_Cod = Request.QueryString["emi_Categoria_Cod"].ToString();
                    //LISTA_REGISTRO_FAMILIARES(Emi_Categoria_Cod, FechaInicio, FechaTermino, Operador);
                }
                else
                {
                    //string Opcion = Request.QueryString["Opcion"].ToString();
                    //string Titular = Request.QueryString["chkTitular"].ToString();
                    //string Familiar = Request.QueryString["chkFamiliar"].ToString();

                    //if (OPS == "Report_registro_emision_carnet")
                    //{
                    //    LISTA_EMI_CARNET_FAMILIAR(OPS, Titular, Familiar, FechaInicio, FechaTermino);
                    //}
                    //else
                    //{
                    //    if (OPS == "Report_cuadro_consolidado_emision_carnet")
                    //    {
                    //        LISTA_EMI_CUADRO_CONSOLIDADO_FAMILIAR(OPS, Titular, Familiar, FechaInicio, FechaTermino);
                    //    }
                    //    else
                    //    {
                    //        if (Opcion == "Titular")
                    //        {
                    //            LISTA_EMI_CARNET_TITULAR(OPS, Titular, Familiar, FechaInicio, FechaTermino);
                    //        }
                    //        if (Opcion == "Familiar")
                    //        {
                    //            LISTA_EMI_CARNET_FAMILIAR(OPS, Titular, Familiar, FechaInicio, FechaTermino);
                    //        }
                    //        if (Opcion == "Todos")
                    //        {
                    //            LISTA_EMI_CARNET_TODOS(OPS, Titular, Familiar, FechaInicio, FechaTermino);
                    //        }
                    //    }
                    //}
                }

            }

        }
    }
}