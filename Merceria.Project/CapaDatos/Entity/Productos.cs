using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entity
{
    public class Productos
    {
        public string nombre { get; set; }
        public float precioPublico { get; set; }
        public string descripcion { get; set; }
    }
}
