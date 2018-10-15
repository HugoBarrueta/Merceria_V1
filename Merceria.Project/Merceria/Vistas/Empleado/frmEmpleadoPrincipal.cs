using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merceria.Vistas.Empleado
{
    public partial class frmEmpleadoPrincipal : Form
    {
        public frmEmpleadoPrincipal()
        {
            InitializeComponent();
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            frmEmpleadoManager obj = new frmEmpleadoManager();
            obj.Show();
        }
    }
}
