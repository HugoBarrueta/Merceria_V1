using CapaDatos.Connection;
using CapaDatos.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repositorios
{
    public class RepoUsuarios
    {
        public List<Tbl_Cargo> ListarCargo()
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Tbl_Cargo> cargo = db.Database.SqlQuery<Tbl_Cargo>("sp_ListarCargo").ToList();
                    return cargo;

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Tbl_Usuarios> ConsultarUsuarios()
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Tbl_Usuarios> usur = db.Database.SqlQuery<Tbl_Usuarios>("sp_ListarUsuarios").ToList();
                    return usur;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public void RegistrarUsuario(Tbl_Usuarios usur)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MerceriaContext"].ConnectionString;
                MerceriaContext db = new MerceriaContext();
                string sqlComand = @"sp_InsertarUsuario";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sqlComand, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCargo", usur.idCargo);
                cmd.Parameters.AddWithValue("@nombre", usur.nombre);
                cmd.Parameters.AddWithValue("@aPaterno", usur.aPaterno);
                cmd.Parameters.AddWithValue("@aMaterno", usur.aMaterno);
                cmd.Parameters.AddWithValue("@direccion", usur.direccion);
                cmd.Parameters.AddWithValue("@celular", usur.celular);
                cmd.Parameters.AddWithValue("@telefono", usur.telefono);
                cmd.Parameters.AddWithValue("@usuario", usur.usuario);
                cmd.Parameters.AddWithValue("@pass", usur.contrasena);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
