using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entity
{
    public class Producto
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }
        public float precioPublico { get; set; }
        public float precioEntrada { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
    }
}
