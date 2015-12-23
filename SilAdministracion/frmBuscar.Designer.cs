namespace SilAdministracion
{
    partial class frmBuscar
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
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.DGAlumno = new System.Windows.Forms.DataGridView();
            this.IdAlumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CursoGrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnoLectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtIdAlumno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Red;
            this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label9.Location = new System.Drawing.Point(417, 99);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(33, 19);
            this.Label9.TabIndex = 22;
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.LimeGreen;
            this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label8.Location = new System.Drawing.Point(417, 69);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(33, 19);
            this.Label8.TabIndex = 21;
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.LightBlue;
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label7.Location = new System.Drawing.Point(417, 39);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(33, 19);
            this.Label7.TabIndex = 20;
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Location = new System.Drawing.Point(417, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(33, 19);
            this.Label3.TabIndex = 19;
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Location = new System.Drawing.Point(452, 99);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(123, 19);
            this.Label6.TabIndex = 18;
            this.Label6.Text = "Ex - Alumnos";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Location = new System.Drawing.Point(452, 69);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(123, 19);
            this.Label5.TabIndex = 17;
            this.Label5.Text = "Pre - Matriculados";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Location = new System.Drawing.Point(452, 39);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(123, 19);
            this.Label4.TabIndex = 16;
            this.Label4.Text = "Matriculados Inactivos";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Location = new System.Drawing.Point(452, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(123, 19);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Matriculados Activos";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 45);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(238, 13);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "Escriba Matricula , Nombre o Apellido del Alumno";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBuscar.Location = new System.Drawing.Point(12, 81);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(375, 20);
            this.tbBuscar.TabIndex = 24;
            this.tbBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBuscar_KeyDown);
            // 
            // DGAlumno
            // 
            this.DGAlumno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGAlumno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAlumno,
            this.IdMatricula,
            this.Matricula,
            this.Nombre,
            this.CursoGrado,
            this.Tip,
            this.Referencia,
            this.AnoLectivo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGAlumno.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGAlumno.Location = new System.Drawing.Point(12, 132);
            this.DGAlumno.MultiSelect = false;
            this.DGAlumno.Name = "DGAlumno";
            this.DGAlumno.ReadOnly = true;
            this.DGAlumno.Size = new System.Drawing.Size(563, 243);
            this.DGAlumno.TabIndex = 25;
            this.DGAlumno.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAlumno_CellDoubleClick);
            this.DGAlumno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGAlumno_KeyDown);
            // 
            // IdAlumno
            // 
            this.IdAlumno.DataPropertyName = "IdAlumno";
            this.IdAlumno.HeaderText = "IdAlumno";
            this.IdAlumno.Name = "IdAlumno";
            this.IdAlumno.ReadOnly = true;
            this.IdAlumno.Visible = false;
            // 
            // IdMatricula
            // 
            this.IdMatricula.DataPropertyName = "IdMatricula";
            this.IdMatricula.HeaderText = "IdMatricula";
            this.IdMatricula.Name = "IdMatricula";
            this.IdMatricula.ReadOnly = true;
            this.IdMatricula.Visible = false;
            // 
            // Matricula
            // 
            this.Matricula.DataPropertyName = "Matricula";
            this.Matricula.HeaderText = "Matricula";
            this.Matricula.Name = "Matricula";
            this.Matricula.ReadOnly = true;
            this.Matricula.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Matricula.Width = 67;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 235;
            // 
            // CursoGrado
            // 
            this.CursoGrado.DataPropertyName = "Curso/Grado";
            this.CursoGrado.HeaderText = "Curso/Grado";
            this.CursoGrado.Name = "CursoGrado";
            this.CursoGrado.ReadOnly = true;
            // 
            // Tip
            // 
            this.Tip.DataPropertyName = "Tip";
            this.Tip.HeaderText = "Tip";
            this.Tip.Name = "Tip";
            this.Tip.ReadOnly = true;
            this.Tip.Visible = false;
            // 
            // Referencia
            // 
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            this.Referencia.Width = 65;
            // 
            // AnoLectivo
            // 
            this.AnoLectivo.DataPropertyName = "AnoLectivo";
            this.AnoLectivo.HeaderText = "AnoLectivo";
            this.AnoLectivo.Name = "AnoLectivo";
            this.AnoLectivo.ReadOnly = true;
            this.AnoLectivo.Visible = false;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(15, 9);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(81, 20);
            this.txtMatricula.TabIndex = 26;
            this.txtMatricula.Visible = false;
            // 
            // txtIdAlumno
            // 
            this.txtIdAlumno.Location = new System.Drawing.Point(169, 9);
            this.txtIdAlumno.Name = "txtIdAlumno";
            this.txtIdAlumno.Size = new System.Drawing.Size(81, 20);
            this.txtIdAlumno.TabIndex = 27;
            this.txtIdAlumno.Visible = false;
            // 
            // frmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 412);
            this.Controls.Add(this.txtIdAlumno);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.DGAlumno);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Alumno";
            this.Load += new System.EventHandler(this.frmBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGAlumno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox tbBuscar;
        internal System.Windows.Forms.DataGridView DGAlumno;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtIdAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CursoGrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnoLectivo;
    }
}