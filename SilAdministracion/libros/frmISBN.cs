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
    public partial class frmISBN : Form
    {
        DBUtils DBMapeo = new DBUtils();
        public frmISBN()
        {
            InitializeComponent();
        }

        public string _txtISBN
        {
          set  {this.txtISBN1.Text = value;}
            get { return this.txtISBN1.Text; }
        }

        //public string _txtISBN2
        //{
        //    get { return "1"; }

        //}
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmISBN_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Operacion();

            this.Close();
        }

      

        private void Operacion()
        {
            if (Requisitos())
            {
                string isbn = this.txtISBN.Text;
                string titulo = this.txtTitulo.Text;

               

                    if (Unico())
                    {
                        List<DbParameter> parameters = new List<DbParameter>();
                        parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 2));
                        parameters.Add(new DbParameter("pId", DbDirection.Input, null));
                        parameters.Add(new DbParameter("pISBN", DbDirection.Input, isbn));
                        parameters.Add(new DbParameter("pTitulo", DbDirection.Input, titulo));
                        parameters.Add(new DbParameter("pCantVol", DbDirection.Input, null));
                        parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));

                        int retorno = DBMapeo.ExecuteNonQuery("spLibros", parameters);
                        this._txtISBN = DBMapeo.OutParameters[0].Value.ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show("Ya existe ese ISBN, verifique por favor!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtISBN.Focus();
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
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("pOperacion", DbDirection.Input, 3));
            parameters.Add(new DbParameter("pId", DbDirection.Input, null));
            parameters.Add(new DbParameter("pISBN", DbDirection.Input, isbn));
            parameters.Add(new DbParameter("pTitulo", DbDirection.Input, titulo));
            parameters.Add(new DbParameter("pCantVol", DbDirection.Input, null));
            parameters.Add(new DbParameter("pUltimoId", DbDirection.Output, null));
            int cantidad = Convert.ToInt32(DBMapeo.Escalar("spLibros", parameters));
            if (cantidad > 0)
                unico = false;
            return unico;
        }

       

      

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtTitulo.Focus();
            }
        }

        private void txtTitulo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Operacion();
                this.Close();
            }
        }

        
    }
}
