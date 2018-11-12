using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entity
{
    public class Tbl_Venta
    {
        [Key]
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }
        public decimal totalVenta { get; set; }
        public DateTime fechaVenta { get; set; }
    }
}
