using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Medusa;
using CrystalDecisions.CrystalReports.Engine;

namespace SilAdministracion
{
    public partial class frmRepMatriculados : Form
    {
        DBUtils DBMapeo = new DBUtils();
        string pathReport = ConfigurationManager.AppSettings["ReportesPath"].ToString() + "\\crMatriculados.rpt";
        public frmRepMatriculados()
        {
            InitializeComponent();
        }

        private void frmRepMatriculados_Load(object sender, EventArgs e)
        {

            CargarAnho();

            int vAno = Convert.ToInt32(this.numAnho.Value);
            int vNuevo = this.chkNuevos.Checked ? 1 : 0;
            int vMat = this.chkMat.Checked ? 1 : 0;
            CargarComboSeccion(0);
            CargarComboCurso();
            CargarComboNivel();

            this.cbEstado.SelectedIndex = 0;
       
            this.cboOrden.SelectedIndex = 0;
           


            ReportDocument rpt = new ReportDocument();
            rpt.Load(pathReport);

            string sql = "spReporteMatPreFut";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, vAno));
            parameters.Add(new DbParameter("pMatriculaPagada", DbDirection.Input, vMat));
            parameters.Add(new DbParameter("pNuevo", DbDirection.Input, vNuevo));
           
            DataTable dt = new DataTable("DtMatriculados");
            dt= DBMapeo.ProcedureSelect(sql, parameters).Copy();

            DataTable dtresalumno = new DataTable("DtResponsableAlumno");
            DataTable dtresponsable = new DataTable("DtResponsables");
            DataSet data = DBMapeo.ProcedureDataSet("spListaResponsableAlumnos", null);
            DataSet Ds = new DataSet();
            dtresalumno = data.Tables[0].Copy();
            dtresponsable = data.Tables[1].Copy();
        
            Ds.Tables.Add(dt);
            Ds.Tables[0].TableName = "DtMatriculados";
            Ds.Tables.Add(dtresalumno);
            Ds.Tables[1].TableName = "DtResponsableAlumno";
            Ds.Tables.Add(dtresponsable);
            Ds.Tables[2].TableName = "DtResponsables";
            DataColumn colParent =
            Ds.Tables["DtMatriculados"].Columns["IdAlumno"];
            DataColumn colChild =
                 Ds.Tables["DtResponsableAlumno"].Columns["IdAlumno"];

            DataColumn colParent2 =
               Ds.Tables["DtResponsables"].Columns["IdResponsable"];
            DataColumn colChild2 =
                Ds.Tables["DtResponsableAlumno"].Columns["IdResponsable"];
            DataRelation drAlumnoId =
                 new DataRelation("AlumnoId", colParent, colChild,false);

            DataRelation drAlumnoId2 =
                new DataRelation("AlumnoId2", colParent2, colChild2,false);



            Ds.Relations.Add(drAlumnoId);
            Ds.Relations.Add(drAlumnoId2);

