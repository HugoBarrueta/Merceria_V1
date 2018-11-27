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

namespace Merceria.Vistas.Proveedor
{
    public partial class frmProveedorManager : Form
    {
        public frmProveedorManager()
        {
            InitializeComponent();
        }

        private void LimpiarTextBox()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(lblAccion.Text == "Registro")
            {
                Tbl_Proveedores prov = new Tbl_Proveedores();
                RepoProveedor repo = new RepoProveedor();

                prov.nombre = txtNombre.Text.Trim();
                prov.direccion = txtDireccion.Text.Trim();
                prov.telefono = txtTelefono.Text.Trim();

                if (MessageBox.Show("¿Desea guardar los cambios?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    repo.RegistrarProveedor(prov);
                    MessageBox.Show("Se ha guardado correctamente", "¡exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTextBox();
                    this.Close();
                }
            }
        }
    }
}
