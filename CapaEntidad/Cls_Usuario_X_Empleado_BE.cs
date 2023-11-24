using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cls_Usuario_X_Empleado_BE
    {
        //public string CodUsuario { get; set; }
        public string Clave { get; set; }
        public string SITUAC { get; set; }
        public string SITESP_COD { get; set; }
        public string PATER { get; set; }
        public string MATER { get; set; }
        public string NOMB { get; set; }
        public string STELEFONO { get; set; }
        public string TESPE { get; set; }
        public string TESPE_COD { get; set; }
        public string MODULO { get; set; }
        public string PERFIL { get; set; }

        public string NOMBRECOMPLETO
        {
            get
            {
                return string.Format("{0},{1},{2}", this.PATER.Trim(), this.MATER.Trim(), this.NOMB.Trim());
            }
        }
        public int idmodulo { get; set; }
        public string TGRAD_COD { get; set; }
        public string GRADO { get; set; }
        public string TCATE { get; set; }
        // VARIABLES DE ACCESO AL AGUILA 6
        public string CARNE { get; set; }
        public string BASE { get; set; }
        public string OPE_LOGIN { get; set; }
        public string REPORTE { get; set; }
        //ADICCIONADO PARA REGRESO accedido desde nuevo sigcp 1 desde integrado 0 desde aqui

        public string sMensaje { get; set; }
        public string TPERSONA { get; set; }
        public string CODUNI_LR { get; set; }

        public string IP { get; set; }
        public string Origen { get; set; }
        //inicio - seguridad para acceso a grados generales
        public string maspolCon { get; set; }
        public string ripe_r { get; set; }
        public string rit_s { get; set; }
        public string raria_d { get; set; }
        public string rav_a { get; set; }
        public string rh_a { get; set; }
        public string rhade_t { get; set; }
        public string ritsbeneficio_s { get; set; }

        public string Curso_cuestionario_PagX { get; set; }
        //fin - seguridad acceso generales

    }
}
