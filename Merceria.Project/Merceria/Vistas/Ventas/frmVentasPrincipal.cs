﻿using CapaDatos.Entity;
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
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }
    }
}
