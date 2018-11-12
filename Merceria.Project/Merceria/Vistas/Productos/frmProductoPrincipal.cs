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
    public partial class frmProductoPrincipal : Form
    {
        public frmProductoPrincipal()
        {
            InitializeComponent();
            ListarProductos();
        }

        RepoProductos repo = new RepoProductos();

        private void ListarProductos()
        {
            dgvProductos.DataSource = repo.ConsultarProductos();
        }


        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProductoManager obj = new frmProductoManager();
            obj.Show();
            obj.lblAccion.Text = "Registro";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.nombre = txtBuscar.Text;
            dgvProductos.DataSource = repo.ConsultarProductoPorNombre(prod);
        }
    }
}
