namespace SilAdministracion
{
    partial class frmSET
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
            this.label1 = new System.Windows.Forms.Label();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDV = new System.Windows.Forms.Button();
            this.txtDV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBuscarDV = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDenLegal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDVLegal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRucLegal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDenAgente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDVAgente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRucAgente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTimbrado = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSilFac = new System.Windows.Forms.TextBox();
            this.txtISILFact = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periodo a Informar :";
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(163, 43);
            this.numAno.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numAno.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.numAno.Name = "numAno";
            this.numAno.Size = new System.Drawing.Size(64, 20);
            this.numAno.TabIndex = 1;
            this.numAno.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(244, 42);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(121, 21);
            this.cmbMes.TabIndex = 2;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = global::Imagenes.Resources.tributaciones;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(231, 294);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(134, 41);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "::Generar::";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de Información :";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Libro Compra",
            "Libro Venta"});
            this.cmbTipo.Location = new System.Drawing.Point(163, 81);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(202, 21);
            this.cmbTipo.TabIndex = 5;
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Items.AddRange(new object[] {
            "Original",
            "Rectificativa"});
            this.cmbTipoReporte.Location = new System.Drawing.Point(163, 118);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(202, 21);
            this.cmbTipoReporte.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de Reporte :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(422, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 415);
            this.panel1.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox3.Controls.Add(this.btnDV);
            this.groupBox3.Controls.Add(this.txtDV);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtBuscarDV);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(23, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 105);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calcular Digito Verificador";
            // 
            // btnDV
            // 
            this.btnDV.Location = new System.Drawing.Point(110, 57);
            this.btnDV.Name = "btnDV";
            this.btnDV.Size = new System.Drawing.Size(97, 24);
            this.btnDV.TabIndex = 8;
            this.btnDV.Text = "Calcula DV";
            this.btnDV.UseVisualStyleBackColor = true;
            this.btnDV.Click += new System.EventHandler(this.btnDV_Click);
            // 
            // txtDV
            // 
            this.txtDV.Location = new System.Drawing.Point(379, 31);
            this.txtDV.Name = "txtDV";
            this.txtDV.Size = new System.Drawing.Size(46, 20);
            this.txtDV.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(351, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "DV";
            // 
            // txtBuscarDV
            // 
            this.txtBuscarDV.Location = new System.Drawing.Point(110, 31);
            this.txtBuscarDV.Name = "txtBuscarDV";
            this.txtBuscarDV.Size = new System.Drawing.Size(97, 20);
            this.txtBuscarDV.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "RUC";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox2.Controls.Add(this.txtDenLegal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDVLegal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtRucLegal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(23, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Representante Legal";
            // 
            // txtDenLegal
            // 
            this.txtDenLegal.Location = new System.Drawing.Point(110, 62);
            this.txtDenLegal.Name = "txtDenLegal";
            this.txtDenLegal.Size = new System.Drawing.Size(316, 20);
            this.txtDenLegal.TabIndex = 5;
            this.txtDenLegal.Text = "RIART DE MANZONI MARIA RAQUEL MARTA CONCEPCION";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Denominación";
            // 
            // txtDVLegal
            // 
            this.txtDVLegal.Location = new System.Drawing.Point(379, 25);
            this.txtDVLegal.Name = "txtDVLegal";
            this.txtDVLegal.Size = new System.Drawing.Size(46, 20);
            this.txtDVLegal.TabIndex = 3;
            this.txtDVLegal.Text = "7";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "DV";
            // 
            // txtRucLegal
            // 
            this.txtRucLegal.Location = new System.Drawing.Point(110, 25);
            this.txtRucLegal.Name = "txtRucLegal";
            this.txtRucLegal.Size = new System.Drawing.Size(97, 20);
            this.txtRucLegal.TabIndex = 1;
            this.txtRucLegal.Text = "378319";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "RUC";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox1.Controls.Add(this.txtDenAgente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDVAgente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRucAgente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(23, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agente de Información";
            // 
            // txtDenAgente
            // 
            this.txtDenAgente.Location = new System.Drawing.Point(110, 62);
            this.txtDenAgente.Name = "txtDenAgente";
            this.txtDenAgente.Size = new System.Drawing.Size(315, 20);
            this.txtDenAgente.TabIndex = 5;
            this.txtDenAgente.Text = " SAN IGNACIO DE LOYOLA SA (S.I.L.S.A.)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Denominación";
            // 
            // txtDVAgente
            // 
            this.txtDVAgente.Location = new System.Drawing.Point(379, 25);
            this.txtDVAgente.Name = "txtDVAgente";
            this.txtDVAgente.Size = new System.Drawing.Size(46, 20);
            this.txtDVAgente.TabIndex = 3;
            this.txtDVAgente.Text = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "DV";
            // 
            // txtRucAgente
            // 
            this.txtRucAgente.Location = new System.Drawing.Point(110, 25);
            this.txtRucAgente.Name = "txtRucAgente";
            this.txtRucAgente.Size = new System.Drawing.Size(97, 20);
            this.txtRucAgente.TabIndex = 1;
            this.txtRucAgente.Text = "80009107";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "RUC";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Nro Timbrado SIL/ISIL :";
            // 
            // txtTimbrado
            // 
            this.txtTimbrado.Location = new System.Drawing.Point(163, 152);
            this.txtTimbrado.Name = "txtTimbrado";
            this.txtTimbrado.Size = new System.Drawing.Size(202, 20);
            this.txtTimbrado.TabIndex = 11;
            this.txtTimbrado.Text = "10604649";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 195);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Comienzo Factura SIL :";
            // 
            // txtSilFac
            // 
            this.txtSilFac.Location = new System.Drawing.Point(163, 192);
            this.txtSilFac.Name = "txtSilFac";
            this.txtSilFac.Size = new System.Drawing.Size(202, 20);
            this.txtSilFac.TabIndex = 13;
            this.txtSilFac.Text = "001-001-";
            // 
            // txtISILFact
            // 
            this.txtISILFact.Location = new System.Drawing.Point(163, 229);
            this.txtISILFact.Name = "txtISILFact";
            this.txtISILFact.Size = new System.Drawing.Size(202, 20);
            this.txtISILFact.TabIndex = 15;
            this.txtISILFact.Text = "001-002-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 232);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Comienzo Factura ISIL :";
            // 
            // frmSET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 506);
            this.Controls.Add(this.txtISILFact);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSilFac);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTimbrado);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoReporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.numAno);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSET";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SET";
            this.Load += new System.EventHandler(this.frmSET_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDenLegal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDVLegal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRucLegal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDenAgente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDVAgente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRucAgente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDV;
        private System.Windows.Forms.TextBox txtDV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBuscarDV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTimbrado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSilFac;
        private System.Windows.Forms.TextBox txtISILFact;
        private System.Windows.Forms.Label label15;
    }
}