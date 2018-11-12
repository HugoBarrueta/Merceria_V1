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
    public class RepoCliente
    {
        public void Registrarcliente(Tbl_Cliente cli)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MerceriaContext"].ConnectionString;
                MerceriaContext db = new MerceriaContext();
                string sqlComand = @"st_RegistrarCliente";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sqlComand, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", cli.nombre);
                cmd.Parameters.AddWithValue("@apellidos", cli.apellidos);
                cmd.Parameters.AddWithValue("@direccion", cli.direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.telefono);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public List<Tbl_Cliente> ConsultarCliente()
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Tbl_Cliente> clientes = db.Database.SqlQuery<Tbl_Cliente>("st_ConsultarClientes").ToList();
                    return clientes;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<Tbl_Cliente> ConsultarClientePorApellidos(Tbl_Cliente cli)
        {
            using (MerceriaContext db = new MerceriaContext())
            {
                try
                {
                    var cliente = db.Database.SqlQuery<Tbl_Cliente>("st_ConsultarClientePorApellidos @apellidos",
                        new SqlParameter("@apellidos", cli.apellidos)).ToList();
                    return cliente;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
