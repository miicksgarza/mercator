using BussinesLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercatorWinFormApp.Empleados
{
    public partial class frmConsultaEmpleados : Form
    {
        public frmConsultaEmpleados()
        {
            InitializeComponent();
          

        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void frmConsultaEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mercatorDataSet.Empleado' table. You can move, or remove it, as needed.
            this.empleadoTableAdapter.Fill(this.mercatorDataSet.Empleado);

        }

        private void dgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Crear Una Cuenta de Usuario Para este Empleado.?", "Mercator.", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                frmRegistrarUsuario U = new frmRegistrarUsuario();
                Program.IdEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells[0].Value.ToString());
                U.lblEmpleado.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString() + ", " +
                                     dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
                U.lblDni.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
                U.Show();
            }
        }

        private void btnSalirEmp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
