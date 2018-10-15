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
    public partial class frmEmpleadoManager : Form
    {
        public frmEmpleadoManager()
        {
            InitializeComponent();
        }

        private void frmEmpleadoManager_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
