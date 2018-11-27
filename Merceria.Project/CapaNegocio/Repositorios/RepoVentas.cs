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
    public class RepoVentas
    {
        public List<Tbl_Productos> ConsultarProductos()
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Tbl_Productos> prod = db.Database.SqlQuery<Tbl_Productos>("st_ConsultarProductos").ToList();
                    return prod;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Tbl_Productos> ConsultarProductosPorCodigo(Tbl_Productos pro)
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Tbl_Productos> prod = db.Database.SqlQuery<Tbl_Productos>("st_ConsultarProductoPorCodigo @codigo",
                        new SqlParameter("@codigo", pro.codigo)).ToList();
                    return prod;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public int Consultarstock(string codigo)
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    int prod = db.Database.SqlQuery<int>("st_ConsultarStock @codigo",
                        new SqlParameter("@codigo", codigo)).FirstOrDefault();
                    return prod;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void RegistrarVenta(Tbl_Venta vent)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MerceriaContext"].ConnectionString;
                MerceriaContext db = new MerceriaContext();
                string sqlComand = @"st_RegistrarVenta";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sqlComand, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@totalVenta", vent.totalVenta);
                cmd.Parameters.AddWithValue("@fechaVenta", vent.fechaVenta);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void ActualizarStock(string codigo, int stock)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MerceriaContext"].ConnectionString;
                MerceriaContext db = new MerceriaContext();
                string sqlComand = @"st_DescontarStock";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sqlComand, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
