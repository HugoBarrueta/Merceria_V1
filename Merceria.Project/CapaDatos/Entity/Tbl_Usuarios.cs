using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entity
{
    public class Tbl_Usuarios
    {
        public int id { get; set; }
        public int idCargo { get; set; }
        public string nombre { get; set; }
        public string aPaterno { get; set; }
        public string aMaterno { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string telefono { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
