using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medusa;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Threading;
namespace SilAdministracion
{
    public partial class frminscripcion : Form
    {
        DBUtils DBMapeo = new DBUtils();
        int NumHermano = 1;
        int CodMatricula = 0;
        int CodCursoGradoOriginal = 0;
        int CodSeccionOriginal = 0;
        int AnoOriginal = 0;
        int EstadoOriginal = 0;
        public int accion = 0;
        int CodAlumno = 0;
        int accionar = 0;
        int NuevoAlumno = 0;
        int mDir = 0;
        int mWidth;
        DataTable dtpadrescopia= new DataTable();
        string[] strControles = new string[] { "txtApellido", "txtNombre", "txtLugar", "txtApeDad", "txtNomDad", "txtCargoDad", "txtApeMom", "txtNomMom", "txtCargoMom", "txtApeAux", "txtNomAux", "txtCargoAux" };
        public frminscripcion()
        {
            InitializeComponent();
            this.tabFicha.Width = 800;
            this.tabFicha.Height = 500;
            var lastColorSaved = Color.Empty;
            TabPage page = this.tabFicha.TabPages[0];
          //  Panel p1 = this.panel1;
            Control.ControlCollection controls = page.Controls;
            this.Recorrer(controls);
            mWidth = panel2.Width;
          //  foreach (Control child in controls)
          //  {
          //   //  if (child is TextBox || child is ComboBox || child is DateTimePicker || child is GroupBox || child is RadioButton || child is NumericUpDown || child is CheckBox)
              
          //   // {
          //     // MessageBox.Show(child.Name);
          //      child.Enter += (s, e) =>
          //      {
          //          var control = (Control)s;
          //          lastColorSaved = control.BackColor;
          //          control.BackColor = Color.GreenYellow;
          //      };
          //      child.Leave += (s, e) =>
          //      {
          //          ((Control)s).BackColor = lastColorSaved;
          //      };
          //// }
          //  }
           
         }

