using MercatorWinFormApp.Configuracion;
using MercatorWinFormApp.Empleados;
using MercatorWinFormApp.Inventario;
using MercatorWinFormApp.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercatorWinFormApp
{
    public partial class frmMercator : Form
    {
        public frmMercator()
        {
            InitializeComponent();
        }

        public static Boolean FormIsOpen(String FromABuscar)
        {
            Boolean lEncontrado = false;
            foreach (Form from in Application.OpenForms)
            {
                if (from.Name == FromABuscar)
                {
                    from.WindowState = FormWindowState.Normal;
                    from.Activate();
                    lEncontrado = true;
                    break;
                }

            }
            return lEncontrado;
        }
        

        private void tlsInventario_Click(object sender, EventArgs e)
        {
            if (!FormIsOpen("frmConsultaStock"))
            {
                frmConsultaStock from = new frmConsultaStock();
                from.Show();
            }
            else
            {
                MessageBox.Show("La ventana que intenta abrir, ya se encuentra abierta");
            }
        }

        private void tlsFactura_Click(object sender, EventArgs e)
        {
            if (!FormIsOpen("frmFactura"))
            {
                frmFactura from = new frmFactura();
                from.Show();
            }
            else
            {
                MessageBox.Show("La ventana que intenta abrir, ya se encuentra abierta");
            }
        }

        private void tlsConfiguracion_Click(object sender, EventArgs e)
        {
            if (!FormIsOpen("frmMantenimiento"))
            {
                frmMantenimiento from = new frmMantenimiento();
                from.Show();
            }
            else
            {
                MessageBox.Show("La ventana que intenta abrir, ya se encuentra abierta");
            }
        }

        private void tlsEmpleados_Click(object sender, EventArgs e)
        {
            if (!FormIsOpen("frmConsultaEmpleados"))
            {
                frmConsultaEmpleados from = new frmConsultaEmpleados();
                from.Show();
            }
            else
            {
                MessageBox.Show("La ventana que intenta abrir, ya se encuentra abierta");
            }
        }

        private void tlsUsuario_Click(object sender, EventArgs e)
        {
            if (!FormIsOpen("frmConsultaUsuario"))
            {
                frmConsultaUsuario from = new frmConsultaUsuario();
                from.Show();
            }
            else
            {
                MessageBox.Show("La ventana que intenta abrir, ya se encuentra abierta");
            }
        }

        private void tlsCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está Seguro que Deseas Cerrar Sesion.?", "Mercator", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                this.Close();
                login.Show();
            }


        }
    }
}
