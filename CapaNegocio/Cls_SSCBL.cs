using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class Cls_SSCBL
    {
        public string Str_Con = "";
        public Cls_SSCBL(string _Str_Con)
        {
            Str_Con = _Str_Con;
        }
        public Cls_Usuario_X_Empleado_BE Obt_Login_BL(Cls_Usuario_X_Empleado_BE objBE, ref string Str_Err)
        {
            Cls_SSCDL Obj_SSC = new Cls_SSCDL(Str_Con);
            return Obj_SSC.Obt_Login_DL(objBE, ref Str_Err);
        }
        public Cls_Usuario_X_Empleado_BE Obt_Login_Acceso_BL(Cls_Usuario_X_Empleado_BE objBE, ref string Str_Err)
        {
            Cls_SSCDL Obj_SSC = new Cls_SSCDL(Str_Con);
            return Obj_SSC.Obt_Login_Acceso_DL(objBE, ref Str_Err);
        }

        public Cls_Usuario_X_Empleado_BE InteraccionLee2(string codigo)
        {
            Cls_SSCDL Obj_SSC = new Cls_SSCDL(Str_Con);
            try
            {
                return Obj_SSC.InteraccionLee2(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cls_Usuario_X_Empleado_BE InteraccionLee3(Cls_Usuario_X_Empleado_BE obje)
        {
            Cls_SSCDL Obj_SSC = new Cls_SSCDL(Str_Con);
            try
            {
                return Obj_SSC.InteraccionLee3(obje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cls_Usuario_X_Empleado_BE Obt_Acceso_General_BL(string Carne,ref string Str_Err)
        {
            Cls_SSCDL Obj_SSC = new Cls_SSCDL(Str_Con);
            return Obj_SSC.Obt_Acceso_General_DL(Carne,ref Str_Err);
        }

        
        public Cls_Usuario_X_Empleado_BE Obt_Operador_Acceso_BL(Cls_Usuario_X_Empleado_BE objBE, ref string Str_Err)
        {
            Cls_SSCDL Obj_SSC = new Cls_SSCDL(Str_Con);
            return Obj_SSC.Obt_Operador_Acceso_DL(objBE, ref Str_Err);
        }


        public Cls_Usuario_X_Empleado_BE InteraccionLee(string codigo)
        {
            Cls_SSCDL Obj_SSC = new Cls_SSCDL(Str_Con);
            try
            {
                return Obj_SSC.InteraccionLee(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
