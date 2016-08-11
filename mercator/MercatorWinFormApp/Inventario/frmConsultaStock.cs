using BussinesLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercatorWinFormApp.Inventario
{
    public partial class frmConsultaStock : Form
    {
        public frmConsultaStock()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmConsultaStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mercatorDataSet.Producto' table. You can move, or remove it, as needed.
            this.productoTableAdapter.Fill(this.mercatorDataSet.Producto);
            
        }

        private void btnSalirPro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
