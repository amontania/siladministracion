using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medusa;
using System.Text.RegularExpressions;

namespace SilAdministracion
{
    public partial class frmItemCombo : Form
    {
        DBUtils DBMapeo = new DBUtils();
        Regex FormatControl = new Regex(@"\D");
        Regex Monto = new Regex(@"\d+(\.\d{1,2})?");
      
        string Operacion = "";
        frmLibros formlibros;
        int rowindewfrmlibros = 0;


        public string _txtIdTransaccion
        {
            set { txtIdTransaccion.Text = value; }
        }

        public string _txtIdItemCombo
        {
            set { txtIdOperacion.Text = value; }
        }

        public object _formlibros
        {
            set { formlibros = (frmLibros)value; }
        }

        public int _rowindewfrmlibros
        {
            set { rowindewfrmlibros = value; }
        }
        public frmItemCombo()
        {
            InitializeComponent();
        }

        private void frmItemCombo_Load(object sender, EventArgs e)
        {
            string sql = "spLibros";
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 6));
            parametro.Add(new DbParameter("pId", DbDirection.Input, null));
            parametro.Add(new DbParameter("pISBN", DbDirection.Input, null));
            parametro.Add(new DbParameter("pTitulo", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCantVol", DbDirection.Input, null));
            parametro.Add(new DbParameter("pUltimoId", DbDirection.Input, null));
            DataTable dtlibros = DBMapeo.ProcedureSelect(sql, parametro);
            this.cboISBN.DataSource = dtlibros;
            this.cboISBN.ValueMember = "Id";
            this.cboISBN.DisplayMember = "Descripcion";
          
            if (this.txtIdOperacion.Text == "0")
            {
                Operacion = "Agregar";
                limpiarControles();
            }
            else
            {
                Operacion = "Modificar";
                this.lblModoStock.Text = "Modificando..";
                List<DbParameter> parametro1 = new List<DbParameter>();
                parametro1.Add(new DbParameter("pId", DbDirection.Input, txtIdOperacion.Text));
                parametro1.Add(new DbParameter("pIdCombo", DbDirection.Input, txtIdTransaccion.Text));
                parametro1.Add(new DbParameter("pOperacion", DbDirection.Input, 6));
                parametro1.Add(new DbParameter("pIdLibro", DbDirection.Input, null));
                parametro1.Add(new DbParameter("pCantidad", DbDirection.Input, null));

                DataTable dtItem = DBMapeo.ProcedureSelect("spComboDetalle", parametro1);
              
                if (dtItem.Rows.Count > 0)
                {
                    this.cboISBN.SelectedValue = Convert.ToInt32(dtItem.Rows[0][1]);
                    
                     this.numCantidad.Text = dtItem.Rows[0][2].ToString();
                }
            }
           
            numCantidad.GotFocus += new EventHandler(numCantidad_GotFocus);
        }

        private void limpiarControles()
        {

            this.numCantidad.Value = 1;
            this.txtIdOperacion.Text = "0";
            this.cboISBN.SelectedIndex = -1;
        }


        protected void numCantidad_GotFocus(Object sender, EventArgs e)
        {
            numCantidad.Select(0,3);
        }

        private void btnCancelarCombo_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool RequisitosCombo()
        {
            bool retorno = true;
            if (Convert.ToInt32(cboISBN.SelectedValue) == 0)
            {
                MessageBox.Show("Falta ISBN", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboISBN.Focus();
                retorno = false;

            }
            else
            {
                if (!Regex.IsMatch(this.numCantidad.Text, @"\d+"))
                {

                    MessageBox.Show("Falta Cantidad de libros comprados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.numCantidad.Focus();
                    retorno = false;
                }
               

            }






            return retorno;
        }



        private void OperacionCombo()
        {

            if (RequisitosCombo())
            {
                string IdItemOperacion = this.txtIdOperacion.Text;
                string IdTransaccion = this.txtIdTransaccion.Text;
                int ISBN = Convert.ToInt32(cboISBN.SelectedValue);
                int cantidad = Convert.ToInt32(this.numCantidad.Value);
               
                int tipoperacion = 2;
                if (Operacion == "Modificar")
                    tipoperacion = 3;


                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pId", DbDirection.Input, IdItemOperacion));
                parameters.Add(new DbParameter("pIdCombo", DbDirection.Input, IdTransaccion));
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, tipoperacion));
                parameters.Add(new DbParameter("pIdLibro", DbDirection.Input, ISBN));
                parameters.Add(new DbParameter("pCantidad", DbDirection.Input, cantidad));


                int retorno = DBMapeo.ExecuteNonQuery("spComboDetalle", parameters);
                if (retorno > 0)
                {
                    Char pad = Convert.ToChar("-");
                    string str = "¿ Desea Agregar otro Libro a este combo ? " + "\r";
                    str = str.PadRight(86, pad);

                    if (MessageBox.Show(str, "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        formlibros.LlenarDetalleCombo();
                        formlibros.CargarCombo(rowindewfrmlibros);
                        limpiarControles();
                        this.cboISBN.Focus();
                    }
                    else
                    {
                        this.Close();
                    }

                }
            }

        }

        private void cboISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.numCantidad.Focus();

            }
        }

        private void numCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { 
                this.btnAceptarCombo.Focus();
            }
        }

        private void btnAceptarCombo_Click(object sender, EventArgs e)
        {
            OperacionCombo();
        }
    }
}
