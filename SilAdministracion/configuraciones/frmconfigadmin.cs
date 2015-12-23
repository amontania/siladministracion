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
    public partial class frmConfigAdmin : Form
    {
        DBUtils DBMapeo = new DBUtils();
        public frmConfigAdmin()
        {
            InitializeComponent();
        }

        private void frmConfigAdmin_Load(object sender, EventArgs e)
        {
            CargarTipoIngreso();
        }

        private void CargarTipoIngreso()
        {
            DataTable dtTipoIngreso = new DataTable();
            string sql = "spTipoIngresoNew";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));

            dtTipoIngreso = DBMapeo.ProcedureSelect(sql, parameters);
            this.DGTipoIngreso.DataSource = dtTipoIngreso;


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
             switch (this.tabControl1.SelectedTab.Name)
            {
                case "tabTipoIngreso":
                    CargarTipoIngreso();
                    this.DGTipoIngreso.Focus();
                    break;
           
             }
        }
    }
}
