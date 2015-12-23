namespace SilAdministracion
{
    partial class frmBuscarResponsable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label1 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.DGPadres = new System.Windows.Forms.DataGridView();
            this.IdResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdResponsable = new System.Windows.Forms.TextBox();
            this.DGHermanos = new System.Windows.Forms.DataGridView();
            this.IdAlumno1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMatricula1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradoCurso1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGPadres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGHermanos)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(25, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(213, 13);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "Escriba Nombre o Apellido del Responsable";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBuscar.Location = new System.Drawing.Point(28, 46);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(375, 20);
            this.tbBuscar.TabIndex = 27;
            this.tbBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBuscar_KeyDown);
            // 
            // DGPadres
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DGPadres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGPadres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGPadres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGPadres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdResponsable,
            this.Nombre,
            this.Cedula});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGPadres.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGPadres.Location = new System.Drawing.Point(28, 89);
            this.DGPadres.MultiSelect = false;
            this.DGPadres.Name = "DGPadres";
            this.DGPadres.ReadOnly = true;
            this.DGPadres.Size = new System.Drawing.Size(389, 213);
            this.DGPadres.TabIndex = 28;
            this.DGPadres.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGPadres_CellDoubleClick);
            this.DGPadres.Click += new System.EventHandler(this.DGPadres_Click);
            this.DGPadres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGPadres_KeyDown);
            this.DGPadres.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DGPadres_KeyUp);
            // 
            // IdResponsable
            // 
            this.IdResponsable.DataPropertyName = "IdResponsable";
            this.IdResponsable.HeaderText = "IdResponsable";
            this.IdResponsable.Name = "IdResponsable";
            this.IdResponsable.ReadOnly = true;
            this.IdResponsable.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 235;
            // 
            // Cedula
            // 
            this.Cedula.DataPropertyName = "ci";
            this.Cedula.HeaderText = "Cedula";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Width = 80;
            // 
            // txtIdResponsable
            // 
            this.txtIdResponsable.Location = new System.Drawing.Point(322, 12);
            this.txtIdResponsable.Name = "txtIdResponsable";
            this.txtIdResponsable.Size = new System.Drawing.Size(81, 20);
            this.txtIdResponsable.TabIndex = 30;
            this.txtIdResponsable.Visible = false;
            // 
            // DGHermanos
            // 
            this.DGHermanos.AllowUserToAddRows = false;
            this.DGHermanos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.DGHermanos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGHermanos.CausesValidation = false;
            this.DGHermanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGHermanos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAlumno1,
            this.IdMatricula1,
            this.Matricula1,
            this.Nombre1,
            this.GradoCurso1});
            this.DGHermanos.Location = new System.Drawing.Point(12, 323);
            this.DGHermanos.MultiSelect = false;
            this.DGHermanos.Name = "DGHermanos";
            this.DGHermanos.ReadOnly = true;
            this.DGHermanos.RowHeadersVisible = false;
            this.DGHermanos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGHermanos.Size = new System.Drawing.Size(419, 76);
            this.DGHermanos.TabIndex = 31;
            // 
            // IdAlumno1
            // 
            this.IdAlumno1.DataPropertyName = "IdAlumno";
            this.IdAlumno1.HeaderText = "IdAlumno1";
            this.IdAlumno1.Name = "IdAlumno1";
            this.IdAlumno1.ReadOnly = true;
            this.IdAlumno1.Visible = false;
            // 
            // IdMatricula1
            // 
            this.IdMatricula1.DataPropertyName = "IdMatricula";
            this.IdMatricula1.HeaderText = "IdMatricula1";
            this.IdMatricula1.Name = "IdMatricula1";
            this.IdMatricula1.ReadOnly = true;
            this.IdMatricula1.Visible = false;
            this.IdMatricula1.Width = 60;
            // 
            // Matricula1
            // 
            this.Matricula1.DataPropertyName = "Matricula";
            this.Matricula1.HeaderText = "Matricula";
            this.Matricula1.Name = "Matricula1";
            this.Matricula1.ReadOnly = true;
            this.Matricula1.Width = 60;
            // 
            // Nombre1
            // 
            this.Nombre1.DataPropertyName = "Nombre";
            this.Nombre1.HeaderText = "Nombre";
            this.Nombre1.Name = "Nombre1";
            this.Nombre1.ReadOnly = true;
            this.Nombre1.Width = 200;
            // 
            // GradoCurso1
            // 
            this.GradoCurso1.DataPropertyName = "Curso/Grado";
            this.GradoCurso1.HeaderText = "GradoCurso";
            this.GradoCurso1.Name = "GradoCurso1";
            this.GradoCurso1.ReadOnly = true;
            this.GradoCurso1.Width = 120;
            // 
            // frmBuscarResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 411);
            this.Controls.Add(this.DGHermanos);
            this.Controls.Add(this.txtIdResponsable);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.DGPadres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarResponsable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Responsable";
            this.Load += new System.EventHandler(this.frmBuscarResponsable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGPadres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGHermanos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox tbBuscar;
        internal System.Windows.Forms.DataGridView DGPadres;
        private System.Windows.Forms.TextBox txtIdResponsable;
        private System.Windows.Forms.DataGridView DGHermanos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAlumno1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMatricula1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradoCurso1;
    }
}