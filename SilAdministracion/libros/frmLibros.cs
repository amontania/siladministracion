using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Medusa;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace SilAdministracion
{
    public partial class frmLibros : Form
    {
        private static frmLibros _instance;
        DBUtils DBMapeo = new DBUtils();
        int rowindex = 0;
        int Modo = 0;
        string IdStockItem = "";
        string IdComboItem = "";
        int rowindexStock = 0;
        int rowindexCombo = 0;
        Regex FormatControl = new Regex(@"\D");
        DataTable dtCombo;
        DataTable dtAlumno;

        public frmLibros instance
        {
            get {
                if (frmLibros._instance == null)
                {
                    frmLibros._instance = new frmLibros();
                }
                return frmLibros._instance;
            }
        }
        //#Region Libros;
        public string _textIdTransaccion
        {
            get { return txtIdTransaccion.Text; }
        }

        public string _textIdStockItem
        {
            get { return IdStockItem; }
            set {  _textIdStockItem = IdStockItem;}

        }

      
        //#End Region; 
        public frmLibros()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            llenarGridCompra(0);
            this.DGCompraLibros.Focus();

            string sql = "spLibros";
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 6));
            parametro.Add(new DbParameter("pId", DbDirection.Input, null));
            parametro.Add(new DbParameter("pISBN", DbDirection.Input, null));
            parametro.Add(new DbParameter("pTitulo", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCantVol", DbDirection.Input, null));
            parametro.Add(new DbParameter("pUltimoId", DbDirection.Input, null));
            DataTable dtlibros = DBMapeo.ProcedureSelect(sql, parametro);
            DataRow datarow = dtlibros.NewRow();
            datarow["Id"] = "0";
            datarow["ISBN"] = "0";
            datarow["Titulo"] = "--------------";
            datarow["Descripcion"] = "----- TODOS ---------";
            datarow["CantidadVol"] = 1;
            dtlibros.Rows.Add(datarow);


            this.cboISBN.DataSource = dtlibros;
            this.cboISBN.ValueMember = "ISBN";
            this.cboISBN.DisplayMember = "Descripcion";
            this.cboISBN.SelectedValue = "0";
      
        }


        public string _textIdCombo
        {
            get { return txtIdCombo.Text; }
        }

        public string _textIdComboItem
        {
            get { return IdComboItem; }
            set { _textIdComboItem = IdComboItem; }

        }

        private void CargarLibros()
        {
            string sql = "spLibros";
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parametro.Add(new DbParameter("pId", DbDirection.Input, null));
            parametro.Add(new DbParameter("pISBN", DbDirection.Input, null));
            parametro.Add(new DbParameter("pTitulo", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCantVol", DbDirection.Input, null));
            parametro.Add(new DbParameter("pUltimoId", DbDirection.Output, null));
            DataTable dtlibros = DBMapeo.ProcedureSelect(sql, parametro);
            this.dataGridLibros.AutoGenerateColumns = false;
            this.dataGridLibros.DataSource = dtlibros;
            this.lblLibros.Text = "Cantidad de libros Distintos: " + this.dataGridLibros.RowCount.ToString();
           
        }

        public void CargarCombo(int rowcombo)
        {
            string sql = "spComboLibros";
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parametro.Add(new DbParameter("pId", DbDirection.Input, null));
            parametro.Add(new DbParameter("pIdCursoGrado", DbDirection.Input, null));
            parametro.Add(new DbParameter("pAnho", DbDirection.Input, null));
            parametro.Add(new DbParameter("pUltimoId", DbDirection.Output, null));
            DataTable dtCombo = DBMapeo.ProcedureSelect(sql, parametro);
            this.DGCombos.AutoGenerateColumns = false;
            this.DGCombos.DataSource = dtCombo;

            if (DGCombos.RowCount > 0)
            {
                DGCombos.Rows[rowcombo].Selected = true;
                DGCombos.CurrentCell = DGCombos.Rows[rowcombo].Cells[2];
            }
        }

        private void mnuAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            Modo = 1;
            this.lblModo.Text = "Agregando...";
            DeshabilitarMenu();
            limpiarControlesTexto();
            this.txtISBN.Focus();
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtTitulo.Focus();
            }
            else
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    habilitarMenu();
                    limpiarControlesTexto();
                    this.dataGridLibros.Focus();
                }
            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Operacion();
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Operacion();
            }
        }

        private void Operacion()
        {
            if (Requisitos())
            {
                string isbn = this.txtISBN.Text;
                string titulo = this.txtTitulo.Text;
                rowindex = dataGridLibros.CurrentRow.Index;
                int cantvol =(int) this.numDow.Value;
                if (Modo == 1)
                {

                    if (Unico())
                    {
                        List<DbParameter> parameters = new List<DbParameter>();
                        parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                        parameters.Add(new DbParameter("pId", DbDirection.Input, null));
                        parameters.Add(new DbParameter("pISBN", DbDirection.Input, isbn));
                        parameters.Add(new DbParameter("pTitulo", DbDirection.Input, titulo));
                        parameters.Add(new DbParameter("pCantVol", DbDirection.Input, cantvol));
                        parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

                        int retorno = DBMapeo.ExecuteNonQuery("spLibros", parameters);
                        CargarLibros();

                        habilitarMenu();
                        MueveDatagrid(isbn);
                    }
                    else
                    {
                        MessageBox.Show("Ya existe ese ISBN, verifique por favor!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtISBN.Focus();
                    }
                }
                else
                {
                    bool modificar = true;
                    if (dataGridLibros["ISBN", rowindex].Value.ToString() != this.txtISBN.Text)
                        modificar = Unico();

                    if (modificar)
                    {
                        
                        int id = Convert.ToInt32(dataGridLibros["Id", rowindex].Value);
                        List<DbParameter> parameters = new List<DbParameter>();
                        parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 4));
                        parameters.Add(new DbParameter("pId", DbDirection.Input, id));
                        parameters.Add(new DbParameter("pISBN", DbDirection.Input, isbn));
                        parameters.Add(new DbParameter("pTitulo", DbDirection.Input, titulo));
                        parameters.Add(new DbParameter("pCantVol", DbDirection.Input, cantvol));
                        parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

                        int retorno = DBMapeo.ExecuteNonQuery("spLibros", parameters);
                        CargarLibros();

                        habilitarMenu();
                        MueveDatagrid(isbn);
                    }
                    else
                    {
                        MessageBox.Show("Ya existe ese ISBN, verifique por favor!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtISBN.Focus();
                    }
                }
            }

        }

        private bool Requisitos()
        {
            bool paso = true;

            string mensaje = "Atención, hay campo(s) vacio(s): ";

            if (this.txtISBN.Text.Length == 0)
            {
                paso = false;
                mensaje = mensaje + " ISBN";
                this.txtISBN.Focus();

            }
            if (this.txtTitulo.Text.Length == 0)
            {
                if (!paso)
                {
                    mensaje = mensaje + ",";
                    this.txtISBN.Focus();
                }
                else
                {
                    this.txtTitulo.Focus();
                }
                paso = false;
                mensaje = mensaje + " Titulo";

            }

            if (!paso)
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



            return paso;
        }

        private bool Unico()
        {
            bool unico = true;
            string isbn = this.txtISBN.Text;
            string titulo = this.txtTitulo.Text;
            int cantvol = (int)this.numDow.Value;
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
            parameters.Add(new DbParameter("pId", DbDirection.Input, null));
            parameters.Add(new DbParameter("pISBN", DbDirection.Input, isbn));
            parameters.Add(new DbParameter("pTitulo", DbDirection.Input, titulo));
            parameters.Add(new DbParameter("pCantVol", DbDirection.Input, cantvol));
            parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));
            int cantidad = Convert.ToInt32(DBMapeo.Escalar("spLibros", parameters));
            if (cantidad > 0)
                unico = false;
            return unico;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {



            habilitarMenu();
            limpiarControlesTexto();
            this.dataGridLibros.Focus();
        }

        private void limpiarControlesTexto()
        {
            this.txtISBN.Text = "";
            this.txtTitulo.Text = "";
           
        }

        private void habilitarMenu()
        {
            this.mnuAgregar.Enabled = false;
            this.mnuEditar.Enabled = true;
            this.mnuEliminar.Enabled = false;
            this.panel1.Visible = false;
            picturelogo.Visible = true;
            this.picturelogo.Location = new Point(25, 114);
        }

        private void DeshabilitarMenu()
        {
            this.mnuAgregar.Enabled = false;
            this.mnuEditar.Enabled = false;
            this.mnuEliminar.Enabled = false;
            this.panel1.Visible = true;
            picturelogo.Visible = false;
        }

        private void mnuEditar_Click(object sender, EventArgs e)
        {
            Editar();

        }

        private void Editar()
        {
            rowindex = dataGridLibros.CurrentRow.Index;
            Modo = 2;
            this.lblModo.Text = "Editando...";
            DeshabilitarMenu();
            this.txtISBN.Text = dataGridLibros["ISBN", rowindex].Value.ToString();
            this.txtTitulo.Text = dataGridLibros["Titulo", rowindex].Value.ToString();
            this.numDow.Value = Convert.ToDecimal(dataGridLibros["Vol", rowindex].Value);
            
            this.txtISBN.Focus();
            this.txtISBN.SelectAll();
          
        }


      

        private void dataGridLibros_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

        private void dataGridLibros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Editar();
            }
        }

        private void mnuEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            if (dataGridLibros.SelectedRows.Count > 0)
            {
                rowindex = dataGridLibros.CurrentRow.Index;
                Char pad = Convert.ToChar("-");
                string str = "¿ Desea borrar el Libro ? " + "\r";
                str = str.PadRight(54, pad) + "\r" + "ISBN : " + dataGridLibros["ISBN", rowindex].Value.ToString();

                if (MessageBox.Show(str, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridLibros["Id", rowindex].Value);
                    List<DbParameter> parameters = new List<DbParameter>();
                    parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 5));
                    parameters.Add(new DbParameter("pId", DbDirection.Input, id));
                    parameters.Add(new DbParameter("pISBN", DbDirection.Input, null));
                    parameters.Add(new DbParameter("pTitulo", DbDirection.Input, null));
                    parameters.Add(new DbParameter("pCantVol", DbDirection.Input, null));
                    parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

                    int retorno = DBMapeo.ExecuteNonQuery("spLibros", parameters);
                    CargarLibros();
                    habilitarMenu();
                }
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void MueveDatagrid(string searchValue)
        {
            int rowIndex = -1;
            DataGridViewRow row = dataGridLibros.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["ISBN"].Value.ToString().Equals(searchValue))
                .First();

            rowIndex = row.Index;
            dataGridLibros.Rows[rowIndex].Selected = true;
            dataGridLibros.CurrentCell = dataGridLibros.Rows[rowIndex].Cells[1];

        }


        private void dataGridLibros_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        

