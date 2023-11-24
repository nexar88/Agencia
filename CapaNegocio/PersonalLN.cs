using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PersonalLN
    {
        #region "PATRON SINGLETON"
        private static PersonalLN objFamiliar = null;
        private PersonalLN() { }
        public static PersonalLN getInstance()
        {
            if (objFamiliar == null)
            {
                objFamiliar = new PersonalLN();
            }
            return objFamiliar;
        }
        #endregion

        public string Procesar_ahora(Cls_Usuario_X_Empleado_BE Usuario,string IdCurso, string Proceso)
        {
            try
            {
                return PersonalDAO.getInstance().Procesar_BD(Usuario,IdCurso,Proceso);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Cls_Materias_BE> LIST_BUTTON_CURSOS_BN(Cls_Usuario_X_Empleado_BE Usuario)
        {
            try
            {
                return PersonalDAO.getInstance().LIST_BUTTON_CURSOS_BD(Usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public string Guardar_Respuesta(Cls_Respuesta_BE ObjRespuesta, Cls_Usuario_X_Empleado_BE objUsuario)
        {
            try
            {
                return PersonalDAO.getInstance().Guardar_Respuesta(ObjRespuesta, objUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cls_Pregunta_BE> Procesar_generar_pregunta(Cls_Usuario_X_Empleado_BE ObjUsu, Cls_Pregunta_BE objPregunta)
        {
            try
            {
                return PersonalDAO.getInstance().Procesar_generar_pregunta_BD(ObjUsu, objPregunta);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cls_Respuesta_BE> Procesar_generar_respuesta(  string nIdPregunta, string nIdCurso, Cls_Usuario_X_Empleado_BE ObjUsu)
        {
            try
            {
                return PersonalDAO.getInstance().Procesar_generar_respuesta_BD(nIdPregunta, nIdCurso, ObjUsu);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    
}
