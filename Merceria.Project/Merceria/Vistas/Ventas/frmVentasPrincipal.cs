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

namespace Merceria.Vistas.Ventas
{
    public partial class frmVentasPrincipal : Form
    {
        public frmVentasPrincipal()
        {
            InitializeComponent();
            LlenardGVentas();
            LlenarComboClientes();
            DenegarEscrituraCombos();
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
            int cantidad = int.Parse(txtCantidad.Text);
            subtotal = precio * cantidad;
            txtSubTotal.Text = subtotal.ToString();   
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularSubtotal();
            btnAgregar.Enabled = true;
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

        private void LlenarComboClientes()
        {
            List<Tbl_Cliente> listaClientes = repoCli.ConsultarCliente().ToList();
            cli.id = -1;
            cli.nombre = "-----------Clientes-----------";
            listaClientes.Insert(0, cli);
            this.cmbClientes.ValueMember = "id";
            this.cmbClientes.DisplayMember = "nombre";
            this.cmbClientes.DataSource = listaClientes;
        }

        private void DenegarEscrituraCombos()
        {
            cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar la venta?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarTextBox();
                dgvDetalleVenta.DataSource = "";
                LlenarComboClientes();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            vent.idCliente = cmbClientes.SelectedIndex;
            vent.totalVenta = decimal.Parse(txtTotal.Text);
            vent.fechaVenta = DateTime.Parse(dTPFecha.Value.ToShortDateString());
            if (MessageBox.Show("¿Desea registrar la venta?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                repo.RegistrarVenta(vent);
                MessageBox.Show("Se ha guardado correctamente", "¡exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextBox();
            }
        }

        Tbl_Venta vent = new Tbl_Venta();
        Tbl_Cliente cli = new Tbl_Cliente();
        Tbl_Productos pro = new Tbl_Productos();
        RepoVentas repo = new RepoVentas();
        RepoCliente repoCli = new RepoCliente();
    }
}
