using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merceria.Vistas.Productos
{
    public partial class frmProductoManager : Form
    {
        public frmProductoManager()
        {
            InitializeComponent();
        }

        private void frmProductoManager_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void lnklblNuevaCategoria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCategoriaProducto obj = new frmCategoriaProducto();
            obj.Show();
        }
    }
}
