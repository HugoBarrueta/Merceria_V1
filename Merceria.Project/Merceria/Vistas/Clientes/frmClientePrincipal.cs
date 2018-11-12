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
    public partial class frmClientePrincipal : Form
    {
        public frmClientePrincipal()
        {
            InitializeComponent();
            LlenarDataGriedViewCliente();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmClienteManager obj = new frmClienteManager();
            obj.Show();
        }

        private void LlenarDataGriedViewCliente()
        {
            dGVClientes.DataSource = repo.ConsultarCliente(); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Tbl_Cliente cli = new Tbl_Cliente();
            cli.apellidos = txtBuscarCliente.Text;
            dGVClientes.DataSource = repo.ConsultarClientePorApellidos(cli);
        }

        RepoCliente repo = new RepoCliente();
    }
}
