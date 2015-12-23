namespace SilAdministracion
{
    partial class frmISBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmISBN));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtISBN1 = new System.Windows.Forms.TextBox();
            this.lblModo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo2 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lbnISBN = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtISBN1);
            this.panel1.Controls.Add(this.lblModo);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.txtTitulo);
            this.panel1.Controls.Add(this.lblTitulo2);
            this.panel1.Controls.Add(this.txtISBN);
            this.panel1.Controls.Add(this.lbnISBN);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 203);
            this.panel1.TabIndex = 30;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtISBN1
            // 
            this.txtISBN1.Location = new System.Drawing.Point(5, 3);
            this.txtISBN1.Name = "txtISBN1";
            this.txtISBN1.Size = new System.Drawing.Size(35, 20);
            this.txtISBN1.TabIndex = 35;
            this.txtISBN1.Text = "0";
            this.txtISBN1.Visible = false;
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblModo.Location = new System.Drawing.Point(42, 13);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(138, 24);
            this.lblModo.TabIndex = 34;
            this.lblModo.Text = "Agregando ...";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(46, 153);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(91, 33);
            this.btnAceptar.TabIndex = 33;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(160, 153);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 33);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(46, 112);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(237, 20);
            this.txtTitulo.TabIndex = 31;
            this.txtTitulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitulo_KeyPress_1);
            // 
            // lblTitulo2
            // 
            this.lblTitulo2.AutoSize = true;
            this.lblTitulo2.Location = new System.Drawing.Point(1, 119);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(39, 13);
            this.lblTitulo2.TabIndex = 30;
            this.lblTitulo2.Text = "Titulo :";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(46, 64);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(161, 20);
            this.txtISBN.TabIndex = 29;
            this.txtISBN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtISBN_KeyPress);
            // 
            // lbnISBN
            // 
            this.lbnISBN.AutoSize = true;
            this.lbnISBN.Location = new System.Drawing.Point(2, 71);
            this.lbnISBN.Name = "lbnISBN";
            this.lbnISBN.Size = new System.Drawing.Size(38, 13);
            this.lbnISBN.TabIndex = 28;
            this.lbnISBN.Text = "ISBN :";
            // 
            // frmISBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 218);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmISBN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmISBN";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmISBN_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblTitulo2;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lbnISBN;
        private System.Windows.Forms.TextBox txtISBN1;
    }
}