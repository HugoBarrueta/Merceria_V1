using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entity
{
    public class Tbl_Productos
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal precioPublico { get; set; }
        public string descripcion { get; set; }
    }
}
