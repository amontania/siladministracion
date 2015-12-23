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
    public partial class frmItemStock : Form
    {
        DBUtils DBMapeo = new DBUtils();
        Regex FormatControl = new Regex(@"\D");
        Regex Monto = new Regex(@"\d+(\.\d{1,2})?");
        Regex Monto2 = new Regex(@"^[0-9]{1,9}([\.\,][0-9]{1,3})?$");
        string Operacion = "";
        decimal cotizacion =0;
        frmLibros formlibros;
        int rowindewfrmlibros = 0;

       
        public string _txtIdTransaccion
        {
            set { txtIdTransaccion.Text = value; }
        }

        public string _txtIdItemStock
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
        public frmItemStock()
        {
            InitializeComponent();
        }

        private void btnAceptarStock_Click(object sender, EventArgs e)
        {
            OperacionStock();
        }


        private void OperacionStock()
        {

            if (RequisitosStock())
            {
                string IdItemOperacion = this.txtIdOperacion.Text;
                string IdTransaccion = this.txtIdTransaccion.Text;
                int ISBN = Convert.ToInt32(cboISBN.SelectedValue);
                int cantidad = Convert.ToInt32(this.numCantidad.Value);
                string dolar = this.txtPrecioDolar.Text.Replace(",","." ) ;
                decimal gs = Convert.ToDecimal(dolar) ;
                int tipoperacion=2;
                if (Operacion == "Modificar")
                    tipoperacion = 3;

                
                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pId", DbDirection.Input, IdItemOperacion));
                parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, IdTransaccion));
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, tipoperacion));
                parameters.Add(new DbParameter("pIdLibros", DbDirection.Input, ISBN));
                parameters.Add(new DbParameter("pCantidad", DbDirection.Input, cantidad));
                parameters.Add(new DbParameter("pCompraUS", DbDirection.Input, dolar));
                parameters.Add(new DbParameter("pCompraGS", DbDirection.Input, gs));

                int retorno = DBMapeo.ExecuteNonQuery("spIngresoLibrosDetalle", parameters);
                if (retorno > 0)
                {



                    Char pad = Convert.ToChar("-");
                    string str = "¿ Desea Agregar otro Libro ? " + "\r";
                    str = str.PadRight(59, pad);

                    if (MessageBox.Show(str, "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        formlibros.LlenarDetalle();
                        formlibros.llenarGridCompra(rowindewfrmlibros);
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
           
         

        private bool RequisitosStock()
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
                else 
                {
                    if (!Regex.IsMatch(this.txtPrecioDolar.Text, @"\d+(\.\d{1,3})?"))
                    {

                        MessageBox.Show("Falta Precio Unitario del Libro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtPrecioDolar.Focus();
                        retorno = false;
                    }
                }
 
            }




            

            return retorno;
        }

        private void frmItemStock_Load(object sender, EventArgs e)
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
                parametro1.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
                parametro1.Add(new DbParameter("pOperacion", DbDirection.Input, 5));
                parametro1.Add(new DbParameter("pIdLibros", DbDirection.Input, null));
                parametro1.Add(new DbParameter("pCantidad", DbDirection.Input, null));
                parametro1.Add(new DbParameter("pCompraUS", DbDirection.Input, null));
                parametro1.Add(new DbParameter("pCompraGS", DbDirection.Input, null));

                DataTable dtItem = DBMapeo.ProcedureSelect("spIngresoLibrosDetalle", parametro1);

                if (dtItem.Rows.Count > 0)
                {
                    this.cboISBN.SelectedValue = Convert.ToInt32(dtItem.Rows[0][1]);
                    this.numCantidad.Text = dtItem.Rows[0][2].ToString();
                    this.txtPrecioDolar.Text = dtItem.Rows[0][3].ToString();

                }


            }
            txtPrecioDolar.GotFocus += new EventHandler(txtPrecioDolar_GotFocus);
            numCantidad.GotFocus += new EventHandler(numCantidad_GotFocus);
        }


        protected void txtPrecioDolar_GotFocus(Object sender, EventArgs e)
        {
            txtPrecioDolar.SelectAll();
        }

        protected void numCantidad_GotFocus(Object sender, EventArgs e)
        {
            numCantidad.Select(0,3);
        }

        private void btnCancelarStock_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarControles()
        {
           
            this.numCantidad.Value = 1;
            this.txtPrecioDolar.Text = "";
            this.txtIdOperacion.Text = "0";
            this.cboISBN.SelectedIndex = -1;
        }

        private void txtPrecioDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptarStock.Focus();
            }
            else
            {
                if (! Monto2.IsMatch(e.KeyChar.ToString()) && (e.KeyChar.ToString()!=",") && (e.KeyChar.ToString()!=".") && (e.KeyChar != 8)) 
                {
                    MessageBox.Show("Solo numero se acepta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                }
            }
           
        }

        private void btnAgregarISBN_Click(object sender, EventArgs e)
        {
            frmISBN frmlib = new frmISBN();
            frmlib.FormClosed += new FormClosedEventHandler(formSer_FormClosed);
            //frmlib._txtISBN.
            frmlib.ShowDialog();

        }

        private void formSer_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmISBN ver = (frmISBN)sender;
            string nuevoindice = ver._txtISBN;
            string sql = "spLibros";
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 6));
            parametro.Add(new DbParameter("pId", DbDirection.Input, null));
            parametro.Add(new DbParameter("pISBN", DbDirection.Input, null));
            parametro.Add(new DbParameter("pTitulo", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCantVol", DbDirection.Input, null));
            parametro.Add(new DbParameter("pUltimoId", DbDirection.Output, null));
            DataTable dtlibros = DBMapeo.ProcedureSelect(sql, parametro);
            this.cboISBN.DataSource = dtlibros;
            this.cboISBN.ValueMember = "Id";
            this.cboISBN.DisplayMember = "Descripcion";
            this.cboISBN.SelectedValue = Convert.ToInt32(nuevoindice);


        }

        private void cboISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.numCantidad.Focus();

            }
            //else
            //{
            //    if (e.KeyChar != 48 && e.KeyChar != 49 && e.KeyChar != 50 && e.KeyChar != 51 && e.KeyChar != 52 && e.KeyChar != 53 && e.KeyChar != 54 && e.KeyChar !=55 && e.KeyChar != 56 && e.KeyChar != 57)
            //    { MessageBox.Show(e.KeyChar.ToString());}
            //}
        }

        private void numCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPrecioDolar.Focus();
                this.txtPrecioDolar.SelectAll();
            }
        }

        private void txtPrecioDolar_KeyUp(object sender, KeyEventArgs e)
        {

        }

    }
}
