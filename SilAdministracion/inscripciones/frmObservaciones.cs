using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medusa;

namespace SilAdministracion
{
    public partial class frmObservaciones : Form
    {
        int alumno = 0;
        DBUtils DBMapeo = new DBUtils();
        public frmObservaciones()
        {
            InitializeComponent();
        }

        public int _txtIdAlumno
        {
            set { alumno = value; }
           
        }

        private void frmObservaciones_Load(object sender, EventArgs e)
        {
            CargaObservacion();

        }

        private void CargaObservacion()
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, alumno));
            parameters.Add(new DbParameter("pFechaDesde", DbDirection.Input, null));
            parameters.Add(new DbParameter("pFechaHasta", DbDirection.Input, null));
            parameters.Add(new DbParameter("pObservacion", DbDirection.Input, null));
            parameters.Add(new DbParameter("pId", DbDirection.Input, null));
            DataTable dtope = DBMapeo.ProcedureSelect("spObservaciones", parameters);
            this.DGObservaciones.AutoGenerateColumns = false;
            if (dtope.Rows.Count > 0)
            {
                this.lblTitulo.Visible = false;
                this.DGObservaciones.Visible = true;
                this.DGObservaciones.DataSource = dtope;
            }
            else
            {
                this.lblTitulo.Visible = true;
                this.DGObservaciones.Visible = false;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, alumno));
            parameters.Add(new DbParameter("pFechaDesde", DbDirection.Input, dtFechaInicio.Value));
            parameters.Add(new DbParameter("pFechaHasta", DbDirection.Input, dtFechaInicio.Value ));
            parameters.Add(new DbParameter("pObservacion", DbDirection.Input, txtObservacion.Text));
            parameters.Add(new DbParameter("pId", DbDirection.Input, null));

            int retorno = DBMapeo.ExecuteNonQuery("spObservaciones", parameters);
            CargaObservacion();

        }
    }
}
