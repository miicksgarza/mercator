namespace MercatorWinFormApp.Empleados
{
    partial class frmConsultaEmpleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaEmpleados));
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimirEmp = new System.Windows.Forms.Button();
            this.btnAgregarEmp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.btnSalirEmp = new System.Windows.Forms.Button();
            this.btnBuscarEmp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDatos
            // 
            this.txtDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatos.Location = new System.Drawing.Point(122, 15);
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.Size = new System.Drawing.Size(488, 21);
            this.txtDatos.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Buscar por Id:";
            // 
            // btnImprimirEmp
            // 
            this.btnImprimirEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirEmp.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirEmp.Image")));
            this.btnImprimirEmp.Location = new System.Drawing.Point(659, 275);
            this.btnImprimirEmp.Name = "btnImprimirEmp";
            this.btnImprimirEmp.Size = new System.Drawing.Size(90, 43);
            this.btnImprimirEmp.TabIndex = 14;
            this.btnImprimirEmp.UseVisualStyleBackColor = true;
            // 
            // btnAgregarEmp
            // 
            this.btnAgregarEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEmp.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarEmp.Image")));
            this.btnAgregarEmp.Location = new System.Drawing.Point(531, 275);
            this.btnAgregarEmp.Name = "btnAgregarEmp";
            this.btnAgregarEmp.Size = new System.Drawing.Size(103, 43);
            this.btnAgregarEmp.TabIndex = 13;
            this.btnAgregarEmp.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvEmpleados);
            this.panel1.Location = new System.Drawing.Point(14, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 213);
            this.panel1.TabIndex = 12;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(-3, -1);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.Size = new System.Drawing.Size(862, 209);
            this.dgvEmpleados.TabIndex = 0;
            this.dgvEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellContentClick);
            // 
            // btnSalirEmp
            // 
            this.btnSalirEmp.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirEmp.Image")));
            this.btnSalirEmp.Location = new System.Drawing.Point(774, 275);
            this.btnSalirEmp.Name = "btnSalirEmp";
            this.btnSalirEmp.Size = new System.Drawing.Size(89, 43);
            this.btnSalirEmp.TabIndex = 18;
            this.btnSalirEmp.UseVisualStyleBackColor = true;
            // 
            // btnBuscarEmp
            // 
            this.btnBuscarEmp.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEmp.Image")));
            this.btnBuscarEmp.Location = new System.Drawing.Point(630, 5);
            this.btnBuscarEmp.Name = "btnBuscarEmp";
            this.btnBuscarEmp.Size = new System.Drawing.Size(90, 43);
            this.btnBuscarEmp.TabIndex = 19;
            this.btnBuscarEmp.UseVisualStyleBackColor = true;
            // 
            // frmConsultaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(885, 337);
            this.Controls.Add(this.btnBuscarEmp);
            this.Controls.Add(this.btnSalirEmp);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimirEmp);
            this.Controls.Add(this.btnAgregarEmp);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Empleados";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImprimirEmp;
        private System.Windows.Forms.Button btnAgregarEmp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Button btnSalirEmp;
        private System.Windows.Forms.Button btnBuscarEmp;
    }
}