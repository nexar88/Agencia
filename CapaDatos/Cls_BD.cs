using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Cls_BD
    {
        protected string Str_Err = "";
        protected string Str_ErrDetalle = "";
        protected static string str_Cuestionario = ConfigurationManager.ConnectionStrings["cn_BD_Cuesti"].ToString();
        protected static string str_Menu = ConfigurationManager.ConnectionStrings["cn_BD"].ToString();
    }
}
