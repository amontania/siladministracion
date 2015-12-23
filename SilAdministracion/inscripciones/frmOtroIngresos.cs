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
    public partial class frmOtroIngresos : Form
    {
        int alumno = 0;
        int ano = DateTime.Now.Year;
        DBUtils DBMapeo = new DBUtils();
        DataTable dtCuota = new DataTable();
        public frmOtroIngresos()
        {
            InitializeComponent();
        }
        public int _txtIdAlumno
        {
            set { alumno = value; }

        }
        public int _txtAno
        {
            set { ano = value; }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            int IdTipoIngreso, Iva,IdMoneda,i;
            decimal Monto;
            
            if (rdCI1.Checked)
            {
                i = 0;
            }
            else
            { i = 1; }
            IdTipoIngreso =Convert.ToInt32( dtCuota.Rows[i]["IdIngreso"]);
            Iva = Convert.ToInt32(dtCuota.Rows[i]["Iva"]);
            Monto = Convert.ToDecimal(dtCuota.Rows[i]["Monto"]);
            IdMoneda = Convert.ToInt32(dtCuota.Rows[i]["IdMoneda"]);
            List<DbParameter> parameters = new List<DbParameter>();
         
            parameters.Add(new DbParameter("_IdAlumno", DbDirection.Input, alumno));
            parameters.Add(new DbParameter("_IdTipoIngreso", DbDirection.Input, IdTipoIngreso));
            parameters.Add(new DbParameter("_IdMoneda", DbDirection.Input, IdMoneda));
            parameters.Add(new DbParameter("_Monto", DbDirection.Input, Monto));
            parameters.Add(new DbParameter("_IVA", DbDirection.Input, Iva));
            parameters.Add(new DbParameter("_IdMes", DbDirection.Input, 0));
            parameters.Add(new DbParameter("_pAnho", DbDirection.Input, ano));
            int retorno = DBMapeo.ExecuteNonQuery("insPagosParticulares", parameters);
            this.Close();
        }


        private void CargaCuota()
        {
             dtCuota = DBMapeo.ProcedureSelect("spListaCuotadeIngreso", null);
            for (int i = 0; i < dtCuota.Rows.Count; i++)
            {
                if (i == 0)
                { this.rdCI1.Text = dtCuota.Rows[i]["Descripcion"].ToString();
               
                }
                else
                {this.rdCI2.Text = dtCuota.Rows[i]["Descripcion"].ToString();
             
                }
            
            }
            
        }

        private void frmOtroIngresos_Load(object sender, EventArgs e)
        {
            CargaCuota();
        }
    }
}