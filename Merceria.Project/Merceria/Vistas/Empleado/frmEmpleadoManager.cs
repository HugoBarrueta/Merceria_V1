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

namespace Merceria.Vistas.Empleado
{
    public partial class frmEmpleadoManager : Form
    {
        public frmEmpleadoManager()
        {
            InitializeComponent();
            ListarCargo();
        }

        private void LimpiarTextBox()
        {
            txtNombre.Clear();
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            txtDireccion.Clear();
            txtCelular.Clear();
            txtCargo.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtPass.Clear();
        }

        private void ListarCargo()
        {
            RepoUsuarios repo = new RepoUsuarios();
            cmbCargo.DataSource = repo.ListarCargo();
            cmbCargo.DisplayMember = "cargo";
            cmbCargo.ValueMember = "id";
        }

        private void frmEmpleadoManager_Load(object sender, EventArgs e)
        {

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
                Tbl_Usuarios usur = new Tbl_Usuarios();
                RepoUsuarios repo = new RepoUsuarios();

                usur.nombre = txtNombre.Text.Trim();
                usur.aPaterno = txtAPaterno.Text.Trim();
                usur.aMaterno = txtAMaterno.Text.Trim();
                usur.idCargo = Int32.Parse(txtCargo.Text.Trim());
                usur.direccion = txtDireccion.Text.Trim();
                usur.celular = txtCelular.Text.Trim();
                usur.telefono = txtTelefono.Text.Trim();
                usur.usuario = txtUsuario.Text.Trim();
                usur.contrasena = txtPass.Text.Trim();

                if (MessageBox.Show("¿Desea guardar los cambios?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    repo.RegistrarUsuario(usur);
                    MessageBox.Show("Se ha guardado correctamente", "¡exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTextBox();
                    this.Close();
                }
            }
            if(lblAccion.Text == "Editar")
            {

            }
        }
    }
}
