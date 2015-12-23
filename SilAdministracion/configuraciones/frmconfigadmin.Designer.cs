namespace SilAdministracion
{
    partial class frmConfigAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTipoIngreso = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuAgregarCombo = new System.Windows.Forms.ToolStripButton();
            this.mnuEditarCombo = new System.Windows.Forms.ToolStripButton();
            this.mnuEliminarCombo = new System.Windows.Forms.ToolStripButton();
            this.mnuSalirCombo = new System.Windows.Forms.ToolStripButton();
            this.DGTipoIngreso = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabTipoIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGTipoIngreso)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabTipoIngreso);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1228, 622);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabTipoIngreso
            // 
            this.tabTipoIngreso.Controls.Add(this.DGTipoIngreso);
            this.tabTipoIngreso.Controls.Add(this.toolStrip1);
            this.tabTipoIngreso.Controls.Add(this.pictureBox3);
            this.tabTipoIngreso.Controls.Add(this.label3);
            this.tabTipoIngreso.Controls.Add(this.pictureBox4);
            this.tabTipoIngreso.Location = new System.Drawing.Point(4, 22);
            this.tabTipoIngreso.Name = "tabTipoIngreso";
            this.tabTipoIngreso.Padding = new System.Windows.Forms.Padding(3);
            this.tabTipoIngreso.Size = new System.Drawing.Size(1220, 596);
            this.tabTipoIngreso.TabIndex = 0;
            this.tabTipoIngreso.Text = "Tipo Ingreso";
            this.tabTipoIngreso.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1220, 596);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1214, 57);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.IndianRed;
            this.label3.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(253, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 32);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tipo  de Ingreso / Egreso";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(53, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgregarCombo,
            this.mnuEditarCombo,
            this.mnuEliminarCombo,
            this.mnuSalirCombo});
            this.toolStrip1.Location = new System.Drawing.Point(3, 60);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1214, 39);
            this.toolStrip1.TabIndex = 32;
            this.toolStrip1.Text = "ToolStrip1";
            // 
            // mnuAgregarCombo
            // 
            this.mnuAgregarCombo.Image = ((System.Drawing.Image)(resources.GetObject("mnuAgregarCombo.Image")));
            this.mnuAgregarCombo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAgregarCombo.Name = "mnuAgregarCombo";
            this.mnuAgregarCombo.Size = new System.Drawing.Size(85, 36);
            this.mnuAgregarCombo.Text = "Agregar";
            // 
            // mnuEditarCombo
            // 
            this.mnuEditarCombo.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditarCombo.Image")));
            this.mnuEditarCombo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEditarCombo.Name = "mnuEditarCombo";
            this.mnuEditarCombo.Size = new System.Drawing.Size(73, 36);
            this.mnuEditarCombo.Text = "Editar";
            // 
            // mnuEliminarCombo
            // 
            this.mnuEliminarCombo.Image = ((System.Drawing.Image)(resources.GetObject("mnuEliminarCombo.Image")));
            this.mnuEliminarCombo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEliminarCombo.Name = "mnuEliminarCombo";
            this.mnuEliminarCombo.Size = new System.Drawing.Size(86, 36);
            this.mnuEliminarCombo.Text = "Eliminar";
            // 
            // mnuSalirCombo
            // 
            this.mnuSalirCombo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuSalirCombo.Image = ((System.Drawing.Image)(resources.GetObject("mnuSalirCombo.Image")));
            this.mnuSalirCombo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalirCombo.Name = "mnuSalirCombo";
            this.mnuSalirCombo.Size = new System.Drawing.Size(65, 36);
            this.mnuSalirCombo.Text = "Salir";
            // 
            // DGTipoIngreso
            // 
            this.DGTipoIngreso.AllowUserToAddRows = false;
            this.DGTipoIngreso.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DGTipoIngreso.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGTipoIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGTipoIngreso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGTipoIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGTipoIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.desc,
            this.tipo});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGTipoIngreso.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGTipoIngreso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGTipoIngreso.Location = new System.Drawing.Point(625, 114);
            this.DGTipoIngreso.MultiSelect = false;
            this.DGTipoIngreso.Name = "DGTipoIngreso";
            this.DGTipoIngreso.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGTipoIngreso.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGTipoIngreso.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGTipoIngreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGTipoIngreso.Size = new System.Drawing.Size(575, 461);
            this.DGTipoIngreso.TabIndex = 33;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.Id.DefaultCellStyle = dataGridViewCellStyle3;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            // 
            // desc
            // 
            this.desc.DataPropertyName = "descripcion";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MediumBlue;
            this.desc.DefaultCellStyle = dataGridViewCellStyle4;
            this.desc.HeaderText = "Ingreso";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 400;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 50;
            // 
            // frmConfigAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 661);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmConfigAdmin";
            this.Text = ":: Configuración Administración ::";
            this.Load += new System.EventHandler(this.frmConfigAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTipoIngreso.ResumeLayout(false);
            this.tabTipoIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGTipoIngreso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTipoIngreso;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.PictureBox pictureBox4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton mnuAgregarCombo;
        internal System.Windows.Forms.ToolStripButton mnuEditarCombo;
        internal System.Windows.Forms.ToolStripButton mnuEliminarCombo;
        internal System.Windows.Forms.ToolStripButton mnuSalirCombo;
        private System.Windows.Forms.DataGridView DGTipoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
    }
}