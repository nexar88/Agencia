using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace CapaDatos
{
    public class PersonalDAO : Cls_BD
    {

        #region "PATRON SINGLETON"
        private static PersonalDAO daoPersonal = null;
        private PersonalDAO() { }
        public static PersonalDAO getInstance()
        {
            if (daoPersonal == null)
            {
                daoPersonal = new PersonalDAO();
            }
            return daoPersonal;
        }
        #endregion


        //ELIMINAR EMISION
        public string Procesar_BD(Cls_Usuario_X_Empleado_BE Usuario, string IdCurso, string Proceso)
        {
            string Resultado = "";
            SqlConnection cn = new SqlConnection(str_Cuestionario);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "ProcesarCuestionario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                        new SqlParameter("@CipUsuario", SqlDbType.Char, 8) { Value = Usuario.CARNE },
                        new SqlParameter("@CodGrado", SqlDbType.VarChar, 4) { Value = Usuario.TGRAD_COD },
                        new SqlParameter("@CodEspe", SqlDbType.VarChar, 4) { Value = Usuario.TESPE_COD },
                        new SqlParameter("@CodCate", SqlDbType.VarChar, 2) { Value = Usuario.TCATE },
                        new SqlParameter("@codProceso", SqlDbType.VarChar, 4) { Value = Proceso },

                        new SqlParameter("@nIdPregunta", SqlDbType.Int) { Value = 0 },
                        new SqlParameter("@nIdRespuesta", SqlDbType.Int) { Value = 0 },
                        new SqlParameter("@IDCURSO", SqlDbType.Int) { Value = IdCurso },
                        new SqlParameter("@Opcion", SqlDbType.VarChar, 2) { Value = "1" },
                        new SqlParameter("@Result", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output }
                };
                cmd.Parameters.AddRange(sqlParams);
                //abrir conexion
                cn.Open();
                //ejecutar procedimiento
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Result"].Value.ToString() != "")
                {
                    Resultado = cmd.Parameters["@Result"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = Resultado + "Error:" + (char)13 + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return Resultado;
        }

        public string Guardar_Respuesta(Cls_Respuesta_BE ObjRespuesta, Cls_Usuario_X_Empleado_BE objUsuario)
        {
            string Resultado = "";
            SqlConnection cn = new SqlConnection(str_Cuestionario);
            try
            {
                
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "ProcesarCuestionario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                        new SqlParameter("@CipUsuario", SqlDbType.Char, 8) { Value = objUsuario.CARNE},
                        new SqlParameter("@Opcion", SqlDbType.VarChar, 2) { Value = "2" },
                        new SqlParameter("@nIdCuestionario", SqlDbType.Int) { Value = ObjRespuesta.sIdCuestionario },
                        new SqlParameter("@nIdRespuesta", SqlDbType.Int) { Value = ObjRespuesta.sIdRespuesta },
                        new SqlParameter("@IDCURSO", SqlDbType.Int) { Value = ObjRespuesta.sIdCurso },
                        new SqlParameter("@Result", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output }
                };
                cmd.Parameters.AddRange(sqlParams);
                //abrir conexion
                cn.Open();
                //ejecutar procedimiento
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Result"].Value.ToString() != "")
                {
                    Resultado = cmd.Parameters["@Result"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = Resultado + "Error:" + (char)13 + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return Resultado;
        }

        public List<Cls_Materias_BE> LIST_BUTTON_CURSOS_BD(Cls_Usuario_X_Empleado_BE ObjUsu)
        {
            List<Cls_Materias_BE> Listar = new List<Cls_Materias_BE>();
            SqlConnection cn = new SqlConnection(str_Cuestionario);
            string MensajeResultado = "";
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "CONSULTA_OPCIONES";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                        new SqlParameter("@Opcion", SqlDbType.VarChar, 2) { Value = "2" },
                         new SqlParameter("@tcate_cod", SqlDbType.VarChar, 2) { Value = ObjUsu.TCATE },
                         new SqlParameter("@tgrado_cod", SqlDbType.VarChar, 4) { Value = ObjUsu.TGRAD_COD },
                         new SqlParameter("@tespe_cod", SqlDbType.VarChar, 4) { Value = ObjUsu.TESPE_COD },
                        new SqlParameter("@Result", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output }
                };
                cmd.Parameters.AddRange(sqlParams);
                //abrir conexion
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Cls_Materias_BE objBE_A = new Cls_Materias_BE();
                    objBE_A.IdMateria = Convert.ToString(dr["nIdMateria"]);
                    objBE_A.Nombre = dr["sNombre"].ToString();
                    objBE_A.Descripcion = dr["sDescripcion"].ToString();
                    objBE_A.Detalle = dr["sDetalle"].ToString();
                    Listar.Add(objBE_A);
                }

            }
            catch (Exception ex)
            {
                MensajeResultado = MensajeResultado + "Error:" + (char)13 + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return Listar;
        }
        public List<Cls_Pregunta_BE> Procesar_generar_pregunta_BD(Cls_Usuario_X_Empleado_BE ObjUsu, Cls_Pregunta_BE objPregunta)
        {
            List<Cls_Pregunta_BE> Lista = new List<Cls_Pregunta_BE>();
            string MensajeResultado = "";
            SqlConnection cn = new SqlConnection(str_Cuestionario);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "CONSULTA_CUESTIONARIO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                        new SqlParameter("@CipUsuario", SqlDbType.Char, 8) { Value = ObjUsu.CARNE.Trim() },
                        new SqlParameter("@CodGrado", SqlDbType.Char, 4) { Value = ObjUsu.TGRAD_COD.Trim() },
                        new SqlParameter("@CodEspe", SqlDbType.Char, 4) { Value = ObjUsu.TESPE_COD.Trim() },

                        new SqlParameter("@nOrden", SqlDbType.VarChar) { Value = objPregunta.nOrden.Trim() },
                        new SqlParameter("@nidCurso", SqlDbType.VarChar) { Value = objPregunta.sIdCurso.Trim() },
                        new SqlParameter("@nIdPregunta", SqlDbType.VarChar) { Value = objPregunta.nIdPregunta.Trim() },
                        new SqlParameter("@sIdCuestionarioDetalle", SqlDbType.VarChar,20) { Value = objPregunta.sIdCuestionarioDetalle.Trim() },
                        new SqlParameter("@sEvento", SqlDbType.VarChar,5) { Value = objPregunta.sEvento.Trim() },

                        new SqlParameter("@Opcion", SqlDbType.VarChar, 2) { Value = "2" },
                        new SqlParameter("@Result", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output }
                };
                cmd.Parameters.AddRange(sqlParams);
                //abrir conexion
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Cls_Pregunta_BE objBE_A = new Cls_Pregunta_BE();
                    objBE_A.nOrden = dr["nOrden"].ToString();
                    objBE_A.sTotalPreg = dr["sTotalPreg"].ToString();
                    objBE_A.nidCuestionario = dr["nidCuestionario"].ToString();
                    objBE_A.nidRespuesta = dr["nidRespuesta"].ToString();
                    objBE_A.nIdPregunta = dr["nidPregunta"].ToString();
                    objBE_A.sTitulo = dr["sTitulo"].ToString();
                    objBE_A.sDescripcion = dr["sDescripcion"].ToString();
                    objBE_A.sEstado = dr["sEstado"].ToString();
                    objBE_A.sNombreMateria = dr["NombreMateria"].ToString();
                    objBE_A.sIdCuestionarioDetalle = dr["sIdCuestionarioDetalle"].ToString();

                    objBE_A.sAlternativaOpcion = dr["Alternativa_Opcion"].ToString();
                    objBE_A.sTituloOpcion = dr["Titulo_Opcion"].ToString();
                    objBE_A.sRptaMarcada = dr["sRptaMarcada"].ToString();

                    Lista.Add(objBE_A);
                }

            }
            catch (Exception ex)
            {
                MensajeResultado = MensajeResultado + "Error:" + (char)13 + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return Lista;
        }

        public List<Cls_Respuesta_BE> Procesar_generar_respuesta_BD(string nIdCurso, string nIdPregunta, Cls_Usuario_X_Empleado_BE ObjUsu)
        {
            List<Cls_Respuesta_BE> Listar = new List<Cls_Respuesta_BE>();
            string MensajeResultado = "";
            SqlConnection cn = new SqlConnection(str_Cuestionario);
            try
            {
                
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "CONSULTA_CUESTIONARIO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                        new SqlParameter("@CipUsuario", SqlDbType.Char, 8) { Value = ObjUsu.CARNE},
                        new SqlParameter("@Opcion", SqlDbType.VarChar, 2) { Value = "3" },
                        new SqlParameter("@nIdCurso", SqlDbType.Int) { Value = Convert.ToInt32(nIdCurso) },
                        new SqlParameter("@nIdPregunta", SqlDbType.Int) { Value = Convert.ToInt32(nIdPregunta) },

                        new SqlParameter("@Result", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output }
                };
                cmd.Parameters.AddRange(sqlParams);
                //abrir conexion
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Cls_Respuesta_BE objBE_A = new Cls_Respuesta_BE();

                    //objBE_A.nIdRespuesta = Convert.ToInt32(dr["nidRespuesta"].ToString());
                    objBE_A.sIdRespuesta = dr["nidRespuesta"].ToString();
                    objBE_A.sRptaMarcada = dr["sRptaMarcada"].ToString();
                    objBE_A.sTitulo = dr["sTitulo"].ToString();
                    objBE_A.sDescripcion = dr["sDescripcion"].ToString();
                    objBE_A.sAlternativa = dr["sAlternativa"].ToString();
                    objBE_A.sEstado = dr["sEstado"].ToString();
                    objBE_A.sRespuestaCorrecta = dr["sRespuestaCorrecta"].ToString();
                    Listar.Add(objBE_A);
                }

            }
            catch (Exception ex)
            {
                MensajeResultado = MensajeResultado + "Error:" + (char)13 + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return Listar;
        }
    }
}
