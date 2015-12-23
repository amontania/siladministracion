namespace SilAdministracion
{
    partial class frmItemCombo
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
            this.txtIdOperacion = new System.Windows.Forms.TextBox();
            this.txtIdTransaccion = new System.Windows.Forms.TextBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.cboISBN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblModoStock = new System.Windows.Forms.Label();
            this.btnAceptarCombo = new System.Windows.Forms.Button();
            this.btnCancelarCombo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdOperacion
            // 
            this.txtIdOperacion.Location = new System.Drawing.Point(50, 9);
            this.txtIdOperacion.Name = "txtIdOperacion";
            this.txtIdOperacion.Size = new System.Drawing.Size(25, 20);
            this.txtIdOperacion.TabIndex = 67;
            this.txtIdOperacion.Visible = false;
            // 
            // txtIdTransaccion
            // 
            this.txtIdTransaccion.Location = new System.Drawing.Point(23, 9);
            this.txtIdTransaccion.Name = "txtIdTransaccion";
            this.txtIdTransaccion.Size = new System.Drawing.Size(25, 20);
            this.txtIdTransaccion.TabIndex = 66;
            this.txtIdTransaccion.Visible = false;
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(100, 93);
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
            this.numCantidad.TabIndex = 60;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numCantidad_KeyPress);
            // 
            // cboISBN
            // 
            this.cboISBN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboISBN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboISBN.FormattingEnabled = true;
            this.cboISBN.Location = new System.Drawing.Point(100, 55);
            this.cboISBN.Name = "cboISBN";
            this.cboISBN.Size = new System.Drawing.Size(328, 21);
            this.cboISBN.TabIndex = 59;
            this.cboISBN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboISBN_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Cantidad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "ISBN :";
            // 
            // lblModoStock
            // 
            this.lblModoStock.AutoSize = true;
            this.lblModoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModoStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblModoStock.Location = new System.Drawing.Point(96, 9);
            this.lblModoStock.Name = "lblModoStock";
            this.lblModoStock.Size = new System.Drawing.Size(138, 24);
            this.lblModoStock.TabIndex = 63;
            this.lblModoStock.Text = "Agregando ...";
            // 
            // btnAceptarCombo
            // 
            this.btnAceptarCombo.Image = global::Imagenes.Resources.save;
            this.btnAceptarCombo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarCombo.Location = new System.Drawing.Point(98, 137);
            this.btnAceptarCombo.Name = "btnAceptarCombo";
            this.btnAceptarCombo.Size = new System.Drawing.Size(91, 33);
            this.btnAceptarCombo.TabIndex = 61;
            this.btnAceptarCombo.Text = "&Aceptar";
            this.btnAceptarCombo.UseVisualStyleBackColor = true;
            this.btnAceptarCombo.Click += new System.EventHandler(this.btnAceptarCombo_Click);
            // 
            // btnCancelarCombo
            // 
            this.btnCancelarCombo.Image = global::Imagenes.Resources.dbcancel;
            this.btnCancelarCombo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarCombo.Location = new System.Drawing.Point(208, 137);
            this.btnCancelarCombo.Name = "btnCancelarCombo";
            this.btnCancelarCombo.Size = new System.Drawing.Size(91, 33);
            this.btnCancelarCombo.TabIndex = 62;
            this.btnCancelarCombo.Text = "&Cancelar";
            this.btnCancelarCombo.UseVisualStyleBackColor = true;
            this.btnCancelarCombo.Click += new System.EventHandler(this.btnCancelarCombo_Click);
            // 
            // frmItemCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 186);
            this.Controls.Add(this.txtIdOperacion);
            this.Controls.Add(this.txtIdTransaccion);
            this.Controls.Add(this.btnAceptarCombo);
            this.Controls.Add(this.btnCancelarCombo);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.cboISBN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblModoStock);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemCombo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Combo";
            this.Load += new System.EventHandler(this.frmItemCombo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdOperacion;
        private System.Windows.Forms.TextBox txtIdTransaccion;
        private System.Windows.Forms.Button btnAceptarCombo;
        private System.Windows.Forms.Button btnCancelarCombo;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.ComboBox cboISBN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblModoStock;
    }
}