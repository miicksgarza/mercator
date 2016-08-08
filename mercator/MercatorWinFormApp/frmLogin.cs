using BussinesLogic;
using Entities;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está Seguro que Desea Salir.?", "Mercator.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();

                if (txtUser.Text.Trim() != "")
                {
                    if (txtPassword.Text.Trim() != "")
                    {
                        String Mensaje = "Acceso Correcto.";
                        user.Usuario1 = txtUser.Text;
                        user.Contraseña = txtPassword.Text;
                        bool U = UsuarioBLL.loginUser(user.Usuario1, user.Contraseña);

                        if (Mensaje == "Su Contraseña es Incorrecta.")
                        {
                            MessageBox.Show(Mensaje, "Mercator.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                        else
                            if (Mensaje == "El Nombre de Usuario no Existe.")
                            {
                                MessageBox.Show(Mensaje, "Mercator.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                txtUser.Clear();
                                txtPassword.Clear();
                                txtUser.Focus();
                            }
                            else
                            {
                                MessageBox.Show(Mensaje, "Mercator.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                frmMercator M = new frmMercator();
                                M.Show();
                                this.Hide();
                            }
                    }
                    else
                    {
                        MessageBox.Show("Por Favor Ingrese su Contraseña.", "Mercator.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor Ingrese Nombre de Usuario.", "Mercator.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
