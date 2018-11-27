using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Merceria.Vistas.Productos;
using Merceria.Vistas.Proveedor;
using Merceria.Vistas.Empleado;
using Merceria.Vistas.Clientes;
using Merceria.Vistas.Ventas;

namespace Merceria.Vistas.Inicio
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Permite que el movimento de la pantalla libremente.
        /// </summary>
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        /// <summary>
        /// Permite que el movimento de la pantalla libremente.
        /// </summary>
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        /// <summary>
        /// Mostrara diversas ventanas en la pantalla inicio
        /// </summary>
        /// <param name="_form"></param>
        public void setForm(Form _form)
        {
            try
            {
                //if (actualForm != null)
                //{
                //    actualForm.Close();
                //}
                //actualForm = _form;
                //actualForm.MdiParent = this;
                //actualForm.Show();
                //actualForm.TopLevel = false;
                //actualForm.Dock = DockStyle.Fill;
                //actualForm.WindowState = FormWindowState.Maximized;
                //this.pnlContentenedor.Controls.Add(actualForm);
                //this.pnlContentenedor.Tag = actualForm;
                //actualForm.Show();

                if (this.pnlPrincipal.Controls.Count > 0)
                    this.pnlPrincipal.Controls.RemoveAt(0);
                Form fh = _form as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnlPrincipal.Controls.Add(fh);
                this.pnlPrincipal.Tag = fh;
                fh.Show();

            }
            catch (Exception _e)
            {
                MessageBox.Show(this, _e.Message);
            }
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            setForm(new frmProductoPrincipal());
            pnlMarca.Location = btnProductos.Location;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            setForm(new frmProveedorPrincipal());
            pnlMarca.Location = btnProveedores.Location;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            setForm(new frmEmpleadoPrincipal());
            pnlMarca.Location = btnEmpleados.Location;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            setForm(new frmClientePrincipal());
            pnlMarca.Location = btnClientes.Location;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            setForm(new frmVentasPrincipal());
            pnlMarca.Location = btnVentas.Location;
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
        }

        private void btnRentas_Click(object sender, EventArgs e)
        {
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
        }

        private void pnlMenuSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            
        }
    }
}
