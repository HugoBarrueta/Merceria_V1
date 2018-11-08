using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Connection
{
    public partial class MerceriaContext : DbContext
    {
        public MerceriaContext()
            :base("MerceriaContext")
        {

        }
    }
}
