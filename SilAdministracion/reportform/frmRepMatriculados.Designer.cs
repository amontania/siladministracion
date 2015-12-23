namespace SilAdministracion
{
    partial class frmRepMatriculados
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
            this.btnReporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.chkNuevos = new System.Windows.Forms.CheckBox();
            this.chkMat = new System.Windows.Forms.CheckBox();
            this.numAnho = new System.Windows.Forms.NumericUpDown();
            this.chkRespDetalles = new System.Windows.Forms.CheckBox();
            this.chkResponsables = new System.Windows.Forms.CheckBox();
            this.chkAlumnos = new System.Windows.Forms.CheckBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGradoCurso = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSeccion = new System.Windows.Forms.ComboBox();
            this.cboOrden = new System.Windows.Forms.ComboBox();
            this.cboDivision = new System.Windows.Forms.ComboBox();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkHermanos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAnho)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.YellowGreen;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Location = new System.Drawing.Point(841, 44);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(98, 30);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = ":: Reporte ::";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Año :";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(5, 96);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(995, 323);
            this.crystalReportViewer1.TabIndex = 5;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // chkNuevos
            // 
            this.chkNuevos.AutoSize = true;
            this.chkNuevos.Location = new System.Drawing.Point(616, 49);
            this.chkNuevos.Name = "chkNuevos";
            this.chkNuevos.Size = new System.Drawing.Size(106, 17);
            this.chkNuevos.TabIndex = 503;
            this.chkNuevos.Text = "Alumnos Nuevos";
            this.chkNuevos.UseVisualStyleBackColor = true;
            this.chkNuevos.CheckedChanged += new System.EventHandler(this.chkNuevos_CheckedChanged);
            // 
            // chkMat
            // 
            this.chkMat.AutoSize = true;
            this.chkMat.Checked = true;
            this.chkMat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMat.Location = new System.Drawing.Point(211, 49);
            this.chkMat.Name = "chkMat";
            this.chkMat.Size = new System.Drawing.Size(92, 17);
            this.chkMat.TabIndex = 504;
            this.chkMat.Text = "Mat. Pagadas";
            this.chkMat.UseVisualStyleBackColor = true;
            // 
            // numAnho
            // 
            this.numAnho.Location = new System.Drawing.Point(71, 49);
            this.numAnho.Name = "numAnho";
            this.numAnho.Size = new System.Drawing.Size(72, 20);
            this.numAnho.TabIndex = 505;
            // 
            // chkRespDetalles
            // 
            this.chkRespDetalles.AutoSize = true;
            this.chkRespDetalles.Location = new System.Drawing.Point(508, 49);
            this.chkRespDetalles.Name = "chkRespDetalles";
            this.chkRespDetalles.Size = new System.Drawing.Size(107, 17);
            this.chkRespDetalles.TabIndex = 508;
            this.chkRespDetalles.Text = "Respons. Detalle";
            this.chkRespDetalles.UseVisualStyleBackColor = true;
            this.chkRespDetalles.CheckedChanged += new System.EventHandler(this.chkRespDetalles_CheckedChanged);
            // 
            // chkResponsables
            // 
            this.chkResponsables.AutoSize = true;
            this.chkResponsables.Location = new System.Drawing.Point(402, 49);
            this.chkResponsables.Name = "chkResponsables";
            this.chkResponsables.Size = new System.Drawing.Size(93, 17);
            this.chkResponsables.TabIndex = 507;
            this.chkResponsables.Text = "Responsables";
            this.chkResponsables.UseVisualStyleBackColor = true;
            this.chkResponsables.CheckedChanged += new System.EventHandler(this.chkResponsables_CheckedChanged);
            // 
            // chkAlumnos
            // 
            this.chkAlumnos.AutoSize = true;
            this.chkAlumnos.Location = new System.Drawing.Point(323, 49);
            this.chkAlumnos.Name = "chkAlumnos";
            this.chkAlumnos.Size = new System.Drawing.Size(66, 17);
            this.chkAlumnos.TabIndex = 506;
            this.chkAlumnos.Text = "Alumnos";
            this.chkAlumnos.UseVisualStyleBackColor = true;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Todos",
            "Activos",
            "Inactivos"});
            this.cbEstado.Location = new System.Drawing.Point(71, 12);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(72, 21);
            this.cbEstado.TabIndex = 509;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 510;
            this.label2.Text = "Estado :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 512;
            this.label3.Text = "Grado/ Curso :";
            // 
            // cboGradoCurso
            // 
            this.cboGradoCurso.FormattingEnabled = true;
            this.cboGradoCurso.Location = new System.Drawing.Point(245, 12);
            this.cboGradoCurso.Name = "cboGradoCurso";
            this.cboGradoCurso.Size = new System.Drawing.Size(91, 21);
            this.cboGradoCurso.TabIndex = 511;
            this.cboGradoCurso.SelectedIndexChanged += new System.EventHandler(this.cboGradoCurso_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 514;
            this.label4.Text = "Sección :";
            // 
            // cboSeccion
            // 
            this.cboSeccion.FormattingEnabled = true;
            this.cboSeccion.Location = new System.Drawing.Point(405, 12);
            this.cboSeccion.Name = "cboSeccion";
            this.cboSeccion.Size = new System.Drawing.Size(91, 21);
            this.cboSeccion.TabIndex = 513;
            this.cboSeccion.SelectedIndexChanged += new System.EventHandler(this.cboSeccion_SelectedIndexChanged);
            // 
            // cboOrden
            // 
            this.cboOrden.FormattingEnabled = true;
            this.cboOrden.Items.AddRange(new object[] {
            "Apellido",
            "Matricula"});
            this.cboOrden.Location = new System.Drawing.Point(862, 12);
            this.cboOrden.Name = "cboOrden";
            this.cboOrden.Size = new System.Drawing.Size(77, 21);
            this.cboOrden.TabIndex = 517;
            // 
            // cboDivision
            // 
            this.cboDivision.FormattingEnabled = true;
            this.cboDivision.Location = new System.Drawing.Point(715, 12);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Size = new System.Drawing.Size(83, 21);
            this.cboDivision.TabIndex = 516;
            // 
            // cboNivel
            // 
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(545, 12);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(108, 21);
            this.cboNivel.TabIndex = 515;
            this.cboNivel.SelectedIndexChanged += new System.EventHandler(this.cboNivel_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 518;
            this.label5.Text = "Nivel :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(659, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 519;
            this.label6.Text = "División :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(814, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 520;
            this.label7.Text = "Orden :";
            // 
            // chkHermanos
            // 
            this.chkHermanos.AutoSize = true;
            this.chkHermanos.Location = new System.Drawing.Point(728, 50);
            this.chkHermanos.Name = "chkHermanos";
            this.chkHermanos.Size = new System.Drawing.Size(74, 17);
            this.chkHermanos.TabIndex = 521;
            this.chkHermanos.Text = "Hermanos";
            this.chkHermanos.UseVisualStyleBackColor = true;
            // 
            // frmRepMatriculados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 431);
            this.Controls.Add(this.chkHermanos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboOrden);
            this.Controls.Add(this.cboDivision);
            this.Controls.Add(this.cboNivel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboSeccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboGradoCurso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.chkRespDetalles);
            this.Controls.Add(this.chkResponsables);
            this.Controls.Add(this.chkAlumnos);
            this.Controls.Add(this.numAnho);
            this.Controls.Add(this.chkMat);
            this.Controls.Add(this.chkNuevos);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReporte);
            this.Name = "frmRepMatriculados";
            this.Text = ":: Reporte Cantidad de Alumnos X Año ::";
            this.Load += new System.EventHandler(this.frmRepMatriculados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAnho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        internal System.Windows.Forms.CheckBox chkNuevos;
        internal System.Windows.Forms.CheckBox chkMat;
        private System.Windows.Forms.NumericUpDown numAnho;
        internal System.Windows.Forms.CheckBox chkRespDetalles;
        internal System.Windows.Forms.CheckBox chkResponsables;
        internal System.Windows.Forms.CheckBox chkAlumnos;
        internal System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cboGradoCurso;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboSeccion;
        internal System.Windows.Forms.ComboBox cboOrden;
        internal System.Windows.Forms.ComboBox cboDivision;
        internal System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.CheckBox chkHermanos;
    }
}