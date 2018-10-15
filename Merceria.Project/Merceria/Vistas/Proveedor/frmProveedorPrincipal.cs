using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merceria.Vistas.Proveedor
{
    public partial class frmProveedorPrincipal : Form
    {
        public frmProveedorPrincipal()
        {
            InitializeComponent();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmProveedorManager obj = new frmProveedorManager();
            obj.Show();
        }
    }
}
