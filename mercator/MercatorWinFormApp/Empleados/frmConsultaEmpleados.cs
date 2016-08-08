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
            dgvEmpleados.DataSource = EmpleadoBLL.getEmpleados();

        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        

    }
}
