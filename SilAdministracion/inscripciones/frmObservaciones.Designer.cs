namespace SilAdministracion
{
    partial class frmObservaciones
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
            this.DGObservaciones = new System.Windows.Forms.DataGridView();
            this.label86 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label85 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.IdObservInOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fec1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fec2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGObservaciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGObservaciones
            // 
            this.DGObservaciones.AllowUserToAddRows = false;
            this.DGObservaciones.AllowUserToResizeRows = false;
            this.DGObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGObservaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdObservInOut,
            this.fec1,
            this.fec2,
            this.texto});
            this.DGObservaciones.Location = new System.Drawing.Point(12, 12);
            this.DGObservaciones.Name = "DGObservaciones";
            this.DGObservaciones.ReadOnly = true;
            this.DGObservaciones.Size = new System.Drawing.Size(526, 83);
            this.DGObservaciones.TabIndex = 0;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(236, 18);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(69, 13);
            this.label86.TabIndex = 12;
            this.label86.Text = "Fecha Salida";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(321, 11);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(99, 20);
            this.dtFechaFin.TabIndex = 13;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.Color.Transparent;
            this.label85.Location = new System.Drawing.Point(28, 18);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(75, 13);
            this.label85.TabIndex = 10;
            this.label85.Text = "Fecha Ingreso";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(112, 12);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(99, 20);
            this.dtFechaInicio.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Imagenes.Resources.dbcancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(136, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 33);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Image = global::Imagenes.Resources.save;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(239, 90);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(85, 33);
            this.BtnAceptar.TabIndex = 15;
            this.BtnAceptar.Text = "Grabar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(31, 64);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(404, 20);
            this.txtObservacion.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(190, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Observación";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtObservacion);
            this.panel1.Controls.Add(this.BtnAceptar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.label86);
            this.panel1.Controls.Add(this.dtFechaFin);
            this.panel1.Controls.Add(this.label85);
            this.panel1.Controls.Add(this.dtFechaInicio);
            this.panel1.Location = new System.Drawing.Point(52, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 133);
            this.panel1.TabIndex = 18;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(136, 47);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(255, 16);
            this.lblTitulo.TabIndex = 19;
            this.lblTitulo.Text = "Observaciones de Entrada o Salida";
            // 
            // IdObservInOut
            // 
            this.IdObservInOut.DataPropertyName = "IdObservInOut";
            this.IdObservInOut.HeaderText = "IdObservInOut";
            this.IdObservInOut.Name = "IdObservInOut";
            this.IdObservInOut.ReadOnly = true;
            this.IdObservInOut.Visible = false;
            // 
            // fec1
            // 
            this.fec1.DataPropertyName = "fec1";
            this.fec1.HeaderText = "Fecha Desde";
            this.fec1.Name = "fec1";
            this.fec1.ReadOnly = true;
            this.fec1.Width = 96;
            // 
            // fec2
            // 
            this.fec2.DataPropertyName = "fec2";
            this.fec2.HeaderText = "Fecha Hasta";
            this.fec2.Name = "fec2";
            this.fec2.ReadOnly = true;
            this.fec2.Width = 96;
            // 
            // texto
            // 
            this.texto.DataPropertyName = "texto";
            this.texto.HeaderText = "Observación";
            this.texto.Name = "texto";
            this.texto.ReadOnly = true;
            this.texto.Width = 260;
            // 
            // frmObservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 246);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.DGObservaciones);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmObservaciones";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Observaciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmObservaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGObservaciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGObservaciones;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdObservInOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn fec1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fec2;
        private System.Windows.Forms.DataGridViewTextBoxColumn texto;

    }
}