using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Merceria.Vistas.Inicio;

namespace Merceria.Vistas.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public void setTabIndex()
        {
            int c=0;
            txtUsuario.TabIndex = c++;
            txtPass.TabIndex = c++;
            btnAcceder.TabIndex = c++;
        }
        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            frmInicio inicio = new frmInicio();
            inicio.Show();
            this.Hide();
        }
    }
}
