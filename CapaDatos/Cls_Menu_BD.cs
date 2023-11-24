using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Cls_Menu_BD : Cls_BD
    {
        public List<Cls_Menu_BE> Obt_Lista_Menu_DL(Cls_Menu_BE objBE, string OptM1, ref string Str_Err)
        {
            List<Cls_Menu_BE> Lista = new List<Cls_Menu_BE>();
            SqlConnection cn = new SqlConnection(str_Menu);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "SP_DETALLE_MENU";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 5;
            SqlParameter[] sqlParams = new SqlParameter[]
            {
               new SqlParameter("@Tipo", SqlDbType.VarChar, 250) { Value = objBE.Tipo },
                new SqlParameter("@IdPerfil", SqlDbType.VarChar, 4) { Value = objBE.xIdPerfil },
                new SqlParameter("@maspe_carne", SqlDbType.VarChar, 8) { Value = objBE.MASPE_CARNE }
            };
            cmd.Parameters.AddRange(sqlParams);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Cls_Menu_BE objBE_A = new Cls_Menu_BE();
                    //objBE.IdPerfil = Convert.ToInt32(dr["IdPerfil"].ToString());
                    objBE_A.IdMenu = Convert.ToString(dr["nIdMenu"].ToString());
                    objBE_A.Descripcion = Convert.ToString(dr["sDescripcion"].ToString());
                    objBE_A.Aplicacion = Convert.ToString(dr["Aplicacion"]);
                    objBE_A.IdNiveles = Convert.ToString(dr["IdNiveles"].ToString());
                    objBE_A.IdPadre = Convert.ToString(dr["nIdPadre"].ToString());
                    objBE_A.Orden = Convert.ToString(dr["nOrder"].ToString());
                    Lista.Add(objBE_A);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
            }
            return Lista;
        }
    }
}