        private void Recorrer(Control.ControlCollection controls)
        {
            var lastColorSaved = Color.Empty;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].Controls != null && controls[i].Controls.Count > 0)
                {
                    this.Recorrer(controls[i].Controls);
                }
                else
                {
                    Control child = controls[i] as Control;
                    if (child is TextBox || child is ComboBox || child is DateTimePicker || child is GroupBox || child is RadioButton || child is NumericUpDown || child is CheckBox)
                    {
                        child.Enter += (s, e) =>
                        {
                            var control = (Control)s;
                            lastColorSaved = control.BackColor;
                            control.BackColor = Color.GreenYellow;

                        };
                        child.Leave += (s, e) =>
                        {
                            ((Control)s).BackColor = lastColorSaved;
                            propername((Control) s);
                        };
                    }

                    //Aqui podes agregar codigo para los demas tipos de control
                }
            }
        }
        private void frminscripcion_Load(object sender, EventArgs e)
        {
            limpiarControles();
            CargarDatosIniciales();
            if (Convert.ToInt32(this.Tag) == 1)
            {
                tabFicha.SelectedTab = tabIns;
                accion = 1;
                
            }
            else
            {
                tabFicha.SelectedTab = tabFic;
                accion = 2;
            }
           
        }


        public void limpiarControles()
        {
            this.txtApellido.Text = "";
            this.txtNombre.Text = "";
            this.rdFem.Checked = false;
            this.rdMas.Checked = false;
            this.txtCedula.Text = "";
            this.dtFechaNac.Text = "";
            this.txtLugar.Text = "";
            this.cboNacionalidad.SelectedIndex = -1;
            this.txtDomicilio.Text = "";
            this.cboCiudad.SelectedIndex = -1;
            this.txtTelefono.Text = "";
            this.txtSeguro.Text = "";
            this.txtNroSeguro.Text = "";
            this.cboSangre.SelectedIndex = -1;
            this.txtAlergia.Text = "";
            this.cboReligion.SelectedIndex = -1;
            this.lblCodigoAlumno.Text = "0";
            CodAlumno = 0;
            CodMatricula = 0;
            this.lblMatricula.Text = "../..";
            this.lblNomComp.Text = ".....";
         
            this.chkSi.Checked = false;
            this.chkNo.Checked = true;
            this.DGHermanos.DataSource = null;
            this.DGHistorico.DataSource = null;

            this.btnImprimir.Visible = false;
            this.btnPrematricular.Visible = false;

            this.lblDatPersonales.Text = "1- DATOS PERSONALES DEL ALUMNO";
            this.panel7.Visible = false;
            this.btnDatosCuentas.Text = "::Cuentas::";
            this.txtApellido.Focus();
            

        }
        private void tabIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void LabelCurso()
        {
            this.lblGrado.Text = this.numAnho.Value.ToString() + " -- " + this.cboGradoCurso.Text + " -- " + this.cboSeccion.Text;
             this.lblCantidadAlumno.Text = "Cantidad de Alumnos : " + this.dataGridAlumnos.RowCount.ToString();
        }

        public void limpiarCurso()
        {
            this.cboGradoCurso2.SelectedIndex = 0;
            this.cboSeccion2.SelectedValue = -1;
            this.cboGradoCurso2.Enabled = true;
            this.dtFechaInicio.CustomFormat = " ";
            this.dtFechaInicio.Format = DateTimePickerFormat.Custom;
            this.dtFechaFin.CustomFormat = " ";
            this.dtFechaFin.Format = DateTimePickerFormat.Custom;
        }

        public void DeshabilitarPaneles()
        {
            this.dtFecNacDad.CustomFormat = " ";
            this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
            this.dtFecNacMom.CustomFormat = " ";
            this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
            this.dtFecNacAux.CustomFormat = " ";
            this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
            this.btnPadreSil.Visible = false;
            this.btnMadreSil.Visible = false;
            this.btnAuxSil.Visible = false;
            //this.panel4.Enabled = false;
            //this.panel5.Enabled = false;
            //this.panel6.Enabled = false;
        }

        public void CargarDatosIniciales()
        {
            CargarComboCiudad(1);
            CargarComboNacionalidad(1);
            CargarComboReligion(1);
            CargarComboTipoSangre(1);
            if (this.cboGradoCurso2.SelectedIndex < 0)
                CargarComboCurso2();
            if (this.cboSeccion.SelectedIndex < 0)
                CargarComboSeccion2(0);

            this.numAno2.Value = DateTime.Now.Year;
            if (DateTime.Now.Month>9)
                this.numAno2.Value = DateTime.Now.Year+1;
         //   this.numAno2.Minimum = DateTime.Now.Year;
            this.numAno2.Maximum = DateTime.Now.Year+1;

            CargarComboParentesco();
            CargarComboProfesion();
            DateTime value1 = new DateTime(Convert.ToInt32(this.numAno2.Value), 1, 31);
            this.dtFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtFechaInicio.Format = DateTimePickerFormat.Custom;
            this.dtFechaInicio.Value = value1;
            DateTime value2 = new DateTime(Convert.ToInt32(this.numAno2.Value),12, 31);
            this.dtFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtFechaFin.Format = DateTimePickerFormat.Custom;
            this.dtFechaFin.Value = value2;

            CargarTipoDescuento(Convert.ToInt32(this.numAno2.Value),0);
            
        }

        private void CargarComboNacionalidad(int iddefault) 
        {
            string sql = "spNacionalidad";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtnacionalidad = DBMapeo.ProcedureSelect(sql, parameters);

            
            this.cboNacionalidad.ValueMember = "IdNacionalidad";
            this.cboNacionalidad.DisplayMember = "Descripcion";
            this.cboNacionalidad.DataSource = dtnacionalidad;
            this.cboNacionalidad.SelectedValue = iddefault;
         

            DataTable dtNacPadre = dtnacionalidad.Copy();
            DataTable dtNacMadre = dtnacionalidad.Copy();
            DataTable dtNacAux = dtnacionalidad.Copy();

            // Nacionalidad Padre
            this.cboNacDad.ValueMember = "IdNacionalidad";
            this.cboNacDad.DisplayMember = "Descripcion";
            this.cboNacDad.DataSource = dtNacPadre;
            this.cboNacDad.SelectedValue = iddefault;

            // Nacionalidad Madre
            this.cboNacMom.ValueMember = "IdNacionalidad";
            this.cboNacMom.DisplayMember = "Descripcion";
            this.cboNacMom.DataSource = dtNacMadre;
            this.cboNacMom.SelectedValue = iddefault;

            // Nacionalidad Aux
            this.cboNacAux.ValueMember = "IdNacionalidad";
            this.cboNacAux.DisplayMember = "Descripcion";
            this.cboNacAux.DataSource = dtNacAux;
            this.cboNacAux.SelectedValue = iddefault;


       }


        private void CargarTipoDescuento(int pAno,int iddefault)
        {
            string sql = "spDescuentos";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, pAno));
            parameters.Add(new DbParameter("pMatricula", DbDirection.Input, 0));
            parameters.Add(new DbParameter("pIdDescuento", DbDirection.Output, 0));
            DataTable dtdescuento = DBMapeo.ProcedureSelect(sql, parameters);
            this.cboDescuento.DataSource = dtdescuento;
           
            this.cboDescuento.ValueMember = "IdDescuento";
            this.cboDescuento.DisplayMember = "Descripcion";
          
            this.cboDescuento.SelectedValue = iddefault;
        }

        private void CargarComboCiudad(int iddefault)
        {
            string sql = "spCiudad";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtciudad = DBMapeo.ProcedureSelect(sql, parameters);

            this.cboCiudad.DataSource = dtciudad;
            this.cboCiudad.ValueMember = "IdCiudad";
            this.cboCiudad.SelectedValue = iddefault;
            this.cboCiudad.DisplayMember = "Descripcion";


            DataTable dtCiuPadre = dtciudad.Copy();
            DataTable dtCiuMadre = dtciudad.Copy();
            DataTable dtCiuAux = dtciudad.Copy();

            this.cboCiudadDad.ValueMember = "IdCiudad";
            this.cboCiudadDad.DisplayMember = "Descripcion";
            this.cboCiudadDad.DataSource = dtCiuPadre;
            this.cboCiudadDad.SelectedValue = iddefault;


            // Madre
            this.cboCiudadMom.ValueMember = "IdCiudad";
            this.cboCiudadMom.DisplayMember = "Descripcion";
            this.cboCiudadMom.DataSource = dtCiuMadre;
            this.cboCiudadMom.SelectedValue = iddefault;

            //// Otro
            this.cboCiudadAux.ValueMember = "IdCiudad";
            this.cboCiudadAux.DisplayMember = "Descripcion";
            this.cboCiudadAux.DataSource = dtCiuAux;
            this.cboCiudadAux.SelectedValue = iddefault;
           


        }

        private void CargarComboReligion(int iddefault)
        {
            string sql = "spReligion";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtreligion = DBMapeo.ProcedureSelect(sql, parameters);

            this.cboReligion.DataSource = dtreligion;
            this.cboReligion.ValueMember = "IdReligion";
            this.cboReligion.SelectedValue= iddefault;
            this.cboReligion.DisplayMember = "Descripcion";
           // this.cboReligion.Text = "";
        }


        private void CargarComboTipoSangre(int iddefault)
        {
            string sql = "spTipoSangre";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dttiposangre = DBMapeo.ProcedureSelect(sql, parameters);

            this.cboSangre.DataSource = dttiposangre;
            this.cboSangre.ValueMember = "IdTipoSangre";
            this.cboSangre.SelectedValue= iddefault;
            this.cboSangre.DisplayMember = "Descripcion";
        }





        private void CargarComboCurso()
        {
            string sql = "spGradoCurso";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtgradocurso = DBMapeo.ProcedureSelect(sql, parameters);
           
            this.cboGradoCurso.ValueMember = "IdCursoGrado";
            this.cboGradoCurso.DisplayMember = "Descripcion";
            this.cboGradoCurso.DataSource = dtgradocurso;
            this.cboGradoCurso.SelectedIndex = 0;
        }


        private void CargarComboCurso2()
        {
            string sql = "spGradoCurso";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtgradocurso = DBMapeo.ProcedureSelect(sql, parameters);
            this.cboGradoCurso2.ValueMember = "IdCursoGrado";
            this.cboGradoCurso2.DisplayMember = "Descripcion";
            this.cboGradoCurso2.DataSource = dtgradocurso;
            this.cboGradoCurso2.SelectedIndex = 0;
            this.cboGradoCurso2.Enabled = true;
        }



        private void CargarComboSeccion(int pCurso)
        {
            string sql = "spSeccionGrado";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pGrado", DbDirection.Input, pCurso));
            DataTable dtsecciongrado = DBMapeo.ProcedureSelect(sql, parameters);


            this.cboSeccion.ValueMember = "IdSeccion";
            this.cboSeccion.DisplayMember = "Descripcion";
            this.cboSeccion.DataSource = dtsecciongrado;
            this.cboSeccion.SelectedValue = -1;

        }


        private void CargarComboSeccion2(int pCurso)
        {
            string sql = "spSeccionGrado";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pGrado", DbDirection.Input, pCurso));
            DataTable dtsecciongrado = DBMapeo.ProcedureSelect(sql, parameters);


            this.cboSeccion2.ValueMember = "IdSeccion";
            this.cboSeccion2.DisplayMember = "Descripcion";
            this.cboSeccion2.DataSource = dtsecciongrado;
            this.cboSeccion2.SelectedValue = -1;

        }


        private void CargarComboParentesco()
        {
            string sql = "spParentesco";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtparentesco = DBMapeo.ProcedureSelect(sql, parameters);
            DataTable dtMadre = dtparentesco.Copy();
            DataTable dtAux = dtparentesco.Copy();
            // Padre
            this.cboParentDad.ValueMember = "IdParentesco";
            this.cboParentDad.DisplayMember = "Descripcion";
            this.cboParentDad.DataSource = dtparentesco;
            this.cboParentDad.SelectedValue = 1;
         

            // Madre
            this.cboParentMom.ValueMember = "IdParentesco";
            this.cboParentMom.DisplayMember = "Descripcion";
            this.cboParentMom.DataSource = dtMadre;
            this.cboParentMom.SelectedValue = 2;

            //// Otro
            this.cboParentAux.ValueMember = "IdParentesco";
            this.cboParentAux.DisplayMember = "Descripcion";
            this.cboParentAux.DataSource = dtAux;
            this.cboParentAux.SelectedIndex = -1;
            this.cboParentAux.SelectedText = "";


        }

        private void CargarComboProfesion()
        {
            string sql = "spProfesion";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtprofesion = DBMapeo.ProcedureSelect(sql, parameters);
            DataTable dtProfMadre = dtprofesion.Copy();
            DataTable dtProfAux = dtprofesion.Copy();

            // Profesion Padre
            this.cboProfDad.ValueMember = "IdProfesion";
            this.cboProfDad.DisplayMember = "Descripcion";
            this.cboProfDad.DataSource = dtprofesion;
            this.cboProfDad.SelectedIndex = -1;
            this.cboProfDad.SelectedText = "";


            // Profesion Madre
            this.cboProfMom.ValueMember = "IdProfesion";
            this.cboProfMom.DisplayMember = "Descripcion";
            this.cboProfMom.DataSource = dtProfMadre;
            this.cboProfMom.SelectedIndex = -1;
            this.cboProfMom.SelectedText = "";


            // Profesion Otro
            this.cboProfAux.ValueMember = "IdProfesion";
            this.cboProfAux.DisplayMember = "Descripcion";
            this.cboProfAux.DataSource = dtProfAux;
            this.cboProfAux.SelectedIndex = -1;
            this.cboProfAux.SelectedText = "";

        }

        private void cboGradoCurso2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboSeccion2(Convert.ToInt16(cboGradoCurso2.SelectedValue));
        }

        private void chkSi_CheckedChanged(object sender, EventArgs e)
        {
           


        }

        private void HabDescheckboxPadre(bool blChek)
        {
            this.rbDadSi.Enabled = blChek;
            this.rbDadNo.Enabled= blChek;
            this.rbMomSi.Enabled = blChek;
            this.rbMomNo.Enabled = blChek;
            this.rbAuxSi.Enabled = blChek;
            this.rbAuxNo.Enabled = blChek;
            if (!blChek)
            {
                this.rbDadSi.Checked = false;
                this.rbDadNo.Checked = false;
                this.rbMomSi.Checked = false;
                this.rbMomNo.Checked = false;
                this.rbAuxSi.Checked = false;
                this.rbAuxNo.Checked = false;

            }
            else 
            {
                this.rbDadSi.Checked = true;
                this.rbDadNo.Checked = false;
                this.rbMomSi.Checked = true;
                this.rbMomNo.Checked = false;
                this.rbAuxSi.Checked = true;
                this.rbAuxNo.Checked = false;
            
            }
        }
        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            this.pictureBox3.Enabled = true;
            this.panel4.Enabled = true;
            this.panel5.Enabled = true;
            this.panel6.Enabled = true;
            if (this.chkNo.Checked && tabFicha.SelectedTab == tabIns)
            {
                HabDescheckboxPadre(false);
                this.chkSi.Checked = false;
                this.DGHermanos.DataSource = null;
                this.DGHistorico.DataSource = null;
                limpiarpaneles(0);
               // this.btnAddBrother.Visible = false;
               // this.btnAddBrother.Location = new Point(this.chkNo.Location.X + 100, this.chkNo.Location.Y);
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                propername(txtApellido);
            }
            
           
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Enter  )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back)
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void dtFechaNac_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dtFechaNac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtLugar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboNacionalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtDomicilio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboCiudad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtNroSeguro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back)
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboSangre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboReligion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
           
           utilitarios.ScrollToUp(this.tabIns);
        }
       

        private void rdMas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void rdFem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtAlergia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboGradoCurso2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboSeccion2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void numAno2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboParentDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtApeDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtNomDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                ///ver
              //  VerificarUsuario(this.txtNomDad,this.txtUserDad);
                
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void VerificarUsuario(TextBox Responsable, TextBox Usuario)
        {
            Responsable.Text = Responsable.Text.Trim();
            string pUltimo = CodMatricula.ToString();
            if ((CodMatricula == 0 && Responsable.Text.Length > 0 ) || (Responsable.Text.Length > 0 && Usuario.Text.Length == 0 ))
            {
                if (pUltimo == "0")
                   pUltimo = "Matricula";

                string textoNormalizado = Responsable.Text[0].ToString().ToLower().Normalize(NormalizationForm.FormD);
                Regex reg = new Regex("[^a-zA-Z0-9 ]");
                string textoSinAcentos = reg.Replace(textoNormalizado, "");


                Usuario.Text = textoSinAcentos + pUltimo;
                int ciclo = 0;
                while (!UnicoUsuario() && ciclo < Responsable.Text.Length)
                {
                    ciclo++;
                    textoNormalizado = Responsable.Text[ciclo].ToString().ToLower().Normalize(NormalizationForm.FormD);
                    textoSinAcentos = reg.Replace(textoNormalizado, "");
                    Usuario.Text = textoSinAcentos + pUltimo;
                }
            }
        }

        private bool UnicoUsuario()
        {
            string dad = this.txtUserDad.Text;
            string mom = this.txtUserMom.Text;
            string aux = this.txtUserAux.Text;

            if (dad.Length == 0)
                dad = "*";
            if (mom.Length == 0)
                mom = "-";
            if (aux.Length == 0)
                aux = "#";

            if ((!dad.Equals(mom)) && (!dad.Equals(aux)) && (!mom.Equals(aux)))
                return true;
            else
                return false;
        }

        private void cboNacDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }

        }

        private void txtDomDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboCiudadDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCelDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtTelDomDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtMailDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboProfDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtEmpDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back)
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtDomLabDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCargoDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtTelLabDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCIDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back)
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtRucDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void dtFecNacDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboParentMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtApeMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back)
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtNomMom_KeyDown(object sender, KeyEventArgs e)
        {
       
            if (e.KeyCode == Keys.Enter )
            {

               
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboNacMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtDomMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboCiudadMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCelMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtTelDomMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtMailMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboProfMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtEmpMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtDomLabMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCargoMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtTelLabMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCIMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtRucMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void dtFecNacMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboParentAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtApeAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtNomAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                             
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboNacAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtDomAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back)
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboCiudadAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCelAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtTelDomAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtMailAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void cboProfAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtEmpAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back)
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtDomLabAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCargoAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtTelLabAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtCIAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void txtRucAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            //if (e.KeyCode == Keys.Back )
            //{
            //    this.SelectNextControl(this.ActiveControl, false, true, true, true);
            //}
        }

        private void frminscripcion_Activated(object sender, EventArgs e)
        {
       
            this.txtApellido.Focus();
           
        }

        private void propername(Control txtName)
        {
            if (txtName is TextBox)
            {
                TextBox tx = (TextBox)txtName;
                if (strControles.Contains(tx.Name))
                {
                    string txProper = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tx.Text);
                    tx.Text = txProper;
                }
            }
        }

        private void cboGradoCurso2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
             CargarComboSeccion2(Convert.ToInt16(cboGradoCurso2.SelectedValue));
        }

        private void txtApellido_Validating(object sender, CancelEventArgs e)
        {
           e.Cancel= ValidaNombre((Control) sender, "Falta Apellido");
           if (e.Cancel)
           {
               //DialogResult result1 = MessageBox.Show("Desea Salir de la Ficha de Inscripción?",
               //    "Verificando Salida",
               //    MessageBoxButtons.YesNo);
               //if (result1 == DialogResult.Yes)
               //{
                //   errorProvider1.Clear();
                   e.Cancel = false;
                 //  tabFicha.SelectedTab = tabFic;
               //}

           }

              
        }


        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaNombre((Control)sender, "Falta Nombre");
            if (e.Cancel)
            {
                e.Cancel = false;
            }
        }


        private bool ValidaNombre(Control ct,string MensajeError)
        {
            bool bStatus = true;
            TextBox tx = (TextBox)ct;
            if (tx.Text == string.Empty)
            {
                errorProvider1.SetError(tx, MensajeError);
                bStatus= true;
            }
            else
            {
                errorProvider1.Clear();
                bStatus= false;
            }
            return bStatus;
        }

        private bool ValidaFechaNac(object sender)
        {
            bool bStatus = true;
            if (dtFechaNac.Text == string.Empty)
            {
                errorProvider1.SetError((Control)sender, "Falta Fecha");
                bStatus = true;
            }
            else
            {
                if (dtFechaNac.Value.Year >= DateTime.Now.Year)
                {
                    errorProvider1.SetError((Control)sender, "Fecha Incorrecta");
                    bStatus = true;
                }
                else
                {
                    errorProvider1.Clear();
                    bStatus = false;
                }
            }
            return bStatus;
        }

        private void groupSexo_Validating(object sender, CancelEventArgs e)
        {
            if (!rdMas.Checked && !rdFem.Checked)
            {
                errorProvider1.SetError((Control)sender, "Falta Genero");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }


        private void dtFechaNac_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel =ValidaFechaNac(sender);
        }

        private void rdMas_Validating(object sender, CancelEventArgs e)
        {
            if (!rdMas.Checked && !rdFem.Checked)
            {
                errorProvider1.SetError((Control)sender, "Falta Genero");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void rdFem_Validating(object sender, CancelEventArgs e)
        {
            if (!rdMas.Checked && !rdFem.Checked)
            {
                errorProvider1.SetError((Control)sender, "Falta Genero");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void txtLugar_Validating(object sender, CancelEventArgs e)
        {
            TextBox tx = (TextBox)sender;
            if (tx.Text == string.Empty)
            {
                errorProvider1.SetError((Control)sender, "Falta Ciudad de Nacimiento");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void cboCiudad_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cboNacionalidad_Validating(object sender, CancelEventArgs e)
        {
            if (this.cboNacionalidad.SelectedIndex < 0)
            {
                errorProvider1.SetError((Control)sender, "Falta Nacionalidad");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

   

        private void GrabarAlumno()
        {
            string Nombre = this.txtNombre.Text;
            string Apellido = this.txtApellido.Text;
            string Sexo = (this.rdMas.Checked) ?  "M" : (this.rdFem.Checked) ? "F" : "M";
            string Cedula = this.txtCedula.Text;
            DateTime FechaNac = this.dtFechaNac.Value;
            string LugarNac = this.txtLugar.Text;
            int Nacionalidad = Convert.ToInt32(this.cboNacionalidad.SelectedValue);

            string Domicilio = this.txtDomicilio.Text;
            int Ciudad = Convert.ToInt32(this.cboCiudad.SelectedValue);
            string Telefono = this.txtTelefono.Text;
            string Seguro = this.txtSeguro.Text;
            string NroSeguro = this.txtNroSeguro.Text;
            int TipoSangre = Convert.ToInt32(this.cboSangre.SelectedValue);
            int Religion = Convert.ToInt32(this.cboReligion.SelectedValue);
            string Alergia = this.txtAlergia.Text;
            CodAlumno = Convert.ToInt32(this.lblCodigoAlumno.Text);
            List<DbParameter> parameters = new List<DbParameter>();
            int pOperacion = 2;
            NuevoAlumno = 1;
            if (CodAlumno > 0)
            {
                pOperacion = 3;
                NuevoAlumno = 0;
            }
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, pOperacion));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, CodAlumno));
            parameters.Add(new DbParameter("pNombre", DbDirection.Input, Nombre));
            parameters.Add(new DbParameter("pApellido", DbDirection.Input, Apellido));
            parameters.Add(new DbParameter("pFechaNac", DbDirection.Input, FechaNac));
            parameters.Add(new DbParameter("pLugarNac", DbDirection.Input, LugarNac));
            parameters.Add(new DbParameter("pIdNacionalidad", DbDirection.Input, Nacionalidad));
            parameters.Add(new DbParameter("pCi", DbDirection.Input, Cedula));
            parameters.Add(new DbParameter("pIdReligion", DbDirection.Input, Religion));
            parameters.Add(new DbParameter("pSexo", DbDirection.Input, Sexo));
            parameters.Add(new DbParameter("pDomicilio", DbDirection.Input, Domicilio));
            parameters.Add(new DbParameter("pIdCiudad", DbDirection.Input, Ciudad));
            parameters.Add(new DbParameter("pTelefono", DbDirection.Input, Telefono));
            parameters.Add(new DbParameter("pSeguroMedico", DbDirection.Input, Seguro));
            parameters.Add(new DbParameter("pNumeroSeguro", DbDirection.Input, NroSeguro));
            parameters.Add(new DbParameter("pIdTipoSangre", DbDirection.Input, TipoSangre));
            parameters.Add(new DbParameter("pAlergias", DbDirection.Input, Alergia));
            parameters.Add(new DbParameter("pEstado", DbDirection.Input, null));
            parameters.Add(new DbParameter("pPerfil", DbDirection.Input, null));
            parameters.Add(new DbParameter("pFoto", DbDirection.Input, null));
            parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

            int retorno = DBMapeo.ExecuteNonQuery("spAlumno", parameters);
            this.lblCodigoAlumno.Text = DBMapeo.OutParameters[0].Value.ToString();

        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            bool bStatus = true;
            errorMessage = "";
            if (emailAddress.Length > 0)
            {
                if (emailAddress.IndexOf("@") > -1)
                {
                    if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                    {
                        errorMessage = "";
                        bStatus = true;
                    }
                }
                else
                {
                    errorMessage = "La dirección de correo no está correcta.\n" +
                       "Por ejemplo 'alguien@ejemplo.com' ";
                    bStatus = false;
                }
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
           
            return bStatus;
        }

        private void GrabarGradoCursoAlumno(int CodAlumno, int Matricula,int NumHermano)
        {
            bool boolCur = ! ValidaGradoCursoSeccion(this.cboGradoCurso2, "Falta Grado/Curso");
            bool boolSec = ! ValidaGradoCursoSeccion(this.cboSeccion2, "Falta Sección");
            if (boolCur && boolSec)
            {
                int codcurso = Convert.ToInt32(this.cboGradoCurso2.SelectedValue);
                int codseccion = Convert.ToInt32(this.cboSeccion2.SelectedValue);
               
                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
                parameters.Add(new DbParameter("pIdGradoCurso", DbDirection.Input, codcurso));
                parameters.Add(new DbParameter("pIdSeccion", DbDirection.Input, codseccion));
                parameters.Add(new DbParameter("pIdCurso", DbDirection.Output, null));
                int retorno = DBMapeo.ExecuteNonQuery("spCurso", parameters);
                int idcurso = Convert.ToInt32( DBMapeo.OutParameters[0].Value.ToString());
                DateTime FechaInicio = this.dtFechaInicio.Value;
                DateTime FechaFin = this.dtFechaFin.Value;
               
                int pOperacion = 1;
                if (Matricula != 0 && NuevoAlumno==0)
                {  //Verificar si no cambio de seccion o de Curso, si de seccion nomas , cambiar sin problema.
                    if ((CodCursoGradoOriginal == codcurso && CodSeccionOriginal != codseccion && Matricula > 0) ||  (CodCursoGradoOriginal == codcurso && CodSeccionOriginal == codseccion && Matricula > 0))
                        pOperacion = 2;
                    // Cambio de Curso, verificar si hay pagos.
                    if (CodCursoGradoOriginal != codcurso)
                        pOperacion = 3;
                    

                }
                int ano = Convert.ToInt32(this.numAno2.Value);
                int estadoactivo = this.rdActivo.Checked ? 1 : 2;
                int iddescuento = Convert.ToInt32(this.cboDescuento.SelectedValue);

                // Verificar si ya no existe


               List<DbParameter> parameter = new List<DbParameter>();
               parameter.Add(new DbParameter("pOperacion", DbDirection.Input, pOperacion));
               parameter.Add(new DbParameter("pIdAlumno", DbDirection.Input, CodAlumno));
               parameter.Add(new DbParameter("pMatricula", DbDirection.Output, Matricula));
               parameter.Add(new DbParameter("pNumHermano", DbDirection.Output, NumHermano));
               parameter.Add(new DbParameter("pIdCurso", DbDirection.Input, idcurso));
               parameter.Add(new DbParameter("pAno", DbDirection.Input, ano));
               parameter.Add(new DbParameter("pEstado", DbDirection.Input, estadoactivo));
               parameter.Add(new DbParameter("pIdTipoDescuento", DbDirection.Input, null));
               parameter.Add(new DbParameter("pNumeroDescuento", DbDirection.Input, null));
               parameter.Add(new DbParameter("pIdDescuento", DbDirection.Input, iddescuento));
               parameter.Add(new DbParameter("pFechaIngreso", DbDirection.Input, FechaInicio));
               parameter.Add(new DbParameter("pFechaSalida", DbDirection.Input, FechaFin));
               retorno = DBMapeo.ExecuteNonQuery("spMatricular", parameter);
               int matricula = Convert.ToInt32(DBMapeo.OutParameters[0].Value.ToString());
               int indice = Convert.ToInt32(DBMapeo.OutParameters[1].Value.ToString());
               if (pOperacion == 0)
               {
                   lblMatricula.Text = matricula.ToString() + "/" + indice.ToString();
               }
               lblNomComp.Text = this.txtApellido.Text + ", " + this.txtNombre.Text;
               CodMatricula = matricula;
            }



        }

        private void btnAceptarAlu_Click(object sender, EventArgs e)
        {
            this.btnAceptarAlu.Enabled = false;
            this.btnAceptarAlu.Text = "Grabando...";
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            try
            {
                bool boolApe = !ValidaNombre(this.txtApellido, "Falta Apellido !!");
                bool boolNom = !ValidaNombre(this.txtNombre, "Falta Nombre !!");
                bool boolFechaNac = !ValidaFechaNac(this.dtFechaNac);
                int haypadre1 = this.txtApeDad.Text.Length;
                int haypadre2 = this.txtNomDad.Text.Length;
                bool okpadre = false;
                if (haypadre1 > 0 && haypadre2 > 0)
                    okpadre = true;

                int haymadre1 = this.txtApeMom.Text.Length;
                int haymadre2 = this.txtNomMom.Text.Length;
                bool okmadre = false;
                if (haymadre1 > 0 && haymadre2 > 0)
                    okmadre = true;


                int hayaux1 = this.txtApeAux.Text.Length;
                int hayaux2 = this.txtNomAux.Text.Length;
                bool okaux = false;
                if (hayaux1 > 0 && hayaux2 > 0)
                    okaux = true;

                bool hayparents = false;
                if (okmadre || okpadre || okaux)
                    hayparents = true;

                bool boolCur = !ValidaGradoCursoSeccion(this.cboGradoCurso2, "Falta Grado/Curso");
                bool boolSec = !ValidaGradoCursoSeccion(this.cboSeccion2, "Falta Sección");
             
                if (boolApe && boolNom && boolFechaNac && hayparents && boolCur && boolSec)
                {
                    GrabarAlumno();
                    bool bNumero = utilitarios.IsNumeric(this.lblCodigoAlumno.Text);
                //    int idalumno = 0;
                    if (bNumero)
                        CodAlumno = Convert.ToInt32(this.lblCodigoAlumno.Text);

                    // Verificar Hermanos
                    if (CodMatricula == 0)
                    {
                        if (chkNo.Checked)
                        {
                            CodMatricula = 0;
                            NumHermano = 1;
                        }
                        if (chkSi.Checked)
                        {

                            NumHermano = DGHermanos.RowCount + 1;
                        }

                    }
                    else
                    {
                        if (chkSi.Checked )
                        {

                            NumHermano = DGHermanos.RowCount + 1;
                        }
                    }

                    if (CodAlumno > 0)
                    {
                        GrabarGradoCursoAlumno(CodAlumno, CodMatricula, NumHermano);
                        bool vPadre = true;
                        bool vMadre = true;
                        bool vAux = true;

                        if (this.chkNo.Checked)
                        { vPadre = false;
                          vMadre = false;
                          vAux = false;
                        }
                        if (this.chkSi.Checked && this.rbDadSi.Checked )
                        { vPadre = false; }
                        if (this.chkSi.Checked && this.rbMomSi.Checked)
                        { vMadre = false; }
                        if (this.chkSi.Checked && this.rbAuxSi.Checked)
                        { vAux = false; }
                        CargarValores(this.panel4, vPadre);
                        CargarValores(this.panel5, vMadre);
                        CargarValores(this.panel6, vAux);

                        if (accionar != 2)
                        {
                            Char pad = Convert.ToChar("-");
                            string str = "¿ Desea imprimir la ficha del Alumno ? " + "\r";
                            str = str.PadRight(80, pad) + "\r" + " " + this.txtApellido.Text + ", " + this.txtNombre.Text;
                            if (MessageBox.Show(str, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                GenerarFicha(CodAlumno, 0, Convert.ToInt32(this.numAno2.Value));
                            }
                        }
                       
                         utilitarios.ScrollToUp(this.tabIns); 
                    }

                }

                else
                {

                    if (!boolCur)
                    {
                        MessageBox.Show("Falta Elegir Grado o Curso");
                        this.cboGradoCurso2.Focus();
                    }
                    else
                    {
                        if (!boolSec)
                        {
                            MessageBox.Show("Falta Elegir Sección!!");
                            this.cboSeccion2.Focus();
                        }
                        else
                        {
                            if (!hayparents)
                            {
                                
                                MessageBox.Show("Falta Colocar Nombre y Apellido de un responsable");
                                if (haypadre1 == 0)
                                    this.txtApeDad.Focus();
                                if (haypadre2 == 0)
                                    this.txtNomDad.Focus();
                                
                            }
                        }
                    }


                }

            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.btnAceptarAlu.Text = "&Grabar";
                this.btnAceptarAlu.Enabled = true;
            }
           
           
        }

        private bool ValidaGradoCursoSeccion(object sender,string Mensaje)
        {
            bool bStatus = true;

            ComboBox cbo = (ComboBox)sender;
            if (Convert.ToInt32(cbo.SelectedValue) <= 0)
            {
                errorProvider1.SetError((Control)sender,Mensaje );
                bStatus = true;
            }
            else
            {
                errorProvider1.Clear();
                bStatus = false;
            }
            return bStatus;
        }

        private void cboGradoCurso2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel= ValidaGradoCursoSeccion(sender,"Verificar Grado/Curso!!" );
        }

        private void cboSeccion2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaGradoCursoSeccion(sender, "Verificar Sección del Grado/Curso!!");
        }

        private void btnAddBrother_Click(object sender, EventArgs e)
        {

        }

        private void formBuscar()
        {
            frmBuscar frmbus = new frmBuscar();
            frmbus.FormClosed += new FormClosedEventHandler(formBuscar_FormClosed);
            frmbus.ShowDialog();
        }


        public void CargaResponsables(int pIdAlumnoHermano)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("_Opcion", DbDirection.Input, "T"));
            parameters.Add(new DbParameter("_IdAlumno", DbDirection.Input, pIdAlumnoHermano));

            DataTable dtpadres = DBMapeo.ProcedureSelect("cnsResponsablesAlumno", parameters);
            if (dtpadres.Rows.Count > 0)
                limpiarpaneles(0);

            for (int i = 0; i < dtpadres.Rows.Count; i++)
            
            {
              switch (i)
	          {
                  case 0:
                      {
                          object pIdParentesco = dtpadres.Rows[i]["IdParentesco"];
                          if (pIdParentesco != DBNull.Value)
                            this.cboParentDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdParentesco"]);

                          this.txtCodDad.Text = dtpadres.Rows[i]["IdResponsable"].ToString();
                          this.txtNomDad.Text = dtpadres.Rows[i]["nombre"].ToString();
                          this.txtApeDad.Text = dtpadres.Rows[i]["apellido"].ToString();

                          object pIdNacionalidad = dtpadres.Rows[i]["IdNacionalidad"];
                          if (pIdNacionalidad != DBNull.Value)
                            this.cboNacDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdNacionalidad"]);

                          this.txtDomDad.Text = dtpadres.Rows[i]["domicilio"].ToString();

                          object pIdCiudad = dtpadres.Rows[i]["IdCiudad"];
                          if (pIdCiudad != DBNull.Value)
                            this.cboCiudadDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdCiudad"]);

                          this.txtCelDad.Text = dtpadres.Rows[i]["celular"].ToString();
                          this.txtTelDomDad.Text = dtpadres.Rows[i]["telefono_domicilio"].ToString();
                          this.txtMailDad.Text = dtpadres.Rows[i]["email"].ToString();
                          object pIdProfesion = dtpadres.Rows[i]["IdProfesion"];
                          if (pIdProfesion != DBNull.Value)
                            this.cboProfDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdProfesion"]);

                          this.txtEmpDad.Text = dtpadres.Rows[i]["empresa"].ToString();
                          this.txtDomLabDad.Text = dtpadres.Rows[i]["direccion_laboral"].ToString();
                          this.txtCargoDad.Text = dtpadres.Rows[i]["cargo"].ToString();
                          this.txtTelLabDad.Text = dtpadres.Rows[i]["telefono_laboral"].ToString();
                          this.txtCIDad.Text = dtpadres.Rows[i]["CI"].ToString();
                          this.txtRucDad.Text = dtpadres.Rows[i]["RUC"].ToString();
                       //   object dtFechaDad = dtpadres.Rows[i]["fecha_nac"];

                          try
                          {
                              DateTime dtFechaDad = Convert.ToDateTime(dtpadres.Rows[i]["fecha_nac"]);
                              this.dtFecNacDad.Value = dtFechaDad;
                          }
                          catch
                          {
                              this.dtFecNacDad.CustomFormat = " ";
                              this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
                              this.dtFecNacDad.Text = "";

                          }
                          //if (dtFechaDad != DBNull.Value)
                          //{
                          //    this.dtFecNacDad.CustomFormat = "dd/MM/yyyy";
                          //    this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
                          //     this.dtFecNacDad.Value =Convert.ToDateTime (dtFechaDad);
                          //}
                          //else
                          //{
                          //    this.dtFecNacDad.CustomFormat = " ";
                          //    this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
                          //}

                          if (dtpadres.Rows[i]["ExAlumno"].ToString() == "0")
                             this.chkExPad.Checked = false;
                          else
                              this.chkExPad.Checked = true;

                          this.txtUserDad.Text = dtpadres.Rows[i]["UsuarioSil"].ToString();

                          if (this.txtUserDad.Text.Length > 0)
                              this.btnPadreSil.Visible = true;
                          else
                              this.btnPadreSil.Visible = false;
                       
                          break;
                      }
                  case 1:
                      {
                          object pIdParentesco = dtpadres.Rows[i]["IdParentesco"];
                          if (pIdParentesco != DBNull.Value)
                              this.cboParentMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdParentesco"]);

                          this.txtCodMom.Text = dtpadres.Rows[i]["IdResponsable"].ToString();
                          this.txtNomMom.Text = dtpadres.Rows[i]["nombre"].ToString();
                          this.txtApeMom.Text = dtpadres.Rows[i]["apellido"].ToString();

                          object pIdNacionalidad = dtpadres.Rows[i]["IdNacionalidad"];
                          if (pIdNacionalidad != DBNull.Value)
                              this.cboNacMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdNacionalidad"]);

                          this.txtDomMom.Text = dtpadres.Rows[i]["domicilio"].ToString();

                          object pIdCiudad = dtpadres.Rows[i]["IdCiudad"];
                          if (pIdCiudad != DBNull.Value)
                              this.cboCiudadMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdCiudad"]);

                          this.txtCelMom.Text = dtpadres.Rows[i]["celular"].ToString();
                          this.txtTelDomMom.Text = dtpadres.Rows[i]["telefono_domicilio"].ToString();
                          this.txtMailMom.Text = dtpadres.Rows[i]["email"].ToString();
                          object pIdProfesion = dtpadres.Rows[i]["IdProfesion"];
                          if (pIdProfesion != DBNull.Value)
                              this.cboProfMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdProfesion"]);

                          this.txtEmpMom.Text = dtpadres.Rows[i]["empresa"].ToString();
                          this.txtDomLabMom.Text = dtpadres.Rows[i]["direccion_laboral"].ToString();
                          this.txtCargoMom.Text = dtpadres.Rows[i]["cargo"].ToString();
                          this.txtTelLabMom.Text = dtpadres.Rows[i]["telefono_laboral"].ToString();
                          this.txtCIMom.Text = dtpadres.Rows[i]["CI"].ToString();
                          this.txtRucMom.Text = dtpadres.Rows[i]["RUC"].ToString();
                         // object dtFechaMom = dtpadres.Rows[i]["fecha_nac"];

                          try
                          {
                              DateTime dtFechaMom = Convert.ToDateTime(dtpadres.Rows[i]["fecha_nac"]);
                              this.dtFecNacMom.Value = dtFechaMom;
                          }
                          catch
                          {
                              this.dtFecNacMom.CustomFormat = " ";
                              this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
                              this.dtFecNacMom.Text = "";

                          }
                          //if (dtFechaMom != DBNull.Value)
                          //{
                          //    this.dtFecNacMom.CustomFormat = "dd/MM/yyyy";
                          //    this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
                          //    this.dtFecNacMom.Value = Convert.ToDateTime(dtFechaMom);
                          //}
                          //else
                          //{
                          //    this.dtFecNacMom.CustomFormat = " ";
                          //    this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
                          //}

                          if (dtpadres.Rows[i]["ExAlumno"].ToString() == "0")
                              this.chkExMad.Checked = false;
                          else
                              this.chkExMad.Checked = true;

                          this.txtUserMom.Text = dtpadres.Rows[i]["UsuarioSil"].ToString();
                          if (this.txtUserMom.Text.Length > 0)
                              this.btnMadreSil.Visible = true;
                          else
                              this.btnMadreSil.Visible = false;

                          break;
                      }
                        
                  case 2:
                       {
                           object pIdParentesco = dtpadres.Rows[i]["IdParentesco"];
                           if (pIdParentesco != DBNull.Value)
                           this.cboParentAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdParentesco"]);

                           this.txtCodAux.Text = dtpadres.Rows[i]["IdResponsable"].ToString();
                           this.txtNomAux.Text = dtpadres.Rows[i]["nombre"].ToString();
                           this.txtApeAux.Text = dtpadres.Rows[i]["apellido"].ToString();

                           object pIdNacionalidad = dtpadres.Rows[i]["IdNacionalidad"];
                           if (pIdNacionalidad != DBNull.Value)
                           this.cboNacAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdNacionalidad"]);

                           this.txtDomAux.Text = dtpadres.Rows[i]["domicilio"].ToString();

                           object pIdCiudad = dtpadres.Rows[i]["IdCiudad"];
                           if (pIdCiudad != DBNull.Value)
                           this.cboCiudadAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdCiudad"]);

                           this.txtCelAux.Text = dtpadres.Rows[i]["celular"].ToString();
                           this.txtTelDomAux.Text = dtpadres.Rows[i]["telefono_domicilio"].ToString();
                           this.txtMailAux.Text = dtpadres.Rows[i]["email"].ToString();
                           object pIdProfesion = dtpadres.Rows[i]["IdProfesion"];
                           if (pIdProfesion != DBNull.Value)
                               this.cboProfAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdProfesion"]);

                           this.txtEmpAux.Text = dtpadres.Rows[i]["empresa"].ToString();
                           this.txtDomLabAux.Text = dtpadres.Rows[i]["direccion_laboral"].ToString();
                           this.txtCargoAux.Text = dtpadres.Rows[i]["cargo"].ToString();
                           this.txtTelLabAux.Text = dtpadres.Rows[i]["telefono_laboral"].ToString();
                           this.txtCIAux.Text = dtpadres.Rows[i]["CI"].ToString();
                           this.txtRucAux.Text = dtpadres.Rows[i]["RUC"].ToString();
                           object dtFechaAux = dtpadres.Rows[i]["fecha_nac"];


                           try
                           {
                               DateTime fecnacnuevo = Convert.ToDateTime(dtpadres.Rows[i]["fecha_nac"]);
                               this.dtFecNacAux.Value = fecnacnuevo;
                           }
                           catch
                           {
                               this.dtFecNacAux.CustomFormat = " ";
                               this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
                               this.dtFecNacAux.Text = "";

                           }
                           //if (dtFechaAux != DBNull.Value)
                           //{
                           //    this.dtFecNacAux.CustomFormat = "dd/MM/yyyy";
                           //    this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
                           //    this.dtFecNacAux.Value = Convert.ToDateTime(dtFechaAux);
                           //}
                           //else
                           //{
                           //    this.dtFecNacAux.CustomFormat = " ";
                           //    this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
                           //}

                           if (dtpadres.Rows[i]["ExAlumno"].ToString() == "0")
                               this.chkExAux.Checked = false;
                           else
                               this.chkExAux.Checked = true;

                           this.txtUserAux.Text = dtpadres.Rows[i]["UsuarioSil"].ToString();
                           if (this.txtUserAux.Text.Length > 0)
                               this.btnAuxSil.Visible = true;
                           else
                               this.btnAuxSil.Visible = false;

                           break;

                       }


              }
            }
            dtpadrescopia=  dtpadres.Copy();
            dtpadres.Clear();
            
        }

        private void CargarHermanos(int pMatricula)
        {
            
             
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pMat", DbDirection.Input, pMatricula));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, CodAlumno));

            DataTable dtope = DBMapeo.ProcedureSelect("spBuscaAlumno", parameters);


            DGHermanos.AutoGenerateColumns = false;
            if (dtope.Rows.Count > 0)
            {
                DGHermanos.DataSource = dtope;
                if (CodAlumno == 0)
                {
                    VerDescuento(pMatricula);
                }
            }
            if (CodAlumno == 0)
            {
                lblMatricula.Text = pMatricula.ToString() + "/" + (dtope.Rows.Count + 1).ToString();
                CodMatricula = pMatricula;
            }
        }

        private void CargaHistorico()
        {
 
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("_IdAlumno", DbDirection.Input, CodAlumno));

            DataTable dtope = DBMapeo.ProcedureSelect("cnsHistorico", parameters);


            DGHistorico.AutoGenerateColumns = false;
            if (dtope.Rows.Count > 0)
            {
                DGHistorico.DataSource = dtope;
            }
                
        
        }

        private void formBuscar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBuscar ver = (frmBuscar)sender;
            string matriculaelegida = ver._txtMatricula;
            string idalumnohermano = ver._txtIdAlumno;

            if (utilitarios.IsNumeric(matriculaelegida))
            {
              
                CargarHermanos(Convert.ToInt32(matriculaelegida));
                CargaResponsables(Convert.ToInt32(idalumnohermano));
                HabDescheckboxPadre(true);

            }
            else
            {
                HabDescheckboxPadre(false);
                this.chkNo.Focus() ;
                this.chkNo.Checked = true;        
            }
        
        }

        private void chkSi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chkSi.Checked = true;
                EjecutarSINO();
                //this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }


        private void EjecutarSINO()
        {
           // this.pictureBox3.Enabled = true;
            this.panel4.Enabled = true;
            this.panel5.Enabled = true;
            this.panel6.Enabled = true;
            if (chkSi.Checked)
            {
                chkNo.Checked = false;
           
            formBuscar();



                // this.btnAddBrother.Location = new Point(this.chkNo.Location.X+100, this.chkNo.Location.Y);
                // this.btnAddBrother.Visible = true;
            }
            else
            {
                this.chkSi.Checked = false;
                this.DGHermanos.DataSource = null;
                this.txtApeDad.Focus();
            }
        }
        private void chkNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 this.chkNo.Checked = true;
                 EjecutarSINO();
              // this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        public void limpiarpaneles(int panel)
        {
            if ((panel==1) || (panel==0))
            {
                foreach (Control child in panel4.Controls)
                {
                    if (child is TextBox) // || child is ComboBox || child is DateTimePicker || child is GroupBox || child is RadioButton || child is NumericUpDown || child is CheckBox)
                    {
                        TextBox tx = (TextBox)child;
                        tx.Text = "";
                    }
                   
              
                }
                this.cboParentDad.SelectedValue = 1;
                this.cboCiudadDad.SelectedValue = 1;
                this.cboNacDad.SelectedValue = 1;
                this.cboProfDad.SelectedIndex = -1;
                chkExPad.Checked = false;
                this.dtFecNacDad.Text = "";
                this.txtCodDad.Text = "0";
          }

            if ((panel == 2) || (panel == 0))
            {
                foreach (Control child in panel5.Controls)
                {
                    if (child is TextBox) // || child is ComboBox || child is DateTimePicker || child is GroupBox || child is RadioButton || child is NumericUpDown || child is CheckBox)
                    {
                        TextBox tx = (TextBox)child;
                        tx.Text = "";
                    }
                   

                }
                this.cboParentMom.SelectedValue = 2;
                this.cboCiudadMom.SelectedValue = 1;
                this.cboNacMom.SelectedValue = 1;
                this.cboProfMom.SelectedIndex = -1;
                chkExMad.Checked = false;
                this.dtFecNacMom.Text = "";
                this.txtCodMom.Text = "0";
            }

            if ((panel == 3) || (panel == 0))
            {
                foreach (Control child in panel6.Controls)
                {
                    if (child is TextBox) // || child is ComboBox || child is DateTimePicker || child is GroupBox || child is RadioButton || child is NumericUpDown || child is CheckBox)
                    {
                        TextBox tx = (TextBox)child;
                        tx.Text = "";
                    }
                  
                }
                this.cboParentAux.SelectedIndex = -1;
                this.cboParentAux.Text = "";
                this.cboCiudadAux.SelectedValue = 1;
                this.cboNacAux.SelectedValue = 1;
                this.cboProfAux.SelectedIndex = -1;
                chkExAux.Checked = false;
                this.dtFecNacAux.Text = "";
                this.txtCodAux.Text = "0";
            }
          
          
           

        }

        private void CargarValores(Panel p, bool PadreNuevo)
        {
            string[] aDatos= new string[20];
            int rec = 0;
            foreach (Control child in p.Controls)
            {
                if (child is TextBox) // || child is ComboBox || child is DateTimePicker || child is GroupBox || child is RadioButton || child is NumericUpDown || child is CheckBox)
                {
                    TextBox tx = (TextBox)child;
                   // string nom = tx.Name;
                   // tx.Text = "";
                    aDatos[rec] = tx.Text;
                    rec++;
                }
                if (child is ComboBox)
                {
                    ComboBox cb = (ComboBox)child;
                    aDatos[rec]=null;
                    if (cb.SelectedValue != null)
                      aDatos[rec] = cb.SelectedValue.ToString();
                    rec++;
                }

                if (child is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)child;
                    aDatos[rec] = dt.Value.ToString();
                    rec++;
                }

                if (child is CheckBox)
                {
                    CheckBox cb = (CheckBox)child;
                    aDatos[rec] = "0";
                    if (cb.Checked == true)
                        aDatos[rec] = "1";
                    rec++;
 
                }
               
              
            }

            //Guardar Valores
            int pOperacion=1;
            int pIdAlumno = Convert.ToInt32(this.lblCodigoAlumno.Text);

          
         
            int pIdParentesco = Convert.ToInt32(aDatos[19]);
          
           
            string pApellido = aDatos[18].ToString();
            string pNombre = aDatos[17].ToString();
            if (pApellido.Length > 0 && pNombre.Length > 0)
            {
                object pIdNacionalidad = null;
                if (utilitarios.IsNumeric(aDatos[16]))
                pIdNacionalidad = Convert.ToInt32(aDatos[16]);
                string pDomicilio = aDatos[15].ToString();
                object pIdCiudad = null;
                 if (utilitarios.IsNumeric(aDatos[14]))
                 pIdCiudad = Convert.ToInt32(aDatos[14]);

                string pCelular = aDatos[13].ToString();
                string pTelefonoDomicilio = aDatos[12].ToString();
                string pEmail = aDatos[11].ToString();
                object pIdProfesion = null;
                if (utilitarios.IsNumeric(aDatos[10]))
                 pIdProfesion = Convert.ToInt32(aDatos[10]);
                string pEmpresa = aDatos[9].ToString();
                string pDireccionLaboral = aDatos[8].ToString();
                string pCargo = aDatos[7].ToString();
                string pTelefonoLaboral = aDatos[6].ToString();
                string pCI = aDatos[5].ToString();
                string pRUC = aDatos[4].ToString();
              //  object pFechaNac = null;
                DateTime pFechaNac = Convert.ToDateTime(aDatos[3]);
                object pDate = null;
                if (pFechaNac.Year < (DateTime.Now.Year))
                    pDate = pFechaNac;

           
              
                int pIdResponsable = Convert.ToInt32(aDatos[2]);
                //if (pIdResponsable > 0 && PadreNuevo && accion == 1)
                //    pIdResponsable = 0;
                int pExAlumno = Convert.ToInt32(aDatos[1]);
                string pUserSil = "";
                if (aDatos[0].ToString().Length>0)
                    pUserSil=aDatos[0].ToString()[0].ToString() + CodMatricula.ToString();

                if (p.Name == "panel4")
                    this.txtUserDad.Text = pUserSil;
                if (p.Name == "panel5")
                    this.txtUserMom.Text = pUserSil;
                if (p.Name == "panel6")
                    this.txtUserAux.Text = pUserSil;

                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, pOperacion));
                parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, pIdAlumno));
                parameters.Add(new DbParameter("pIdResponsable", DbDirection.Output, pIdResponsable));
                parameters.Add(new DbParameter("pIdParentesco", DbDirection.Input, pIdParentesco));
                parameters.Add(new DbParameter("pNombre", DbDirection.Input, pNombre));
                parameters.Add(new DbParameter("pApellido", DbDirection.Input, pApellido));

                parameters.Add(new DbParameter("pIdNacionalidad", DbDirection.Input, pIdNacionalidad));
                parameters.Add(new DbParameter("pDomicilio", DbDirection.Input, pDomicilio));

                parameters.Add(new DbParameter("pIdCiudad", DbDirection.Input, pIdCiudad));
                parameters.Add(new DbParameter("pCelular", DbDirection.Input, pCelular));
                parameters.Add(new DbParameter("pTelefonoDomicilio", DbDirection.Input, pTelefonoDomicilio));
                parameters.Add(new DbParameter("pEmail", DbDirection.Input, pEmail));
                parameters.Add(new DbParameter("pIdProfesion", DbDirection.Input, pIdProfesion));
                parameters.Add(new DbParameter("pEmpresa", DbDirection.Input, pEmpresa));

                parameters.Add(new DbParameter("pDireccionLaboral", DbDirection.Input, pDireccionLaboral));
                parameters.Add(new DbParameter("pCargo", DbDirection.Input, pCargo));
                parameters.Add(new DbParameter("pTelefonoLaboral", DbDirection.Input, pTelefonoLaboral));
                parameters.Add(new DbParameter("pCI", DbDirection.Input, pCI));
                parameters.Add(new DbParameter("pRUC", DbDirection.Input, pRUC));
                parameters.Add(new DbParameter("pFechaNac", DbDirection.Input, pDate));
                parameters.Add(new DbParameter("pExAlumno", DbDirection.Input, pExAlumno));
                parameters.Add(new DbParameter("pUserSil", DbDirection.Input, pUserSil));
                int retorno = DBMapeo.ExecuteNonQuery("spResponsableAlumno", parameters);
                int idresponsable = Convert.ToInt32(DBMapeo.OutParameters[0].Value.ToString());
                if ( pIdResponsable==0 && pUserSil.Length>1 )
                GenerarUsuarioSil(idresponsable, pUserSil, CodMatricula.ToString(), pNombre + "," + pApellido,"P");
               
            }
            
        }


        public void CuentasAlumno(int IdAlumno)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("_IdAlumno", DbDirection.Input, IdAlumno));
           
            DataTable dtCuentas = DBMapeo.ProcedureSelect("spCuentas", parameters);
            this.dataGridCuentas.AutoGenerateColumns = false;
            this.dataGridCuentas.DataSource = dtCuentas;
        }

        public void CargaAlumno(int IdAlumno, int Anho)
        {
            accionar = 2;
            CuentasAlumno(IdAlumno);
            MostrarCuentas();
            if (Convert.ToInt32(this.Tag) == 1)
            {
                tabFicha.SelectedTab = tabIns;
                accion = 1;
            }
            else
            {
                tabFicha.SelectedTab = tabFic;
                accion = 2;
            }
            this.btnImprimir.Visible = true;
            this.btnCuota.Visible = true;
            lblCodigoAlumno.Text = IdAlumno.ToString();
            CodAlumno = IdAlumno;
            int Operacion = 1;
            if (Anho < DateTime.Now.Year)
                Operacion = 5;
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, Operacion));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
            parameters.Add(new DbParameter("pAno", DbDirection.Input, Anho));
            parameters.Add(new DbParameter("pBandera", DbDirection.Input, 1));
            //  parameters.Add(new DbParameter("pIdCurso", DbDirection.Input, 0));
            DataTable dtalumno = DBMapeo.ProcedureSelect("spFichaAlumno", parameters);

            if (dtalumno.Rows.Count > 0)
            {
                int i = 0;

                this.lblMatricula.Text = dtalumno.Rows[i]["Mat"].ToString();
                this.txtApellido.Text = dtalumno.Rows[i]["apellido"].ToString();
                this.txtNombre.Text = dtalumno.Rows[i]["nombre"].ToString();
                this.lblNomComp.Text = this.txtApellido.Text + ", " + this.txtNombre.Text;
                this.cboReligion.SelectedValue = dtalumno.Rows[i]["IdReligion"].ToString();
                //datarowa["Religion"] = dtalumno.Rows[i]["rel"].ToString();
                //datarowa["Sexo"] = dtalumno.Rows[i]["sexo"].ToString();
                if (dtalumno.Rows[i]["sexo"].ToString() == "Masc.")
                {
                    rdMas.Checked = true;
                    rdFem.Checked = false;
                }
                else
                {
                    rdMas.Checked = false;
                    rdFem.Checked = true;
                }
                object fecnac = dtalumno.Rows[i]["fecha_nac"];
                if (fecnac != DBNull.Value)
                {
                    try
                    {
                        DateTime fecnacnuevo = Convert.ToDateTime(dtalumno.Rows[i]["fecha_nac"]);
                        this.dtFechaNac.Value = fecnacnuevo;
                    }
                    catch
                    {
                        this.dtFechaNac.CustomFormat = " ";
                        this.dtFechaNac.Format = DateTimePickerFormat.Custom;
                        this.dtFechaNac.Text = "";

                    }

                }


                this.txtLugar.Text = dtalumno.Rows[i]["lugar_nac"].ToString(); ;
                this.cboNacionalidad.SelectedValue = dtalumno.Rows[i]["Idnacionalidad"].ToString();
                this.txtCedula.Text = dtalumno.Rows[i]["ci"].ToString();
                this.txtDomicilio.Text = dtalumno.Rows[i]["domicilio"].ToString();

                this.cboCiudad.SelectedValue = dtalumno.Rows[i]["IdCiudad"].ToString();
                this.txtTelefono.Text = dtalumno.Rows[i]["telefono"].ToString();
                this.txtSeguro.Text = dtalumno.Rows[i]["seguro_medico"].ToString();
                this.txtNroSeguro.Text = dtalumno.Rows[i]["numero_seguro"].ToString();

                this.cboSangre.SelectedValue = dtalumno.Rows[i]["IdTiposangre"].ToString();
                this.txtAlergia.Text = dtalumno.Rows[i]["alergias"].ToString();

                //datarowa["Matricula"] =  dtalumno.Rows[i]["Mat"].ToString();
                //datarowa["Fecha"] = dtalumno.Rows[i]["Fecha"].ToString();
                this.cboGradoCurso2.SelectedValue = Convert.ToInt32(dtalumno.Rows[i]["IdCursoGrado"]);
                CodCursoGradoOriginal = Convert.ToInt32(dtalumno.Rows[i]["IdCursoGrado"]);
                this.cboGradoCurso2.Enabled = false;
                //datarowa["IdDivision"] = dtalumno.Rows[i]["IdDivision"].ToString();
                //datarowa["Grado"] = dtalumno.Rows[i]["Grado"].ToString();
                this.cboSeccion2.SelectedValue = Convert.ToInt32(dtalumno.Rows[i]["IdSeccion"].ToString());
                CodSeccionOriginal = Convert.ToInt32(dtalumno.Rows[i]["IdSeccion"].ToString());
                this.numAno2.Value = Anho;
                AnoOriginal = Anho;
                EstadoOriginal = Convert.ToInt32(dtalumno.Rows[i]["Estado"]);
                object fecing = dtalumno.Rows[i]["FechaIngreso"];
                if (fecing != DBNull.Value)
                {
                    try
                    {
                        DateTime fecingreso = Convert.ToDateTime(dtalumno.Rows[i]["FechaIngreso"]);
                        this.dtFechaInicio.CustomFormat = "dd/MM/yyyy";
                        this.dtFechaInicio.Format = DateTimePickerFormat.Custom;
                        this.dtFechaInicio.Value = fecingreso;
                    }
                    catch
                    {
                        this.dtFechaInicio.CustomFormat = " ";
                        this.dtFechaInicio.Format = DateTimePickerFormat.Custom;
                        this.dtFechaInicio.Text = "";

                    }

                }

                object fecsal = dtalumno.Rows[i]["FechaSalida"];
                if (fecsal != DBNull.Value)
                {

                    try
                    {
                        DateTime fecsalida = Convert.ToDateTime(dtalumno.Rows[i]["FechaSalida"]);
                        this.dtFechaFin.CustomFormat = "dd/MM/yyyy";
                        this.dtFechaFin.Format = DateTimePickerFormat.Custom;
                        this.dtFechaFin.Value = fecsalida;
                    }
                    catch
                    {
                        this.dtFechaFin.CustomFormat = " ";
                        this.dtFechaFin.Format = DateTimePickerFormat.Custom;
                        this.dtFechaFin.Text = "";

                    }
                }

                if (EstadoOriginal == 1)
                {
                    this.rdActivo.Checked = true;
                    this.rdInactivo.Checked = false;
                }
                else
                {
                    this.rdActivo.Checked = false;
                    this.rdInactivo.Checked = true;
                }
                int iddescuento = Convert.ToInt32(dtalumno.Rows[i]["IdDescuento"]);
                CargarTipoDescuento(AnoOriginal, iddescuento);
                int anopre = Prematriculados(IdAlumno);
                if (anopre > Anho)
                {
                    if (anopre == 9999)
                    { 
                        this.btnPrematricular.Visible = false;
                    }
                    else
                    {
                        if (anopre == 9998)
                        {
                            this.cboGradoCurso2.Enabled = true;
                            this.btnPrematricular.Visible = false;
                        }
                        else
                        {
                            this.btnPrematricular.Visible = true;
                            this.btnPrematricular.Text = "Ver PreMatricula";
                        }
                    }
                }
                else
                {
                    if (anopre == Anho)
                    {
                        this.btnPrematricular.Visible = true;
                        this.btnPrematricular.Text = "Ver Matricula";
                    }
                    else
                    {
                        if (anopre == -1)
                        { this.btnPrematricular.Visible = false; }
                        else
                       {
                            //anopre =0
                           if (Anho < DateTime.Now.Year)
                           {
                               this.btnPrematricular.Visible = true;
                               this.btnPrematricular.Text = " Matricular ";
                           }
                           else
                           {
                               this.btnPrematricular.Visible = true;
                               this.btnPrematricular.Text = " Pre-Matricular ";
                           }
                        }
                    }

                }

                //this.ActiveControl = panel1;
                // this.dataGridCuentas.Focus();
                //  this.tabIns.VerticalScroll.Value = this.tabIns.VerticalScroll.Minimum;
                CargaHistorico();
                utilitarios.ScrollToUp(this.tabIns);
            }
        }


        private void GenerarFicha(int IdAlumno, int CodCurso,int Anho)
        {


          //  object reporte;
           // if (IdAlumno>0)
            SilAdministracion.inscripciones.rptFichaInscripcion reporte= new SilAdministracion.inscripciones.rptFichaInscripcion();
         //   else
          //   reporte = new SilAdministracion.inscripciones.rptFichaInscripcionZoraida();

            DataTable dt = new DataTable("DtDatosPerAlumnos");
            dt.Columns.Add("IdAlumno");
            dt.Columns.Add("IdMatricula");
            dt.Columns.Add("NumHermano");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Religion");
            dt.Columns.Add("Sexo");
            dt.Columns.Add("FechaNac");
            dt.Columns.Add("Lugar");
            dt.Columns.Add("Nacionalidad");
            dt.Columns.Add("CI");
            dt.Columns.Add("Domicilio");
            dt.Columns.Add("Ciudad");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("SeguroMed");
            dt.Columns.Add("NroSeguro");
            dt.Columns.Add("TipoSangre");
            dt.Columns.Add("Alergias");
            dt.Columns.Add("Matricula");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("IdCursoGrado");
            dt.Columns.Add("IdDivision");
            dt.Columns.Add("Grado");
            dt.Columns.Add("Seccion");
            dt.Columns.Add("Hermanos");

            DataTable dther = new DataTable("DtHermanos");
            dther.Columns.Add("IdAlumno");
            dther.Columns.Add("Mat1");
            dther.Columns.Add("ApeNom1");
            dther.Columns.Add("IdCursoGrado1");
            dther.Columns.Add("Grado1");
            dther.Columns.Add("Seccion1");

            dther.Columns.Add("Mat2");
            dther.Columns.Add("ApeNom2");
            dther.Columns.Add("IdCursoGrado2");
            dther.Columns.Add("Grado2");
            dther.Columns.Add("Seccion2");

            dther.Columns.Add("Mat3");
            dther.Columns.Add("ApeNom3");
            dther.Columns.Add("IdCursoGrado3");
            dther.Columns.Add("Grado3");
            dther.Columns.Add("Seccion3");
           
             
            DataTable dtresp = new DataTable("DtResponsables");
            dtresp.Columns.Add("IdAlumno");
            dtresp.Columns.Add("IdResponsable1");
            dtresp.Columns.Add("ApeNom1");
            dtresp.Columns.Add("fecha_nac1");
            dtresp.Columns.Add("nac1");
            dtresp.Columns.Add("domicilio1");
            dtresp.Columns.Add("telefono_domicilio1");
            dtresp.Columns.Add("profesion1");
            dtresp.Columns.Add("empresa1");
            dtresp.Columns.Add("celular1");
            dtresp.Columns.Add("ci1");
            dtresp.Columns.Add("direccion_laboral1");
            dtresp.Columns.Add("telefono_laboral1");
            dtresp.Columns.Add("email1");
            dtresp.Columns.Add("IdParentesco1");

            dtresp.Columns.Add("IdResponsable2");
            dtresp.Columns.Add("ApeNom2");
            dtresp.Columns.Add("fecha_nac2");
            dtresp.Columns.Add("nac2");
            dtresp.Columns.Add("domicilio2");
            dtresp.Columns.Add("telefono_domicilio2");
            dtresp.Columns.Add("profesion2");
            dtresp.Columns.Add("empresa2");
            dtresp.Columns.Add("celular2");
            dtresp.Columns.Add("ci2");
            dtresp.Columns.Add("direccion_laboral2");
            dtresp.Columns.Add("telefono_laboral2");
            dtresp.Columns.Add("email2");
            dtresp.Columns.Add("IdParentesco2");

            dtresp.Columns.Add("ApeNom3");
            dtresp.Columns.Add("celular3");
           
         


            //Cargar Valores
            int hermanos = 0;
            int resp = 0;
            if (IdAlumno > 0)
            {
                // Operacion 3 Carga Hermanos
                List<DbParameter> parameter = new List<DbParameter>();
                parameter.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
                parameter.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
                parameter.Add(new DbParameter("pAno", DbDirection.Input, Anho));
                parameter.Add(new DbParameter("pBandera", DbDirection.Input, 1));
                parameter.Add(new DbParameter("pIdCurso", DbDirection.Input, 0));
                DataTable dthermanos = DBMapeo.ProcedureSelect("spFichaAlumno", parameter);
                hermanos = dthermanos.Rows.Count;
                DataRow datarow;
               

                if (hermanos > 0)
                {
                    datarow = dther.NewRow();
                    datarow["IdAlumno"] = IdAlumno;
                    datarow["Mat1"] = dthermanos.Rows[0]["Mat"].ToString();
                    datarow["ApeNom1"] = dthermanos.Rows[0]["ApeNom"].ToString();
                    datarow["IdCursoGrado1"] = Convert.ToInt32(dthermanos.Rows[0]["IdCursoGrado"]);
                    datarow["Grado1"] = dthermanos.Rows[0]["Grado"].ToString();
                    datarow["Seccion1"] = dthermanos.Rows[0]["Seccion"].ToString();
                    if (hermanos > 1)
                    {
                        datarow["Mat2"] = dthermanos.Rows[1]["Mat"].ToString();
                        datarow["ApeNom2"] = dthermanos.Rows[1]["ApeNom"].ToString();
                        datarow["IdCursoGrado2"] = Convert.ToInt32(dthermanos.Rows[1]["IdCursoGrado"]);
                        datarow["Grado2"] = dthermanos.Rows[1]["Grado"].ToString();
                        datarow["Seccion2"] = dthermanos.Rows[1]["Seccion"].ToString();
                    }
                    if (hermanos > 2)
                    {
                        datarow["Mat3"] = dthermanos.Rows[2]["Mat"].ToString();
                        datarow["ApeNom3"] = dthermanos.Rows[2]["ApeNom"].ToString();
                        datarow["IdCursoGrado3"] = Convert.ToInt32(dthermanos.Rows[2]["IdCursoGrado"]);
                        datarow["Grado3"] = dthermanos.Rows[2]["Grado"].ToString();
                        datarow["Seccion3"] = dthermanos.Rows[2]["Seccion"].ToString();
                    }
                    dther.Rows.Add(datarow);
                }



                // Operacion 4 Carga Padres
                List<DbParameter> parameter1 = new List<DbParameter>();
                parameter1.Add(new DbParameter("pOperacion", DbDirection.Input, 4));
                parameter1.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
                parameter1.Add(new DbParameter("pAno", DbDirection.Input, Anho));
                parameter1.Add(new DbParameter("pBandera", DbDirection.Input, 1));
                parameter1.Add(new DbParameter("pIdCurso", DbDirection.Input, 0));
                DataTable dtresponsables = DBMapeo.ProcedureSelect("spFichaAlumno", parameter1);
                resp = dtresponsables.Rows.Count;

                DataRow datarow2;
                if (resp > 0)
                {
                    datarow2 = dtresp.NewRow();
                    int i = 0;
                 
                    if (Convert.ToInt32(dtresponsables.Rows[i]["Idparentesco"]) < 3)
                    {
                        datarow2["IdAlumno"] = IdAlumno;
                        datarow2["IdResponsable1"] = Convert.ToInt32(dtresponsables.Rows[i]["IdResponsable"].ToString());
                        datarow2["ApeNom1"] = dtresponsables.Rows[i]["ApeNom"].ToString();

                        object fecnac1 = dtresponsables.Rows[i]["fecha_nac"];
                        if (fecnac1 != DBNull.Value)
                        {
                            DateTime fecnacnuevo = Convert.ToDateTime(dtresponsables.Rows[i]["fecha_nac"]);
                            datarow2["fecha_nac1"] = fecnacnuevo.Date.ToShortDateString();
                        }

                        datarow2["nac1"] = dtresponsables.Rows[i]["nac"].ToString();
                        datarow2["domicilio1"] = dtresponsables.Rows[i]["domicilio"].ToString();
                        datarow2["telefono_domicilio1"] = dtresponsables.Rows[i]["telefono_domicilio"].ToString();
                        datarow2["profesion1"] = dtresponsables.Rows[i]["profesion"].ToString(); ;
                        datarow2["empresa1"] = dtresponsables.Rows[i]["empresa"].ToString();
                        datarow2["celular1"] = dtresponsables.Rows[i]["celular"].ToString();
                        datarow2["ci1"] = dtresponsables.Rows[i]["ci"];
                        datarow2["direccion_laboral1"] = dtresponsables.Rows[i]["direccion_laboral"].ToString();
                        datarow2["telefono_laboral1"] = dtresponsables.Rows[i]["telefono_laboral"].ToString();
                        datarow2["email1"] = dtresponsables.Rows[i]["email"].ToString();
                        object pIdParentesco = dtresponsables.Rows[i]["Idparentesco"];
                        datarow2["IdParentesco1"] = 0;
                        if (pIdParentesco != DBNull.Value)
                            datarow2["IdParentesco1"] = Convert.ToInt32(dtresponsables.Rows[i]["Idparentesco"]);
                        
                        if (resp > 1 &&  Convert.ToInt32(dtresponsables.Rows[1]["Idparentesco"]) < 3)
                    
                        {
                            i++;

                            datarow2["IdResponsable2"] = Convert.ToInt32(dtresponsables.Rows[i]["IdResponsable"].ToString());
                            datarow2["ApeNom2"] = dtresponsables.Rows[i]["ApeNom"].ToString();

                            fecnac1 = dtresponsables.Rows[i]["fecha_nac"];
                            if (fecnac1 != DBNull.Value)
                            {
                                DateTime fecnacnuevo = Convert.ToDateTime(dtresponsables.Rows[i]["fecha_nac"]);
                                datarow2["fecha_nac2"] = fecnacnuevo.Date.ToShortDateString();
                            }
                            datarow2["nac2"] = dtresponsables.Rows[i]["nac"].ToString();
                            datarow2["domicilio2"] = dtresponsables.Rows[i]["domicilio"].ToString();
                            datarow2["telefono_domicilio2"] = dtresponsables.Rows[i]["telefono_domicilio"].ToString();
                            datarow2["profesion2"] = dtresponsables.Rows[i]["profesion"].ToString(); ;
                            datarow2["empresa2"] = dtresponsables.Rows[i]["empresa"].ToString();
                            datarow2["celular2"] = dtresponsables.Rows[i]["celular"].ToString();
                            datarow2["ci2"] = dtresponsables.Rows[i]["ci"];
                            datarow2["direccion_laboral2"] = dtresponsables.Rows[i]["direccion_laboral"].ToString();
                            datarow2["telefono_laboral2"] = dtresponsables.Rows[i]["telefono_laboral"].ToString();
                            datarow2["email2"] = dtresponsables.Rows[i]["email"].ToString();
                            pIdParentesco = dtresponsables.Rows[i]["Idparentesco"];
                            datarow2["IdParentesco2"] = 0;
                            if (pIdParentesco != DBNull.Value)
                                datarow2["IdParentesco2"] = Convert.ToInt32(dtresponsables.Rows[i]["Idparentesco"]);
                        }
                    }


                    if (resp >= 2 && Convert.ToInt32(dtresponsables.Rows[1]["Idparentesco"]) > 2)
                    {
                        i++;
                        datarow2["ApeNom3"] = dtresponsables.Rows[i]["ApeNom"].ToString();
                        datarow2["celular3"] = dtresponsables.Rows[i]["celular"].ToString();
                    }
                    dtresp.Rows.Add(datarow2);
                }





                // Operacion 1 Carga Datos del Alumno
                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
                parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
                parameters.Add(new DbParameter("pAno", DbDirection.Input, Anho));
                parameters.Add(new DbParameter("pBandera", DbDirection.Input, 1));
                parameters.Add(new DbParameter("pIdCurso", DbDirection.Input, 0));
                DataTable dtalumno = DBMapeo.ProcedureSelect("spFichaAlumno", parameters);

                if (dtalumno.Rows.Count > 0)
                {
                    int i = 0;
                    DataRow datarowa = dt.NewRow();
                    datarowa["IdAlumno"] = IdAlumno;
                    datarowa["IdMatricula"] = Convert.ToInt32( dtalumno.Rows[i]["IdMatricula"].ToString());
                    datarowa["NumHermano"] =  Convert.ToInt32(dtalumno.Rows[i]["NumHermano"].ToString());
                    datarowa["Apellido"] = dtalumno.Rows[i]["apellido"].ToString();
                    datarowa["Nombre"] = dtalumno.Rows[i]["nombre"].ToString();
                    datarowa["Religion"] = dtalumno.Rows[i]["rel"].ToString();
                    datarowa["Sexo"] = dtalumno.Rows[i]["sexo"].ToString();

                    object fecnac = dtalumno.Rows[i]["fecha_nac"];
                    if (fecnac != DBNull.Value)
                    {
                        DateTime fecnacnuevo = Convert.ToDateTime(dtalumno.Rows[i]["fecha_nac"]);
                        datarowa["FechaNac"] = fecnacnuevo.Date.ToShortDateString();
                    }
                

                    datarowa["Lugar"] = dtalumno.Rows[i]["lugar_nac"].ToString(); ;
                    datarowa["Nacionalidad"] = dtalumno.Rows[i]["nac"].ToString();
                    datarowa["CI"] = dtalumno.Rows[i]["ci"].ToString();
                    datarowa["Domicilio"] = dtalumno.Rows[i]["domicilio"].ToString();

                    datarowa["Ciudad"] = dtalumno.Rows[i]["ciu"].ToString();
                    datarowa["Telefono"] = dtalumno.Rows[i]["telefono"].ToString();
                    datarowa["SeguroMed"] = dtalumno.Rows[i]["seguro_medico"].ToString();
                    datarowa["NroSeguro"] = dtalumno.Rows[i]["numero_seguro"].ToString();

                    datarowa["TipoSangre"] = dtalumno.Rows[i]["tip"].ToString();
                    datarowa["Alergias"] = dtalumno.Rows[i]["alergias"].ToString();

                    datarowa["Matricula"] =  dtalumno.Rows[i]["Mat"].ToString();
                    datarowa["Fecha"] = dtalumno.Rows[i]["Fecha"].ToString();
                    datarowa["IdCursoGrado"] = Convert.ToInt32(dtalumno.Rows[i]["IdCursoGrado"]);
                    datarowa["IdDivision"] = dtalumno.Rows[i]["IdDivision"].ToString();
                    datarowa["Grado"] = dtalumno.Rows[i]["Grado"].ToString();
                    datarowa["Seccion"] = dtalumno.Rows[i]["Seccion"].ToString();
                    datarowa["Hermanos"] = hermanos;

                    dt.Rows.Add(datarowa);

                    DataSet Ds = new DataSet();
                    Ds.Tables.Add(dt);
                    Ds.Tables.Add(dther);
                    Ds.Tables.Add(dtresp);
                    DataColumn colParent =
                    Ds.Tables["DtDatosPerAlumnos"].Columns["IdAlumno"];
                    DataColumn colChild =
                         Ds.Tables["DtHermanos"].Columns["IdAlumno"];

                    DataColumn colChild2 =
                        Ds.Tables["DtResponsables"].Columns["IdAlumno"];

                    DataRelation drAlumnoId =
                         new DataRelation("AlumnoId", colParent, colChild);

                    DataRelation drAlumnoId2 =
                        new DataRelation("AlumnoId2", colParent, colChild2);



                    Ds.Relations.Add(drAlumnoId);
                    Ds.Relations.Add(drAlumnoId2);

                    reporte.SetDataSource(Ds);
                    crystalReportViewer1.ReportSource = reporte;
                    tabFicha.SelectedTab = tabRep;
                }

            }
            else
            { 
                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
                parameters.Add(new DbParameter("pAno", DbDirection.Input, Anho));
                parameters.Add(new DbParameter("pBandera", DbDirection.Input, 0));
                parameters.Add(new DbParameter("pIdCurso", DbDirection.Input, CodCurso));

                DataTable dtalumno = DBMapeo.ProcedureSelect("spFichaAlumno", parameters);
                for (int i=0; i < dtalumno.Rows.Count;i++)
                {
                    IdAlumno =Convert.ToInt32(dtalumno.Rows[i]["IdAlumno"]);
                    List<DbParameter> parameter = new List<DbParameter>();
                    parameter.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
                    parameter.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
                    parameter.Add(new DbParameter("pAno", DbDirection.Input, Anho));
                    parameter.Add(new DbParameter("pBandera", DbDirection.Input, 0));
                    DataTable dthermanos = DBMapeo.ProcedureSelect("spFichaAlumno", parameter);
                    hermanos = dthermanos.Rows.Count;
                    DataRow datarow;
                    if (hermanos > 0)
                    {
                        datarow = dther.NewRow();
                        datarow["IdAlumno"] = IdAlumno;
                        datarow["Mat1"] = dthermanos.Rows[0]["Mat"].ToString();
                        datarow["ApeNom1"] = dthermanos.Rows[0]["ApeNom"].ToString();
                        datarow["IdCursoGrado1"] = Convert.ToInt32(dthermanos.Rows[0]["IdCursoGrado"]);
                        datarow["Grado1"] = dthermanos.Rows[0]["Grado"].ToString();
                        datarow["Seccion1"] = dthermanos.Rows[0]["Seccion"].ToString();
                        if (hermanos > 1)
                        {
                            datarow["Mat2"] = dthermanos.Rows[1]["Mat"].ToString();
                            datarow["ApeNom2"] = dthermanos.Rows[1]["ApeNom"].ToString();
                            datarow["IdCursoGrado2"] = Convert.ToInt32(dthermanos.Rows[1]["IdCursoGrado"]);
                            datarow["Grado2"] = dthermanos.Rows[1]["Grado"].ToString();
                            datarow["Seccion2"] = dthermanos.Rows[1]["Seccion"].ToString();
                        }
                        if (hermanos > 2)
                        {
                            datarow["Mat3"] = dthermanos.Rows[2]["Mat"].ToString();
                            datarow["ApeNom3"] = dthermanos.Rows[2]["ApeNom"].ToString();
                            datarow["IdCursoGrado3"] = Convert.ToInt32(dthermanos.Rows[2]["IdCursoGrado"]);
                            datarow["Grado3"] = dthermanos.Rows[2]["Grado"].ToString();
                            datarow["Seccion3"] = dthermanos.Rows[2]["Seccion"].ToString();
                        }
                        dther.Rows.Add(datarow);
                    }


                    List<DbParameter> parameter1 = new List<DbParameter>();
                    parameter1.Add(new DbParameter("pOperacion", DbDirection.Input, 4));
                    parameter1.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
                    parameter1.Add(new DbParameter("pAno", DbDirection.Input, Anho));
                    parameter1.Add(new DbParameter("pBandera", DbDirection.Input, 0));
                    parameter1.Add(new DbParameter("pIdCurso", DbDirection.Input, CodCurso));
                    DataTable dtresponsables = DBMapeo.ProcedureSelect("spFichaAlumno", parameter1);

                    resp = dtresponsables.Rows.Count;
                    DataRow datarow2;
                    if (resp > 0)
                    {
                        datarow2 = dtresp.NewRow();
                        int j = 0;
                        datarow2["IdAlumno"] = IdAlumno;
                        datarow2["IdResponsable1"] = Convert.ToInt32(dtresponsables.Rows[j]["IdResponsable"].ToString());
                        datarow2["ApeNom1"] = dtresponsables.Rows[j]["ApeNom"].ToString();
                     //   datarow2["fecha_nac1"] = dtresponsables.Rows[j]["fecha_nac"].ToString();

                        object fecnac1 = dtresponsables.Rows[j]["fecha_nac"];
                        if (fecnac1 != DBNull.Value)
                        {
                            DateTime fecnacnuevo = Convert.ToDateTime(dtresponsables.Rows[j]["fecha_nac"]);
                            datarow2["fecha_nac1"] = fecnacnuevo.Date.ToShortDateString();
                        }
                        datarow2["nac1"] = dtresponsables.Rows[j]["nac"].ToString();
                        datarow2["domicilio1"] = dtresponsables.Rows[j]["domicilio"].ToString();
                        datarow2["telefono_domicilio1"] = dtresponsables.Rows[j]["telefono_domicilio"].ToString();
                        datarow2["profesion1"] = dtresponsables.Rows[j]["profesion"].ToString(); ;
                        datarow2["empresa1"] = dtresponsables.Rows[j]["empresa"].ToString();
                        datarow2["celular1"] = dtresponsables.Rows[j]["celular"].ToString();
                        datarow2["ci1"] = dtresponsables.Rows[j]["ci"];
                        datarow2["direccion_laboral1"] = dtresponsables.Rows[j]["direccion_laboral"].ToString();
                        datarow2["telefono_laboral1"] = dtresponsables.Rows[j]["telefono_laboral"].ToString();
                        datarow2["email1"] = dtresponsables.Rows[j]["email"].ToString();
                        object pIdParentesco = dtresponsables.Rows[j]["Idparentesco"];
                        datarow2["IdParentesco1"] = 0;
                        if (pIdParentesco != DBNull.Value)
                            datarow2["IdParentesco1"] = Convert.ToInt32(dtresponsables.Rows[j]["Idparentesco"]);

                        if (resp > 1)
                        {
                            j++;
                            datarow2["IdResponsable2"] = Convert.ToInt32(dtresponsables.Rows[j]["IdResponsable"].ToString());
                            datarow2["ApeNom2"] = dtresponsables.Rows[j]["ApeNom"].ToString();
                          //  datarow2["fecha_nac2"] = dtresponsables.Rows[j]["fecha_nac"].ToString();
                             fecnac1 = dtresponsables.Rows[j]["fecha_nac"];
                            if (fecnac1 != DBNull.Value)
                            {
                                DateTime fecnacnuevo = Convert.ToDateTime(dtresponsables.Rows[j]["fecha_nac"]);
                                datarow2["fecha_nac2"] = fecnacnuevo.Date.ToShortDateString();
                            }
                            datarow2["nac2"] = dtresponsables.Rows[j]["nac"].ToString();
                            datarow2["domicilio2"] = dtresponsables.Rows[j]["domicilio"].ToString();
                            datarow2["telefono_domicilio2"] = dtresponsables.Rows[j]["telefono_domicilio"].ToString();
                            datarow2["profesion2"] = dtresponsables.Rows[j]["profesion"].ToString(); ;
                            datarow2["empresa2"] = dtresponsables.Rows[j]["empresa"].ToString();
                            datarow2["celular2"] = dtresponsables.Rows[j]["celular"].ToString();
                            datarow2["ci2"] = dtresponsables.Rows[j]["ci"];
                            datarow2["direccion_laboral2"] = dtresponsables.Rows[j]["direccion_laboral"].ToString();
                            datarow2["telefono_laboral2"] = dtresponsables.Rows[j]["telefono_laboral"].ToString();
                            datarow2["email2"] = dtresponsables.Rows[j]["email"].ToString();
                            pIdParentesco = dtresponsables.Rows[j]["Idparentesco"];
                            datarow2["IdParentesco2"] = 0;
                            if (pIdParentesco != DBNull.Value)
                                datarow2["IdParentesco2"] = Convert.ToInt32(dtresponsables.Rows[j]["Idparentesco"]);
                        }
                        if (resp > 3)
                        {
                            j++;
                            datarow2["ApeNom3"] = dtresponsables.Rows[j]["ApeNom"].ToString();
                            datarow2["celular3"] = dtresponsables.Rows[j]["celular"].ToString();
                        }
                        dtresp.Rows.Add(datarow2);
                    }

                     datarow = dt.NewRow();
                    datarow["IdAlumno"] = dtalumno.Rows[i]["IdAlumno"].ToString();
                    datarow["IdMatricula"] =  Convert.ToInt32(dtalumno.Rows[i]["IdMatricula"].ToString());
                    datarow["NumHermano"] = Convert.ToInt32(dtalumno.Rows[i]["NumHermano"].ToString());
                    datarow["Apellido"] = dtalumno.Rows[i]["apellido"].ToString();
                    datarow["Nombre"] = dtalumno.Rows[i]["nombre"].ToString();
                    datarow["Religion"] = dtalumno.Rows[i]["rel"].ToString();
                    datarow["Sexo"] = dtalumno.Rows[i]["sexo"].ToString();
                    object fecnac = dtalumno.Rows[i]["fecha_nac"];
                    if (fecnac != DBNull.Value)
                    {
                        DateTime fecnacnuevo = Convert.ToDateTime(dtalumno.Rows[i]["fecha_nac"]);
                        datarow["FechaNac"] = fecnacnuevo.Date.ToShortDateString();
                    }

                    datarow["Lugar"] = dtalumno.Rows[i]["lugar_nac"].ToString(); ;
                    datarow["Nacionalidad"] = dtalumno.Rows[i]["nac"].ToString();
                    datarow["CI"] = dtalumno.Rows[i]["ci"].ToString();
                    datarow["Domicilio"] = dtalumno.Rows[i]["domicilio"].ToString();

                    datarow["Ciudad"] = dtalumno.Rows[i]["ciu"].ToString();
                    datarow["Telefono"] = dtalumno.Rows[i]["telefono"].ToString();
                    datarow["SeguroMed"] = dtalumno.Rows[i]["seguro_medico"].ToString();
                    datarow["NroSeguro"] = dtalumno.Rows[i]["numero_seguro"].ToString();

                    datarow["TipoSangre"] = dtalumno.Rows[i]["tip"].ToString();
                    datarow["Alergias"] = dtalumno.Rows[i]["alergias"].ToString();

                    datarow["Matricula"] = dtalumno.Rows[i]["Mat"].ToString();
                    datarow["Fecha"] = dtalumno.Rows[i]["Fecha"].ToString();
                    datarow["IdCursoGrado"] = Convert.ToInt32(dtalumno.Rows[i]["IdCursoGrado"]);
                    datarow["IdDivision"] = dtalumno.Rows[i]["IdDivision"].ToString();
                    datarow["Grado"] = dtalumno.Rows[i]["Grado"].ToString();
                    datarow["Seccion"] = dtalumno.Rows[i]["Seccion"].ToString();
                    datarow["Hermanos"] = hermanos;
                    dt.Rows.Add(datarow);

                   
                }

                DataSet Ds = new DataSet();
                Ds.Tables.Add(dt);
                Ds.Tables.Add(dther);
                Ds.Tables.Add(dtresp);
                DataColumn colParent =
                Ds.Tables["DtDatosPerAlumnos"].Columns["IdAlumno"];
                DataColumn colChild =
                     Ds.Tables["DtHermanos"].Columns["IdAlumno"];

                DataColumn colChild2 =
                    Ds.Tables["DtResponsables"].Columns["IdAlumno"];

                DataRelation drAlumnoId =
                     new DataRelation("AlumnoId", colParent, colChild);

                DataRelation drAlumnoId2 =
                    new DataRelation("AlumnoId2", colParent, colChild2);



                Ds.Relations.Add(drAlumnoId);
                Ds.Relations.Add(drAlumnoId2);

                reporte.SetDataSource(Ds);
                crystalReportViewer1.ReportSource = reporte;
                tabFicha.SelectedTab = tabRep;
                
            }
               
        }

        private void tabFicha_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabFicha.SelectedTab.Name)
            {
                case "tabFic":
                    this.numAnho.Value = DateTime.Now.Year;
                    this.numAnho.Minimum = DateTime.Now.Year;
                    this.numAnho.Maximum = DateTime.Now.Year+1;
                    if (DateTime.Now.Month > 9)
                        this.numAnho.Value = DateTime.Now.Year + 1;
                //    if (Convert.ToInt32(this.cboGradoCurso.SelectedValue) < 0)
                        CargarComboCurso();
               //     if (Convert.ToInt32(this.cboSeccion.SelectedValue) < 0)
                  //      CargarComboSeccion(0);
                    this.cboGradoCurso.Focus();

                    LabelCurso();
                    int pBandera = 1;
                    if (this.chkGeneral.Checked)
                    {
                        pBandera = 0;
                    }
                        List<DbParameter> parameters = new List<DbParameter>();
                        parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                        parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, 1));
                        parameters.Add(new DbParameter("pAno", DbDirection.Input, Convert.ToInt32(this.numAnho.Value)));
                        parameters.Add(new DbParameter("pBandera", DbDirection.Input, pBandera));
                        parameters.Add(new DbParameter("pIdCurso", DbDirection.Input, 1));
                        DataTable dtalumno = DBMapeo.ProcedureSelect("spFichaAlumno", parameters);

                       

                        this.dataGridAlumnos.AutoGenerateColumns = false;
                        this.dataGridAlumnos.DataSource = dtalumno;
                    break;
                case "tabIns":
                  //  CargarDatosIniciales();
                   this.txtApellido.Focus();
                   if (accion == 2)
                   {
                       this.txtNombre.Focus();
                       this.txtApellido.Focus();
                   }
                    break;

            }
        }


        private int GetIdAlumno()
        {
            int rowindexAlumno = 0;
            if (dataGridAlumnos.RowCount > 0 && dataGridAlumnos.CurrentRow != null)
                rowindexAlumno = dataGridAlumnos.CurrentRow.Index;
            int IdAlumno = 0;
            if (dataGridAlumnos.RowCount > 0)
            {
                IdAlumno = Convert.ToInt32(dataGridAlumnos["IdAlumno", rowindexAlumno].Value.ToString());

            }
            return IdAlumno;
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            btnReporte.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int idalumno = 0;
                if (chkGeneral.Checked)
                    GenerarFicha(idalumno, 1, Convert.ToInt32(this.numAnho.Value));
                else
                {
                    idalumno = GetIdAlumno();
                    int Ano = Convert.ToInt32(this.numAnho.Value);
                    if (DateTime.Now.Month > 8)
                        Ano = DateTime.Now.Year + 1;

                    GenerarFicha(idalumno, 0, Ano);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                btnReporte.Enabled = true;
            }
          
           
           
        }

        private void chkGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGeneral.Checked)
            {
                this.cboGradoCurso.SelectedIndex = -1;
                this.cboGradoCurso.Enabled = false;
                this.cboSeccion.SelectedIndex = -1;
                this.cboSeccion.Enabled = false;
            }
            else
            {
                this.cboGradoCurso.SelectedValue = 0;
                this.cboGradoCurso.Enabled = true;
                this.cboSeccion.SelectedValue = -1;
                this.cboSeccion.Enabled = true;
            }
        }

        private void cboGradoCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboSeccion(Convert.ToInt16(cboGradoCurso.SelectedValue));
            CargaAlumnos();
        }
      
        private void CargaAlumnos()
        {

            int pBandera = 1;
            if (this.chkGeneral.Checked)
            {
                pBandera = 0;
            }
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pAno", DbDirection.Input, Convert.ToInt32(this.numAnho.Value)));
            parameters.Add(new DbParameter("pBandera", DbDirection.Input, pBandera));
            parameters.Add(new DbParameter("pIdCurso", DbDirection.Input, 1));
            DataTable dtalumno = DBMapeo.ProcedureSelect("spFichaAlumno", parameters);
            DataView dw = new DataView();
            dw.Table = dtalumno;
         
            if (Convert.ToInt32(this.cboGradoCurso.SelectedValue) > 0)
            {
                dw.RowFilter = "IdCursoGrado=" + Convert.ToInt32(this.cboGradoCurso.SelectedValue).ToString();

                if (Convert.ToInt32(this.cboSeccion.SelectedValue) > 0)
                {
                    dw.RowFilter = "IdCursoGrado=" + Convert.ToInt32(this.cboGradoCurso.SelectedValue).ToString() + " and IdSeccion=" + Convert.ToInt32(this.cboSeccion.SelectedValue).ToString();
                }
            }

          


            this.dataGridAlumnos.AutoGenerateColumns = false;

            this.dataGridAlumnos.DataSource = dw;
            LabelCurso();
        }

        private void numAnho_ValueChanged(object sender, EventArgs e)
        {
            CargaAlumnos();
        }

        private void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaAlumnos();
        }

        private void dataGridAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int idalumno = GetIdAlumno();
                GenerarFicha(idalumno, 0, Convert.ToInt32(this.numAnho.Value));
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

     
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(192, 192, 255), Color.Gold, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(192, 192, 255), Color.Gold, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(192, 192, 255), Color.Gold, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(192, 192, 255), Color.Gold, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(192, 192, 255), Color.Gold, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

       

        private void dataGridAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    limpiarControles();
                    accion = 2;
                    int idalumno = GetIdAlumno();
                    lblCodigoAlumno.Text = idalumno.ToString();
                    string matricula = dataGridAlumnos["Matricula", dataGridAlumnos.CurrentRow.Index].Value.ToString();
                    string[] idmat  = matricula.Split('/');
                    int matr = Convert.ToInt32( idmat[0]);
                    int indice = Convert.ToInt32(idmat[1]);
                    NumHermano = indice;
                    CargaAlumno(idalumno,Convert.ToInt32(this.numAnho.Value));
                
                    CargarHermanos2(matr,idalumno,indice);
                    limpiarpaneles(0);
                    CargaResponsables(idalumno);
                    tabFicha.SelectedTab = tabIns;
                    this.txtNombre.Focus();
                    this.txtApellido.Focus();
                    utilitarios.ScrollToUp(this.tabIns);
                   // GenerarFicha(idalumno, 0, Convert.ToInt32(this.numAnho.Value));
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }


        public void CargarHermanos2(int pMatricula,int idalumno, int indice)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pMat", DbDirection.Input, pMatricula));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, 0));
            DataTable dtope = DBMapeo.ProcedureSelect("spBuscaAlumno", parameters);
            for (int i = dtope.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtope.Rows[i];
                if (Convert.ToInt32(dr["IdAlumno"]) == idalumno)
                    dr.Delete();
            }
            dtope.AcceptChanges();

            DGHermanos.DataSource = null;
            DGHermanos.AutoGenerateColumns = false;
            this.chkSi.Checked = false;
            this.chkNo.Checked = true;
            if (dtope.Rows.Count > 0)
            {
                DGHermanos.DataSource = dtope;
                this.chkSi.Checked = true;
                this.chkNo.Checked = false;
            }
            lblMatricula.Text = pMatricula.ToString() + "/" + indice.ToString();
            CodMatricula = pMatricula;

        }

        private void dtFecNacDad_ValueChanged(object sender, EventArgs e)
        {
            this.dtFecNacDad.CustomFormat = "dd/MM/yyyy";
            this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
        }

        private void dtFecNacAux_ValueChanged(object sender, EventArgs e)
        {
            this.dtFecNacAux.CustomFormat = "dd/MM/yyyy";
            this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
        }

        private void dtFecNacMom_ValueChanged(object sender, EventArgs e)
        {
            this.dtFecNacMom.CustomFormat = "dd/MM/yyyy";
            this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
        }

        private void txtNomDad_Leave(object sender, EventArgs e)
        {
            VerificarUsuario(this.txtNomDad, this.txtUserDad);
        }

        private void txtNomMom_Leave(object sender, EventArgs e)
        {
            VerificarUsuario(this.txtNomMom, this.txtUserMom);
        }

        private void txtNomAux_Leave(object sender, EventArgs e)
        {
            VerificarUsuario(this.txtNomAux, this.txtUserAux);
        }

        private void dtFecNacAux_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void chkExPad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
               // this.txtApeDad.Focus();

                 this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void chkExMad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // this.txtApeDad.Focus();

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void chkExAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // this.txtApeDad.Focus();

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtUserDad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // this.txtApeDad.Focus();

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtUserMom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // this.txtApeDad.Focus();

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtUserAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.btnAceptarAlu.Focus();

               // this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void formResponsable(int responsable)
        {
            frmBuscarResponsable frmbus = new frmBuscarResponsable();
            frmbus.FormClosed += new FormClosedEventHandler(formResposanble_FormClosed);
            frmbus.Tag = responsable;
            frmbus.ShowDialog();
        }

        private void btnBuscarPadre_Click(object sender, EventArgs e)
        {
            formResponsable(1);
        }


        private void formResposanble_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBuscarResponsable ver = (frmBuscarResponsable)sender;
           
            string idresponsable = ver._txtIdResponsable;
            int panel = Convert.ToInt32(ver.Tag)-1;

            if (utilitarios.IsNumeric(idresponsable))
            {
                CargaResponsables2(Convert.ToInt32(idresponsable),panel);
             //   HabDescheckboxPadre(true);

            }
            else
            {
             //   HabDescheckboxPadre(false);
               
            }

        }

        private void CargaResponsables2(int pIdResponsable,int panel)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("_Opcion", DbDirection.Input, "R"));
            parameters.Add(new DbParameter("_IdAlumno", DbDirection.Input, pIdResponsable));

            DataTable dtpadres = DBMapeo.ProcedureSelect("cnsResponsablesAlumno", parameters);
            int i = 0;
            switch (panel)
                {
                    case 0:
                        {
                            object pIdParentesco = dtpadres.Rows[i]["IdParentesco"];
                            if (pIdParentesco != DBNull.Value)
                                this.cboParentDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdParentesco"]);

                            this.txtCodDad.Text = dtpadres.Rows[i]["IdResponsable"].ToString();
                            this.txtNomDad.Text = dtpadres.Rows[i]["nombre"].ToString();
                            this.txtApeDad.Text = dtpadres.Rows[i]["apellido"].ToString();

                            object pIdNacionalidad = dtpadres.Rows[i]["IdNacionalidad"];
                            if (pIdNacionalidad != DBNull.Value)
                                this.cboNacDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdNacionalidad"]);

                            this.txtDomDad.Text = dtpadres.Rows[i]["domicilio"].ToString();

                            object pIdCiudad = dtpadres.Rows[i]["IdCiudad"];
                            if (pIdCiudad != DBNull.Value)
                                this.cboCiudadDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdCiudad"]);

                            this.txtCelDad.Text = dtpadres.Rows[i]["celular"].ToString();
                            this.txtTelDomDad.Text = dtpadres.Rows[i]["telefono_domicilio"].ToString();
                            this.txtMailDad.Text = dtpadres.Rows[i]["email"].ToString();
                            object pIdProfesion = dtpadres.Rows[i]["IdProfesion"];
                            if (pIdProfesion != DBNull.Value)
                                this.cboProfDad.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdProfesion"]);

                            this.txtEmpDad.Text = dtpadres.Rows[i]["empresa"].ToString();
                            this.txtDomLabDad.Text = dtpadres.Rows[i]["direccion_laboral"].ToString();
                            this.txtCargoDad.Text = dtpadres.Rows[i]["cargo"].ToString();
                            this.txtTelLabDad.Text = dtpadres.Rows[i]["telefono_laboral"].ToString();
                            this.txtCIDad.Text = dtpadres.Rows[i]["CI"].ToString();
                            this.txtRucDad.Text = dtpadres.Rows[i]["RUC"].ToString();
                            object dtFechaDad = dtpadres.Rows[i]["fecha_nac"];
                            if (dtFechaDad != DBNull.Value)
                            {
                                this.dtFecNacDad.CustomFormat = "dd/MM/yyyy";
                                this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
                                this.dtFecNacDad.Value = Convert.ToDateTime(dtFechaDad);
                            }
                            else
                            {
                                this.dtFecNacDad.CustomFormat = " ";
                                this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
                            }

                            if (dtpadres.Rows[i]["ExAlumno"].ToString() == "0")
                                this.chkExPad.Checked = false;
                            else
                                this.chkExPad.Checked = true;

                            this.txtUserDad.Text = dtpadres.Rows[i]["UsuarioSil"].ToString();
                            if (this.txtUserDad.Text.Length > 0)
                                this.btnPadreSil.Visible = true;
                            else
                                this.btnPadreSil.Visible = false;

                            break;
                        }
                    case 1:
                        {
                            object pIdParentesco = dtpadres.Rows[i]["IdParentesco"];
                            if (pIdParentesco != DBNull.Value)
                                this.cboParentMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdParentesco"]);

                            this.txtCodMom.Text = dtpadres.Rows[i]["IdResponsable"].ToString();
                            this.txtNomMom.Text = dtpadres.Rows[i]["nombre"].ToString();
                            this.txtApeMom.Text = dtpadres.Rows[i]["apellido"].ToString();

                            object pIdNacionalidad = dtpadres.Rows[i]["IdNacionalidad"];
                            if (pIdNacionalidad != DBNull.Value)
                                this.cboNacMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdNacionalidad"]);

                            this.txtDomMom.Text = dtpadres.Rows[i]["domicilio"].ToString();

                            object pIdCiudad = dtpadres.Rows[i]["IdCiudad"];
                            if (pIdCiudad != DBNull.Value)
                                this.cboCiudadMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdCiudad"]);

                            this.txtCelMom.Text = dtpadres.Rows[i]["celular"].ToString();
                            this.txtTelDomMom.Text = dtpadres.Rows[i]["telefono_domicilio"].ToString();
                            this.txtMailMom.Text = dtpadres.Rows[i]["email"].ToString();
                            object pIdProfesion = dtpadres.Rows[i]["IdProfesion"];
                            if (pIdProfesion != DBNull.Value)
                                this.cboProfMom.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdProfesion"]);

                            this.txtEmpMom.Text = dtpadres.Rows[i]["empresa"].ToString();
                            this.txtDomLabMom.Text = dtpadres.Rows[i]["direccion_laboral"].ToString();
                            this.txtCargoMom.Text = dtpadres.Rows[i]["cargo"].ToString();
                            this.txtTelLabMom.Text = dtpadres.Rows[i]["telefono_laboral"].ToString();
                            this.txtCIMom.Text = dtpadres.Rows[i]["CI"].ToString();
                            this.txtRucMom.Text = dtpadres.Rows[i]["RUC"].ToString();
                            object dtFechaMom = dtpadres.Rows[i]["fecha_nac"];
                            if (dtFechaMom != DBNull.Value)
                            {
                                this.dtFecNacMom.CustomFormat = "dd/MM/yyyy";
                                this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
                                this.dtFecNacMom.Value = Convert.ToDateTime(dtFechaMom);
                            }
                            else
                            {
                                this.dtFecNacMom.CustomFormat = " ";
                                this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
                            }

                            if (dtpadres.Rows[i]["ExAlumno"].ToString() == "0")
                                this.chkExMad.Checked = false;
                            else
                                this.chkExMad.Checked = true;

                            this.txtUserMom.Text = dtpadres.Rows[i]["UsuarioSil"].ToString();
                            if (this.txtUserMom.Text.Length > 0)
                                this.btnMadreSil.Visible = true;
                            else
                                this.btnMadreSil.Visible = false;
                            break;
                        }

                    case 2:
                        {
                            object pIdParentesco = dtpadres.Rows[i]["IdParentesco"];
                            if (pIdParentesco != DBNull.Value)
                                this.cboParentAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdParentesco"]);

                            this.txtCodAux.Text = dtpadres.Rows[i]["IdResponsable"].ToString();
                            this.txtNomAux.Text = dtpadres.Rows[i]["nombre"].ToString();
                            this.txtApeAux.Text = dtpadres.Rows[i]["apellido"].ToString();

                            object pIdNacionalidad = dtpadres.Rows[i]["IdNacionalidad"];
                            if (pIdNacionalidad != DBNull.Value)
                                this.cboNacAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdNacionalidad"]);

                            this.txtDomAux.Text = dtpadres.Rows[i]["domicilio"].ToString();

                            object pIdCiudad = dtpadres.Rows[i]["IdCiudad"];
                            if (pIdCiudad != DBNull.Value)
                                this.cboCiudadAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdCiudad"]);

                            this.txtCelAux.Text = dtpadres.Rows[i]["celular"].ToString();
                            this.txtTelDomAux.Text = dtpadres.Rows[i]["telefono_domicilio"].ToString();
                            this.txtMailAux.Text = dtpadres.Rows[i]["email"].ToString();
                            object pIdProfesion = dtpadres.Rows[i]["IdProfesion"];
                            if (pIdProfesion != DBNull.Value)
                                this.cboProfAux.SelectedValue = Convert.ToInt32(dtpadres.Rows[i]["IdProfesion"]);

                            this.txtEmpAux.Text = dtpadres.Rows[i]["empresa"].ToString();
                            this.txtDomLabAux.Text = dtpadres.Rows[i]["direccion_laboral"].ToString();
                            this.txtCargoAux.Text = dtpadres.Rows[i]["cargo"].ToString();
                            this.txtTelLabAux.Text = dtpadres.Rows[i]["telefono_laboral"].ToString();
                            this.txtCIAux.Text = dtpadres.Rows[i]["CI"].ToString();
                            this.txtRucAux.Text = dtpadres.Rows[i]["RUC"].ToString();
                            object dtFechaAux = dtpadres.Rows[i]["fecha_nac"];
                            if (dtFechaAux != DBNull.Value)
                            {
                                this.dtFecNacAux.CustomFormat = "dd/MM/yyyy";
                                this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
                                this.dtFecNacAux.Value = Convert.ToDateTime(dtFechaAux);
                            }
                            else
                            {
                                this.dtFecNacAux.CustomFormat = " ";
                                this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
                            }

                            if (dtpadres.Rows[i]["ExAlumno"].ToString() == "0")
                                this.chkExAux.Checked = false;
                            else
                                this.chkExAux.Checked = true;

                            this.txtUserAux.Text = dtpadres.Rows[i]["UsuarioSil"].ToString();
                            if (this.txtUserAux.Text.Length > 0)
                                this.btnAuxSil.Visible = true;
                            else
                                this.btnAuxSil.Visible = false;
                            break;

                        }


                }
          

            dtpadres.Clear();
        }

        private void rbDadNo_Click(object sender, EventArgs e)
        {
          //  this.btnBuscarPadre.Enabled= true;
            limpiarpaneles(1);

        }

        private void rbDadSi_Click(object sender, EventArgs e)
        {
            limpiarpaneles(1);
            CargaResponsables3(1);
        }

        private void btnBuscarMadre_Click(object sender, EventArgs e)
        {
            formResponsable(2);
        }

        private void CargaResponsables3(int panel)
        {
            if (panel <= dtpadrescopia.Rows.Count)
            {
            DataRow row = dtpadrescopia.Rows[panel - 1];

          //  foreach (DataRow row in result)
        //    {
                switch (panel)
                {
                    case 1:
                        {
                            object pIdParentesco = row["IdParentesco"];
                            if (pIdParentesco != DBNull.Value)
                                this.cboParentDad.SelectedValue = Convert.ToInt32(row["IdParentesco"]);

                            this.txtCodDad.Text = row["IdResponsable"].ToString();
                            this.txtNomDad.Text = row["nombre"].ToString();
                            this.txtApeDad.Text = row["apellido"].ToString();

                            object pIdNacionalidad = row["IdNacionalidad"];
                            if (pIdNacionalidad != DBNull.Value)
                                this.cboNacDad.SelectedValue = Convert.ToInt32(row["IdNacionalidad"]);

                            this.txtDomDad.Text = row["domicilio"].ToString();

                            object pIdCiudad = row["IdCiudad"];
                            if (pIdCiudad != DBNull.Value)
                                this.cboCiudadDad.SelectedValue = Convert.ToInt32(row["IdCiudad"]);

                            this.txtCelDad.Text = row["celular"].ToString();
                            this.txtTelDomDad.Text = row["telefono_domicilio"].ToString();
                            this.txtMailDad.Text = row["email"].ToString();
                            object pIdProfesion = row["IdProfesion"];
                            if (pIdProfesion != DBNull.Value)
                                this.cboProfDad.SelectedValue = Convert.ToInt32(row["IdProfesion"]);

                            this.txtEmpDad.Text = row["empresa"].ToString();
                            this.txtDomLabDad.Text = row["direccion_laboral"].ToString();
                            this.txtCargoDad.Text = row["cargo"].ToString();
                            this.txtTelLabDad.Text = row["telefono_laboral"].ToString();
                            this.txtCIDad.Text = row["CI"].ToString();
                            this.txtRucDad.Text = row["RUC"].ToString();
                            object dtFechaDad = row["fecha_nac"];
                            if (dtFechaDad != DBNull.Value)
                            {
                                this.dtFecNacDad.CustomFormat = "dd/MM/yyyy";
                                this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
                                this.dtFecNacDad.Value = Convert.ToDateTime(dtFechaDad);
                            }
                            else
                            {
                                this.dtFecNacDad.CustomFormat = " ";
                                this.dtFecNacDad.Format = DateTimePickerFormat.Custom;
                            }

                            if (row["ExAlumno"].ToString() == "0")
                                this.chkExPad.Checked = false;
                            else
                                this.chkExPad.Checked = true;

                            this.txtUserDad.Text = row["UsuarioSil"].ToString();
                            if (this.txtUserDad.Text.Length > 0)
                                this.btnPadreSil.Visible = true;
                            else
                                this.btnPadreSil.Visible = false;

                            break;
                        }
                    case 2:
                        {
                            object pIdParentesco = row["IdParentesco"];
                            if (pIdParentesco != DBNull.Value)
                                this.cboParentMom.SelectedValue = Convert.ToInt32(row["IdParentesco"]);

                            this.txtCodMom.Text = row["IdResponsable"].ToString();
                            this.txtNomMom.Text = row["nombre"].ToString();
                            this.txtApeMom.Text = row["apellido"].ToString();

                            object pIdNacionalidad = row["IdNacionalidad"];
                            if (pIdNacionalidad != DBNull.Value)
                                this.cboNacMom.SelectedValue = Convert.ToInt32(row["IdNacionalidad"]);

                            this.txtDomMom.Text = row["domicilio"].ToString();

                            object pIdCiudad = row["IdCiudad"];
                            if (pIdCiudad != DBNull.Value)
                                this.cboCiudadMom.SelectedValue = Convert.ToInt32(row["IdCiudad"]);

                            this.txtCelMom.Text = row["celular"].ToString();
                            this.txtTelDomMom.Text = row["telefono_domicilio"].ToString();
                            this.txtMailMom.Text = row["email"].ToString();
                            object pIdProfesion =row["IdProfesion"];
                            if (pIdProfesion != DBNull.Value)
                                this.cboProfMom.SelectedValue = Convert.ToInt32(row["IdProfesion"]);

                            this.txtEmpMom.Text = row["empresa"].ToString();
                            this.txtDomLabMom.Text = row["direccion_laboral"].ToString();
                            this.txtCargoMom.Text = row["cargo"].ToString();
                            this.txtTelLabMom.Text = row["telefono_laboral"].ToString();
                            this.txtCIMom.Text = row["CI"].ToString();
                            this.txtRucMom.Text = row["RUC"].ToString();
                            object dtFechaMom = row["fecha_nac"];
                            if (dtFechaMom != DBNull.Value)
                            {
                                this.dtFecNacMom.CustomFormat = "dd/MM/yyyy";
                                this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
                                this.dtFecNacMom.Value = Convert.ToDateTime(dtFechaMom);
                            }
                            else
                            {
                                this.dtFecNacMom.CustomFormat = " ";
                                this.dtFecNacMom.Format = DateTimePickerFormat.Custom;
                            }

                            if (row["ExAlumno"].ToString() == "0")
                                this.chkExMad.Checked = false;
                            else
                                this.chkExMad.Checked = true;

                            this.txtUserMom.Text = row["UsuarioSil"].ToString();
                            if (this.txtUserMom.Text.Length > 0)
                                this.btnMadreSil.Visible = true;
                            else
                                this.btnMadreSil.Visible = false;
                            break;
                        }

                    case 3:
                        {
                            object pIdParentesco = row["IdParentesco"];
                            if (pIdParentesco != DBNull.Value)
                                this.cboParentAux.SelectedValue = Convert.ToInt32(row["IdParentesco"]);

                            this.txtCodAux.Text = row["IdResponsable"].ToString();
                            this.txtNomAux.Text = row["nombre"].ToString();
                            this.txtApeAux.Text = row["apellido"].ToString();

                            object pIdNacionalidad = row["IdNacionalidad"];
                            if (pIdNacionalidad != DBNull.Value)
                                this.cboNacAux.SelectedValue = Convert.ToInt32(row["IdNacionalidad"]);

                            this.txtDomAux.Text = row["domicilio"].ToString();

                            object pIdCiudad = row["IdCiudad"];
                            if (pIdCiudad != DBNull.Value)
                                this.cboCiudadAux.SelectedValue = Convert.ToInt32(row["IdCiudad"]);

                            this.txtCelAux.Text = row["celular"].ToString();
                            this.txtTelDomAux.Text = row["telefono_domicilio"].ToString();
                            this.txtMailAux.Text = row["email"].ToString();
                            object pIdProfesion = row["IdProfesion"];
                            if (pIdProfesion != DBNull.Value)
                                this.cboProfAux.SelectedValue = Convert.ToInt32(row["IdProfesion"]);

                            this.txtEmpAux.Text = row["empresa"].ToString();
                            this.txtDomLabAux.Text = row["direccion_laboral"].ToString();
                            this.txtCargoAux.Text = row["cargo"].ToString();
                            this.txtTelLabAux.Text = row["telefono_laboral"].ToString();
                            this.txtCIAux.Text = row["CI"].ToString();
                            this.txtRucAux.Text =row["RUC"].ToString();
                            object dtFechaAux = row["fecha_nac"];
                            if (dtFechaAux != DBNull.Value)
                            {
                                this.dtFecNacAux.CustomFormat = "dd/MM/yyyy";
                                this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
                                this.dtFecNacAux.Value = Convert.ToDateTime(dtFechaAux);
                            }
                            else
                            {
                                this.dtFecNacAux.CustomFormat = " ";
                                this.dtFecNacAux.Format = DateTimePickerFormat.Custom;
                            }

                            if (row["ExAlumno"].ToString() == "0")
                                this.chkExAux.Checked = false;
                            else
                                this.chkExAux.Checked = true;

                            this.txtUserAux.Text = row["UsuarioSil"].ToString();
                            if (this.txtUserAux.Text.Length > 0)
                                this.btnAuxSil.Visible = true;
                            else
                                this.btnAuxSil.Visible = false;
                            break;

                        }


                }
           }

           
        }

        private void rbMomSi_Click(object sender, EventArgs e)
        {
            limpiarpaneles(2);
            CargaResponsables3(2);
        }

        private void rbAuxSi_Click(object sender, EventArgs e)
        {
            limpiarpaneles(3);
            CargaResponsables3(3);
        }

        private void rbMomNo_Click(object sender, EventArgs e)
        {
            limpiarpaneles(2);
        }

        private void rbAuxNo_Click(object sender, EventArgs e)
        {
            limpiarpaneles(3);
        }

        private void DGHermanos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int anho = Convert.ToInt32(DGHermanos["AnoLectivo", DGHermanos.CurrentRow.Index].Value.ToString()); ;
            int tip = Convert.ToInt32(DGHermanos["IdAlumno1", DGHermanos.CurrentRow.Index].Value.ToString());
          
            int idalumno =Convert.ToInt32( DGHermanos["IdAlumno1", DGHermanos.CurrentRow.Index].Value.ToString());
            lblCodigoAlumno.Text = DGHermanos["IdAlumno1", DGHermanos.CurrentRow.Index].Value.ToString() ;
            string matricula = DGHermanos["Matricula1", DGHermanos.CurrentRow.Index].Value.ToString();
            string[] idmat = matricula.Split('/');
            int matr = Convert.ToInt32(idmat[0]);
            int indice = Convert.ToInt32(idmat[1]);
            limpiarControles();
            this.Tag = 1;
            CargaAlumno(idalumno, anho);

            CargarHermanos2(matr, idalumno, indice);
            limpiarpaneles(0);
            CargaResponsables(idalumno);
            utilitarios.ScrollToUp(this.tabIns);
          //  tabFicha.SelectedTab = tabIns;
        }


        private int GenerarUsuarioSil(int idresponsable,string iduser,string matricula,string nombre,string tipousuario)
        {
           

            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pIdResponsable", DbDirection.Input, idresponsable));
            parameters.Add(new DbParameter("pIdUser", DbDirection.Input, iduser));
            parameters.Add(new DbParameter("pMatricula", DbDirection.Output, matricula));
            parameters.Add(new DbParameter("pTipoUsuario", DbDirection.Input, tipousuario));
            parameters.Add(new DbParameter("pNombre", DbDirection.Input, nombre));
            int retorno = DBMapeo.ExecuteNonQuery("MySQLConnection2", "spUserOnline", parameters);
            return retorno; 
        }

        private void btnPadreSil_Click(object sender, EventArgs e)
        {
            this.btnPadreSil.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            int ret = 0;
            int idresponsable = Convert.ToInt32(this.txtCodDad.Text);
            string iduser = this.txtUserDad.Text;
            string nombre = this.txtNomDad.Text + ", " + this.txtApeDad.Text;
            if (idresponsable > 0 && iduser.Length > 0)
            {
                if (iduser != this.txtUserMom.Text && iduser != this.txtUserAux.Text)
                {
                    ret = GenerarUsuarioSil(idresponsable, iduser, CodMatricula.ToString(), nombre,"P");
                    if (ret > 0)
                        MessageBox.Show("Usuario Reseteado , Usuario : " + iduser + "  Contraseña : " + CodMatricula);
                    else
                        MessageBox.Show("Intente de nuevo por favor!!");
                }
                else
                {
                    if (iduser == this.txtUserMom.Text)
                        MessageBox.Show("Madre ya tiene este usuario");
                    else
                    {   if (iduser == this.txtUserAux.Text)
                        MessageBox.Show("Auxiliar ya tiene este usuario");
                    }
                    
                }
            }
            
            Cursor.Current = Cursors.Default;
            this.btnPadreSil.Enabled = true;
        }

        private void btnMadreSil_Click(object sender, EventArgs e)
        {
            this.btnMadreSil.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            int ret = 0;
            int idresponsable = Convert.ToInt32(this.txtCodMom.Text);
            string iduser = this.txtUserMom.Text;
            string nombre = this.txtNomMom.Text + ", " + this.txtApeMom.Text;
            if (iduser != this.txtUserDad.Text && iduser != this.txtUserAux.Text)
            {
                ret = GenerarUsuarioSil(idresponsable, iduser, CodMatricula.ToString(), nombre, "P");
                if (ret > 0)
                    MessageBox.Show("Usuario Reseteado , Usuario : " + iduser + "  Contraseña : " + CodMatricula);
                else
                    MessageBox.Show("Intente de nuevo por favor!!");
            }
            else
            {
                if (iduser == this.txtUserDad.Text)
                    MessageBox.Show("Padre ya tiene este usuario");
                else
                {
                    if (iduser == this.txtUserAux.Text)
                        MessageBox.Show("Auxiliar ya tiene este usuario");
                }

            }
            Cursor.Current = Cursors.Default;
            this.btnMadreSil.Enabled = true;
        }

        private void btnAuxSil_Click(object sender, EventArgs e)
        {
            this.btnAuxSil.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            int ret = 0;
            int idresponsable = Convert.ToInt32(this.txtCodAux.Text);
            string iduser = this.txtUserAux.Text;
            string nombre = this.txtNomAux.Text + ", " + this.txtApeAux.Text;
            if (iduser != this.txtUserMom.Text && iduser != this.txtUserDad.Text)
            {
                ret = GenerarUsuarioSil(idresponsable, iduser, CodMatricula.ToString(), nombre,"P");
                if (ret > 0)
                    MessageBox.Show("Usuario Reseteado, Usuario : " + iduser + "  Contraseña : " + CodMatricula);
                else
                    MessageBox.Show("Intente de nuevo por favor!!");
            }
            else
            {
                if (iduser == this.txtUserMom.Text)
                    MessageBox.Show("Madre ya tiene este usuario");
                else
                {
                    if (iduser == this.txtUserDad.Text)
                        MessageBox.Show("Padre ya tiene este usuario");
                }

            }
            Cursor.Current = Cursors.Default;
            this.btnAuxSil.Enabled = true;
        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numAno2_ValueChanged(object sender, EventArgs e)
        {
            DateTime value1 = new DateTime(Convert.ToInt32(this.numAno2.Value), 1, 31);
            this.dtFechaInicio.Value = value1;
            DateTime value2 = new DateTime(Convert.ToInt32(this.numAno2.Value), 12, 31);
            this.dtFechaFin.Value = value2;
            CargarTipoDescuento(Convert.ToInt32(this.numAno2.Value), 0);
        }

        private void dtFechaFin_CloseUp(object sender, EventArgs e)
        {

            if (dtFechaFin.Value.Month < 12)
            {
                MessageBox.Show("Se pondrá al alumno en estado Inactivo");
                this.rdInactivo.Checked = true;
            }
        }

        public void tabActivo(int tab)
        {
            if (tab == 1)
                tabFicha.SelectedTab = tabIns;
            else
                tabFicha.SelectedTab = tabFic;
        }


        private void VerDescuento(int pMatricula)
        {
            string sql = "spDescuentos";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, Convert.ToInt32(this.numAno2.Value)));
            parameters.Add(new DbParameter("pMatricula", DbDirection.Input, pMatricula));
            parameters.Add(new DbParameter("pIdDescuento", DbDirection.Output, 0));
            DBMapeo.ExecuteNonQuery(sql, parameters);
            int iddescuento= Convert.ToInt32(DBMapeo.OutParameters[0].Value.ToString());
            this.cboDescuento.SelectedValue = iddescuento;
        }

        private void dtFechaInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void dtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void rdActivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void rdInactivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void frminscripcion_Shown(object sender, EventArgs e)
        {
            this.txtApellido.Focus();
            utilitarios.ScrollToUp(this.tabIns);
        }

        private void chkSi_Click(object sender, EventArgs e)
        {
            chkNo.Checked = false;
            EjecutarSINO();
        }

        private void chkNo_Click(object sender, EventArgs e)
        {
            chkSi.Checked = false;
          
            EjecutarSINO();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(192, 192, 255), Color.Gold, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, rc);
            }    
        }

       

        private void frminscripcion_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            btnImprimir.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            GenerarFicha(CodAlumno, 0, Convert.ToInt32(this.numAno2.Value));
            Cursor.Current = Cursors.Default;
            btnImprimir.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.lblDatPersonales.Text == "1- DATOS PERSONALES DEL ALUMNO")
            {
                MostrarCuentas();
                this.btnAlumSil.Visible = false;
            }
            else
            {
              this.lblDatPersonales.Text = "1- DATOS PERSONALES DEL ALUMNO";
              this.panel7.Visible = false;
              this.btnDatosCuentas.Text = "::Cuentas::";
              this.btnAlumSil.Visible = true;
              this.txtApellido.Focus();

            }
        }

        private void MostrarCuentas()
        {
            this.lblDatPersonales.Text = "1- ESTADO DE CUENTA DEL ALUMNO";
            this.panel7.Visible = true;
            this.btnDatosCuentas.Text = "::Datos::"; 
        }

        private void dataGridCuentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridCuentas.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToInt32(Myrow.Cells["Multa"].Value)>0 && Convert.ToInt32(Myrow.Cells["Saldo"].Value)>0)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Tomato;
                }
               
            }
        }

        private int Prematriculados(int pIdAlumno)
        {
            int retorno = 0;
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, pIdAlumno));
            parameters.Add(new DbParameter("pMat", DbDirection.Output, null));

            DBMapeo.ExecuteNonQuery("spPrematriculados", parameters);
            retorno = Convert.ToInt32(DBMapeo.OutParameters[0].Value.ToString());
            return retorno;
        }

        private void btnPrematricular_Click(object sender, EventArgs e)
        {
            if (btnPrematricular.Text == " Pre-Matricular " || btnPrematricular.Text == " Matricular ")
            {
                 Char pad = Convert.ToChar("-");
                 string str = "¿ Estas seguro que desea"+ btnPrematricular.Text +"a :  " + "\r";
                 str = str.PadRight(88, pad) + "\r"  + this.lblNomComp.Text;

                 if (MessageBox.Show(str, "Pre-Matricular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                 {
                     List<DbParameter> parameters = new List<DbParameter>();
                     parameters.Add(new DbParameter("_VerTodoPago", DbDirection.Input, "N"));
                     parameters.Add(new DbParameter("_IdAlumno", DbDirection.Input, CodAlumno));
                     DBMapeo.ExecuteNonQuery("prcPreMatricular", parameters);
                     this.Tag = 1;
                     panel2.Visible = false;
                     mDir = panel2.Visible ? -10 :10;
                     panel2.Width = 0;
                     panel2.Visible = true;
                     timer1.Enabled = true;
                    // Color guardar = this.panel2.BackColor;
                     CargaAlumno(CodAlumno, Convert.ToInt32(this.numAno2.Value) + 1);
                    // this.panel2.BackColor = Color.Beige;
                     //Application.DoEvents();
                   //  Thread.Sleep(5000);
                    // this.panel2.BackColor = guardar;
                     
                 }
            }
            else
            {
                this.Tag = 1;
                int anoelegido =Convert.ToInt32( this.numAno2.Value);
                if (btnPrematricular.Text == "Ver Matricula")
                    anoelegido--;
                else
                    anoelegido++;
                CargaAlumno(CodAlumno, anoelegido);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int width = panel2.Width + mDir;
            if (width >= mWidth)
            {
                width = mWidth;
                timer1.Enabled = false;
            }
            else if (width < Math.Abs(mDir))
            {
                width = 0;
                timer1.Enabled = false;
                panel2.Visible = false;
            }
            panel2.Width = width;
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
         
        }

        private void btnObservaciones_Click(object sender, EventArgs e)
        {
            frmObservaciones frm = new frmObservaciones();
           // frm.MdiParent = this;
            frm._txtIdAlumno = CodAlumno;
            frm.Show();
        }

        private void btnAlumSil_Click(object sender, EventArgs e)
        {
           
            this.btnAlumSil.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            GrabarAlumno();
        
            int idresponsable = Convert.ToInt32(this.lblCodigoAlumno.Text);
         
            int ret = 0;

            string iduser = this.txtCedula.Text.Replace(".", "").Replace("-", "");
            string nombre = this.txtNombre.Text + ", " + this.txtApellido.Text;
            string contrasenha = "sil" + DateTime.Now.Year.ToString();
            if (iduser.Length > 5 && idresponsable>0)
            {
                ret = GenerarUsuarioSil(idresponsable, iduser, contrasenha, nombre, "A");
                if (ret > 0)
                    MessageBox.Show("Usuario Reseteado , Usuario : " + iduser + "  Contraseña : " + contrasenha);
                else
                    MessageBox.Show("Intente de nuevo por favor!!");
            }
            else
            {
                if (idresponsable.ToString().Length==0 || idresponsable==0)
                    MessageBox.Show("Alumno todavía no se matriculo!!!");
                else
                {
                    if (iduser.Length < 6)
                        MessageBox.Show("Verifique la Cedula de Identidad");
                }

            }
            Cursor.Current = Cursors.Default;
            this.btnAlumSil.Enabled = true;

        }

        private void btnCuota_Click(object sender, EventArgs e)
        {
            frmOtroIngresos frm = new frmOtroIngresos();
            frm._txtIdAlumno = CodAlumno;
            frm._txtAno = Convert.ToInt32(this.numAno2.Value);
            frm.FormClosed += new FormClosedEventHandler(Inicio_FormClosed_1);
            frm.Show();
        }

        private void Inicio_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            CuentasAlumno(CodAlumno);
        }

        private void dataGridCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridCuentas.Rows.Count == 0)
                return;


            int intIndice;
            intIndice = e.RowIndex; // dvgGrilla.Rows(e.RowIndex).Cells("IdPagosGenerales").Value
            string valor=dataGridCuentas.Rows[intIndice].Cells["IdTipoIngreso"].Value.ToString() ;
            decimal mn = Convert.ToDecimal(dataGridCuentas.Rows[intIndice].Cells["MontoNeto"].Value.ToString());
            decimal sa = Convert.ToDecimal(dataGridCuentas.Rows[intIndice].Cells["Saldo"].Value.ToString());

            if( (valor == "89" || valor == "90" ) && mn==sa && mn>0)
            {
                //'confirmar
                if (MessageBox.Show("Desea eliminar el Item?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int pId = Convert.ToInt32(dataGridCuentas.Rows[intIndice].Cells["IdPagosGenerales"].Value.ToString()); ;
                    List<DbParameter> parameters = new List<DbParameter>();
                    parameters.Add(new DbParameter("pIdPagosGenerales", DbDirection.Input, pId));
                    DBMapeo.ExecuteNonQuery("spBorrarItemPagosGenerales", parameters);
                    CuentasAlumno(CodAlumno);
                }
            }


        }
       
    }
}
