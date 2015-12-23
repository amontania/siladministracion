namespace SilAdministracion
{
    partial class frmOtroIngresos
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rdCI1 = new System.Windows.Forms.RadioButton();
            this.rdCI2 = new System.Windows.Forms.RadioButton();
            this.lblTipoIngreso1 = new System.Windows.Forms.Label();
            this.lblTipoIngreso2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(47, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 16);
            this.lblTitulo.TabIndex = 20;
            this.lblTitulo.Text = "Cuota de Ingreso";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Image = global::Imagenes.Resources.save;
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(174, 112);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(85, 33);
            this.BtnAceptar.TabIndex = 22;
            this.BtnAceptar.Text = "Grabar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Imagenes.Resources.dbcancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(71, 112);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 33);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rdCI1
            // 
            this.rdCI1.AutoSize = true;
            this.rdCI1.Location = new System.Drawing.Point(34, 41);
            this.rdCI1.Name = "rdCI1";
            this.rdCI1.Size = new System.Drawing.Size(212, 17);
            this.rdCI1.TabIndex = 23;
            this.rdCI1.TabStop = true;
            this.rdCI1.Text = "Cuota de Ingreso Vinculante 500.00 U$";
            this.rdCI1.UseVisualStyleBackColor = true;
            // 
            // rdCI2
            // 
            this.rdCI2.AutoSize = true;
            this.rdCI2.Location = new System.Drawing.Point(34, 74);
            this.rdCI2.Name = "rdCI2";
            this.rdCI2.Size = new System.Drawing.Size(235, 17);
            this.rdCI2.TabIndex = 24;
            this.rdCI2.TabStop = true;
            this.rdCI2.Text = "Cuota de Ingreso No Vinculante 1000.00 U$";
            this.rdCI2.UseVisualStyleBackColor = true;
            // 
            // lblTipoIngreso1
            // 
            this.lblTipoIngreso1.AutoSize = true;
            this.lblTipoIngreso1.Location = new System.Drawing.Point(284, 47);
            this.lblTipoIngreso1.Name = "lblTipoIngreso1";
            this.lblTipoIngreso1.Size = new System.Drawing.Size(38, 13);
            this.lblTipoIngreso1.TabIndex = 25;
            this.lblTipoIngreso1.Text = "lblTipo";
            this.lblTipoIngreso1.Visible = false;
            // 
            // lblTipoIngreso2
            // 
            this.lblTipoIngreso2.AutoSize = true;
            this.lblTipoIngreso2.Location = new System.Drawing.Point(284, 74);
            this.lblTipoIngreso2.Name = "lblTipoIngreso2";
            this.lblTipoIngreso2.Size = new System.Drawing.Size(38, 13);
            this.lblTipoIngreso2.TabIndex = 26;
            this.lblTipoIngreso2.Text = "lblTipo";
            this.lblTipoIngreso2.Visible = false;
            // 
            // frmOtroIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 164);
            this.Controls.Add(this.lblTipoIngreso2);
            this.Controls.Add(this.lblTipoIngreso1);
            this.Controls.Add(this.rdCI2);
            this.Controls.Add(this.rdCI1);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOtroIngresos";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuota de Ingreso";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmOtroIngresos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton rdCI1;
        private System.Windows.Forms.RadioButton rdCI2;
        private System.Windows.Forms.Label lblTipoIngreso1;
        private System.Windows.Forms.Label lblTipoIngreso2;
    }
}