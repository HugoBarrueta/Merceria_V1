using CapaDatos.Connection;
using CapaDatos.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repositorios
{
    public class RepoProveedor
    {
        public List<Tbl_Proveedores> ConsultarProveedores()
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Tbl_Proveedores> prov = db.Database.SqlQuery<Tbl_Proveedores>("sp_ListarProveedores").ToList();
                    return prov;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void RegistrarProveedor(Tbl_Proveedores prov)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MerceriaContext"].ConnectionString;
                MerceriaContext db = new MerceriaContext();
                string sqlComand = @"sp_InsertarProveedor";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sqlComand, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", prov.nombre);
                cmd.Parameters.AddWithValue("@direccion", prov.direccion);
                cmd.Parameters.AddWithValue("@telefono", prov.telefono);
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
