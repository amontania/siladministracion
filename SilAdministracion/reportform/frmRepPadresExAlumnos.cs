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
  
    public partial class frmRepPadres : Form
    {
        DBUtils DBMapeo = new DBUtils();
        string pathReport = ConfigurationManager.AppSettings["ReportesPath"].ToString() + "\\rptPadresExAlumnos.rpt";
        public frmRepPadres()
        {
            InitializeComponent();
        }

        private void frmRepPadres_Load(object sender, EventArgs e)
        {
            CargarResponsable();
          
        }

        private void CargarResponsable()
        {

            DataTable dtresp = new DataTable("DtResponsables");
          
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
            dtresp.Columns.Add("Parentesco1");

            // Operacion 1 Carga Datos Padres Ex Alumnos
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtresponsables = DBMapeo.ProcedureSelect("spExAlumnosConHijos", parameters);
            int cantPadre = dtresponsables.Rows.Count;
            DataRow datarow;

            int i = 0;
            while (cantPadre > i)
            {
                datarow = dtresp.NewRow();

                datarow["IdResponsable1"] = Convert.ToInt32(dtresponsables.Rows[i]["IdResponsable"].ToString());
                datarow["ApeNom1"] = dtresponsables.Rows[i]["ApeNom"].ToString();

                object fecnac1 = dtresponsables.Rows[i]["fecha_nac"];
                if (fecnac1 != DBNull.Value)
                {
                    DateTime fecnacnuevo = Convert.ToDateTime(dtresponsables.Rows[i]["fecha_nac"]);
                    datarow["fecha_nac1"] = fecnacnuevo.Date.ToShortDateString();
                }

                datarow["nac1"] = dtresponsables.Rows[i]["Nacionalidad"].ToString();
                datarow["domicilio1"] = dtresponsables.Rows[i]["domicilio"].ToString();
                datarow["telefono_domicilio1"] = dtresponsables.Rows[i]["telefono_domicilio"].ToString();
                datarow["profesion1"] = dtresponsables.Rows[i]["profesion"].ToString(); ;
                datarow["empresa1"] = dtresponsables.Rows[i]["empresa"].ToString();
                datarow["celular1"] = dtresponsables.Rows[i]["celular"].ToString();
                datarow["ci1"] = dtresponsables.Rows[i]["ci"];
                datarow["direccion_laboral1"] = dtresponsables.Rows[i]["direccion_laboral"].ToString();
                datarow["telefono_laboral1"] = dtresponsables.Rows[i]["telefono_laboral"].ToString();
                datarow["email1"] = dtresponsables.Rows[i]["email"].ToString();
                datarow["Parentesco1"] = dtresponsables.Rows[i]["Parentesco"].ToString();
                dtresp.Rows.Add(datarow);
                i++;
            }


            DataTable dtalumno = new DataTable("DtDatosPerAlumnos");
            dtalumno.Columns.Add("IdAlumno");
            dtalumno.Columns.Add("NumHermano");
            dtalumno.Columns.Add("Apellido");
            dtalumno.Columns.Add("Nombre");
            dtalumno.Columns.Add("Matricula");
            dtalumno.Columns.Add("IdCursoGrado");
            dtalumno.Columns.Add("IdDivision");
            dtalumno.Columns.Add("Grado");
            dtalumno.Columns.Add("Seccion");
          



            // Operacion 1 Carga Datos Alumnos
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
            DataTable dtalu = DBMapeo.ProcedureSelect("spExAlumnosConHijos", parameter);
            int cantAlumno = dtalu.Rows.Count;
            int l = 0;
            while (cantAlumno > l)
            {

                DataRow datarowa = dtalumno.NewRow();
                datarowa["IdAlumno"] = Convert.ToInt32(dtalu.Rows[l]["IdAlumno"].ToString());
                datarowa["Matricula"] = dtalu.Rows[l]["IdMatricula"].ToString();
                datarowa["NumHermano"] = Convert.ToInt32(dtalu.Rows[l]["NumHermano"].ToString());
                datarowa["Apellido"] = dtalu.Rows[l]["apellido"].ToString();
                datarowa["Nombre"] = dtalu.Rows[l]["nombre"].ToString();
                datarowa["IdCursoGrado"] = Convert.ToInt32(dtalu.Rows[l]["IdCursoGrado"]);
                datarowa["IdDivision"] = dtalu.Rows[l]["IdDivision"].ToString();
                datarowa["Grado"] = dtalu.Rows[l]["CursoGrado"].ToString();
                datarowa["Seccion"] = dtalu.Rows[l]["Seccion"].ToString();
                dtalumno.Rows.Add(datarowa);
                l++;
            }


            DataTable dtresalu = new DataTable("DtAlumnosResponsables");
            dtresalu.Columns.Add("IdAlumno");
            dtresalu.Columns.Add("IdResponsable");

            // Operacion 1 Carga Datos Alumnos
            List<DbParameter> parameter3 = new List<DbParameter>();
            parameter3.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
            DataTable dtalumnopadre = DBMapeo.ProcedureSelect("spExAlumnosConHijos", parameter3);
            int cantAlumnoPadre = dtalumnopadre.Rows.Count;
            int j = 0;
            while (cantAlumnoPadre > j)
            {

                DataRow datarowa = dtresalu.NewRow();
                datarowa["IdAlumno"] = Convert.ToInt32(dtalumnopadre.Rows[j]["IdAlumno"].ToString());
                datarowa["IdResponsable"] = Convert.ToInt32(dtalumnopadre.Rows[j]["IdResponsable"].ToString());
                dtresalu.Rows.Add(datarowa);
                j++;
            }


            DataSet Ds = new DataSet();
            Ds.Tables.Add(dtresp);
            Ds.Tables.Add(dtalumno);
            Ds.Tables.Add(dtresalu);
            DataColumn colParent =
            Ds.Tables["DtResponsables"].Columns["IdResponsable1"];
            DataColumn colChild =
                 Ds.Tables["DtAlumnosResponsables"].Columns["IdResponsable"];
           
            
            DataColumn colChild3 =
               Ds.Tables["DtAlumnosResponsables"].Columns["IdAlumno"];


            DataColumn colParent2 =
                Ds.Tables["DtDatosPerAlumnos"].Columns["IdAlumno"];

            DataRelation drAlumnoId =
                 new DataRelation("AlumnoId", colParent, colChild);

            DataRelation drAlumnoId2 =
                new DataRelation("AlumnoId2", colParent2, colChild3);



            Ds.Relations.Add(drAlumnoId);
            Ds.Relations.Add(drAlumnoId2);

            //SilAdministracion.inscripciones...rptFichaInscripcion reporte = new SilAdministracion.inscripciones.rptFichaInscripcion();
            ReportDocument rpt = new ReportDocument();
            rpt.Load(pathReport);
            rpt.SetDataSource(Ds);
            //this.crystalReportViewer1.ReportSource = rpt; 
            //reporte.SetDataSource(Ds);
           // reporte.SetDataSource(Ds);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