            rpt.SetDataSource(Ds);
       
          
            rpt.SetParameterValue("PorPagina", "N");
            rpt.SetParameterValue("DetalleResp", "N");
            rpt.SetParameterValue("Parametros", "Año : " + vAno.ToString() + "- Estado : Todos -  Nivel : Todos - Division : Todos - Curso/Grado : Todos - Seccion : Todos ");
           

        
            this.crystalReportViewer1.ReportSource = rpt;   
            

          
          

        }

        private void CargarAnho()
        {
            string sql = "spAnhos";
            List<DbParameter> parametro = new List<DbParameter>();
            DataTable dtCombo = DBMapeo.ProcedureSelect(sql, null);
            decimal minimo=0,maximo=0;
            if (dtCombo.Rows.Count>0)
            { minimo = Convert.ToInt32(dtCombo.Rows[0][0]); 
              maximo = Convert.ToInt32(dtCombo.Rows[dtCombo.Rows.Count-1][0]);
            }
            this.numAnho.Minimum = minimo;
            this.numAnho.Maximum = maximo;
            this.numAnho.Value = maximo - 1;
          
        }


        private void CargarComboCurso()
        {
            string sql = "spGradoCurso";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtgradocurso = DBMapeo.ProcedureSelect(sql, parameters);
            this.cboGradoCurso.DataSource = dtgradocurso;
            this.cboGradoCurso.ValueMember = "IdCursoGrado";
            this.cboGradoCurso.DisplayMember = "Descripcion";
           
        }


        private void CargarComboSeccion(int pCurso)
        {
            string sql = "spSeccionGrado";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pGrado", DbDirection.Input, pCurso));
            DataTable dtsecciongrado = DBMapeo.ProcedureSelect(sql, parameters);

            this.cboSeccion.DataSource = dtsecciongrado;
          
            this.cboSeccion.ValueMember = "IdSeccion";
            this.cboSeccion.DisplayMember = "Descripcion";
            this.cboSeccion.SelectedValue= 0;
         
        }

        private void CargarComboDivision(int pNivel)
        {
           string sql = "spDivision";
           List<DbParameter> parameters = new List<DbParameter>();
           parameters.Add(new DbParameter("pNivel", DbDirection.Input, pNivel));
           DataTable dtdivision = DBMapeo.ProcedureSelect(sql, parameters);
           this.cboDivision.ValueMember = "IdDivision";
           this.cboDivision.DisplayMember = "Division";
           this.cboDivision.DataSource = dtdivision;
           this.cboDivision.SelectedValue = 0;
        }

        private void CargarComboNivel()
        {
            string sql = "spNivel";
            DataTable dtnivel = DBMapeo.ProcedureSelect(sql, null);
            this.cboNivel.ValueMember = "IdNivel";
            this.cboNivel.DisplayMember = "Nivel";
            this.cboNivel.DataSource = dtnivel;
            this.cboNivel.SelectedValue= 0;
        }


        private void chkNuevos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAlumnos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkResponsables_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkRespDetalles_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboGradoCurso_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (utilitarios.IsNumeric(cboGradoCurso.SelectedValue.ToString()))
            CargarComboSeccion(Convert.ToInt16(cboGradoCurso.SelectedValue));

        }

        private void cboNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (utilitarios.IsNumeric(cboNivel.SelectedValue.ToString()))
            CargarComboDivision(Convert.ToInt32(this.cboNivel.SelectedValue));
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            int vAno = Convert.ToInt32(this.numAnho.Value);
            int vNuevo = this.chkNuevos.Checked ? 1 : 0;
            int vMat = this.chkMat.Checked ? 1 : 0;
          
            string strParametro="";
            string strCondicion = "";
            ReportDocument rpt = new ReportDocument();
            rpt.Load(pathReport);

            int valDiv=0;
            if (cboDivision.SelectedValue != null)
                valDiv =Convert.ToInt32( cboDivision.SelectedValue);

            string sql = "spReporteMatPreFut";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, vAno));
            parameters.Add(new DbParameter("pMatriculaPagada", DbDirection.Input, vMat));
            parameters.Add(new DbParameter("pNuevo", DbDirection.Input, vNuevo));

            DataTable dt = new DataTable("DtMatriculados");
            dt = DBMapeo.ProcedureSelect(sql, parameters).Copy();
           
            DataView dw= new DataView();
            dw.Table = dt;
            if (cboOrden.SelectedIndex==0)
                dw.Sort = "IdNivel, IdDivision, IdCursoGrado, IdSeccion, apellido,nombre ";
            else
                dw.Sort = "IdNivel, IdDivision, IdCursoGrado, IdSeccion, IdMatricula";

            strParametro += "Año : " + vAno.ToString() + "- ";
            switch (cbEstado.SelectedIndex)
            {
                case 0:
                    strParametro += "Estado : Todos - ";
                    strCondicion += "Estado>0 ";
                    break;
                case 1:
                    strCondicion += "Estado=1 ";
                    strParametro += "Estado : Activo - ";
                    break;
                case 2:
                    strCondicion += "Estado=2 ";
                    strParametro += "Estado : Inactivo - ";
                    break;
            }

            if ( cboNivel.SelectedIndex > 0 )
            {
                strCondicion += "and IdNivel = " + cboNivel.SelectedValue.ToString() + " ";
                strParametro += "Nivel : " + cboNivel.Text + " - ";
            }
            else
                strParametro += "Nivel : Todos - ";


            if (Convert.ToInt32(cboDivision.SelectedValue) > 0)
            {
                strCondicion += "and IdDivision = " + cboDivision.SelectedValue.ToString() + " ";
                strParametro += "Division : " + cboDivision.Text + " - ";
            }
            else
                strParametro += "Division : Todos - ";
          

            if( cboGradoCurso.SelectedIndex>0)
            {
                strCondicion += "and IdCursoGrado = " + cboGradoCurso.SelectedValue.ToString() + " ";
                strParametro += "Curso/Grado : " + cboGradoCurso.Text + " - ";
            }
            else
                strParametro += "Curso/Grado : Todos - ";
           

            if( Convert.ToInt32( cboSeccion.SelectedValue) > 0 )
            {
                strCondicion += "and IdSeccion = " + cboSeccion.SelectedValue.ToString() + " ";
                strParametro += "Seccion : " + cboSeccion.Text + " - ";
             }
            else
                strParametro += "Seccion : Todos ";
          


            dw.RowFilter = strCondicion;

            DataTable dtresalumno = new DataTable("DtResponsableAlumno");
            DataTable dtresponsable = new DataTable("DtResponsables");
            DataSet data = DBMapeo.ProcedureDataSet("spListaResponsableAlumnos", null);
            DataSet Ds = new DataSet();
            dtresalumno = data.Tables[0].Copy();
            dtresponsable = data.Tables[1].Copy();
            Ds.Tables.Add(dw.ToTable());
            Ds.Tables[0].TableName = "DtMatriculados";
            Ds.Tables.Add(dtresalumno);
            Ds.Tables[1].TableName = "DtResponsableAlumno";
            Ds.Tables.Add(dtresponsable);
            Ds.Tables[2].TableName = "DtResponsables";
            DataColumn colParent =
            Ds.Tables["DtMatriculados"].Columns["IdAlumno"];
            DataColumn colChild =
                 Ds.Tables["DtResponsableAlumno"].Columns["IdAlumno"];

            DataColumn colParent2 =
               Ds.Tables["DtResponsables"].Columns["IdResponsable"];
            DataColumn colChild2 =
                Ds.Tables["DtResponsableAlumno"].Columns["IdResponsable"];
            DataRelation drAlumnoId =
                 new DataRelation("AlumnoId", colParent, colChild, false);

            DataRelation drAlumnoId2 =
                new DataRelation("AlumnoId2", colParent2, colChild2, false);



            Ds.Relations.Add(drAlumnoId);
            Ds.Relations.Add(drAlumnoId2);

           rpt.SetDataSource(Ds);


           

            string pPorPagina = "N";
            if (this.chkAlumnos.Checked)
            {
                rpt.ReportDefinition.Sections["GroupFooterSection4"].SectionFormat.EnableNewPageBefore = true;
                rpt.ReportDefinition.Sections["GroupHeaderSection5"].SectionFormat.EnableSuppress = false;
                pPorPagina = "S";
            }
            else
            {
                rpt.ReportDefinition.Sections["GroupFooterSection4"].SectionFormat.EnableNewPageBefore = false;
                rpt.ReportDefinition.Sections["GroupHeaderSection5"].SectionFormat.EnableSuppress = true;
            }

            if (this.chkResponsables.Checked)

                rpt.ReportDefinition.Sections["Section3"].SectionFormat.EnableSuppress = false;
            else
                rpt.ReportDefinition.Sections["Section3"].SectionFormat.EnableSuppress = true;
           
           if(chkRespDetalles.Checked )
                rpt.SetParameterValue("DetalleResp", "S");
           else
                rpt.SetParameterValue("DetalleResp", "N");

           if (this.chkHermanos.Checked)

               rpt.ReportDefinition.Sections["Seccion10"].SectionFormat.EnableSuppress = false;
           else
               rpt.ReportDefinition.Sections["Seccion10"].SectionFormat.EnableSuppress = true;

            rpt.SetParameterValue("PorPagina", pPorPagina);
            rpt.SetParameterValue("Parametros", strParametro);
            this.crystalReportViewer1.ReportSource = rpt;



        }
    }
}
