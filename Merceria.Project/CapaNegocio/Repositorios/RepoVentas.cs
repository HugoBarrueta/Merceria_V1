using CapaDatos.Connection;
using CapaDatos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repositorios
{
    public class RepoVentas
    {
        public List<Producto> ConsultarProductos()
        {
            try
            {
                using (MerceriaContext db = new MerceriaContext())
                {
                    List<Producto> prod = db.Database.SqlQuery<Producto>("st_ConsultarProductos").ToList();
                    return prod;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
