using CapaDatos.Entity;
using CapaNegocio.Repositorios;
using Repo.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merceria.Vistas.Ventas
{
    public partial class frmVentasPrincipal : Form
    {
        public frmVentasPrincipal()
        {
            InitializeComponent();
            LlenardGVentas();
            btnAgregar.Enabled = false;
            txtCantidad.Enabled = false;
            btnCalcular.Enabled = false;
            btnAceptar.Enabled = false;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pro.codigo = txtBuscar.Text;
            dGVMostrarProductos.DataSource = repo.ConsultarProductosPorCodigo(pro);
        }

        private void LlenardGVentas()
        {
            dGVMostrarProductos.DataSource = repo.ConsultarProductos();
        }
        
        private void dGVMostrarProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVMostrarProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dGVMostrarProductos.SelectedRows)  
                {
                    lblP.Text = row.Cells[0].Value.ToString();
                    txtNombre.Text = row.Cells[1].Value.ToString();
                    txtPrecio.Text = row.Cells[2].Value.ToString();
                    txtDescripcion.Text = row.Cells[3].Value.ToString();
                    txtCantidad.Enabled = true;
                    txtCantidad.Clear();
                    btnCalcular.Enabled = true;
                }
            }
        }

        private void CalcularSubtotal()
        {
            decimal subtotal;
            decimal precio = decimal.Parse(txtPrecio.Text);
            lblCantidad.Text = txtCantidad.Text;
            var stock = repo.Consultarstock(lblP.Text);
            if (lblCantidad.Text == "")
            {
                MessageBox.Show("Debe de ingresar una cantidad", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarTextBox();
                btnAgregar.Enabled = false;
                btnCancelar.Enabled = false;
                btnCalcularTotal.Enabled = false;
            }
            else if(lblCantidad.Text == "0")
            {
                MessageBox.Show("0 no es valido en cantidad", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarTextBox();
                btnAgregar.Enabled = false;
                btnCancelar.Enabled = false;
                btnCalcularTotal.Enabled = false;
            }
            else if(int.Parse(lblCantidad.Text) > stock)
            {
                MessageBox.Show("No tienes suficiente stock", "¡ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Solo tienes disponible "+stock, "¡ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarTextBox();
                btnAgregar.Enabled = false;
                btnCancelar.Enabled = false;
                btnCalcularTotal.Enabled = false;
            }
            else
            {
                int cantidad = int.Parse(lblCantidad.Text);
                subtotal = precio * cantidad;
                txtSubTotal.Text = subtotal.ToString();
                btnAgregar.Enabled = true;
            }   
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
                CalcularSubtotal();
                btnCalcular.Enabled = false;  
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvDetalleVenta.Rows.Add(txtNombre.Text, txtCantidad.Text, txtSubTotal.Text);
            LimpiarTextBox();
            btnCalcular.Enabled = true;
            btnAgregar.Enabled = false;
            txtCantidad.Enabled = false;
            btnCalcular.Enabled = false;
            btnCalcularTotal.Enabled = true;
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            SumaTotal();
            btnAceptar.Enabled = true;
        }

        private void SumaTotal()
        {
            decimal suma = 0;
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                suma += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }
            txtTotal.Text = suma.ToString();
        }

        private void LimpiarTextBox()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtSubTotal.Clear();
            txtBuscar.Clear();
            txtTotal.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar la venta?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarTextBox();
                txtCantidad.Clear();
                dgvDetalleVenta.Rows.Clear();
                dgvDetalleVenta.Refresh();
                btnAgregar.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            vent.totalVenta = decimal.Parse(txtTotal.Text);
            vent.fechaVenta = DateTime.Parse(dTPFecha.Value.ToShortDateString());
            if (MessageBox.Show("¿Desea registrar la venta?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string codigo = lblP.Text;
                var stock = repo.Consultarstock(codigo);
                int totalStock;
                totalStock = stock - int.Parse(lblCantidad.Text);
                repo.ActualizarStock(codigo, totalStock);
                repo.RegistrarVenta(vent);
                MessageBox.Show("Se ha guardado correctamente", "¡exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextBox();
                dgvDetalleVenta.Rows.Clear();
                dgvDetalleVenta.Refresh();
            }
        }
        
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            vn.SoloNumeros(e);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            vn.SoloNumeros(e);
        }

        Tbl_Venta vent = new Tbl_Venta();
        Tbl_Productos pro = new Tbl_Productos();
        RepoVentas repo = new RepoVentas();
        ValidarNumeros vn = new ValidarNumeros(); 
    }
}
