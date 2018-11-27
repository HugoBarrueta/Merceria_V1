using CapaDatos.Connection;
using CapaDatos.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repositorios
{
        public class RepoProductos
        {
        public List<Producto> ConsultarProductos()
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Producto> prod = db.Database.SqlQuery<Producto>("sp_ListarProductos").ToList();
                    return prod;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Tbl_Categoria> ListarCategoria()
        {
            try
            {
                using(MerceriaContext db = new MerceriaContext())
                {
                    List<Tbl_Categoria> prod = db.Database.SqlQuery<Tbl_Categoria>("sp_ListarCategoria").ToList();
                    return prod;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<Producto> ConsultarProductoPorNombre(Producto prod)
        {
            using (MerceriaContext db = new MerceriaContext())
            {
                try
                {
                    var productos = db.Database.SqlQuery<Producto>("sp_BuscarProdNombre @nombre",
                        new SqlParameter("@apellidos", prod.nombre)).ToList();
                    return productos;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public void RegistrarProducto(Producto prod)
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["MerceriaContext"].ConnectionString;
                    MerceriaContext db = new MerceriaContext();
                    string sqlComand = @"sp_InsertarProducto";
                    SqlConnection con = new SqlConnection(constr);
                    SqlCommand cmd = new SqlCommand(sqlComand, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod", prod.codigo);
                    cmd.Parameters.AddWithValue("@nombre", prod.nombre);
                    cmd.Parameters.AddWithValue("@precEntrada", prod.precioEntrada);
                    cmd.Parameters.AddWithValue("@precPubl", prod.precioPublico);
                    cmd.Parameters.AddWithValue("@stock", prod.stock);
                    cmd.Parameters.AddWithValue("descr", prod.descripcion);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }