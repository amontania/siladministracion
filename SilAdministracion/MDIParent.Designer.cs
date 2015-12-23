namespace SilAdministracion
{
    partial class MDIParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.inscribirAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verFichaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.matriculadosXAñoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.padresExAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuscarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarAlumnoF3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rpMatxAno = new System.Windows.Forms.ToolStripMenuItem();
            this.rpPadresExAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsMenu,
            this.windowsMenu,
            this.editMenu,
            this.configurationMenu,
            this.BuscarMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(948, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscribirAlumnoToolStripMenuItem,
            this.verFichaToolStripMenuItem});
            this.toolsMenu.Image = global::Imagenes.Resources.userstudent;
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(83, 20);
            this.toolsMenu.Text = "&Alumnos";
            this.toolsMenu.Click += new System.EventHandler(this.toolsMenu_Click);
            // 
            // inscribirAlumnoToolStripMenuItem
            // 
            this.inscribirAlumnoToolStripMenuItem.Image = global::Imagenes.Resources.ficha;
            this.inscribirAlumnoToolStripMenuItem.Name = "inscribirAlumnoToolStripMenuItem";
            this.inscribirAlumnoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.inscribirAlumnoToolStripMenuItem.Text = "Inscribir Alumno";
            this.inscribirAlumnoToolStripMenuItem.Click += new System.EventHandler(this.inscribirAlumnoToolStripMenuItem_Click);
            // 
            // verFichaToolStripMenuItem
            // 
            this.verFichaToolStripMenuItem.Image = global::Imagenes.Resources.listusers;
            this.verFichaToolStripMenuItem.Name = "verFichaToolStripMenuItem";
            this.verFichaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.verFichaToolStripMenuItem.Text = "Ver Ficha";
            this.verFichaToolStripMenuItem.Click += new System.EventHandler(this.verFichaToolStripMenuItem_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientosToolStripMenuItem});
            this.windowsMenu.Image = global::Imagenes.Resources.bookicon;
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(67, 20);
            this.windowsMenu.Text = "Libros";
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.Image = global::Imagenes.Resources.bookicon1;
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.movimientosToolStripMenuItem.Text = "Movimientos";
            this.movimientosToolStripMenuItem.Click += new System.EventHandler(this.movimientoToolStripMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matriculadosXAñoToolStripMenuItem,
            this.padresExAlumnosToolStripMenuItem,
            this.sETToolStripMenuItem});
            this.editMenu.Image = global::Imagenes.Resources.report;
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(76, 20);
            this.editMenu.Text = "Reporte";
            // 
            // matriculadosXAñoToolStripMenuItem
            // 
            this.matriculadosXAñoToolStripMenuItem.Image = global::Imagenes.Resources.Teacherschoolstudentprofessor;
            this.matriculadosXAñoToolStripMenuItem.Name = "matriculadosXAñoToolStripMenuItem";
            this.matriculadosXAñoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.matriculadosXAñoToolStripMenuItem.Text = "Matriculados X Año";
            this.matriculadosXAñoToolStripMenuItem.Click += new System.EventHandler(this.rpMatxAno_Click);
            // 
            // padresExAlumnosToolStripMenuItem
            // 
            this.padresExAlumnosToolStripMenuItem.Image = global::Imagenes.Resources.iconperson;
            this.padresExAlumnosToolStripMenuItem.Name = "padresExAlumnosToolStripMenuItem";
            this.padresExAlumnosToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.padresExAlumnosToolStripMenuItem.Text = "Padres Ex-Alumnos";
            this.padresExAlumnosToolStripMenuItem.Click += new System.EventHandler(this.rpPadresExAlumnos_Click);
            // 
            // sETToolStripMenuItem
            // 
            this.sETToolStripMenuItem.Image = global::Imagenes.Resources.tributaciones;
            this.sETToolStripMenuItem.Name = "sETToolStripMenuItem";
            this.sETToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.sETToolStripMenuItem.Text = "SET ";
            this.sETToolStripMenuItem.Click += new System.EventHandler(this.sETToolStripMenuItem_Click);
            // 
            // configurationMenu
            // 
            this.configurationMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrationMenuItem});
            this.configurationMenu.Image = global::Imagenes.Resources.iconsettings;
            this.configurationMenu.Name = "configurationMenu";
            this.configurationMenu.Size = new System.Drawing.Size(111, 20);
            this.configurationMenu.Text = "Configuración";
            // 
            // administrationMenuItem
            // 
            this.administrationMenuItem.Image = global::Imagenes.Resources.listcomponents;
            this.administrationMenuItem.Name = "administrationMenuItem";
            this.administrationMenuItem.Size = new System.Drawing.Size(155, 22);
            this.administrationMenuItem.Text = "Administración";
            this.administrationMenuItem.Click += new System.EventHandler(this.administraciónToolStripMenuItem_Click);
            // 
            // BuscarMenu
            // 
            this.BuscarMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarAlumnoF3ToolStripMenuItem});
            this.BuscarMenu.Image = global::Imagenes.Resources.find16x16;
            this.BuscarMenu.Name = "BuscarMenu";
            this.BuscarMenu.Size = new System.Drawing.Size(139, 20);
            this.BuscarMenu.Text = "Buscar Alumno (F3)";
            this.BuscarMenu.Click += new System.EventHandler(this.BuscarMenu_Click);
            // 
            // buscarAlumnoF3ToolStripMenuItem
            // 
            this.buscarAlumnoF3ToolStripMenuItem.Image = global::Imagenes.Resources.find16x16;
            this.buscarAlumnoF3ToolStripMenuItem.Name = "buscarAlumnoF3ToolStripMenuItem";
            this.buscarAlumnoF3ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.buscarAlumnoF3ToolStripMenuItem.Text = "Buscar Alumno (F3)";
            this.buscarAlumnoF3ToolStripMenuItem.Click += new System.EventHandler(this.BuscarMenu_Click);
            // 
            // movimientoToolStripMenuItem
            // 
            this.movimientoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("movimientoToolStripMenuItem.Image")));
            this.movimientoToolStripMenuItem.Name = "movimientoToolStripMenuItem";
            this.movimientoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.movimientoToolStripMenuItem.Text = "Movimiento";
            this.movimientoToolStripMenuItem.Click += new System.EventHandler(this.movimientoToolStripMenuItem_Click);
            // 
            // rpMatxAno
            // 
            this.rpMatxAno.Name = "rpMatxAno";
            this.rpMatxAno.Size = new System.Drawing.Size(32, 19);
            // 
            // rpPadresExAlumnos
            // 
            this.rpPadresExAlumnos.Name = "rpPadresExAlumnos";
            this.rpPadresExAlumnos.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(175, 6);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(948, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(948, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent";
            this.Text = "::Sistema Administrativo::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIParent_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MDIParent_KeyPress);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem rpMatxAno;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem BuscarMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem inscribirAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verFichaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rpPadresExAlumnos;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarAlumnoF3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matriculadosXAñoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem padresExAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationMenu;
        private System.Windows.Forms.ToolStripMenuItem administrationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sETToolStripMenuItem;
    }
}



