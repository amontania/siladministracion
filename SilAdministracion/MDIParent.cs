using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SilAdministracion
{
    public partial class MDIParent : Form
    {
        frminscripcion frm = null;
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {

        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void windowsMenu_Click(object sender, EventArgs e)
        {

        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {


        }

        private void inscribirAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frm == null || frm.Text == "")
            {
                frm = new frminscripcion();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.MinimumSize = this.Size;
                frm.MaximumSize = this.Size;
                frm.Dock = DockStyle.Fill;
                frm.Tag = 1;
                frm.Show();
                
            }
            else if (CheckOpened(frm.Text))
            {
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.MinimumSize = this.Size;
                frm.MaximumSize = this.Size;
                frm.Dock = DockStyle.Fill;
                frm.Tag = 1;
                frm.Show();
                frm.Focus();
                frm.limpiarControles();
                frm.limpiarpaneles(0);
                frm.limpiarCurso();
                frm.CargarDatosIniciales();
                frm.DeshabilitarPaneles();
            }

            frm.tabActivo(1);
        }

        private void rpMatxAno_Click(object sender, EventArgs e)
        {
            frmRepMatriculados frm1 = new frmRepMatriculados();
            frm1.MdiParent = this;
            frm1.WindowState = FormWindowState.Maximized;
            frm1.MinimumSize = this.Size;
            frm1.MaximumSize = this.Size;
            frm1.Show();

        }

        private void movimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibros frm = new frmLibros();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.MinimumSize = this.Size;
            frm.MaximumSize = this.Size;

            frm.Show();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        public void verFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            abrirforminscripcion();
            frm.tabActivo(2);

        }

        private frminscripcion abrirforminscripcion()
        {
            if (frm == null || frm.Text == "")
            {
                frm = new frminscripcion();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.MinimumSize = this.Size;
                frm.MaximumSize = this.Size;
                frm.Dock = DockStyle.Fill;
                frm.Tag = 2;
                frm.Show();
               // frm.Focus();
              //  frm.txtApellido.Focus();
             //   frm.ActiveControl = frm.txtApellido;
              
            }
            else if (CheckOpened(frm.Text))
            {
                frm.Tag = 1;

                frm.WindowState = FormWindowState.Maximized;
                frm.MinimumSize = this.Size;
                frm.MaximumSize = this.Size;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.Focus();
                frm.limpiarControles();
                frm.limpiarpaneles(0);
                frm.limpiarCurso();
                frm.DeshabilitarPaneles();
              //  frm.txtApellido.Focus();
              //  frm.ActiveControl = frm.txtApellido;
            }
            return frm;



        }

        private void rpPadresExAlumnos_Click(object sender, EventArgs e)
        {
            frmRepPadres frm1 = new frmRepPadres();
            frm1.MdiParent = this;
            frm1.WindowState = FormWindowState.Maximized;
            frm1.MinimumSize = this.Size;
            frm1.MaximumSize = this.Size;
            frm1.Show();

        }


        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text==name)
                {
                    return true;
                }
            }
            return false;
        }

        private void BuscarMenu_Click(object sender, EventArgs e)
        {
            BuscarAlumno();

        }

        private void formBuscar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBuscar ver = (frmBuscar)sender;
            string matricula = ver._txtMatricula;
            string idalumno = ver._txtIdAlumno;
            string indices = ver._txtNumHermano;

            if (utilitarios.IsNumeric(matricula))
            {
                frminscripcion fin = abrirforminscripcion();
                int ano = ver._intAno; // DateTime.Now.Year;
                //  if (DateTime.Now.Month > 8)
                //      ano = DateTime.Now.Year + 1;
                fin.Tag = 1;
                string[] idmat = matricula.Split('/');
                int matr = Convert.ToInt32(matricula);
                int indice = Convert.ToInt32(indices);
                int idalumno2 = Convert.ToInt32(idalumno);
                fin.CargaAlumno(idalumno2, ano);

                fin.CargarHermanos2(matr, idalumno2, indice);
                fin.CargaResponsables(idalumno2);
              


           
            }


        }


        private void BuscarAlumno()
        {
            frmBuscar frmbus = new frmBuscar();
            frmbus.FormClosed += new FormClosedEventHandler(formBuscar_FormClosed);
            frmbus.ShowDialog();
        }

        private void MDIParent_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.F3:
                    {
                        BuscarAlumno();
                        return true;
                    }
                case Keys.Alt | Keys.B:
                    {
                        BuscarAlumno();
                        return true;
                    }
                //case Keys.Enter:
                //    {
                //       // if (this.BuscarMenu.Checked)
                //            BuscarAlumno();
                //        return true;
                //    }
            }
            return base.ProcessCmdKey(ref message, keys);
        }

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigAdmin frm = new frmConfigAdmin();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.MinimumSize = this.Size;
            frm.MaximumSize = this.Size;

            frm.Show();
        }

        private void sETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSET frms = new frmSET();
            frms.MdiParent = this;

          //  frms.WindowState = FormWindowState.Maximized;
          //  frms.MinimumSize = this.Size;
           // frms.MaximumSize = this.Size;
            frms.Show();
        }

      

      

    }
       
    
}