//--------------------------------------------------------------------------------------------------


        private void AgregarStock()
        {
            Modo = 1;
            this.lblModoStock.Text = "Agregando...";

            DeshabilitarMenuStock();
            limpiarControlesTextoStock();
            ControlesStock(true);
            this.DGDetalle.Enabled = false;
            this.btnAgregarStock.Enabled = false;
        
            this.txtIdTransaccion.Text = "0";
            this.dtFecha.Value = DateTime.Now;
            this.txtNroComprobante.Focus();
            DGDetalle.DataSource = null;
            DGDetalle.Refresh();
        }

        private void habilitarMenuStock()
        {
            this.mnuAgregarStock.Enabled = true;
            this.mnuEditarStock.Enabled = true;
            this.mnuEliminarStock.Enabled = true;
            this.panel2.Visible = false;
            this.DGCompraLibros.Enabled = true;
            this.DGCompraLibros.Focus();
            this.picturelogo2.Visible = true;
            this.picturelogo2.Location = new Point(25, 114);
        }

        private void DeshabilitarMenuStock()
        {
            this.mnuAgregarStock.Enabled = false;
            this.mnuEditarStock.Enabled = false;
            this.mnuEliminarStock.Enabled = false;
            this.panel2.Visible = true;
            this.DGCompraLibros.Enabled = false;
            this.picturelogo2.Visible = false;
            this.btnAgregarStock.Enabled = false;

        }

        private void limpiarControlesTextoStock()
        {
            this.txtNroComprobante.Text = "";
            this.txtIdTransaccion.Text = "";
            this.txtCotizacion.Text = "";
            this.txtDescripcion.Text = "";
            this.dtFecha.Text = "";
            this.txtTotalGS.Text = "0";
            this.txtTotalUS.Text = "0";
            //this.dtFecha.CustomFormat = "";
            //this.dtFecha.Format = DateTimePickerFormat.Custom;
            this.dtFecha.Format = DateTimePickerFormat.Short;
            this.txtDescripcion.Focus();

        }

        private void ControlesStock(bool valor)
        {
            this.txtNroComprobante.Enabled = valor;
            this.txtCotizacion.Enabled = valor;
            this.txtDescripcion.Enabled = valor;
            this.dtFecha.Enabled = valor;

        }

        private void mnuAgregarStock_Click(object sender, EventArgs e)
        {
            AgregarStock();
        }



        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            IdStockItem = "0";
            abrirlibro();
        }

        private void abrirlibro()
        {
            frmItemStock frmItem = new frmItemStock();
            frmItem.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            frmItem._txtIdTransaccion = _textIdTransaccion;
            frmItem._txtIdItemStock = _textIdStockItem;
            frmItem._formlibros = this;
            frmItem._rowindewfrmlibros = rowindexStock;
            frmItem.ShowDialog();
        }

        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {

            LlenarDetalle();
            llenarGridCompra(rowindexStock);
            //BotonABM(true);
            //Controles(false);
            this.DGCompraLibros.Enabled = false;
         //   this.DGDetalle.Enabled = false;
            //Operacion = "";
        }

        private void tabLibros_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptarStock_Click(object sender, EventArgs e)
        {

            OperacionStock();
           
        }

        private void OperacionStock()
        {
            if (RequisitosStock())
            {
                int IdTransaccione = Convert.ToInt32(this.txtIdTransaccion.Text);
                string nrocomprobantes = this.txtNroComprobante.Text;
                string sFecha = dtFecha.Value.Year.ToString() + "-" + dtFecha.Value.Month.ToString() + "-" + dtFecha.Value.Day.ToString();
                string descripcion = this.txtDescripcion.Text;
                string cotizacion = this.txtCotizacion.Text;
                string totalus ="0";
                string totalgs = "0";


                if (Modo == 1)
                {
                    List<DbParameter> parameters = new List<DbParameter>();
                    parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, IdTransaccione));
                    parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                    parameters.Add(new DbParameter("pNroComprobantes", DbDirection.Input, nrocomprobantes));
                    parameters.Add(new DbParameter("pFecha", DbDirection.Input, sFecha));
                    parameters.Add(new DbParameter("pDescripcion", DbDirection.Input, descripcion));
                    parameters.Add(new DbParameter("pCotizacion", DbDirection.Input, cotizacion));
                    parameters.Add(new DbParameter("pTotalUS", DbDirection.Input, totalus));
                    parameters.Add(new DbParameter("pTotalGs", DbDirection.Input, totalgs));
                    parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, 0));
                    int retorno = DBMapeo.ExecuteNonQuery("spIngresoLibros", parameters);
                    this.txtIdTransaccion.Text = DBMapeo.OutParameters[0].Value.ToString();
                    if (DGDetalle.RowCount == 0)
                    {
                        IdStockItem = "0";

                        abrirlibro();
                    }
                    else
                    {
                        llenarGridCompra(rowindexStock);
                        habilitarMenuStock();
                    }
                    Modo = 2;
                }
                else 
                {
                    List<DbParameter> parameters = new List<DbParameter>();
                    parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, IdTransaccione));
                    parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
                    parameters.Add(new DbParameter("pNroComprobantes", DbDirection.Input, nrocomprobantes));
                    parameters.Add(new DbParameter("pFecha", DbDirection.Input, sFecha));
                    parameters.Add(new DbParameter("pDescripcion", DbDirection.Input, descripcion));
                    parameters.Add(new DbParameter("pCotizacion", DbDirection.Input, cotizacion));
                    parameters.Add(new DbParameter("pTotalUS", DbDirection.Input, totalus));
                    parameters.Add(new DbParameter("pTotalGs", DbDirection.Input, totalgs));
                    parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, 0));
                    int retorno = DBMapeo.ExecuteNonQuery("spIngresoLibros", parameters);
                    llenarGridCompra(rowindexStock);
                    habilitarMenuStock();
                    Modo = 0;

                }


            }

        }

        private bool RequisitosStock()
        {
            bool retorno = true;
            if (!Regex.IsMatch(this.txtNroComprobante.Text, @"\d+"))
            {
                MessageBox.Show("Falta Nro. de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroComprobante.Focus();
                retorno = false;

            }
            else
            {
                if (dtFecha.Text.Length == 0)
                {
                    MessageBox.Show("Falta Fecha", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dtFecha.Focus();
                    retorno = false;
                }
                else
                {
                    if (!Regex.IsMatch(this.txtCotizacion.Text, @"\d+"))
                    {
                        MessageBox.Show("Falta Cotizacion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtCotizacion.Focus();
                        retorno = false;
                    }
                    //else
                    //{
                    //    if (txtDescripcion.Text.Length == 0)
                    //    {
                    //        MessageBox.Show("Falta Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        this.txtDescripcion.Focus();
                    //        retorno = false;
                    //    }

                    //}
                }
            }





            return retorno;
        }



        private void btnCancelarStock_Click(object sender, EventArgs e)
        {

            habilitarMenuStock();
            limpiarControlesTextoStock();
            this.DGCompraLibros.Focus();

            Modo = 0;
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            dtFecha.Format = DateTimePickerFormat.Short;
        
        }

        public void LlenarDetalle()
        {
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pId", DbDirection.Input, 0));
            parametro.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parametro.Add(new DbParameter("pIdLibros", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCantidad", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCompraUS", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCompraGS", DbDirection.Input, null));
            DataTable dtResults = DBMapeo.ProcedureSelect("spIngresoLibrosDetalle", parametro);

            this.DGDetalle.AutoGenerateColumns = false;
            this.DGDetalle.DataSource = dtResults;
            if (DGDetalle.RowCount == 0)
                IdStockItem = "0";
            else
            {
                IdStockItem = DGDetalle["Id1", 0].Value.ToString();
                DGDetalle.Rows[0].Selected = true;
                DGDetalle.CurrentCell = DGDetalle.Rows[0].Cells[2];
            }


            //--------------------------------------------------------------------------

            List<DbParameter> parametro1 = new List<DbParameter>();
            parametro1.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
            parametro1.Add(new DbParameter("pOperacion", DbDirection.Input, 4));
            parametro1.Add(new DbParameter("pNroComprobantes", DbDirection.Input, null));
            parametro1.Add(new DbParameter("pFecha", DbDirection.Input, null));
            parametro1.Add(new DbParameter("pDescripcion", DbDirection.Input, null));
            parametro1.Add(new DbParameter("pCotizacion", DbDirection.Input, null));
            parametro1.Add(new DbParameter("pTotalUS", DbDirection.Input, null));
            parametro1.Add(new DbParameter("pTotalGs", DbDirection.Input, null));
            parametro1.Add(new DbParameter("pUltimoId", DbDirection.Output, 0));
            DataTable dtTotal = DBMapeo.ProcedureSelect("spIngresoLibros", parametro1);

            if (dtTotal.Rows.Count > 0)
            {
                //this.txtTotalUS.Text = dtTotal.Rows[0][0].ToString();
                //this.txtTotalGS.Text = dtTotal.Rows[0][1].ToString();
                this.txtTotalUS.Text = string.Format("{0:#,###.##}", Convert.ToDouble(dtTotal.Rows[0][0].ToString()));
                this.txtTotalGS.Text = string.Format("{0:#,###}", Convert.ToDouble(dtTotal.Rows[0][1].ToString()));
            }





        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl.SelectedTab.Name)
            {
                case "tabLibros":
                    CargarLibros();
                    this.dataGridLibros.Focus();
                    break;
                case "tabCompra" :
                    llenarGridCompra(0 );
                    this.DGCompraLibros.Focus();
                    break;
                case "tabCombo" :
                    CargarCombo(0);
                    this.DGCombos.Focus();
                    CargarComboCurso();
                    break;
                case "tabMov":
                    this.numAnho.Value = DateTime.Now.Year;
                    this.numAnho.Minimum = 2000;
                    this.numAnho.Maximum = DateTime.Now.Year;
                    if (this.cboGradoCurso2.SelectedIndex<0)
                        CargarComboCurso2();
                    if (this.cboSeccion.SelectedIndex<0)
                        CargarComboSeccion(0);
                    this.cboGradoCurso2.Focus();
                  
                        LabelCurso();
                    break;

                case "tabStock":
                    CargarStock(2,null);
                    break;

                
            }
        }

        public void llenarGridCompra(int rowindexaux)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, 0));
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pNroComprobantes", DbDirection.Input, null));
            parameters.Add(new DbParameter("pFecha", DbDirection.Input, null));
            parameters.Add(new DbParameter("pDescripcion", DbDirection.Input, null));
            parameters.Add(new DbParameter("pCotizacion", DbDirection.Input, null));
            parameters.Add(new DbParameter("pTotalUS", DbDirection.Input, null));
            parameters.Add(new DbParameter("pTotalGs", DbDirection.Input, null));
            parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, 0));
            DataTable dtope = DBMapeo.ProcedureSelect("spIngresoLibros", parameters);

            this.DGCompraLibros.AutoGenerateColumns = false;
            this.DGCompraLibros.DataSource = dtope;

            if (DGCompraLibros.RowCount > 0)
            {
                DGCompraLibros.Rows[rowindexaux].Selected = true;
                DGCompraLibros.CurrentCell = DGCompraLibros.Rows[rowindexaux].Cells[1];
            }
        }


        private void EditarStock()
        {
            Modo = 2;
            this.lblModoStock.Text = "Editando...";
            DeshabilitarMenuStock();
            
            rowindexStock = DGCompraLibros.CurrentRow.Index;
            this.txtNroComprobante.Text = DGCompraLibros["NroComprobantes", rowindexStock].Value.ToString();
            this.txtIdTransaccion.Text = DGCompraLibros["IdTransaccion", rowindexStock].Value.ToString();
            this.dtFecha.Value = Convert.ToDateTime(DGCompraLibros["Fecha", rowindexStock].Value.ToString());
           
            this.txtCotizacion.Text = DGCompraLibros["Cotizacion", rowindexStock].Value.ToString();
            this.txtDescripcion.Text = DGCompraLibros["Descripcion", rowindexStock].Value.ToString();
            LlenarDetalle();
            ControlesStock(true);

            this.DGDetalle.Enabled = true;
            this.btnAgregarStock.Enabled = true;
            this.txtNroComprobante.Focus();
            this.txtNroComprobante.SelectAll();
            
        }

        private void DGCompraLibros_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

       
        private void DGCompraLibros_DoubleClick(object sender, EventArgs e)
        {
            EditarStock();
        }

        private void mnuEditarStock_Click(object sender, EventArgs e)
        {
            EditarStock();
        }


        private void EliminarStock()
        {
            Modo = 3;
            this.lblModoStock.Text = "Eliminando...";
            rowindexStock = DGCompraLibros.CurrentRow.Index;
            DeshabilitarMenuStock();
            this.txtNroComprobante.Text = DGCompraLibros["NroComprobantes", rowindexStock].Value.ToString();
            this.txtIdTransaccion.Text = DGCompraLibros["IdTransaccion", rowindexStock].Value.ToString();
            this.dtFecha.Value = Convert.ToDateTime(DGCompraLibros["Fecha", rowindexStock].Value.ToString());
            this.txtCotizacion.Text = DGCompraLibros["Cotizacion", rowindexStock].Value.ToString();
            this.txtDescripcion.Text = DGCompraLibros["Descripcion", rowindexStock].Value.ToString();
            LlenarDetalle();
            ControlesStock(false);
            this.DGDetalle.Enabled = false;
            this.btnAgregarStock.Enabled = false;


            Char pad = Convert.ToChar("-");
            string str = "¿ Desea borrar el Registro ? " + "\r";
            str = str.PadRight(54, pad) + "\r" + "Nro. Comprobante : " + this.txtNroComprobante.Text;

            if (MessageBox.Show(str, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(this.txtIdTransaccion.Text);

                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, id));
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 5));
                parameters.Add(new DbParameter("pNroComprobantes", DbDirection.Input, null));
                parameters.Add(new DbParameter("pFecha", DbDirection.Input, null));
                parameters.Add(new DbParameter("pDescripcion", DbDirection.Input, null));
                parameters.Add(new DbParameter("pCotizacion", DbDirection.Input, null));
                parameters.Add(new DbParameter("pTotalUS", DbDirection.Input, null));
                parameters.Add(new DbParameter("pTotalGs", DbDirection.Input, null));
                parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, 0));
                int retorno = DBMapeo.ExecuteNonQuery("spIngresoLibros", parameters);
                llenarGridCompra(0);

               
            }
            habilitarMenuStock();

        }

        private void mnuEliminarStock_Click(object sender, EventArgs e)
        {
            EliminarStock();
        }

        private void DGDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirlibro();
        }

        private void DGDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(DGDetalle["Id1", e.RowIndex].Value);
            IdStockItem = Id.ToString();
            if (e.ColumnIndex == 6)
            { abrirlibro(); }
            else
            {
                if (e.ColumnIndex == 7)
                {
                     Char pad = Convert.ToChar("-");
                     string str = "¿ Desea borrar el Registro ? " + "\r";
                     str = str.PadRight(54, pad) + "\r" + "ISBN : " + DGDetalle["ISBN1", e.RowIndex].Value.ToString();
                    if (MessageBox.Show(str, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        EliminarItem(Id);
                        LlenarDetalle();
                    }

                }
            }

        }

        private void EliminarItem(int IdDetalle)
        {
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pId", DbDirection.Input, IdDetalle));
            parametro.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 4));
            parametro.Add(new DbParameter("pIdLibros", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCantidad", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCompraUS", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCompraGS", DbDirection.Input, null));
          
            int retorno = DBMapeo.ExecuteNonQuery("spIngresoLibrosDetalle", parametro);
        }

        private void txtCotizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDescripcion.Focus();
            }
            else
            {
                if (FormatControl.IsMatch(e.KeyChar.ToString()) && (e.KeyChar != 8))
                {

                    MessageBox.Show("Solo numero se acepta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
            }
        }

        private void txtNroComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13 || e.KeyChar==9 )
            {
                this.dtFecha.Focus();
            }
            else
            {
                if (e.KeyChar == (char)Keys.Escape)
                {

                    habilitarMenuStock();
                    limpiarControlesTextoStock();

                    Modo = 0;
                    this.DGCompraLibros.Focus();
                }
                else
                {
                    if (FormatControl.IsMatch(e.KeyChar.ToString()) && (e.KeyChar != 8))
                    {

                        MessageBox.Show("Solo numero se acepta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Handled = true;
                    }
                }
            }
        }

        private void dtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtCotizacion.Focus();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar==9)
            {
                if (DGDetalle.RowCount == 0 && this.txtIdTransaccion.Text=="0")
                {
                    OperacionStock();
                }
                else
                {
                    this.btnAgregarStock.Focus();
                }
            }
        }

        private void mnuSalirStock_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabCompra" && Modo == 0 && e.KeyChar == '+')
            {
                AgregarStock();
                e.Handled = true;
            }
          
        }

        private void DGCompraLibros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; 
                EditarStock();
               
            }
        }

        private void dataGridLibros_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Editar();

            }
        }

        private void frmLibros_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLibros._instance = null;
        }

       

   

        //---------------------------------------
        // -----------Combo----------------------
        //---------------------------------------
        private void AgregarCombo()
        {
            Modo = 1;
            this.lblModoCombo.Text = "Agregando...";
            this.txtIdCombo.Text = "0";
            DeshabilitarMenuCombo();

            limpiarControlesCombo();
            ControlesCombo(true);
            this.btnAgregarCombo.Enabled = false;
            this.DGDetalleCombo.Enabled = false;
            
            this.numAno.Value = DateTime.Now.Year;
            this.cboGradoCurso.Focus();

        }

        private void DeshabilitarMenuCombo()
        {
            this.mnuAgregarCombo.Enabled = false;
            this.mnuEditarCombo.Enabled = false;
            this.mnuEliminarCombo.Enabled = false;
            this.panel3.Visible = true;
            picturecombo.Visible = false;
        }

        private void limpiarControlesCombo()
        {

            this.cboGradoCurso.SelectedIndex = -1;

        }

        private void mnuAgregarCombo_Click(object sender, EventArgs e)
        {
            AgregarCombo();
        }


        private void habilitarMenuCombo()
        {
            this.mnuAgregarCombo.Enabled = true;
            this.mnuEditarCombo.Enabled = true;
            this.mnuEliminarCombo.Enabled = true;
            this.panel3.Visible = false;
            this.DGCombos.Enabled = true;
            this.DGCombos.Focus();
            this.picturecombo.Visible = true;
            this.picturecombo.Location = new Point(25, 114);
        }

        private void btnCancelarCombo_Click(object sender, EventArgs e)
        {

            habilitarMenuCombo();
            limpiarControlesCombo();
            this.DGCombos.Focus();

            Modo = 0;
        }

        private void mnuSalirCombo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarComboCurso()
        {
            string sql = "spGradoCurso";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            DataTable dtgradocurso = DBMapeo.ProcedureSelect(sql, parameters);



            this.cboGradoCurso.DataSource = dtgradocurso;
            this.cboGradoCurso.ValueMember = "IdCursoGrado";
            this.cboGradoCurso.SelectedIndex = 0;
            this.cboGradoCurso.DisplayMember = "Descripcion";
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

        private void btnAceptarCombo_Click(object sender, EventArgs e)
        {
            OperacionCombo();
        }

        private void OperacionCombo()
        {
            if (RequisitosCombo())
            {
                int id = Convert.ToInt32(this.txtIdCombo.Text);
                int ano = Convert.ToInt32(this.numAno.Value);
                int gradocurso = Convert.ToInt32(this.cboGradoCurso.SelectedValue);
                if (Modo == 1)
                {
                    if (UnicoCombo(4))
                    {
                        List<DbParameter> parameters = new List<DbParameter>();
                        parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                        parameters.Add(new DbParameter("pId", DbDirection.Input, id));
                        parameters.Add(new DbParameter("pIdCursoGrado", DbDirection.Input, gradocurso));
                        parameters.Add(new DbParameter("pAnho", DbDirection.Input, ano));
                        parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

                        int retorno = DBMapeo.ExecuteNonQuery("spComboLibros", parameters);
                        this.txtIdCombo.Text = DBMapeo.OutParameters[0].Value.ToString();
                        if (DGDetalleCombo.RowCount == 0)
                        {
                            IdComboItem = "0";

                            abrircombo();
                        }
                        else
                        {
                            CargarCombo(0);
                            habilitarMenuCombo();
                        }
                        Modo = 2;
                       

                        //habilitarMenuCombo();
                      //  MueveDatagrid(isbn);
                    }
                    else
                    {
                        MessageBox.Show("Ya existe ese combo para el Grado/Curso - Año!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.numAno.Focus();
                    }
                }
                else
                {
                    if (UnicoCombo(7))
                    {
                        List<DbParameter> parameters = new List<DbParameter>();
                        parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
                        parameters.Add(new DbParameter("pId", DbDirection.Input, id));
                        parameters.Add(new DbParameter("pIdCursoGrado", DbDirection.Input, gradocurso));
                        parameters.Add(new DbParameter("pAnho", DbDirection.Input, ano));
                        parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

                        int retorno = DBMapeo.ExecuteNonQuery("spComboLibros", parameters);
                        CargarCombo(rowindexCombo);
                        habilitarMenuCombo();
                        Modo = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ya existe ese combo para el Grado/Curso - Año!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.numAno.Focus();
                    }

                }
 
            }
        }

        private bool RequisitosCombo()
        {
            bool retorno = true;
            if (Convert.ToInt32(cboGradoCurso.SelectedValue) == 0)
            {
                MessageBox.Show("Falta Grado o Curso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboGradoCurso.Focus();
                retorno = false;

            }
            else
            {
                if (!Regex.IsMatch(this.numAno.Text, @"\d+"))
                {

                    MessageBox.Show("Falta Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.numAno.Focus();
                    retorno = false;
                }

            }
            return retorno;
        }

        private bool UnicoCombo(int operacion)
        {
            bool unico = true;
            int id =Convert.ToInt32( this.txtIdCombo.Text);
            int ano = Convert.ToInt32(this.numAno.Value);
            int gradocurso = Convert.ToInt32(this.cboGradoCurso.SelectedValue);
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, operacion));
            parameters.Add(new DbParameter("pId", DbDirection.Input, id));
            parameters.Add(new DbParameter("pIdCursoGrado", DbDirection.Input, gradocurso));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, ano));
            parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));
            int cantidad = Convert.ToInt32(DBMapeo.Escalar("spComboLibros", parameters));
            if (cantidad > 0)
                unico = false;
            return unico;
        }

        

        private void abrircombo()
        {

            frmItemCombo frmItem = new frmItemCombo();
            frmItem.FormClosed += new FormClosedEventHandler(form3_FormClosed);
            frmItem._txtIdTransaccion = _textIdCombo;
            frmItem._txtIdItemCombo = _textIdComboItem;
            frmItem._formlibros = this;
            frmItem._rowindewfrmlibros = rowindexCombo;
            frmItem.ShowDialog();
        }

        private void DetalleCombo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            abrircombo();
        }

        private void btnAgregarCombo_Click(object sender, EventArgs e)
        {
            IdComboItem = "0";
            abrircombo();
        }


        public void LlenarDetalleCombo()
        {
            List<DbParameter> parametro = new List<DbParameter>();
            parametro.Add(new DbParameter("pId", DbDirection.Input, 0));
            parametro.Add(new DbParameter("pIdCombo", DbDirection.Input, txtIdCombo.Text));
            parametro.Add(new DbParameter("pOperacion", DbDirection.Input, 5));
            parametro.Add(new DbParameter("pIdLibro", DbDirection.Input, null));
            parametro.Add(new DbParameter("pCantidad", DbDirection.Input, null));
           
            DataTable dtResults = DBMapeo.ProcedureSelect("spComboDetalle", parametro);

            this.DGDetalleCombo.AutoGenerateColumns = false;
            this.DGDetalleCombo.DataSource = dtResults;
            if (DGDetalleCombo.RowCount == 0)
                IdComboItem = "0";
            else
            {
                IdComboItem = DGDetalleCombo["IdCombo", 0].Value.ToString();
                DGDetalleCombo.Rows[0].Selected = true;
                DGDetalleCombo.CurrentCell = DGDetalleCombo.Rows[0].Cells[2];
            }

                       
        }


        private void form3_FormClosed(object sender, FormClosedEventArgs e)
        {

           
            CargarCombo(rowindexCombo);
            LlenarDetalleCombo();
           
            this.DGCombos.Enabled = false;
          
            //Operacion = "";
        }


        private void ControlesCombo(bool valor)
        {
          //  this.txtIdCombo.Enabled = valor;
            this.numAno.Enabled = valor;
            this.cboGradoCurso.Enabled = valor;
            
        }
        private void mnuEliminarCombo_Click(object sender, EventArgs e)
        {
            Modo = 3;
            this.lblModoCombo.Text = "Eliminando...";
            rowindexCombo = DGCombos.CurrentRow.Index;
            DeshabilitarMenuCombo();
            this.txtIdCombo.Text = DGCombos["IdComboLibro", rowindexCombo].Value.ToString();
            this.numAno.Value = Convert.ToDecimal(DGCombos["Anho", rowindexCombo].Value);
            this.cboGradoCurso.SelectedValue = DGCombos["IdCursoGrado", rowindexCombo].Value.ToString();

            LlenarDetalleCombo();
            ControlesCombo(false);
            this.btnAgregarCombo.Enabled = false;
            this.DGDetalleCombo.Enabled = false;
            Char pad = Convert.ToChar("-");
            string str = "¿ Desea borrar el Registro ? " + "\r";
            str = str.PadRight(54, pad) + "\r" + "Id Combo : " + this.txtIdCombo.Text;

            if (MessageBox.Show(str, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(this.txtIdCombo.Text);

                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 5));
                parameters.Add(new DbParameter("pId", DbDirection.Input, id));
                parameters.Add(new DbParameter("pIdCursoGrado", DbDirection.Input, null));
                parameters.Add(new DbParameter("pAnho", DbDirection.Input, null));
                parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, 0));
                int retorno = DBMapeo.ExecuteNonQuery("spComboLibros", parameters);
                CargarCombo(0);


            }
            habilitarMenuCombo();


        }

        private void EditarCombo()
        {

            Modo = 2;
            this.lblModoCombo.Text = "Editando...";
            rowindexCombo = DGCombos.CurrentRow.Index;
            DeshabilitarMenuCombo();
            this.txtIdCombo.Text = DGCombos["IdComboLibro", rowindexCombo].Value.ToString();
            this.numAno.Value = Convert.ToDecimal(DGCombos["Anho", rowindexCombo].Value);
            this.cboGradoCurso.SelectedValue = DGCombos["IdCursoGrado", rowindexCombo].Value.ToString();

            LlenarDetalleCombo();
            ControlesCombo(true);
            this.btnAgregarCombo.Enabled = true;
            this.DGDetalleCombo.Enabled = true;
        }

        private void mnuEditarCombo_Click(object sender, EventArgs e)
        {
            EditarCombo();
        }

        private void DGCombos_DoubleClick(object sender, EventArgs e)
        {
            EditarCombo();
        }

        private void DGCombos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EditarCombo();

            }
        }
        private void EliminarItemCombo(int IdBorrar)
        {
                List<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pId", DbDirection.Input, IdBorrar));
                parameters.Add(new DbParameter("pIdCombo", DbDirection.Input, null));
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 4));
                parameters.Add(new DbParameter("pIdLibro", DbDirection.Input, null));
                parameters.Add(new DbParameter("pCantidad", DbDirection.Input, null));
                int retorno = DBMapeo.ExecuteNonQuery("spComboDetalle", parameters);
         
        }


        private void DGDetalleCombo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(DGDetalleCombo["IdCombo", e.RowIndex].Value);
            IdComboItem = Id.ToString();
            if (e.ColumnIndex == 3)
            { abrircombo(); }
            else
            {
                if (e.ColumnIndex == 4)
                {
                    Char pad = Convert.ToChar("-");
                    string str = "¿ Desea borrar el Registro ? " + "\r";
                    str = str.PadRight(60, pad) + "\r" + "ISBN : " + DGDetalleCombo["ISBNCombo", e.RowIndex].Value.ToString();
                    if (MessageBox.Show(str, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        EliminarItemCombo(Id);
                        LlenarDetalleCombo();
                    }

                }
            }
        }

        private void cboGradoCurso2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                CargarComboSeccion(Convert.ToInt16(cboGradoCurso2.SelectedValue));
                CargaComboIngreso(Convert.ToInt32(this.numAnho.Value), Convert.ToInt16(cboGradoCurso2.SelectedValue));
                CargarAlumnos(Convert.ToInt32(this.numAnho.Value),Convert.ToInt32( this.cboTipoIngreso.SelectedValue), Convert.ToInt16(cboGradoCurso2.SelectedValue), Convert.ToInt32(this.cboSeccion.SelectedValue));
                CargarCombo(Convert.ToInt32(this.numAnho.Value), Convert.ToInt16(cboGradoCurso2.SelectedValue));
                LabelCurso();
                this.dataGridAlumnos.Focus();
              
                MostrarMovimiento();
               
               
            
            
        }

        private void LabelCurso()
        { 
            this.lblGrado.Text = this.numAnho.Value.ToString() + " -- " + this.cboGradoCurso2.Text + " -- " + this.cboSeccion.Text + "      Ingreso Pagado :" + this.cboTipoIngreso.Text;
            this.lblCantidadAlumno.Text = "Cantidad de Alumnos : " + this.dataGridAlumnos.RowCount.ToString();
        }


        private void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                CargarAlumnos(Convert.ToInt32(this.numAnho.Value), Convert.ToInt32(this.cboTipoIngreso.SelectedValue), Convert.ToInt16(cboGradoCurso2.SelectedValue), Convert.ToInt32(this.cboSeccion.SelectedValue));
                LabelCurso();
                MostrarMovimiento();
                
            
        }

        private void CargaComboIngreso(int pAno,int pCurso)
        {
            string sql = "spTipoIngreso";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pAno", DbDirection.Input, pAno));
            parameters.Add(new DbParameter("pGrado", DbDirection.Input, pCurso));
            DataTable dttipoingreso = DBMapeo.ProcedureSelect(sql, parameters);



           
            this.cboTipoIngreso.ValueMember = "IdTipoIngreso";
            this.cboTipoIngreso.DisplayMember = "Descripcion";
            this.cboTipoIngreso.DataSource = dttipoingreso;
            this.cboTipoIngreso.SelectedValue = 2;
           
        
        }

        private void CargarAlumnos(int pAno, int pTipoIngreso, int pCurso, int pSeccion)
        {
            string sql = "spAlumnosActivos";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, pAno));
            parameters.Add(new DbParameter("pTipoIngreso", DbDirection.Input, pTipoIngreso));  
            parameters.Add(new DbParameter("pCurso", DbDirection.Input, pCurso));
            parameters.Add(new DbParameter("pSeccion", DbDirection.Input, pSeccion));
            dtAlumno = DBMapeo.ProcedureSelect(sql, parameters);
            this.dataGridAlumnos.DataSource = dtAlumno;
            if (dtAlumno.Rows.Count > 0)
                this.panel4.Enabled = true;
            else
                this.panel4.Enabled = false;
        }

        private void CargarStock(int pOperacion,string pISBN)
        {
            DataTable dtStock = new DataTable();
            string sql = "spStockLibros";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, pOperacion));
            parameters.Add(new DbParameter("pISBN", DbDirection.Input, pISBN));
            dtStock = DBMapeo.ProcedureSelect(sql, parameters);
            this.dataGridStock.DataSource = dtStock;

           
        }

        private void cboTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                CargarAlumnos(Convert.ToInt32(this.numAnho.Value), Convert.ToInt32(this.cboTipoIngreso.SelectedValue), Convert.ToInt16(cboGradoCurso2.SelectedValue), Convert.ToInt32(this.cboSeccion.SelectedValue));
                LabelCurso();
            
        }

        private void CargarCombo(int pAno, int pCurso)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 6));
            parameters.Add(new DbParameter("pId", DbDirection.Input, 0));
            parameters.Add(new DbParameter("pIdCursoGrado", DbDirection.Input, pCurso));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, pAno));
            parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, 0));
            dtCombo = DBMapeo.ProcedureSelect("spComboLibros", parameters);
            dtCombo.Columns.Add("Disponible");
            dtCombo.Columns.Add("Completo");
            
            for (int i = 0; i < dtCombo.Rows.Count; i++)
            {
                dtCombo.Rows[i]["Completo"] = dtCombo.Rows[i]["ISBN"].ToString() + "---" + dtCombo.Rows[i]["Titulo"].ToString();
                dtCombo.Rows[i]["Disponible"] = Convert.ToInt32(dtCombo.Rows[i]["Cantidad"]) - Convert.ToInt32(dtCombo.Rows[i]["Alquiler"]) - Convert.ToInt32(dtCombo.Rows[i]["Venta"]) + Convert.ToInt32(dtCombo.Rows[i]["Devolucion"]);
            }

            this.dataGridCombo.DataSource = dtCombo;
        }

        private void numAnho_ValueChanged(object sender, EventArgs e)
        {

            CargarComboSeccion(Convert.ToInt16(cboGradoCurso2.SelectedValue));
            CargaComboIngreso(Convert.ToInt32(this.numAnho.Value), Convert.ToInt16(cboGradoCurso2.SelectedValue));
            CargarAlumnos(Convert.ToInt32(this.numAnho.Value), Convert.ToInt32(this.cboTipoIngreso.SelectedValue), Convert.ToInt16(cboGradoCurso2.SelectedValue), Convert.ToInt32(this.cboSeccion.SelectedValue));
            CargarCombo(Convert.ToInt32(this.numAnho.Value), Convert.ToInt16(cboGradoCurso2.SelectedValue));
            LabelCurso();
        }

        private void CargaMovimiento(int pIdAlumno )
        {
            int pAno =Convert.ToInt32( this.numAnho.Value);
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input,null));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, pIdAlumno));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, pAno));
            parameters.Add(new DbParameter("pCurso", DbDirection.Input, null));
            parameters.Add(new DbParameter("pIdLibro", DbDirection.Input, null));
            parameters.Add(new DbParameter("pTipoMovimiento", DbDirection.Input, null));
            DataTable dtAlumno = DBMapeo.ProcedureSelect("spMovimientoLibro", parameters);
            this.dataGridMov.DataSource = dtAlumno;
            foreach (DataGridViewRow row in dataGridMov.Rows)
            {
                if (Convert.ToInt32(row.Cells["IdTipoMovimiento"].Value) == 2)
                {
                    row.DefaultCellStyle.BackColor = Color.Pink;
                }
                if (Convert.ToInt32(row.Cells["IdTipoMovimiento"].Value) == 7)
                {
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                    //row.Cells["Devolver"].ReadOnly = true;
                    //row.Cells["Devolver"].Style.BackColor = Color.LightGray;
                    //row.Cells["Devolver"].Style.ForeColor = Color.DarkGray;
                    //row.Cells["Devolver"].Value = false;
                }
                if (Convert.ToInt32(row.Cells["IdTipoMovimiento"].Value) == 6)
                {
                    row.DefaultCellStyle.BackColor = Color.Gold;
                }
            }

        }

        private void dataGridAlumnos_DoubleClick(object sender, EventArgs e)
        {
            MostrarMovimiento();
        }

        private void dataGridAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                MostrarMovimiento();

            }
        }

        public void MostrarMovimiento()
        { 
             int rowindexAlumno=0;
            if (dataGridAlumnos.RowCount>0 && dataGridAlumnos.CurrentRow!= null)
                rowindexAlumno = dataGridAlumnos.CurrentRow.Index;


            if (dataGridAlumnos.RowCount>0)
            { 
                CargaMovimiento(Convert.ToInt32(dataGridAlumnos["IdAlumno", rowindexAlumno].Value.ToString()));
            }

           
        }

        private void dataGridAlumnos_MouseEnter(object sender, EventArgs e)
        {
            MostrarMovimiento();
        }

        private void dataGridAlumnos_Enter(object sender, EventArgs e)
        {
            MostrarMovimiento();
        }

        private void dataGridAlumnos_KeyUp(object sender, KeyEventArgs e)
        {
            MostrarMovimiento();
        }

        private void dataGridAlumnos_Click(object sender, EventArgs e)
        {
            MostrarMovimiento();
        }

        private void dataGridMov_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int IdTransaccion=0;
            int Anho=Convert.ToInt32(this.numAnho.Value);
            int GradoCurso= Convert.ToInt16(cboGradoCurso2.SelectedValue);
            int IdAlumno = GetIdAlumno();
            string Operacion = "Alquiler";
            abrirMovLibro(IdTransaccion, IdAlumno, Anho, GradoCurso,Operacion);
           

        }
        private string GetMatNombre()
        {
            int rowindexAlumno = 0;
            if (dataGridAlumnos.RowCount > 0 && dataGridAlumnos.CurrentRow != null)
                rowindexAlumno = dataGridAlumnos.CurrentRow.Index;
            string MatNombre = "";
            if (dataGridAlumnos.RowCount > 0)
            {
                MatNombre = dataGridAlumnos["Matricula", rowindexAlumno].Value.ToString() + "   " + dataGridAlumnos["ApellidosNombres", rowindexAlumno].Value.ToString();

            }
            return MatNombre;
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


        private void dataGridMov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
             {
                DataGridView dgv = (DataGridView)sender;
                string columnName = dgv.Columns[e.ColumnIndex].Name;

                if (columnName == "EditarMov")
                {
                    int IdTransaccion = Convert.ToInt32(dataGridMov["IdTransaccionTab", e.RowIndex].Value);
                    int Anho = Convert.ToInt32(this.numAnho.Value);
                    int GradoCurso = Convert.ToInt16(cboGradoCurso2.SelectedValue);
                    int IdAlumno = GetIdAlumno();
                    string Operacion = "Editar";
                    abrirMovLibro(IdTransaccion, IdAlumno, Anho, GradoCurso, Operacion);
                }

                if (columnName == "Devolver")
                {
                    int IdTipoMovimiento = Convert.ToInt32(dataGridMov["IdTipoMovimiento", e.RowIndex].Value);
                    if (IdTipoMovimiento == 7)
                    { MessageBox.Show("Libro ya ha sido devuelto !!!"); }
                    else
                    {
                        int IdLibro = Convert.ToInt32(dataGridMov["IdLibroNuevo", e.RowIndex].Value);
                        int IdTransaccion = Convert.ToInt32(dataGridMov["IdTransaccionTab", e.RowIndex].Value);
                        int NroEjemplar = Convert.ToInt32(dataGridMov["NroEjemplar", e.RowIndex].Value);
                        int Anho = Convert.ToInt32(this.numAnho.Value);
                        int GradoCurso = Convert.ToInt16(cboGradoCurso2.SelectedValue);
                        int IdAlumno = GetIdAlumno();
                        string Operacion = "Devolver";
                        DBUtils DBMapeo = new DBUtils();
                        List<DbParameter> parametros = new List<DbParameter>();
                        parametros.Add(new DbParameter("pIdAlumno", DbDirection.Input, IdAlumno));
                        parametros.Add(new DbParameter("pIdLibro", DbDirection.Input, IdLibro));
                        parametros.Add(new DbParameter("pNroEjemplar", DbDirection.Input, NroEjemplar));
                        //  parametros.Add(new DbParameter("pNroEjemplar", DbDirection.ReturnValue, 0));

                        bool retorno = (bool)DBMapeo.EscalarText("Select fnDevuelto(?pIdAlumno,?pIdLibro,?pNroEjemplar)", parametros);

                        if (retorno)
                        {
                            MessageBox.Show("Libro ya ha sido devuelto !!!");
                        }
                        else
                        {

                            abrirMovLibro(IdTransaccion, IdAlumno, Anho, GradoCurso, Operacion);
                        }
                    }
                }
            }
        }


        private void abrirMovLibro(int IdTransaccion, int IdAlumno, int Anho, int GradoCurso, string Operacion)
        {
            frmMovimiento frmMov = new frmMovimiento();
            frmMov._txtIdTransaccion = IdTransaccion;
            frmMov._txtIdAlumno = IdAlumno;
            frmMov._txtAnho = Anho;
            frmMov._txtGradoCurso = GradoCurso;
            frmMov._txtOperacion = Operacion;
            frmMov._txtMatriculaNombre = GetMatNombre();
            frmMov._formlibros = this;
            frmMov.FormClosed += new FormClosedEventHandler(form4_FormClosed);
            frmMov.ShowDialog();
        }

        private void form4_FormClosed(object sender, FormClosedEventArgs e)
        {


            MostrarMovimiento();
            CargarCombo(Convert.ToInt32(this.numAnho.Value), Convert.ToInt16(cboGradoCurso2.SelectedValue));
          // this.DGCombos.Enabled = false;

            //Operacion = "";
        }

        private void dataGridAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridAlumnos.Enabled = false;
            
            SilAdministracion.libros.infEntregaLibros reporte;
            reporte = new SilAdministracion.libros.infEntregaLibros();

            
            DataTable dt = new DataTable("DtDatosAlumno");
            dt.Columns.Add("IdAlumno");
            dt.Columns.Add("Matricula");
            dt.Columns.Add("Anho");
            dt.Columns.Add("Grado");
          
            DataRow datarow= dt.NewRow();
            datarow["IdAlumno"] = GetIdAlumno();
            datarow["Matricula"] = GetMatNombre();
            datarow["Anho"] =  Convert.ToInt32(this.numAnho.Value);
            datarow["Grado"] = cboGradoCurso2.Text + " - " + cboSeccion.Text;
            dt.Rows.Add(datarow);



            DataTable dtlibros = new DataTable("DtComboLibros");
            dtlibros.Columns.Add("IdAlumno");
            dtlibros.Columns.Add("ISBN");
            dtlibros.Columns.Add("Titulo");
            dtlibros.Columns.Add("Cantidad");
            dtlibros.Columns.Add("Ejemplar");

            for (int i = 0; i < dtCombo.Rows.Count; i++)
            {
                DataRow librorow = dtlibros.NewRow();

                librorow["IdAlumno"] = GetIdAlumno();
                librorow["ISBN"] = dtCombo.Rows[i]["ISBN"].ToString();
                librorow["Titulo"] = dtCombo.Rows[i]["Titulo"].ToString();
                librorow["Cantidad"] = Convert.ToInt32(dtCombo.Rows[i]["Cantidad"]);
                librorow["Ejemplar"] = Convert.ToInt32(dtCombo.Rows[i]["Cantidad"]);
                dtlibros.Rows.Add(librorow);
               
            }

            DataSet Ds = new DataSet();
            Ds.Tables.Add(dt);
            Ds.Tables.Add(dtlibros);
            DataColumn colParent =
            Ds.Tables["DtDatosAlumno"].Columns["IdAlumno"];
            DataColumn colChild =
                 Ds.Tables["DtComboLibros"].Columns["IdAlumno"];
            DataRelation drAlumnoId =
                 new DataRelation("AlumnoId", colParent, colChild);

            Ds.Relations.Add(drAlumnoId);

            

            reporte.SetDataSource(Ds);
            crystalReportViewer1.ReportSource = reporte;
            tabControl.SelectedTab = tabImp;
            this.dataGridAlumnos.Enabled = true;
               
        
        }

        private void tabMov_Click(object sender, EventArgs e)
        {

        }

        private void btnGrado_Click(object sender, EventArgs e)
        {
            this.btnGrado.Enabled = false;
            this.dataGridAlumnos.Enabled = false;

            SilAdministracion.libros.infMovimientoLibro reporte;
            reporte = new SilAdministracion.libros.infMovimientoLibro();
            int codcurso = Convert.ToInt16(cboGradoCurso2.SelectedValue);
            int codseccion = Convert.ToInt16(cboSeccion.SelectedValue); 
            List<DbParameter> parameters1 = new List<DbParameter>();
            parameters1.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
            parameters1.Add(new DbParameter("pIdGradoCurso", DbDirection.Input, codcurso));
            parameters1.Add(new DbParameter("pIdSeccion", DbDirection.Input, codseccion));
            parameters1.Add(new DbParameter("pIdCurso", DbDirection.Output, null));
            int retorno = DBMapeo.ExecuteNonQuery("spCurso", parameters1);
            int idcurso = Convert.ToInt32(DBMapeo.OutParameters[0].Value.ToString());



            DataTable dt = new DataTable("DtDatosAlumno");
            dt.Columns.Add("IdAlumno");
            dt.Columns.Add("Matricula");
            dt.Columns.Add("Anho");
            dt.Columns.Add("Grado");
            dt.Columns.Add("IdGrado");
            dt.Columns.Add("Nombre");
            for (int i = 0; i < dtAlumno.Rows.Count; i++)
            {
                if (dtAlumno.Rows[i]["estado"].ToString() == "A")
                {
                    DataRow datarow = dt.NewRow();
                    datarow["IdAlumno"] = dtAlumno.Rows[i]["IdAlumno"].ToString();
                    datarow["Matricula"] = dtAlumno.Rows[i]["Matricula"].ToString();
                    datarow["Anho"] = Convert.ToInt32(this.numAnho.Value);
                    datarow["Grado"] = cboGradoCurso2.Text + " - " + cboSeccion.Text;
                    datarow["IdGrado"] = idcurso;
                    datarow["Nombre"] = dtAlumno.Rows[i]["ApellidosNombres"].ToString();
                    dt.Rows.Add(datarow);
                }
            }


            DataTable dtlibros = new DataTable("DtComboLibros");
            dtlibros.Columns.Add("IdLibro");
            dtlibros.Columns.Add("ISBN");
            dtlibros.Columns.Add("Titulo");
            dtlibros.Columns.Add("IdGrado");
       

            for (int i = 0; i < dtCombo.Rows.Count; i++)
            {
                DataRow librorow = dtlibros.NewRow();
                librorow["IdLibro"] = dtCombo.Rows[i]["IdLibro"].ToString();
                librorow["ISBN"] = dtCombo.Rows[i]["ISBN"].ToString();
                librorow["Titulo"] = dtCombo.Rows[i]["Titulo"].ToString();
                librorow["IdGrado"] = idcurso;
                dtlibros.Rows.Add(librorow);

            }

            DataTable dtMovLibros = new DataTable("DtMovLibro");
            dtMovLibros.Columns.Add("IdAlumno");
            dtMovLibros.Columns.Add("IdLibro");
            dtMovLibros.Columns.Add("Ejemplar");

            int pMovimiento = rdPrestamo.Checked ? 2 : 7;
            int pAno = Convert.ToInt32(this.numAnho.Value);
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 5));
            parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, null));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, null));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, pAno));
            parameters.Add(new DbParameter("pCurso", DbDirection.Input, idcurso));
            parameters.Add(new DbParameter("pIdLibro", DbDirection.Input, null));
            parameters.Add(new DbParameter("pTipoMovimiento", DbDirection.Input, pMovimiento));
            DataTable dtMovimiento = DBMapeo.ProcedureSelect("spMovimientoLibro", parameters);

            for (int i = 0; i < dtMovimiento.Rows.Count; i++)
            {
                DataRow libromovrow = dtMovLibros.NewRow();
                libromovrow["IdAlumno"] = dtMovimiento.Rows[i]["IdAlumno"].ToString();
                libromovrow["IdLibro"] = dtMovimiento.Rows[i]["IdLibroNuevo"].ToString();
                libromovrow["Ejemplar"] = dtMovimiento.Rows[i]["NroEjemplar"].ToString();

                dtMovLibros.Rows.Add(libromovrow);

            }



            DataSet Ds = new DataSet();
            Ds.Tables.Add(dt);
            Ds.Tables.Add(dtlibros);
            Ds.Tables.Add(dtMovLibros);
            DataColumn colParent =
            Ds.Tables["DtDatosAlumno"].Columns["IdGrado"];
            DataColumn colChild =
                 Ds.Tables["DtComboLibros"].Columns["IdGrado"];
            DataRelation drGradoId =
                 new DataRelation("GradoId", colParent,colChild,false );

            Ds.Relations.Add(drGradoId);

            DataColumn colParent1 =
          Ds.Tables["DtDatosAlumno"].Columns["IdAlumno"];
            DataColumn colChild1 =
                 Ds.Tables["DtMovLibro"].Columns["IdAlumno"];
            DataRelation drAlumnoId =
                 new DataRelation("AlumnoId", colParent1, colChild1,false);
            Ds.Relations.Add(drAlumnoId);

            DataColumn colParent2 =
          Ds.Tables["DtComboLibros"].Columns["IdLibro"];
            DataColumn colChild2 =
                 Ds.Tables["DtMovLibro"].Columns["IdLibro"];
            DataRelation drLibroId =
                 new DataRelation("drLibroId", colParent2, colChild2,false);
            Ds.Relations.Add(drLibroId);


            reporte.SetDataSource(Ds);
            crystalReportViewer1.ReportSource = reporte;
            tabControl.SelectedTab = tabImp;
            this.dataGridAlumnos.Enabled = true;
            this.btnGrado.Enabled = true;
               
        }

        private void btnEntrega_Click(object sender, EventArgs e)
        {
            this.btnGrado.Enabled = false;
            this.dataGridAlumnos.Enabled = false;

            SilAdministracion.libros.infEntregaLibros reporte;
            reporte = new SilAdministracion.libros.infEntregaLibros();
            int codcurso = Convert.ToInt16(cboGradoCurso2.SelectedValue);
            int codseccion = Convert.ToInt16(cboSeccion.SelectedValue);
            if (codseccion > 0)
            {

                List<DbParameter> parameters1 = new List<DbParameter>();
                parameters1.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
                parameters1.Add(new DbParameter("pIdGradoCurso", DbDirection.Input, codcurso));
                parameters1.Add(new DbParameter("pIdSeccion", DbDirection.Input, codseccion));
                parameters1.Add(new DbParameter("pIdCurso", DbDirection.Output, null));
                int retorno = DBMapeo.ExecuteNonQuery("spCurso", parameters1);
                int idcurso = Convert.ToInt32(DBMapeo.OutParameters[0].Value.ToString());



                DataTable dt = new DataTable("DtDatosAlumno");
                dt.Columns.Add("IdAlumno");
                dt.Columns.Add("Matricula");
                dt.Columns.Add("Anho");
                dt.Columns.Add("Grado");
                dt.Columns.Add("IdGrado");
                dt.Columns.Add("Nombre");
                if (rdTodos.Checked)
                {
                    for (int i = 0; i < dtAlumno.Rows.Count; i++)
                    {
                        DataRow datarow = dt.NewRow();
                        datarow["IdAlumno"] = dtAlumno.Rows[i]["IdAlumno"].ToString();
                        datarow["Matricula"] = dtAlumno.Rows[i]["Matricula"].ToString();
                        datarow["Anho"] = Convert.ToInt32(this.numAnho.Value);
                        datarow["Grado"] = cboGradoCurso2.Text + " - " + cboSeccion.Text;
                        datarow["IdGrado"] = idcurso;
                        datarow["Nombre"] = dtAlumno.Rows[i]["ApellidosNombres"].ToString();
                        dt.Rows.Add(datarow);
                    }
                }
                else
                {
                    DataRow datarow = dt.NewRow();
                    DataRow[] alumselect = dtAlumno.Select("IdAlumno=" + Convert.ToInt32(dataGridAlumnos.CurrentRow.Cells[0].Value));
                    datarow["IdAlumno"] = alumselect[0][0];
                    datarow["Matricula"] = alumselect[0][1];
                    datarow["Anho"] = Convert.ToInt32(this.numAnho.Value);
                    datarow["Grado"] = cboGradoCurso2.Text + " - " + cboSeccion.Text;
                    datarow["IdGrado"] = idcurso;
                    datarow["Nombre"] = alumselect[0][2];
                    dt.Rows.Add(datarow);

                }


                DataTable dtlibros = new DataTable("DtComboLibros");
                dtlibros.Columns.Add("IdLibro");
                dtlibros.Columns.Add("ISBN");
                dtlibros.Columns.Add("Titulo");
                dtlibros.Columns.Add("IdGrado");


                for (int i = 0; i < dtCombo.Rows.Count; i++)
                {
                    DataRow librorow = dtlibros.NewRow();
                    librorow["IdLibro"] = dtCombo.Rows[i]["IdLibro"].ToString();
                    librorow["ISBN"] = dtCombo.Rows[i]["ISBN"].ToString();
                    librorow["Titulo"] = dtCombo.Rows[i]["Titulo"].ToString();
                    librorow["IdGrado"] = idcurso;
                    dtlibros.Rows.Add(librorow);

                }




                DataSet Ds = new DataSet();
                Ds.Tables.Add(dt);
                Ds.Tables.Add(dtlibros);

                DataColumn colParent =
                Ds.Tables["DtDatosAlumno"].Columns["IdGrado"];
                DataColumn colChild =
                     Ds.Tables["DtComboLibros"].Columns["IdGrado"];
                DataRelation drGradoId =
                     new DataRelation("GradoId", colParent, colChild, false);

                Ds.Relations.Add(drGradoId);





                reporte.SetDataSource(Ds);
                crystalReportViewer1.ReportSource = reporte;
                tabControl.SelectedTab = tabImp;
                this.dataGridAlumnos.Enabled = true;
                this.btnGrado.Enabled = true;
            }
        }

        private void cboISBN_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (this.cboISBN.SelectedValue.ToString()=="0")
                 CargarStock(2,null);
            else
                CargarStock(3, this.cboISBN.SelectedValue.ToString());
           
        }

        private void btnImprimirCombo_Click(object sender, EventArgs e)
        {
            ReportDocument rdReporte = new ReportDocument();
            string strReportPath = Convert.ToString(ConfigurationManager.AppSettings["ReportesPath"]);
            rdReporte.Load(strReportPath + "\\crComboLibros.rpt");
            crystalReportViewer1.ReportSource = rdReporte;
            tabControl.SelectedTab = tabImp;
        }

    }
   
}
