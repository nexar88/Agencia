using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class Cls_Menu_BN
    {
        Cls_Menu_BD objDL = new Cls_Menu_BD();

        public List<Cls_Menu_BE> Obt_Lista_Menu_BL(Cls_Menu_BE objBE, string OptM1, ref string Str_Error)
        {
            return objDL.Obt_Lista_Menu_DL(objBE, OptM1, ref Str_Error);
        }
    }
}
