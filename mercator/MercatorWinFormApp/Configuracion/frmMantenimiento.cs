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
            // TODO: This line of code loads data into the 'mercatorDataSet.Proveedor' table. You can move, or remove it, as needed.
            this.proveedorTableAdapter.Fill(this.mercatorDataSet.Proveedor);


            fillListaCategoria(cbxCategoria, "IdCategoria", ListaCategoriaBLL.mostrarCategoria());


        }





        #region Tabla Producto
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                Producto pro = new Producto();



                //pro.IdProducto = Convert.ToInt32(txtId.Text.Trim());
                pro.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue.ToString());
                pro.Nombre = txtProducto.Text.Trim();
                pro.Marca = txtMarca.Text.Trim();
                pro.Stock = Convert.ToInt32(txtStock.Text.ToString());
                pro.PrecioCompra = Convert.ToDecimal(txtPCompra.Text.ToString());
                pro.PrecioVenta = Convert.ToDecimal(txtPVenta.Text.ToString());
                pro.FechaVencimiento = Convert.ToDateTime(dateTimePicker1.Text.ToString());
                pro.Foto = imageToByteArray(pbImagen.Image);





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

            Producto pro = new Producto();


            pro.IdProducto = Convert.ToInt32(txtId.Text.ToString());
            pro.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue.ToString());
            pro.Nombre = txtProducto.Text.Trim();
            pro.Marca = txtMarca.Text.Trim();
            pro.Stock = Convert.ToInt32(txtStock.Text.ToString());
            pro.PrecioCompra = Convert.ToDecimal(txtPCompra.Text.ToString());
            pro.PrecioVenta = Convert.ToDecimal(txtPVenta.Text.ToString());
            pro.FechaVencimiento = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            pro.Foto = imageToByteArray(pbImagen.Image);

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                int id;

                id = Convert.ToInt32(txtId.Text);

                ProductoBLL.getProductoByDescription(id);

                bool IsDelete = ProductoBLL.deleteProducto(id);

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
                int id;

                id = Convert.ToInt32(txtIdProv.Text);

                ProveedorBLL.getProveedorByName(id);

                bool IsDelete = ProveedorBLL.deleteProveedor(id);

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


                emp.Dni = txtDni.Text.Trim();
                emp.Apellido = txtApellidoEmp.Text.Trim();
                emp.Nombre = txtNombreEmp.Text.Trim();

                if (rbnFemenino.Checked == true)
                {
                    emp.Sexo = rbnFemenino.Text = "F";
                }
                else if (rbnMasculino.Checked == true)
                {
                    emp.Sexo = rbnMasculino.Text = "M";
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
            try
            {

                int id;

                id = Convert.ToInt32(txtIdEmp.Text);

                EmpleadoBLL.getEmpleadoByName(id);

                bool IsDelete = EmpleadoBLL.deleteEmpleado(id);

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

                dat.IdDatos = Convert.ToInt32(txtIdDat.Text.ToString());
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




        private void fillListaCategoria(ComboBox cbo, string valueField, DataTable dt)
        {


            cbo.DataSource = dt;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "IdCategoria";

        }


        #region Imagen a Binario
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        #endregion

        #region Leer Codigo de Barras
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                MessageBox.Show("Codigo de producto añadido.");
        }
        #endregion

        #region SearchProduct
        private void SearchProduct()
        {

            int Id;

            Id = Convert.ToInt32(txtId.Text);

            Producto pro = ProductoBLL.getProductoByDescription(Id);

            cbxCategoria.SelectedValue = pro.IdCategoria.ToString();
            txtProducto.Text = pro.Nombre.ToString();
            txtMarca.Text = pro.Marca.ToString();
            txtStock.Text = pro.Stock.ToString();
            txtPCompra.Text = pro.PrecioCompra.ToString();
            txtPVenta.Text = pro.PrecioVenta.ToString();
            pro.FechaVencimiento = Convert.ToDateTime(dateTimePicker1.Text.ToString());
            pbImagen.Image = byteArrayToImage(pro.Foto);


        }
        #endregion

        #region SearchProveedor
        private void SearchProvedor()
        {

            int Id;

            Id = Convert.ToInt32(txtIdProv.Text);

            Proveedor prov = ProveedorBLL.getProveedorByName(Id);


            txtNomProv.Text = prov.NombreProv.ToString();
            txtDireccionProv.Text = prov.Direccion.ToString();
            txtTelefono.Text = prov.Telefono.ToString();


        }
        #endregion

        #region SearchEmp
        private void SearchEmp()
        {

            int Id;

            Id = Convert.ToInt32(txtIdEmp.Text);

            Empleado emp = EmpleadoBLL.getEmpleadoByName(Id);

            txtDni.Text = emp.Dni.ToString();
            txtApellidoEmp.Text = emp.Apellido.ToString();
            txtNombreEmp.Text = emp.Nombre.ToString();
            rbnMasculino.Checked = false;
            rbnFemenino.Checked = false;
            dtpFecha.Text = Convert.ToString(emp.FechaNac);
            txtDireccionEmp.Text = emp.Direccion.ToString();


        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchProduct();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchProvedor();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SearchEmp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtIdEmp.Text = "";
            txtDni.Text = "";
            txtApellidoEmp.Text = "";
            txtNombreEmp.Text = "";
            dtpFecha.Text = "";
            txtDireccionEmp.Clear();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIdProv.Clear();
            txtNomProv.Clear();
            txtDireccionProv.Clear();
            txtTelefono.Clear();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtProducto.Clear();
            txtMarca.Clear();
            txtStock.Clear();
            txtPCompra.Clear();
            txtPVenta.Clear();
            pbImagen.Image = null;
        }






    }




}

