namespace Biblioteca_Gestion2
{
    partial class FrmUsuarios
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabBiblioteca = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DgvUsuarios = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAgregarUsuario = new System.Windows.Forms.Button();
            this.TxtCarnetUsuario = new System.Windows.Forms.TextBox();
            this.TxtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblNombreUsuario = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CmbUsuario = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.DgvPrestamos = new System.Windows.Forms.DataGridView();
            this.BtnDevolver = new System.Windows.Forms.Button();
            this.BtnPrestar = new System.Windows.Forms.Button();
            this.LblUsuario1 = new System.Windows.Forms.Label();
            this.LblMaterial = new System.Windows.Forms.Label();
            this.LblPrestamo = new System.Windows.Forms.Label();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.tabBiblioteca.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabBiblioteca
            // 
            this.tabBiblioteca.Controls.Add(this.tabPage1);
            this.tabBiblioteca.Controls.Add(this.tabPage2);
            this.tabBiblioteca.Location = new System.Drawing.Point(12, 27);
            this.tabBiblioteca.Name = "tabBiblioteca";
            this.tabBiblioteca.SelectedIndex = 0;
            this.tabBiblioteca.Size = new System.Drawing.Size(944, 414);
            this.tabBiblioteca.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnEliminar);
            this.tabPage1.Controls.Add(this.BtnEditar);
            this.tabPage1.Controls.Add(this.DgvUsuarios);
            this.tabPage1.Controls.Add(this.BtnAgregarUsuario);
            this.tabPage1.Controls.Add(this.TxtCarnetUsuario);
            this.tabPage1.Controls.Add(this.TxtNombreUsuario);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.LblNombreUsuario);
            this.tabPage1.Controls.Add(this.LblUsuario);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(936, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DgvUsuarios
            // 
            this.DgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.DgvUsuarios.Location = new System.Drawing.Point(390, 88);
            this.DgvUsuarios.Name = "DgvUsuarios";
            this.DgvUsuarios.RowHeadersWidth = 51;
            this.DgvUsuarios.RowTemplate.Height = 24;
            this.DgvUsuarios.Size = new System.Drawing.Size(522, 169);
            this.DgvUsuarios.TabIndex = 6;
            this.DgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsuarios_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Carnet";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // BtnAgregarUsuario
            // 
            this.BtnAgregarUsuario.Location = new System.Drawing.Point(22, 268);
            this.BtnAgregarUsuario.Name = "BtnAgregarUsuario";
            this.BtnAgregarUsuario.Size = new System.Drawing.Size(273, 66);
            this.BtnAgregarUsuario.TabIndex = 5;
            this.BtnAgregarUsuario.Text = "Agregar";
            this.BtnAgregarUsuario.UseVisualStyleBackColor = true;
            this.BtnAgregarUsuario.Click += new System.EventHandler(this.BtnAgregarUsuario_Click);
            // 
            // TxtCarnetUsuario
            // 
            this.TxtCarnetUsuario.Location = new System.Drawing.Point(22, 211);
            this.TxtCarnetUsuario.Name = "TxtCarnetUsuario";
            this.TxtCarnetUsuario.Size = new System.Drawing.Size(304, 22);
            this.TxtCarnetUsuario.TabIndex = 4;
            // 
            // TxtNombreUsuario
            // 
            this.TxtNombreUsuario.Location = new System.Drawing.Point(22, 121);
            this.TxtNombreUsuario.Name = "TxtNombreUsuario";
            this.TxtNombreUsuario.Size = new System.Drawing.Size(304, 22);
            this.TxtNombreUsuario.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Carnet";
            // 
            // LblNombreUsuario
            // 
            this.LblNombreUsuario.AutoSize = true;
            this.LblNombreUsuario.Location = new System.Drawing.Point(19, 88);
            this.LblNombreUsuario.Name = "LblNombreUsuario";
            this.LblNombreUsuario.Size = new System.Drawing.Size(117, 16);
            this.LblNombreUsuario.TabIndex = 1;
            this.LblNombreUsuario.Text = "Nombre Completo";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(335, 24);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(279, 32);
            this.LblUsuario.TabIndex = 0;
            this.LblUsuario.Text = "Registro de usuario";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CmbUsuario);
            this.tabPage2.Controls.Add(this.cmbMaterial);
            this.tabPage2.Controls.Add(this.DgvPrestamos);
            this.tabPage2.Controls.Add(this.BtnDevolver);
            this.tabPage2.Controls.Add(this.BtnPrestar);
            this.tabPage2.Controls.Add(this.LblUsuario1);
            this.tabPage2.Controls.Add(this.LblMaterial);
            this.tabPage2.Controls.Add(this.LblPrestamo);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(936, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Prestamos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CmbUsuario
            // 
            this.CmbUsuario.FormattingEnabled = true;
            this.CmbUsuario.Location = new System.Drawing.Point(51, 186);
            this.CmbUsuario.Name = "CmbUsuario";
            this.CmbUsuario.Size = new System.Drawing.Size(162, 24);
            this.CmbUsuario.TabIndex = 7;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(51, 97);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(162, 24);
            this.cmbMaterial.TabIndex = 6;
            // 
            // DgvPrestamos
            // 
            this.DgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPrestamos.Location = new System.Drawing.Point(276, 68);
            this.DgvPrestamos.Name = "DgvPrestamos";
            this.DgvPrestamos.RowHeadersWidth = 51;
            this.DgvPrestamos.RowTemplate.Height = 24;
            this.DgvPrestamos.Size = new System.Drawing.Size(619, 262);
            this.DgvPrestamos.TabIndex = 5;
            // 
            // BtnDevolver
            // 
            this.BtnDevolver.Location = new System.Drawing.Point(51, 300);
            this.BtnDevolver.Name = "BtnDevolver";
            this.BtnDevolver.Size = new System.Drawing.Size(162, 30);
            this.BtnDevolver.TabIndex = 4;
            this.BtnDevolver.Text = "Devolver";
            this.BtnDevolver.UseVisualStyleBackColor = true;
            this.BtnDevolver.Click += new System.EventHandler(this.BtnDevolver_Click);
            // 
            // BtnPrestar
            // 
            this.BtnPrestar.Location = new System.Drawing.Point(51, 242);
            this.BtnPrestar.Name = "BtnPrestar";
            this.BtnPrestar.Size = new System.Drawing.Size(162, 30);
            this.BtnPrestar.TabIndex = 3;
            this.BtnPrestar.Text = "Prestar";
            this.BtnPrestar.UseVisualStyleBackColor = true;
            this.BtnPrestar.Click += new System.EventHandler(this.BtnPrestar_Click);
            // 
            // LblUsuario1
            // 
            this.LblUsuario1.AutoSize = true;
            this.LblUsuario1.Location = new System.Drawing.Point(48, 142);
            this.LblUsuario1.Name = "LblUsuario1";
            this.LblUsuario1.Size = new System.Drawing.Size(108, 16);
            this.LblUsuario1.TabIndex = 2;
            this.LblUsuario1.Text = "Lista de usuarios";
            // 
            // LblMaterial
            // 
            this.LblMaterial.AutoSize = true;
            this.LblMaterial.Location = new System.Drawing.Point(48, 54);
            this.LblMaterial.Name = "LblMaterial";
            this.LblMaterial.Size = new System.Drawing.Size(132, 16);
            this.LblMaterial.TabIndex = 1;
            this.LblMaterial.Text = "Lista de Disponibles ";
            // 
            // LblPrestamo
            // 
            this.LblPrestamo.AutoSize = true;
            this.LblPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrestamo.Location = new System.Drawing.Point(375, 17);
            this.LblPrestamo.Name = "LblPrestamo";
            this.LblPrestamo.Size = new System.Drawing.Size(315, 32);
            this.LblPrestamo.TabIndex = 0;
            this.LblPrestamo.Text = "Control de Prestamos ";
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(310, 268);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(271, 66);
            this.BtnEditar.TabIndex = 7;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(597, 268);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(304, 66);
            this.BtnEliminar.TabIndex = 8;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.tabBiblioteca);
            this.Name = "FrmUsuarios";
            this.Text = "BiblioUser";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.tabBiblioteca.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsuarios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrestamos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBiblioteca;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnAgregarUsuario;
        private System.Windows.Forms.TextBox TxtCarnetUsuario;
        private System.Windows.Forms.TextBox TxtNombreUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblNombreUsuario;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.DataGridView DgvUsuarios;
        private System.Windows.Forms.Label LblUsuario1;
        private System.Windows.Forms.Label LblMaterial;
        private System.Windows.Forms.Label LblPrestamo;
        private System.Windows.Forms.ComboBox CmbUsuario;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.DataGridView DgvPrestamos;
        private System.Windows.Forms.Button BtnDevolver;
        private System.Windows.Forms.Button BtnPrestar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnEditar;
    }
}

