using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class Cls_SSCDL:Cls_BD
    {
        public string str_Con = "";
        public Cls_SSCDL(string _Str_Con)
        {
            str_Con = _Str_Con;
        }
        public Cls_Usuario_X_Empleado_BE InteraccionLee2(string codigo)
        {
            Cls_Usuario_X_Empleado_BE oUser = null;
            try
            {
                SqlConnection cn = new SqlConnection(str_Menu);
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "PA_MSEG_ACCESO_INTERACCION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 90;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@codigo", SqlDbType.Int) { Value = codigo }
                };
                cmd.Parameters.AddRange(sqlParams);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        oUser = new Cls_Usuario_X_Empleado_BE();
                        oUser.CARNE = dr["carne"].ToString();
                        oUser.idmodulo = Convert.ToInt32(dr["idmodulo"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    cn.Dispose();
                    throw;
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    cn.Dispose();
                }
            }
            catch (Exception ex)
            {
                oUser = null;
            }
            return oUser;
        }
        public Cls_Usuario_X_Empleado_BE InteraccionLee3(Cls_Usuario_X_Empleado_BE obje)
        {
            Cls_Usuario_X_Empleado_BE oUser = null;
            //byte[] encubrir = System.Text.Encoding.UTF8.GetBytes(obje.CARNE);
            try
            {
                SqlConnection cn = new SqlConnection(str_Menu);
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SP_PA_ACCESO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    //new SqlParameter("@carne", SqlDbType.VarChar,50) { Value = Convert.ToBase64String(encubrir)},
                     new SqlParameter("@Usuario", SqlDbType.VarChar,50) { Value = obje.CARNE  },
                    new SqlParameter("@Clave", SqlDbType.VarChar,50) { Value = obje.Clave }
                };
                cmd.Parameters.AddRange(sqlParams);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        // Crear objetos de tipo Usuarios
                        oUser = new Cls_Usuario_X_Empleado_BE();
                        oUser.CARNE = dr["sDni"].ToString();
                        oUser.STELEFONO = dr["sTelefono"].ToString();
                        oUser.PATER = dr["sPater"].ToString();
                        oUser.MATER = dr["sMater"].ToString();
                        oUser.NOMB = dr["sNombres"].ToString();
                        //oUser.TCATE = dr["sCate"].ToString();
                        oUser.TGRAD_COD = dr["sGrado"].ToString();
                        oUser.TESPE_COD = dr["sTEspe"].ToString();
                        oUser.TCATE = dr["nIdModulo"].ToString();
                        oUser.PERFIL = dr["nIdPerfil"].ToString();
                    }
                }
                catch (Exception)
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    cn.Dispose();
                    throw;
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    cn.Dispose();
                }
            }
            catch (Exception ex)
            {
                oUser = null;
            }
            return oUser;
        }
        public Cls_Usuario_X_Empleado_BE Obt_Login_DL(Cls_Usuario_X_Empleado_BE objBE, ref string Str_Err)
        {
            SqlConnection cn = new SqlConnection(str_Menu);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "sp_con_maspe";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                    new SqlParameter("@XCARNE", SqlDbType.Char, 8) { Value = objBE.CARNE }
            };
            cmd.Parameters.AddRange(sqlParams);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    objBE.CARNE = dr["CARNE"].ToString();
                    objBE.PATER = dr["PATER"].ToString();
                    objBE.MATER = dr["MATER"].ToString();
                    objBE.NOMB = dr["NOMBRE"].ToString();
                    objBE.SITESP_COD = dr["SITESP_COD"].ToString();
                    objBE.SITUAC = dr["SITUAC"].ToString();
                    objBE.TGRAD_COD = dr["TGRAD_COD"].ToString();
                    objBE.GRADO = dr["GRADO"].ToString();
                    objBE.TCATE = dr["TPCAT1"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
            }
            return objBE;
        }


        public Cls_Usuario_X_Empleado_BE Obt_Login_Acceso_DL(Cls_Usuario_X_Empleado_BE objBE,ref string Str_Err)
        {
            SqlConnection cn = new SqlConnection(str_Menu);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "IDEN_sp_Acceso";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                    new SqlParameter("@XCARNE", SqlDbType.Char, 8) { Value = objBE.CARNE },
                    new SqlParameter("@TPERSONA", SqlDbType.VarChar,2) { Value = objBE.TPERSONA }
            };
            cmd.Parameters.AddRange(sqlParams);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    objBE.sMensaje = dr["sMensaje"].ToString().Trim();
                    objBE.BASE = dr["sBase"].ToString().Trim();
                    objBE.OPE_LOGIN = dr["sOperadorlogin"].ToString().Trim();
                    objBE.REPORTE = dr["sreporte"].ToString().Trim();
                    //tabla maspe
                    objBE.CARNE = dr["sCarne"].ToString().Trim();
                    objBE.PATER = dr["sPaterno"].ToString().Trim();
                    objBE.MATER = dr["sMaterno"].ToString().Trim();
                    objBE.NOMB = dr["sNombres"].ToString().Trim();
                    objBE.TCATE = dr["sCodGradoMaspe"].ToString().Trim();
                    //tabla grados
                    objBE.TGRAD_COD = dr["sCodGrado"].ToString().Trim();
                    objBE.GRADO = dr["sDesGrado"].ToString().Trim();
                    //tabla situacion especial
                    objBE.SITUAC = dr["sSituacion"].ToString().Trim();
                    objBE.SITESP_COD = dr["sTituacionEspecial"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                string msje = ex.Message.ToString();
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
            }
            return objBE;
        }
        public Cls_Usuario_X_Empleado_BE Obt_Acceso_General_DL(string Carne, ref string Str_Err)
        {
            Cls_Usuario_X_Empleado_BE objBEmpleadoAcceso = new Cls_Usuario_X_Empleado_BE();
            SqlConnection cn = new SqlConnection(str_Menu);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "IDEN_sp_Acceso";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                    new SqlParameter("@XCARNE", SqlDbType.Char, 8) { Value = Carne }
            };
            cmd.Parameters.AddRange(sqlParams);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    objBEmpleadoAcceso.maspolCon = dr["MaspolConsulta"].ToString().Trim();
                    objBEmpleadoAcceso.ripe_r = dr["Riper"].ToString().Trim();
                    objBEmpleadoAcceso.rit_s = dr["Rits"].ToString().Trim();
                    objBEmpleadoAcceso.raria_d = dr["Rariad"].ToString().Trim();
                    objBEmpleadoAcceso.rav_a = dr["Rava"].ToString().Trim();
                    objBEmpleadoAcceso.rh_a = dr["RHA"].ToString().Trim();
                    objBEmpleadoAcceso.rhade_t = dr["RHADet"].ToString().Trim();
                    objBEmpleadoAcceso.ritsbeneficio_s = dr["RitsBeneficios"].ToString().Trim();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
            }
            return objBEmpleadoAcceso;
        }
        public Cls_Usuario_X_Empleado_BE Obt_Operador_Acceso_DL(Cls_Usuario_X_Empleado_BE objBE, ref string Str_Err)
        {
            try
            {
                Cls_Usuario_X_Empleado_BE objBEmpleadoAcceso = new Cls_Usuario_X_Empleado_BE();
                SqlConnection cn = new SqlConnection(str_Menu);
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_con_maspe_acceso_prueba";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@K_CARNE", SqlDbType.VarChar, 10) { Value = objBE.CARNE }
                };
                cmd.Parameters.AddRange(sqlParams);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        objBE.BASE = dr["base"].ToString();
                        objBE.OPE_LOGIN = dr["Ope_login"].ToString();
                        objBE.REPORTE = dr["reporte"].ToString();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    cn.Dispose();
                }
                return objBE;
            }
            catch (Exception EX)
            {

                throw EX;
            }
            
        }

        public Cls_Usuario_X_Empleado_BE InteraccionLee(string codigo)
        {
            Cls_Usuario_X_Empleado_BE oUser = null;
            try
            {
                SqlConnection cn = new SqlConnection(str_Menu);
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SP_MSEG_INTERACCION_LEE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@codigo", SqlDbType.Int) { Value = codigo }
                };
                cmd.Parameters.AddRange(sqlParams);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        // Crear objetos de tipo Usuarios
                        oUser = new Cls_Usuario_X_Empleado_BE();
                        oUser.CARNE = dr["carne"].ToString();
                        oUser.PATER = dr["pater"].ToString();
                        oUser.MATER = dr["mater"].ToString();
                        oUser.NOMB = dr["nombres"].ToString();
                        oUser.idmodulo = Convert.ToInt32(dr["idmodulo"].ToString());
                        oUser.TGRAD_COD = dr["codgrado"].ToString();
                        oUser.GRADO = dr["grado"].ToString();
                        oUser.SITUAC = dr["situa"].ToString();
                        oUser.TCATE = dr["cate"].ToString();
                        oUser.SITESP_COD = dr["sitesp"].ToString();
                        oUser.TPERSONA = dr["tpersona"].ToString().Trim();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    cn.Dispose();
                }
            }
            catch (Exception ex)
            {
                oUser = null;
            }
            return oUser;
        }




    }
}
