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

namespace McSoftware
{
    public partial class Intro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        [WebMethod]
        public static List<Cls_Pregunta_BE> GENERAR_PREGUNTA(Cls_Pregunta_BE ObjPregunta)
        {
            //=======================================================================================================
            string JS =  HttpContext.Current.Session["UserSession"].ToString();
            Cls_Usuario_X_Empleado_BE objUser = JsonConvert.DeserializeObject<Cls_Usuario_X_Empleado_BE>(JS);
            //=========================================================================================================
            return PersonalLN.getInstance().Procesar_generar_pregunta(objUser, ObjPregunta);
        }


        [WebMethod]
        public static List<Cls_Respuesta_BE> GENERAR_RESPUESTA(string sIdCurso,string sIdPregunta)
        {
            //=======================================================================================================
            string JS =  HttpContext.Current.Session["UserSession"].ToString();
            Cls_Usuario_X_Empleado_BE objUser = JsonConvert.DeserializeObject<Cls_Usuario_X_Empleado_BE>(JS);
            //=========================================================================================================
            return PersonalLN.getInstance().Procesar_generar_respuesta(sIdCurso, sIdPregunta, objUser);
        }

        [WebMethod]
        public static string Procesar_ahora(string sIdCurso)
        {
            //=======================================================================================================
            string JS = HttpContext.Current.Session["UserSession"].ToString();
            Cls_Usuario_X_Empleado_BE objUser = JsonConvert.DeserializeObject<Cls_Usuario_X_Empleado_BE>(JS);
            //=========================================================================================================
            return PersonalLN.getInstance().Procesar_ahora(objUser, sIdCurso,"");
        }

        [WebMethod]
        public static List<Cls_Materias_BE> LIST_BUTTON_CURSOS()
        {
            //=======================================================================================================
            string JS = HttpContext.Current.Session["UserSession"].ToString();
            Cls_Usuario_X_Empleado_BE objUser = JsonConvert.DeserializeObject<Cls_Usuario_X_Empleado_BE>(JS);
            //=========================================================================================================
            return PersonalLN.getInstance().LIST_BUTTON_CURSOS_BN(objUser);
        }

        [WebMethod]
        public static string Guardar_Respuesta(Cls_Respuesta_BE ObjRespuesta)
        {
            //=======================================================================================================
            string JS = HttpContext.Current.Session["UserSession"].ToString();
            Cls_Usuario_X_Empleado_BE objUser = JsonConvert.DeserializeObject<Cls_Usuario_X_Empleado_BE>(JS);
            //=========================================================================================================
            return PersonalLN.getInstance().Guardar_Respuesta(ObjRespuesta, objUser);
        }

        
    }
}