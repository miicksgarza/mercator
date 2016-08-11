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

namespace MercatorWinFormApp.Usuarios
{
    public partial class frmConsultaUsuario : Form
    {
        public frmConsultaUsuario()
        {
            InitializeComponent();

           
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmConsultaUsuario_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'mercatorDataSet.Usuario' table. You can move, or remove it, as needed.
            this.usuarioTableAdapter.Fill(this.mercatorDataSet.Usuario);

            dgvUsuarios.DataSource = UsuarioBLL.cargarUsuarios();

        }

        private void btnSalirPro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
