namespace MercatorWinFormApp.Usuarios
{
    partial class frmConsultaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaUsuario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnSalirPro = new System.Windows.Forms.Button();
            this.btnImprimirPro = new System.Windows.Forms.Button();
            this.btnBuscarPro = new System.Windows.Forms.Button();
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvUsuarios);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 209);
            this.panel1.TabIndex = 18;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(-1, -1);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(862, 209);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // btnSalirPro
            // 
            this.btnSalirPro.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirPro.Image")));
            this.btnSalirPro.Location = new System.Drawing.Point(705, 293);
            this.btnSalirPro.Name = "btnSalirPro";
            this.btnSalirPro.Size = new System.Drawing.Size(81, 46);
            this.btnSalirPro.TabIndex = 25;
            this.btnSalirPro.UseVisualStyleBackColor = true;
            // 
            // btnImprimirPro
            // 
            this.btnImprimirPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirPro.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirPro.Image")));
            this.btnImprimirPro.Location = new System.Drawing.Point(577, 292);
            this.btnImprimirPro.Name = "btnImprimirPro";
            this.btnImprimirPro.Size = new System.Drawing.Size(84, 46);
            this.btnImprimirPro.TabIndex = 24;
            this.btnImprimirPro.UseVisualStyleBackColor = true;
            // 
            // btnBuscarPro
            // 
            this.btnBuscarPro.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPro.Image")));
            this.btnBuscarPro.Location = new System.Drawing.Point(723, 12);
            this.btnBuscarPro.Name = "btnBuscarPro";
            this.btnBuscarPro.Size = new System.Drawing.Size(63, 50);
            this.btnBuscarPro.TabIndex = 26;
            this.btnBuscarPro.UseVisualStyleBackColor = true;
            // 
            // txtDatos
            // 
            this.txtDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatos.Location = new System.Drawing.Point(217, 26);
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.Size = new System.Drawing.Size(488, 21);
            this.txtDatos.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Buscar por Id:";
            // 
            // frmConsultaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(886, 364);
            this.Controls.Add(this.btnBuscarPro);
            this.Controls.Add(this.btnSalirPro);
            this.Controls.Add(this.btnImprimirPro);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaUsuario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Usuario";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnSalirPro;
        private System.Windows.Forms.Button btnImprimirPro;
        private System.Windows.Forms.Button btnBuscarPro;
        private System.Windows.Forms.TextBox txtDatos;
        private System.Windows.Forms.Label label1;
    }
}