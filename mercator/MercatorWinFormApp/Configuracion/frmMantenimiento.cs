using BussinesLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercatorWinFormApp.Configuracion
{
    public partial class frmMantenimiento : Form
    {
        public frmMantenimiento()
        {
            InitializeComponent();
        }

        private void frmRegistrarProducto_Load(object sender, EventArgs e)
        {


            fillListaCategoria(cbxCategoria, "IdCategoria", ListaCategoriaBLL.mostrarCategoria());
            dgvProveedor.DataSource = ProveedorBLL.getProveedores();
            
        }

        SqlCommand cmd;
        MemoryStream ms;
        byte[] photo_aray;


        #region Tabla Producto
        private void button2_Click(object sender, EventArgs e)
        {
             try
            {

                Producto pro = new Producto();


             
                pro.IdProducto = Convert.ToInt32(txtId.Text.Trim());
                pro.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue.ToString());
                pro.Nombre = txtNombreEmp.Text.Trim();
                pro.Marca = txtMarca.Text.Trim();
                pro.Stock = Convert.ToInt32(txtStock.Text.ToString());
                pro.PrecioCompra = Convert.ToDecimal(txtPCompra.Text.ToString());
                pro.PrecioVenta = Convert.ToDecimal(txtPVenta.Text.ToString());
                pro.FechaVencimiento = Convert.ToDateTime(dateTimePicker1.Text.ToString());
                conv_photo();
                
                
                 

                    
                bool IsInsert = ProductoBLL.createProducto(pro);

                if (IsInsert)
                {
                    MessageBox.Show("se agrego correctamente al registro.");

                   
                }
                else
                {
                    MessageBox.Show("fallo al momento de registrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Producto pro = new Producto();
               


                pro.IdProducto = Convert.ToInt32(txtId.Text.Trim());
                pro.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue.ToString());
                pro.Nombre = txtNombreEmp.Text.Trim();
                pro.Marca = txtMarca.Text.Trim();
                pro.Stock = Convert.ToInt32(txtStock.Text.ToString());
                pro.PrecioCompra = Convert.ToDecimal(txtPCompra.Text.ToString());
                pro.PrecioVenta = Convert.ToDecimal(txtPVenta.Text.ToString());
                pro.FechaVencimiento = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                conv_photo();

                bool IsUpdate = ProductoBLL.updateProducto(pro);

                if (IsUpdate)
                {
                    MessageBox.Show("El registro se modifico correctamente.");

                }
                else
                {
                    MessageBox.Show("El registro no se pudo modificar .");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Producto pro = new Producto();

                pro.IdProducto = Convert.ToInt32(txtId.Text = "");
                pro.IdCategoria = Convert.ToInt32(cbxCategoria.Text = "");
                pro.Nombre = txtProducto.Text = "";
                pro.Marca = txtMarca.Text = "";
                pro.PrecioCompra = Convert.ToDecimal(txtPCompra.Text = "");
                pro.PrecioVenta = Convert.ToDecimal(txtPVenta.Text= "");
                pro.Stock = Convert.ToInt32(txtStock.Text = "");
                pro.FechaVencimiento = dateTimePicker1.Value = DateTime.Now;
                pbImagen.Image = null;
                txtProducto.Focus();

                bool IsDelete = ProductoBLL.deleteProducto(pro.IdProducto);

                if (IsDelete)
                {
                    MessageBox.Show("El registro se elimino correctamente.");

                }
                else
                {
                    MessageBox.Show("El registro no se pudo eliminar.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = OpenFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(OpenFileDialog.FileName);
            } 
        }

        #endregion

        #region Tabla Proveedor

       private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Proveedor prov = new Proveedor();


                prov.IdProveedor = Convert.ToInt32(txtId.Text.Trim());
                prov.NombreProv = txtNomProv.Text.Trim();
                prov.Direccion = txtDireccionProv.Text.Trim();
                prov.Telefono = Convert.ToInt32(txtTelefono.Text.ToString());
                




                bool IsInsert = ProveedorBLL.createProveedor(prov);

                if (IsInsert)
                {
                    MessageBox.Show("Se agrego correctamente al registro de Proveedores.");


                }
                else
                {
                    MessageBox.Show("Fallo al momento de registrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {


            try
            {

                Proveedor prov = new Proveedor();


                prov.IdProveedor = Convert.ToInt32(txtId.Text.Trim());
                prov.NombreProv = txtNomProv.Text.Trim();
                prov.Direccion = txtDireccionProv.Text.Trim();
                prov.Telefono = Convert.ToInt32(txtTelefono.Text.ToString());
            
                bool IsUpdate = ProveedorBLL.updateProveedor(prov);

                if (IsUpdate)
                {
                    MessageBox.Show("El proveedor se modifico correctamente.");

                }
                else
                {
                    MessageBox.Show("El proveedor no se pudo modificar .");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
       
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor prov = new Proveedor();

                prov.IdProveedor = Convert.ToInt32(txtId.Text = "");
                prov.NombreProv = txtNomProv.Text = "";
                prov.Direccion = txtDireccionProv.Text = "";
                prov.Telefono = Convert.ToInt32(txtTelefono.Text = "");
                
                bool IsDelete = ProveedorBLL.deleteProveedor(prov.IdProveedor);

                if (IsDelete)
                {
                    MessageBox.Show("El registro se elimino correctamente.");

                }
                else
                {
                    MessageBox.Show("El registro no se pudo eliminar.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

                
            
        }


        #endregion


        #region Tabla Empleado
        private void btnGuardarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado emp = new Empleado();

                emp.IdEmpleado = Convert.ToInt32(txtIdEmp.Text.ToString());
                emp.Dni = txtDni.Text.Trim();
                emp.Apellido = txtApellidoEmp.Text.Trim();
                emp.Nombre = txtNombreEmp.Text.Trim();

                if (rbnFemenino.Checked == true)
                {
                    emp.Sexo = rbnFemenino.Checked.ToString();
                }
                else if (rbnMasculino.Checked == true)
                {
                    emp.Sexo = rbnMasculino.Checked.ToString();
                }

                emp.FechaNac = Convert.ToDateTime(dtpFecha.Text.ToString());

                emp.Direccion = txtDireccionEmp.Text.Trim();

                bool IsInsert = EmpleadoBLL.createEmpleado(emp);

                if (IsInsert)
                {
                    MessageBox.Show("Se agrego correctamente al registro de Empleados.");


                }
                else
                {
                    MessageBox.Show("Fallo al momento de registrar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnModificarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado emp = new Empleado();

                emp.IdEmpleado = Convert.ToInt32(txtIdEmp.Text.ToString());
                emp.Dni = txtDni.Text.Trim();
                emp.Apellido = txtApellidoEmp.Text.Trim();
                emp.Nombre = txtNombreEmp.Text.Trim();

                if (rbnFemenino.Checked == true)
                {
                    emp.Sexo = rbnFemenino.Checked.ToString();
                }
                else if (rbnMasculino.Checked == true)
                {
                    emp.Sexo = rbnMasculino.Checked.ToString();
                }

                emp.FechaNac = Convert.ToDateTime(dtpFecha.Text.ToString());

                emp.Direccion = txtDireccionEmp.Text.Trim();

                bool IsUpdate = EmpleadoBLL.updateEmpleado(emp);

                if (IsUpdate)
                {
                    MessageBox.Show("Se modifico el empleado.");


                }
                else
                {
                    MessageBox.Show("Fallo al momento de modificar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnBorrarEmp_Click(object sender, EventArgs e)
        {
            try {
            Empleado emp = new Empleado();

            emp.IdEmpleado = Convert.ToInt32(txtIdEmp.Text = "");
            emp.Dni = txtDni.Text = "";
            emp.Apellido = txtApellidoEmp.Text = "";
            emp.Nombre = txtNombreEmp.Text = "";
            rbnFemenino.AutoCheck = false;
            rbnMasculino.AutoCheck = false;
            emp.FechaNac = dtpFecha.Value = DateTime.Now;
            emp.Direccion = txtDireccionEmp.Text = "";

             bool IsDelete = EmpleadoBLL.deleteEmpleado(emp.IdEmpleado);

                if (IsDelete)
                {
                    MessageBox.Show("Se elimino el empleado.");


                }
                else
                {
                    MessageBox.Show("Fallo al momento de eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        #endregion


        #region Tabla Datos de Negocio
        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            try
            {

                Dato dat = new Dato();
               

                dat.Nombre = txtNombreDato.Text.Trim();
                dat.Localidad = txtLocalidad.Text.Trim();
                dat.Telefono = Convert.ToInt32(txtTelefonoDato.Text.ToString());
                dat.Horario = Convert.ToDateTime(dtpHorario.Value.ToString());
               

                bool IsInsert = DatosBLL.createDatosEmpresa(dat);

                if (IsInsert)
                {
                    MessageBox.Show("Se agregaron los datos del negocio.");


                }
                else
                {
                    MessageBox.Show("Fallo al momento de agregar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            try
            {

                Dato dat = new Dato();


                dat.Nombre = txtNombreDato.Text.Trim();
                dat.Localidad = txtLocalidad.Text.Trim();
                dat.Telefono = Convert.ToInt32(txtTelefonoDato.Text.ToString());
                dat.Horario = Convert.ToDateTime(dtpHorario.Value.ToString());


                bool IsUpdate = DatosBLL.updateDatosEmpresa(dat);

                if (IsUpdate)
                {
                    MessageBox.Show("Se agregaron los datos del negocio.");


                }
                else
                {
                    MessageBox.Show("Fallo al momento de agregar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNombreDato.Clear();
            txtLocalidad.Clear();
            txtTelefonoDato.Clear();
            dtpHorario.Value = DateTime.Now;
        }
        #endregion

       

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

          


            fillListaCategoria(cbxCategoria, "IdCategoria", ListaCategoriaBLL.mostrarCategoria());


           
        }

        private void fillListaCategoria(ComboBox cbo, string valueField, DataTable dt)
        {


            cbo.DataSource = dt;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "IdCategoria";
            
        }


        void conv_photo()
        {
            if (pbImagen.Image != null)
            {
                ms = new MemoryStream();
                pbImagen.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@Foto", photo_aray);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            ProductoBLL.getProductos();
        }

       





    }

       

    
    }

