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
    public partial class frmRegistrarUsuario : Form
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {

                if (Program.IdEmpleado != 0)
                {
                    Usuario U = new Usuario();
                    U.FKIdEmpleado1 = Program.IdEmpleado;
                    U.Usuario1 = txtUser.Text.Trim();
                    U.Contraseña = txtPassword.Text.Trim();

                    bool IsInsert = UsuarioBLL.createUsuario(U);

                    if (IsInsert)
                    {
                        MessageBox.Show("Se creo la cuenta del empleado.");


                    }
                }
                else
                {
                    MessageBox.Show("Fallo al momento de crear.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
                    
                      

                      
               
           }
        }
    
       
        


        }


        
    

