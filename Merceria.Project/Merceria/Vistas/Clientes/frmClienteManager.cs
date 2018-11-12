using CapaDatos.Entity;
using CapaNegocio.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merceria.Vistas.Clientes
{
    public partial class frmClienteManager : Form
    {
        public frmClienteManager()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Tbl_Cliente cli = new Tbl_Cliente();
            RepoCliente repo = new RepoCliente();

            cli.nombre = txtNombre.Text;
            cli.apellidos = txtApellidos.Text;
            cli.direccion = rTBDirecion.Text;
            cli.telefono = txtTelefono.Text;

            if (MessageBox.Show("¿Desea guardar los cambios?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                repo.Registrarcliente(cli);
                MessageBox.Show("Se ha guardado correctamente", "¡exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextBox();
                this.Close();    
            }
        }

        private void LimpiarTextBox()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            rTBDirecion.Clear();
            txtTelefono.Clear();
        }
    }
}
