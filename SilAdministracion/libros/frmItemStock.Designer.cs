namespace SilAdministracion
{
    partial class frmItemStock
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
            this.lblModoStock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboISBN = new System.Windows.Forms.ComboBox();
            this.txtPrecioDolar = new System.Windows.Forms.TextBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtIdTransaccion = new System.Windows.Forms.TextBox();
            this.txtIdOperacion = new System.Windows.Forms.TextBox();
            this.btnAgregarISBN = new System.Windows.Forms.Button();
            this.btnAceptarStock = new System.Windows.Forms.Button();
            this.btnCancelarStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModoStock
            // 
            this.lblModoStock.AutoSize = true;
            this.lblModoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModoStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblModoStock.Location = new System.Drawing.Point(86, 9);
            this.lblModoStock.Name = "lblModoStock";
            this.lblModoStock.Size = new System.Drawing.Size(138, 24);
            this.lblModoStock.TabIndex = 45;
            this.lblModoStock.Text = "Agregando ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "ISBN :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Cantidad :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Precio U$ :";
            // 
            // cboISBN
            // 
            this.cboISBN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboISBN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboISBN.FormattingEnabled = true;
            this.cboISBN.Location = new System.Drawing.Point(90, 55);
            this.cboISBN.Name = "cboISBN";
            this.cboISBN.Size = new System.Drawing.Size(330, 21);
            this.cboISBN.TabIndex = 0;
            this.cboISBN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboISBN_KeyPress);
            // 
            // txtPrecioDolar
            // 
            this.txtPrecioDolar.Location = new System.Drawing.Point(90, 130);
            this.txtPrecioDolar.Name = "txtPrecioDolar";
            this.txtPrecioDolar.Size = new System.Drawing.Size(144, 20);
            this.txtPrecioDolar.TabIndex = 2;
            this.txtPrecioDolar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioDolar_KeyPress);
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(90, 93);
            this.numCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(120, 20);
            this.numCantidad.TabIndex = 1;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numCantidad_KeyPress);
            // 
            // txtIdTransaccion
            // 
            this.txtIdTransaccion.Location = new System.Drawing.Point(13, 9);
            this.txtIdTransaccion.Name = "txtIdTransaccion";
            this.txtIdTransaccion.Size = new System.Drawing.Size(25, 20);
            this.txtIdTransaccion.TabIndex = 57;
            this.txtIdTransaccion.Visible = false;
            // 
            // txtIdOperacion
            // 
            this.txtIdOperacion.Location = new System.Drawing.Point(40, 9);
            this.txtIdOperacion.Name = "txtIdOperacion";
            this.txtIdOperacion.Size = new System.Drawing.Size(25, 20);
            this.txtIdOperacion.TabIndex = 58;
            this.txtIdOperacion.Visible = false;
            // 
            // btnAgregarISBN
            // 
            this.btnAgregarISBN.Image = global::Imagenes.Resources.filenew3;
            this.btnAgregarISBN.Location = new System.Drawing.Point(427, 52);
            this.btnAgregarISBN.Name = "btnAgregarISBN";
            this.btnAgregarISBN.Size = new System.Drawing.Size(29, 23);
            this.btnAgregarISBN.TabIndex = 59;
            this.btnAgregarISBN.UseVisualStyleBackColor = true;
            this.btnAgregarISBN.Click += new System.EventHandler(this.btnAgregarISBN_Click);
            // 
            // btnAceptarStock
            // 
            this.btnAceptarStock.Image = global::Imagenes.Resources.save;
            this.btnAceptarStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarStock.Location = new System.Drawing.Point(90, 178);
            this.btnAceptarStock.Name = "btnAceptarStock";
            this.btnAceptarStock.Size = new System.Drawing.Size(91, 33);
            this.btnAceptarStock.TabIndex = 3;
            this.btnAceptarStock.Text = "&Aceptar";
            this.btnAceptarStock.UseVisualStyleBackColor = true;
            this.btnAceptarStock.Click += new System.EventHandler(this.btnAceptarStock_Click);
            // 
            // btnCancelarStock
            // 
            this.btnCancelarStock.Image = global::Imagenes.Resources.dbcancel;
            this.btnCancelarStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarStock.Location = new System.Drawing.Point(200, 178);
            this.btnCancelarStock.Name = "btnCancelarStock";
            this.btnCancelarStock.Size = new System.Drawing.Size(91, 33);
            this.btnCancelarStock.TabIndex = 5;
            this.btnCancelarStock.Text = "&Cancelar";
            this.btnCancelarStock.UseVisualStyleBackColor = true;
            this.btnCancelarStock.Click += new System.EventHandler(this.btnCancelarStock_Click);
            // 
            // frmItemStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 239);
            this.Controls.Add(this.btnAgregarISBN);
            this.Controls.Add(this.txtIdOperacion);
            this.Controls.Add(this.txtIdTransaccion);
            this.Controls.Add(this.btnAceptarStock);
            this.Controls.Add(this.btnCancelarStock);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.txtPrecioDolar);
            this.Controls.Add(this.cboISBN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblModoStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Libros ::";
            this.Load += new System.EventHandler(this.frmItemStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModoStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboISBN;
        private System.Windows.Forms.TextBox txtPrecioDolar;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAceptarStock;
        private System.Windows.Forms.Button btnCancelarStock;
        private System.Windows.Forms.TextBox txtIdTransaccion;
        private System.Windows.Forms.TextBox txtIdOperacion;
        private System.Windows.Forms.Button btnAgregarISBN;
    }
}