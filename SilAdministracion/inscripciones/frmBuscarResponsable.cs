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
    public partial class frmBuscarResponsable : Form
    {
        DBUtils DBMapeo = new DBUtils();
        public frmBuscarResponsable()
        {
            InitializeComponent();
        }

        public string _txtIdResponsable
        {
            set { this.txtIdResponsable.Text = value; }
            get { return this.txtIdResponsable.Text; }
        }
        private void frmBuscarResponsable_Load(object sender, EventArgs e)
        {

        }

        private void tbBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbBuscar.Text.Length > 0)
                    buscar();
            }
        }


        private void buscar()
        {
            string Opcion = "";
           
            string buscar = tbBuscar.Text;
             buscar = buscar.Replace("'", "\'");
                    //  'busca por nombre
                    Opcion = "N";
                         


            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOption", DbDirection.Input, Opcion));
            parameters.Add(new DbParameter("pNombre", DbDirection.Input, buscar));

            DataTable dtope = DBMapeo.ProcedureSelect("spBuscaResponsable", parameters);
            this.DGPadres.AutoGenerateColumns = false;
            this.DGPadres.DataSource = dtope;

            if (DGPadres.RowCount > 1)
            {
                this.DGPadres.Focus();
                DGPadres.Rows[0].Selected = true;
                MostrarHijos();
            }

        }

        private void DGPadres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIdResponsable.Text = DGPadres["IdResponsable", e.RowIndex].Value.ToString();
            this.Close();
        }

        private void DGPadres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int rowindexStock = DGPadres.CurrentRow.Index;
                this.txtIdResponsable.Text = DGPadres["IdResponsable", rowindexStock].Value.ToString();
                this.Close();
            }
            else
                MostrarHijos();
          
        }

        public void MostrarHijos()
        {
            int rowindexAlumno = 0;
            if (DGPadres.RowCount > 0 && DGPadres.CurrentRow != null)
                rowindexAlumno = DGPadres.CurrentRow.Index;


            if (DGPadres.RowCount > 0)
            {
                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                parameters.Add(new DbParameter("pMat", DbDirection.Input, Convert.ToInt32(DGPadres["IdResponsable", rowindexAlumno].Value.ToString())));
                parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, 0));
                DataTable dtope = DBMapeo.ProcedureSelect("spBuscaAlumno", parameters);
              

                DGHermanos.DataSource = null;
                DGHermanos.AutoGenerateColumns = false;
               
                if (dtope.Rows.Count > 0)
                {
                    DGHermanos.DataSource = dtope;
                  
                }
            }


        }

        private void DGPadres_KeyPress(object sender, KeyPressEventArgs e)
        {
            MostrarHijos();
        }

        private void DGPadres_Enter(object sender, EventArgs e)
        {
            MostrarHijos();
        }

        private void DGPadres_Click(object sender, EventArgs e)
        {
            MostrarHijos();
        }

        private void DGPadres_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            MostrarHijos();
        }

        private void DGPadres_KeyUp(object sender, KeyEventArgs e)
        {
            MostrarHijos();
        }
    }
}
