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
    public partial class frmMovimiento : Form
    {

        DBUtils DBMapeo = new DBUtils();
        public int pAnho;
        public int pGradoCurso;
        public int pIdAlumno;
        public string pOperacion;
        public int indice = 0;
        DataTable dtAlumno;
        frmLibros formlibros;
        public int _txtIdTransaccion
        {
            set { txtIdTransaccion.Text = value.ToString(); }
        }

        public int _txtIdAlumno
        {
            set { pIdAlumno = value; }
        }

        public string _txtMatriculaNombre
        {
            set { lblAlumno.Text= value; }
        }

        public int _txtAnho
        {
            set { pAnho = value; }
        }

        public string _txtOperacion
        {
          //  get { return IdStockItem; }
            set { pOperacion = value.ToString(); }

        }

        public int _txtGradoCurso
        {
            set { pGradoCurso = value; }
        }
       
        public object _formlibros
        {
            set { formlibros = (frmLibros)value; }
        }
        public frmMovimiento()
        {
            InitializeComponent();
        }

        private void frmMovimiento_Load(object sender, EventArgs e)
        {
             indice = 0;
            int pNewOperacion = 0;
            int NroComprobante = 0;
            if (pOperacion == "Alquiler")
            {
                pNewOperacion = 2;
                List<DbParameter> parametro1 = new List<DbParameter>();
                parametro1.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
                parametro1.Add(new DbParameter("pIdTransaccion", DbDirection.Input, null));
                NroComprobante = Convert.ToInt32(DBMapeo.Escalar("spComprobante", parametro1));
                this.txtNroComprobante.Text = NroComprobante.ToString();

            }
            else
            {
                if (pOperacion == "Editar")
                {
                    pNewOperacion = 4;
                    List<DbParameter> parametro1 = new List<DbParameter>();
                    parametro1.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                    parametro1.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
                    DataTable dtDatos = DBMapeo.ProcedureSelect("spComprobante", parametro1);
                    if (dtDatos.Rows.Count > 0)
                    {
                        this.txtNroComprobante.Text = dtDatos.Rows[0]["NroComprobante"].ToString();
                        this.dtFecha.Text = dtDatos.Rows[0]["Fecha"].ToString();
                        this.txtObservacion.Text = dtDatos.Rows[0]["Descripcion"].ToString();
                    }

                }


                if (pOperacion == "Devolver")
                {
                    this.lblAgregarLibro.Visible = false;
                    this.cboLibros.Visible = false;
                    this.btnAgregar.Visible = false;
                
                    pNewOperacion = 4;
                    List<DbParameter> parametro1 = new List<DbParameter>();
                    parametro1.Add(new DbParameter("pOperacion", DbDirection.Input, 1));
                    parametro1.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
                    NroComprobante = Convert.ToInt32(DBMapeo.Escalar("spComprobante", parametro1));
                    this.txtNroComprobante.Text = NroComprobante.ToString();


                }

            }

            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, pNewOperacion));
            parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, pIdAlumno));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, pAnho));
            parameters.Add(new DbParameter("pCurso", DbDirection.Input, pGradoCurso));
            parameters.Add(new DbParameter("pIdLibro", DbDirection.Input, null));
            parameters.Add(new DbParameter("pTipoMovimiento", DbDirection.Input, null));
            dtAlumno = DBMapeo.ProcedureSelect("spMovimientoLibro", parameters);

            dtAlumno.Columns.Add("Disponible");

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "Disponible";
            col1.DataPropertyName = "Disponible";
            col1.Width = 60;
            dataGridMovimiento.Columns.Add(col1);



            for (int i = 0; i < dtAlumno.Rows.Count; i++)
            {
                dtAlumno.Rows[i]["Disponible"] = Convert.ToInt32(dtAlumno.Rows[i]["CantidadTotal"]) - Convert.ToInt32(dtAlumno.Rows[i]["Alquiler"]) - Convert.ToInt32(dtAlumno.Rows[i]["Venta"]) + Convert.ToInt32(dtAlumno.Rows[i]["Devolucion"]);
              
            }

           
            this.dataGridMovimiento.DataSource = dtAlumno;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Stock";
            img.ValuesAreIcons = false;
            img.Width = 50;
            dataGridMovimiento.Columns.Add(img);
            foreach (DataGridViewRow row in dataGridMovimiento.Rows)
            {
                if (Convert.ToInt32(row.Cells["Disponible"].Value) > 0)
                {
                    Bitmap image = Imagenes.Resources.flaggreen;
                      
                     row.Cells["img"].Value = image;
                     
                }
                else
                {
                    Bitmap image = Imagenes.Resources.flagred;
                    row.Cells["img"].Value = image;
                }
              
            }

            //DataGridViewButtonColumn cbutton = new DataGridViewButtonColumn();
            //    cbutton.Name = "Borrar";
            //    cbutton.Width = 70;
            //    cbutton.Text = "Borrar";
            //    cbutton.HeaderText = "---";
            //    cbutton.UseColumnTextForButtonValue = true;
            //    dataGridMovimiento.Columns.Add(cbutton);


                DataGridViewImageColumn img1 = new DataGridViewImageColumn();
                img1.Name = "Borrar";
                img1.HeaderText = "Borrar";
                img1.ValuesAreIcons = true;
                img1.Width = 50;
                img1.Icon = Imagenes.Resources.del;
                dataGridMovimiento.Columns.Add(img1);

              
                if (pOperacion != "Devolver")
                {
                    CargarCombo();

                }
                else
                {
                    this.txtIdTransaccion.Text = "0";
                 }
                if (dataGridMovimiento.RowCount > 0)
                {
                   // dataGridMovimiento.Focus();
                    dataGridMovimiento.CurrentCell = dataGridMovimiento.Rows[0].Cells["NroEjemplar"];
                    dataGridMovimiento.CurrentCell.Selected = true;
                    dataGridMovimiento.BeginEdit(true);
                  //  SendKeys.Send("{F2}");
                  

                   // dataGridMovimiento.c
                //    dataGridMovimiento.Rows[0].Cells["NroEjemplar"].Selected = true;
                //  //dataGridMovimiento.MultiSelect = false;
                //    dataGridMovimiento.BeginEdit(true);
                //    //DataGridViewRow rowToSelect = this.dataGridMovimiento.CurrentRow;
                //    //rowToSelect.Selected = true;

                //    //rowToSelect.Cells["NroEjemplar"].Selected = true;
                //    //this.dataGridMovimiento.CurrentCell = rowToSelect.Cells["NroEjemplar"];
                //    //this.dataGridMovimiento.BeginEdit(true);
                }
              //  MessageBox.Show("Load");
        }

        private void CargarCombo()
        {
            // Cargar Combo 

           
            string listalibros = "(";
            for (int i = 0; i < dataGridMovimiento.RowCount; i++)
            {
                if (i + 1 == dataGridMovimiento.Rows.Count)
                    listalibros = listalibros + dataGridMovimiento["IdLibro", i].Value.ToString() + ")";
                else
                    listalibros = listalibros + dataGridMovimiento["IdLibro", i].Value.ToString() + ",";

            }

            string sentencia = "SELECT concat(ISBN,'-- - ',Titulo) as ISBN,Id from tlibros ";
            if (dataGridMovimiento.RowCount>0)
                 sentencia += " where Id not in " + listalibros;

            DataTable dtCombo =DBMapeo.ProcedureSelect2(sentencia, null);

            DataRow dr = dtCombo.NewRow();
            dr["Id"] = 0;
            dr["ISBN"] = "------";
            dtCombo.Rows.Add(dr);
           
            //ComboBox item = new ComboboxItem();
            //item.Text = "--";
            //item.Value = 0;

            //cboLibros.Items.Add(item);
            //cboLibros.SelectedIndex = 0;

          
            this.cboLibros.ValueMember = "Id";
            this.cboLibros.DisplayMember = "ISBN";
           
            this.cboLibros.DataSource = dtCombo;
            this.cboLibros.SelectedValue = 0;
          
        }

        private void dataGridMovimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                string columnName = dgv.Columns[e.ColumnIndex].Name;
                if (columnName == "NroEjemplar")
                {
                    DataGridViewCell cell = dataGridMovimiento[e.ColumnIndex, e.RowIndex];
                    dataGridMovimiento.CurrentCell = cell;
                    dataGridMovimiento.BeginEdit(true);
                }
                if (columnName == "Borrar")
                {
                     Char pad = Convert.ToChar("-");
                    string str = "¿ Desea borrar el Registro ? " + "\r";
                    str = str.PadRight(60, pad) + "\r" + "ISBN : " + dataGridMovimiento["ISBNMov", e.RowIndex].Value.ToString();
                    if (MessageBox.Show(str, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string idlibro = dataGridMovimiento["IdLibro", e.RowIndex].Value.ToString();
                        DataRow[] drr = dtAlumno.Select("IdLibro=' " + idlibro + " ' ");
                        for (int i = 0; i < drr.Length; i++)
                            drr[i].Delete();
                        EliminarItem(idlibro);
                        dtAlumno.AcceptChanges();
                        ActualizarGrid();

                    }

                   
                    
                }
            }
        }

        private void ActualizarGrid()
        {
            foreach (DataGridViewRow row in dataGridMovimiento.Rows)
            {
                // row.Cells["Disponible"].ReadOnly = true;
                if (Convert.ToInt32(row.Cells["Disponible"].Value) > 0)
                {
                    Bitmap image = Imagenes.Resources.flaggreen;

                    row.Cells["img"].Value = image;

                }
                else
                {
                    Bitmap image = Imagenes.Resources.flagred;
                    row.Cells["img"].Value = image;
                }

            }

            //DataGridViewButtonColumn cbutton = new DataGridViewButtonColumn();
            //cbutton.Name = "Borrar";
            //cbutton.Width = 70;
            //cbutton.Text = "Borrar";
            //cbutton.HeaderText = "---";
            //cbutton.UseColumnTextForButtonValue = true;

            //dataGridMovimiento.Columns.Add(cbutton);
            CargarCombo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int IdLibro = Convert.ToInt32(cboLibros.SelectedValue);
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
            parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input,null));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, pIdAlumno));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, pAnho));
            parameters.Add(new DbParameter("pCurso", DbDirection.Input, pGradoCurso));
            parameters.Add(new DbParameter("pIdLibro", DbDirection.Input, IdLibro));
            parameters.Add(new DbParameter("pTipoMovimiento", DbDirection.Input, null));
            DataTable dtAuxAlumno = DBMapeo.ProcedureSelect("spMovimientoLibro", parameters);

            if (dtAuxAlumno.Rows.Count > 0)
            {
                DataRow dr = dtAlumno.NewRow();
                dr["IdLibro"] = dtAuxAlumno.Rows[0]["IdLibro"];
                dr["ISBN"] = dtAuxAlumno.Rows[0]["ISBN"];
                dr["NroEjemplar"] = dtAuxAlumno.Rows[0]["NroEjemplar"];
                dr["Cantidad"] = dtAuxAlumno.Rows[0]["Cantidad"];
                dr["CantidadTotal"] = dtAuxAlumno.Rows[0]["CantidadTotal"];
                dr["Alquiler"] = dtAuxAlumno.Rows[0]["Alquiler"];
                dr["Devolucion"] = dtAuxAlumno.Rows[0]["Devolucion"];
                dr["Venta"] = dtAuxAlumno.Rows[0]["Venta"];
                dr["NroItem"] = 0;
                dr["Disponible"] = Convert.ToInt32(dtAuxAlumno.Rows[0]["CantidadTotal"]) - Convert.ToInt32(dtAuxAlumno.Rows[0]["Alquiler"]) - Convert.ToInt32(dtAuxAlumno.Rows[0]["Venta"]) + Convert.ToInt32(dtAuxAlumno.Rows[0]["Devolucion"]);

                dtAlumno.Rows.Add(dr);
                CargarCombo();
                ActualizarGrid();
            }

        }

        private void btnAceptarCombo_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            OperacionMovimiento();
            this.Enabled = true;
            this.Close();
        }


        private void EliminarItem(string IdLibro)
        {
            int IdTransaccion = Convert.ToInt32(txtIdTransaccion.Text);
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 6));
            parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, IdTransaccion));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, null));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, null));
            parameters.Add(new DbParameter("pCurso", DbDirection.Input, null));
            parameters.Add(new DbParameter("pIdLibro", DbDirection.Input, Convert.ToInt32(IdLibro)));
            parameters.Add(new DbParameter("pTipoMovimiento", DbDirection.Input, null));

            int retorno = DBMapeo.ExecuteNonQuery("spMovimientoLibro", parameters);
        
        }

        private void OperacionMovimiento()
        {
            int idTipoOperacion = 2;
            int TipoMovimiento = 1;
            

            if (pOperacion == "Alquiler")
            {
                idTipoOperacion = 1;
              
                TipoMovimiento = 2;
            }
            if (pOperacion == "Editar")
            {
                idTipoOperacion = 2;
                TipoMovimiento = 2;
            }

            if (pOperacion == "Devolver")
            {
                idTipoOperacion = 1;
                TipoMovimiento = 7;
            }
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, idTipoOperacion));
            parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
            parameters.Add(new DbParameter("pFecha", DbDirection.Input, this.dtFecha.Value));
            parameters.Add(new DbParameter("pNroComprobante", DbDirection.Input, this.txtNroComprobante.Text));
            parameters.Add(new DbParameter("pIdAlumno", DbDirection.Input, this.pIdAlumno));
            parameters.Add(new DbParameter("pDescripcion", DbDirection.Input, this.txtObservacion.Text));
            parameters.Add(new DbParameter("pAnho", DbDirection.Input, this.dtFecha.Value.Year));
            parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

            int retorno = DBMapeo.ExecuteNonQuery("spAlquilerLibros", parameters);
            string IdTransaccion = DBMapeo.OutParameters[0].Value.ToString();
            if (pOperacion != "Editar")
            {
                this.txtIdTransaccion.Text = IdTransaccion;
            }
            string nroejemplar="";
            int cantidad = 0;
            int idlibro = 0;
            int nroitem = 0;
            int guardarnroitem = 0;
          
            for (int i = 0; i < dtAlumno.Rows.Count; i++)
            {
                nroitem = Convert.ToInt32(dtAlumno.Rows[i]["NroItem"]);

                if (nroitem == 0)
                {
                    if (pOperacion == "Alquiler")
                    { guardarnroitem = i; }
                    nroitem = guardarnroitem;
                    nroitem++;
                    idTipoOperacion = 1;
                }
                else
                {
                    idTipoOperacion = 2;
                    guardarnroitem = nroitem;
                }
               
                if (pOperacion == "Devolver")
                {
                    idTipoOperacion = 1;
                }

                nroejemplar = dtAlumno.Rows[i]["NroEjemplar"].ToString();
                cantidad = Convert.ToInt32( dtAlumno.Rows[i]["Cantidad"]);
                idlibro = Convert.ToInt32(dtAlumno.Rows[i]["IdLibro"]);

                parameters = new List<DbParameter>();
                parameters.Add(new DbParameter("pOperacion", DbDirection.Input, idTipoOperacion));
                parameters.Add(new DbParameter("pIdTransaccion", DbDirection.Input, txtIdTransaccion.Text));
                parameters.Add(new DbParameter("pNroItem", DbDirection.Input, nroitem));
                parameters.Add(new DbParameter("pNroEjemplar", DbDirection.Input, nroejemplar));
                parameters.Add(new DbParameter("pCantidad", DbDirection.Input, cantidad));
                parameters.Add(new DbParameter("pIdLibroNuevo", DbDirection.Input, idlibro));
                parameters.Add(new DbParameter("pIdTipoMovimiento", DbDirection.Input, TipoMovimiento));
                DBMapeo.ExecuteNonQuery("spDetalleAlquilerLibros", parameters);
            }


        }

        private void btnCancelarCombo_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridMovimiento_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dataGridMovimiento_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && dataGridMovimiento.CurrentCell.ColumnIndex == 4 && dataGridMovimiento.CurrentRow.Index==0)
            { 
                e.Handled = true;
                 int row = dataGridMovimiento.CurrentRow.Index;
                 if (row < dataGridMovimiento.RowCount)
                 {
                     DataGridViewCell cell = dataGridMovimiento.Rows[row].Cells["NroEjemplar"];
                     dataGridMovimiento.CurrentCell = cell;
                     dataGridMovimiento.BeginEdit(true);
                     MessageBox.Show(row.ToString());
                 }
                 
            }
        }

        private void dataGridMovimiento_KeyUp(object sender, KeyEventArgs e)
        {   
            if (e.KeyCode == Keys.Enter && dataGridMovimiento.CurrentCell.ColumnIndex == 4 )
            { 
                indice++;
                e.Handled = true;
                int row = dataGridMovimiento.CurrentRow.Index;
                if (row < dataGridMovimiento.RowCount && indice < dataGridMovimiento.RowCount)
                {
                    DataGridViewCell cell = dataGridMovimiento.Rows[row].Cells["NroEjemplar"];
                    dataGridMovimiento.CurrentCell = cell;
                    dataGridMovimiento.BeginEdit(true);
                  
                }
                else { btnAceptarCombo.Focus(); }
            }
        }

        private void dataGridMovimiento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show("Cell entre");
        }

        private void frmMovimiento_Shown(object sender, EventArgs e)
        {
           // MessageBox.Show("Shown");
            if (dataGridMovimiento.RowCount > 0)
            {
                // dataGridMovimiento.Focus();
                dataGridMovimiento.CurrentCell = dataGridMovimiento.Rows[0].Cells["NroEjemplar"];
                dataGridMovimiento.CurrentCell.Selected = true;
                dataGridMovimiento.BeginEdit(true);
            }
        }
       
    }
}
