namespace SilAdministracion
{
    partial class frmMovimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimiento));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdTransaccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.dataGridMovimiento = new System.Windows.Forms.DataGridView();
            this.lblAgregarLibro = new System.Windows.Forms.Label();
            this.cboLibros = new System.Windows.Forms.ComboBox();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAceptarCombo = new System.Windows.Forms.Button();
            this.btnCancelarCombo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.ISBNMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroEjemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Devolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMovimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transacción : ";
            // 
            // txtIdTransaccion
            // 
            this.txtIdTransaccion.Enabled = false;
            this.txtIdTransaccion.Location = new System.Drawing.Point(116, 45);
            this.txtIdTransaccion.Name = "txtIdTransaccion";
            this.txtIdTransaccion.Size = new System.Drawing.Size(38, 20);
            this.txtIdTransaccion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha :";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(413, 45);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(89, 20);
            this.dtFecha.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nro. Comprobante : ";
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Location = new System.Drawing.Point(280, 45);
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.Size = new System.Drawing.Size(72, 20);
            this.txtNroComprobante.TabIndex = 4;
            // 
            // dataGridMovimiento
            // 
            this.dataGridMovimiento.AllowUserToAddRows = false;
            this.dataGridMovimiento.AllowUserToDeleteRows = false;
            this.dataGridMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMovimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBNMov,
            this.CantidadMov,
            this.NroEjemplar,
            this.IdLibro,
            this.CantidadTotal,
            this.Alquiler,
            this.Devolucion,
            this.Venta,
            this.NroItem});
            this.dataGridMovimiento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridMovimiento.Location = new System.Drawing.Point(32, 108);
            this.dataGridMovimiento.MultiSelect = false;
            this.dataGridMovimiento.Name = "dataGridMovimiento";
            this.dataGridMovimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridMovimiento.Size = new System.Drawing.Size(647, 174);
            this.dataGridMovimiento.TabIndex = 9;
            this.dataGridMovimiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMovimiento_CellClick);
            this.dataGridMovimiento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMovimiento_CellEnter);
            this.dataGridMovimiento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridMovimiento_KeyUp);
            // 
            // lblAgregarLibro
            // 
            this.lblAgregarLibro.AutoSize = true;
            this.lblAgregarLibro.Location = new System.Drawing.Point(29, 285);
            this.lblAgregarLibro.Name = "lblAgregarLibro";
            this.lblAgregarLibro.Size = new System.Drawing.Size(102, 13);
            this.lblAgregarLibro.TabIndex = 10;
            this.lblAgregarLibro.Text = "Agregar Otro Libro ?";
            // 
            // cboLibros
            // 
            this.cboLibros.FormattingEnabled = true;
            this.cboLibros.Location = new System.Drawing.Point(32, 301);
            this.cboLibros.Name = "cboLibros";
            this.cboLibros.Size = new System.Drawing.Size(320, 21);
            this.cboLibros.TabIndex = 11;
            // 
            // lblAlumno
            // 
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumno.Location = new System.Drawing.Point(113, 9);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(51, 16);
            this.lblAlumno.TabIndex = 0;
            this.lblAlumno.Text = "label5";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(361, 301);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(52, 23);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAceptarCombo
            // 
            this.btnAceptarCombo.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptarCombo.Image")));
            this.btnAceptarCombo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarCombo.Location = new System.Drawing.Point(480, 329);
            this.btnAceptarCombo.Name = "btnAceptarCombo";
            this.btnAceptarCombo.Size = new System.Drawing.Size(91, 33);
            this.btnAceptarCombo.TabIndex = 12;
            this.btnAceptarCombo.Text = "&Aceptar";
            this.btnAceptarCombo.UseVisualStyleBackColor = true;
            this.btnAceptarCombo.Click += new System.EventHandler(this.btnAceptarCombo_Click);
            // 
            // btnCancelarCombo
            // 
            this.btnCancelarCombo.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarCombo.Image")));
            this.btnCancelarCombo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarCombo.Location = new System.Drawing.Point(588, 329);
            this.btnCancelarCombo.Name = "btnCancelarCombo";
            this.btnCancelarCombo.Size = new System.Drawing.Size(91, 33);
            this.btnCancelarCombo.TabIndex = 13;
            this.btnCancelarCombo.Text = "&Cancelar";
            this.btnCancelarCombo.UseVisualStyleBackColor = true;
            this.btnCancelarCombo.Click += new System.EventHandler(this.btnCancelarCombo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Observación : ";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(116, 77);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(563, 20);
            this.txtObservacion.TabIndex = 8;
            // 
            // ISBNMov
            // 
            this.ISBNMov.DataPropertyName = "ISBN";
            this.ISBNMov.HeaderText = "ISBN";
            this.ISBNMov.Name = "ISBNMov";
            this.ISBNMov.ReadOnly = true;
            this.ISBNMov.Width = 300;
            // 
            // CantidadMov
            // 
            this.CantidadMov.DataPropertyName = "Cantidad";
            this.CantidadMov.HeaderText = "Cantidad";
            this.CantidadMov.Name = "CantidadMov";
            this.CantidadMov.ReadOnly = true;
            this.CantidadMov.Width = 50;
            // 
            // NroEjemplar
            // 
            this.NroEjemplar.DataPropertyName = "NroEjemplar";
            this.NroEjemplar.HeaderText = "NroEjemplar";
            this.NroEjemplar.Name = "NroEjemplar";
            this.NroEjemplar.Width = 70;
            // 
            // IdLibro
            // 
            this.IdLibro.DataPropertyName = "IdLibro";
            this.IdLibro.HeaderText = "IdLibro";
            this.IdLibro.Name = "IdLibro";
            this.IdLibro.ReadOnly = true;
            this.IdLibro.Visible = false;
            // 
            // CantidadTotal
            // 
            this.CantidadTotal.DataPropertyName = "CantidadTotal";
            this.CantidadTotal.HeaderText = "CantidadTotal";
            this.CantidadTotal.Name = "CantidadTotal";
            this.CantidadTotal.ReadOnly = true;
            this.CantidadTotal.Visible = false;
            // 
            // Alquiler
            // 
            this.Alquiler.DataPropertyName = "Alquiler";
            this.Alquiler.HeaderText = "Alquiler";
            this.Alquiler.Name = "Alquiler";
            this.Alquiler.ReadOnly = true;
            this.Alquiler.Visible = false;
            // 
            // Devolucion
            // 
            this.Devolucion.DataPropertyName = "Devolucion";
            this.Devolucion.HeaderText = "Devolucion";
            this.Devolucion.Name = "Devolucion";
            this.Devolucion.ReadOnly = true;
            this.Devolucion.Visible = false;
            // 
            // Venta
            // 
            this.Venta.DataPropertyName = "Venta";
            this.Venta.HeaderText = "Venta";
            this.Venta.Name = "Venta";
            this.Venta.ReadOnly = true;
            this.Venta.Visible = false;
            // 
            // NroItem
            // 
            this.NroItem.DataPropertyName = "NroItem";
            this.NroItem.HeaderText = "NroItem";
            this.NroItem.Name = "NroItem";
            this.NroItem.ReadOnly = true;
            this.NroItem.Visible = false;
            // 
            // frmMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 374);
            this.ControlBox = false;
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAceptarCombo);
            this.Controls.Add(this.btnCancelarCombo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblAlumno);
            this.Controls.Add(this.cboLibros);
            this.Controls.Add(this.lblAgregarLibro);
            this.Controls.Add(this.dataGridMovimiento);
            this.Controls.Add(this.txtNroComprobante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdTransaccion);
            this.Controls.Add(this.label1);
            this.Name = "frmMovimiento";
            this.Text = "Movimiento de Libro";
            this.Load += new System.EventHandler(this.frmMovimiento_Load);
            this.Shown += new System.EventHandler(this.frmMovimiento_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMovimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdTransaccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroComprobante;
        public System.Windows.Forms.DataGridView dataGridMovimiento;
        private System.Windows.Forms.Label lblAgregarLibro;
        private System.Windows.Forms.ComboBox cboLibros;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAceptarCombo;
        private System.Windows.Forms.Button btnCancelarCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBNMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroEjemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Devolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroItem;
    }
}