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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lblAccion.Text == "Registro") { 
                Producto prod = new Producto();
                RepoProductos repo = new RepoProductos();

                prod.codigo = txtCodigo.Text.Trim();
                prod.nombre = txtNombre.Text.Trim();
                prod.precioPublico = float.Parse(txtPrecPublico.Text.Trim());
                prod.precioEntrada = float.Parse(txtPrecCosto.Text.Trim());
                prod.stock = int.Parse(txtCantidad.Text.Trim());
                prod.descripcion = txtDescripcion.Text.Trim();

                if (MessageBox.Show("¿Desea guardar los cambios?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    repo.RegistrarProducto(prod);
                    MessageBox.Show("Se ha guardado correctamente", "¡exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTextBox();
                    this.Close();
                }
            }


        }
        
        private void LimpiarTextBox()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecCosto.Clear();
            txtPrecPublico.Clear();
            txtStock.Clear();
            txtDescripcion.Clear();
        }
    }
}
