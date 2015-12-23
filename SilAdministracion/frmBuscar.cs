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
    public partial class frmBuscar : Form
    {
        DBUtils DBMapeo = new DBUtils();
        string numhermano = "1";
        int Anho = DateTime.Now.Year;
        public frmBuscar()
        {
            InitializeComponent();
        }

        public string _txtMatricula
        {
            set { this.txtMatricula.Text = value; }
            get { return this.txtMatricula.Text; }
        }


        public string _txtIdAlumno
        {
            set { this.txtIdAlumno.Text = value; }
            get { return this.txtIdAlumno.Text; }
        }

        public string _txtNumHermano
        {
            set { numhermano = value; }
            get { return numhermano; }
        }


        public int _intAno
        {
            set { this.Anho = value; }
            get { return this.Anho; }
        }
        private void frmBuscar_Load(object sender, EventArgs e)
        {

        }

        private void tbBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                if (tbBuscar.Text.Length>0)
                    buscar();
            }
        }

        private void buscar()
        {
            string Opcion = "";
            int Matricula = 0;
            int NumHermano = 0;
            string buscar = tbBuscar.Text;
            if (utilitarios.IsNumeric(buscar))
            {
                Opcion = "M";
                Matricula = Convert.ToInt32( buscar);

            }
            else
            {
                if (buscar.Contains("/"))
                {
                  char t= Convert.ToChar("/");
                  string[] mat=  buscar.Split(t);
                 //busca con mat y nro hermano
                  Matricula =Convert.ToInt32( mat[0]);
                  NumHermano =Convert.ToInt32( mat[1]);
                  Opcion = "MN";

                }
                else
                {
                    buscar=buscar.Replace("'", "\'");
                   //  'busca por nombre
                   Opcion = "N";
                   buscar = buscar.Replace(" ", "%");
                   buscar = "%" + buscar + "%";
                }

            }


            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("_Opcion", DbDirection.Input, Opcion));
            parameters.Add(new DbParameter("_IdMatricula", DbDirection.Input, Matricula));
            parameters.Add(new DbParameter("_NumHermano", DbDirection.Input, NumHermano));
            parameters.Add(new DbParameter("_NombreApe", DbDirection.Input, buscar));
            DataTable dtope = DBMapeo.ProcedureSelect("cnsBuscaAlumno", parameters);
            this.DGAlumno.AutoGenerateColumns = false;
            this.DGAlumno.DataSource = dtope;
            if (this.DGAlumno.RowCount > 1)
            {
                this.DGAlumno.Focus();
                DGAlumno.Rows[0].Selected = true;
                foreach (DataGridViewRow dr in DGAlumno.Rows)
                {
                    switch (Convert.ToInt32(dr.Cells["Tip"].Value))
                    {
                        case 1:
                            dr.Cells["Referencia"].Style.BackColor = Color.DodgerBlue;
                            break;
                        case 2:
                            dr.Cells["Referencia"].Style.BackColor = Color.LightBlue;
                            break;
                        case 3:
                            dr.Cells["Referencia"].Style.BackColor = Color.LimeGreen;
                            break;
                        case 4:
                            dr.Cells["Referencia"].Style.BackColor = Color.Red;
                            break;
                    }
                }
            }

        }

        private void DGAlumno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionaralumno();
            this.Close();
        }

        private void DGAlumno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
               seleccionaralumno();
                this.Close();
            }
        }

        private void seleccionaralumno()
        {
            int rowindex = DGAlumno.CurrentRow.Index;
            int Id = Convert.ToInt32(DGAlumno["IdMatricula", rowindex].Value);
            int IdAlumno = Convert.ToInt32(DGAlumno["IdAlumno", rowindex].Value);
            this.txtMatricula.Text = Id.ToString();
            this.txtIdAlumno.Text = IdAlumno.ToString();
            string[] idmat =  DGAlumno["Matricula", rowindex].Value.ToString().Split('/');
            this.numhermano = idmat[1];
            this._intAno = Convert.ToInt32(DGAlumno["AnoLectivo", rowindex].Value);
 
        }


        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Escape:
                    {
                       this.Close();
                        return true;
                    }
              
            }
            return base.ProcessCmdKey(ref message, keys);
        }

    }
}
