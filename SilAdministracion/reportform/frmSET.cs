using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medusa;
using MedusaSQLServer;
using MedusaSQLServer2;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 
namespace SilAdministracion
{
    public partial class frmSET : Form
    {
        DBUtils DBMapeo = new DBUtils();
        DBUtilsServer DBMapeoSLQ = new DBUtilsServer();
        DBUtilsServer2 DBMapeoSLQ2 = new DBUtilsServer2();
        int CantidadRegistros = 0;
        float MontoTotal = 0;
        public frmSET()
        {
            InitializeComponent();
        }

        private void frmSET_Load(object sender, EventArgs e)
        {
            this.numAno.Value = DateTime.Now.Year;
          
            CargarComboMes();

           
           
        }

        public string cabecera(int libro)
        {
            int TipoRegistro = 1;

            int value =Convert.ToInt32( this.cmbMes.SelectedValue);
            string vmes=value.ToString("D2");
            int Periodo = Convert.ToInt32(this.numAno.Value.ToString() + vmes);
            
            int CodigoObligacion = 921;
            int  CodigoFormulario = 221;
           
            if (libro==1) // --Libro Compras.
            {
                CodigoObligacion = 911; 	
	            CodigoFormulario =211 ;
                
            }



          
            
            int TipoReporte = (cmbTipoReporte.Text == "Rectificativa")? 2:1;

            string RucAgenteInformacion = this.txtRucAgente.Text;
            string DVAgenteInformacion = this.txtDVAgente.Text;
            string AgenteInformacion = this.txtDenAgente.Text;

            string RucRepresentanteLegal = this.txtRucLegal.Text;
            string DVRepresentanteLegal = this.txtDVLegal.Text;
            string RepresentanteLegal = this.txtDenLegal.Text;



            string header = TipoRegistro + "\t" + Periodo + "\t" + TipoReporte + "\t" + CodigoObligacion + "\t" + CodigoFormulario + "\t" +
              RucAgenteInformacion + "\t" + DVAgenteInformacion + "\t"+ AgenteInformacion + "\t" +
              RucRepresentanteLegal + "\t" + DVRepresentanteLegal + "\t" + RepresentanteLegal;

             return header;

        }

        public void detalle(int libro)
        {

            int value = Convert.ToInt32(this.cmbMes.SelectedValue);
            string vmes = value.ToString("D2");
            int Periodo = Convert.ToInt32(this.numAno.Value.ToString() + vmes);
            string nombretxt = "libroventa" + Periodo.ToString();
            string header=cabecera(libro);
            
            int tiporegistro = 2;
            DataTable dtlibro = new DataTable();
            dtlibro.Clear();
            decimal MontoTotal = 0;
            string Exportador = "NO";
            string version = "2";
            string detalle = "";

            if (libro == 1)
            {
                dtlibro = dtLibroCompra(Convert.ToInt32(this.numAno.Value), Convert.ToInt32(this.cmbMes.SelectedValue));
                CantidadRegistros = dtlibro.Rows.Count;
                object sumObject1, sumObject2, sumObject3;
                sumObject1 = dtlibro.Compute("Sum(Monto10)", "");
                sumObject2 = dtlibro.Compute("Sum(Monto5)", "");
                sumObject3 = dtlibro.Compute("Sum(Exenta)", "");
                MontoTotal = Convert.ToDecimal(sumObject1) + Convert.ToDecimal(sumObject2) + Convert.ToDecimal(sumObject3);
                nombretxt = "librocompra" + Periodo.ToString();

                string sMontoTotal=MontoTotal.ToString();
                int indice= sMontoTotal.IndexOf(",");
                
                if (indice>0)
                 sMontoTotal= MontoTotal.ToString().Substring(0,indice);

                header = header + "\t" + CantidadRegistros + "\t" + sMontoTotal + "\t" + "NO" + "\t" + version;
            }
            else
            {
                dtlibro = dtLibroVenta(Convert.ToInt32(this.numAno.Value), Convert.ToInt32(this.cmbMes.SelectedValue));
                CantidadRegistros = dtlibro.Rows.Count;
                object sumObject1;
                sumObject1 = dtlibro.Compute("Sum(ImporteTotal)", "");
                MontoTotal = Convert.ToDecimal(sumObject1);
                string sMontoTotal = MontoTotal.ToString();
                int indice = sMontoTotal.IndexOf(",");

                if (indice > 0)
                    sMontoTotal = MontoTotal.ToString().Substring(0, indice);

                header = header + "\t" + CantidadRegistros + "\t" + sMontoTotal + "\t" + version;
             }


            nombretxt = nombretxt + "_" + DateTime.Now.ToString("ddHHmmss");
            StreamWriter outputFile = new StreamWriter("C:\\datos\\set\\" + nombretxt + ".txt");
            outputFile.WriteLine(header);
            float monto10, monto5, iva10, iva5 = 0;
            for (int i = 0; i < dtlibro.Rows.Count; i++)
            {
                string TR = dtlibro.Rows[i]["TipoRegistro"].ToString();
                string Ruc = dtlibro.Rows[i]["RUC"].ToString().Trim().Replace(".","").Replace(" ","") ;
                string aux = "";
                string DV = "";
                if (Ruc.Length > 0)
                {
                    string[] rucunico = Ruc.Split('-') ;
                    if (rucunico.Length==1)
                        rucunico = Ruc.Split('/');
                    aux = calcular(rucunico[0].Trim(), 11);
                     DV = dtlibro.Rows[i]["DV"].ToString().Trim();
                     Ruc = rucunico[0].Trim();
                    if (aux != DV || aux=="")
                    {
                        MessageBox.Show("Revisar RUC de " + dtlibro.Rows[i]["Nombre"].ToString() + "  Ruc: "+ Ruc);
                        DV = "";
                    }
                }
               
                string Nombre=dtlibro.Rows[i]["Nombre"].ToString();
                detalle = TR + "\t" + Ruc + "\t" + DV + "\t" + Nombre + "\t";
                if (libro == 1)
                { detalle = detalle + dtlibro.Rows[i]["timbrado"].ToString() +"\t"; }

                string TipoDoc = dtlibro.Rows[i]["TipoDocumento"].ToString();
                string NroDoc = dtlibro.Rows[i]["NroDocumento"].ToString().Trim();
                if (NroDoc.Length > 15)
                { 
                    MessageBox.Show("Revisar Nro Documento de " + "  Ruc:" + Ruc); 
                }
                else
                {
                    if (NroDoc.Length < 7 && !NroDoc.Contains("-"))
                    {
                         value = Convert.ToInt32(NroDoc);

                         if (value != 0)
                         {
                             NroDoc = value.ToString("D7");
                             if (libro ==1 || dtlibro.Rows[i]["sil"].ToString()=="1")
                             NroDoc =  this.txtSilFac.Text + NroDoc;
                             else
                                 NroDoc = this.txtISILFact.Text + NroDoc;
                         }
                         else { NroDoc = "0"; }
                    }
 
                }

                string FechaDoc = dtlibro.Rows[i]["FechaDoc"].ToString();
                string Monto10 =dtlibro.Rows[i]["Monto10"].ToString();
                Monto10 = Monto10.Substring(0, Monto10.IndexOf(",") != -1 ? Monto10.IndexOf(",") : Monto10.Length); 
                string IVA10 =dtlibro.Rows[i]["IVA10"].ToString();
                IVA10 = IVA10.Substring(0, IVA10.IndexOf(",") != -1 ? IVA10.IndexOf(",") : IVA10.Length); 
                string Monto5 =dtlibro.Rows[i]["Monto5"].ToString();
                Monto5 = Monto5.Substring(0, Monto5.IndexOf(",") != -1 ? Monto5.IndexOf(",") : Monto5.Length); 
                string IVA5 =dtlibro.Rows[i]["IVA5"].ToString();
                IVA5 = IVA5.Substring(0, IVA5.IndexOf(",") != -1 ? IVA5.IndexOf(",") : IVA5.Length); 
                string Exenta =dtlibro.Rows[i]["Exenta"].ToString();
                Exenta = Exenta.Substring(0, Exenta.IndexOf(",") != -1 ? Exenta.IndexOf(",") : Exenta.Length);
                string ImpTotal = "";
                if (libro == 2)
                {
                     ImpTotal = dtlibro.Rows[i]["ImporteTotal"].ToString();
                     ImpTotal = ImpTotal.Substring(0, ImpTotal.IndexOf(",") != -1 ? ImpTotal.IndexOf(",") : ImpTotal.Length);
                }

                detalle = detalle+ TipoDoc + "\t" + NroDoc + "\t" + FechaDoc + "\t"+
                 Monto10 + "\t" + IVA10 + "\t" + Monto5 + "\t" + IVA5 + "\t" + Exenta + "\t";
                    if (libro == 1)
                    {
                        detalle = detalle + dtlibro.Rows[i]["TipoOperacion"].ToString() + "\t" +
                          dtlibro.Rows[i]["CondicionCompra"].ToString() + "\t" + dtlibro.Rows[i]["CantidadCuotas"].ToString();
                    }
                    else {
                        detalle = detalle + ImpTotal + "\t" +
                          dtlibro.Rows[i]["CondicionVenta"].ToString() + "\t" + dtlibro.Rows[i]["CantidadCuotas"].ToString() +
                          "\t" + dtlibro.Rows[i]["timbrado"].ToString();
                    }

                  outputFile.WriteLine(detalle);
                }

                     outputFile.Close();
               //     MessageBox.Show("Generado txt en " + nombretxt+".txt");

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    object objOpt = Type.Missing;
                    xlApp = new Excel.Application();
                    xlApp.Visible = true;
                    xlWorkBook = xlApp.Workbooks.Open("C:\\datos\\set\\" + nombretxt + ".txt", objOpt, true, objOpt, objOpt, objOpt, objOpt, objOpt, objOpt, objOpt, objOpt, objOpt, objOpt, objOpt, objOpt);
                 //   xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                //    MessageBox.Show(xlWorkSheet.get_Range("A1", "A1").Value2.ToString());

                //    xlWorkBook.Close(true, misValue, misValue);
                 //   xlApp.Quit();

               //     releaseObject(xlWorkSheet);
                  //  releaseObject(xlWorkBook);
                   // releaseObject(xlApp);
              

            }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        } 


        

        private void CargarComboMes()
        {
            string sql = "spMes";
            DataTable dtmes = DBMapeo.ProcedureSelect(sql, null);
            this.cmbMes.ValueMember = "IdMes";
            this.cmbMes.DisplayMember = "Descripcion";
            this.cmbMes.DataSource = dtmes;
            this.cmbMes.SelectedValue = 0;
        }

        private DataTable dtLibroCompra(int pAno, int pMes)
        {
            List<MedusaSQLServer.DbParameter> parametro = new List<MedusaSQLServer.DbParameter>();
            parametro.Add(new MedusaSQLServer.DbParameter("@pAno", MedusaSQLServer.DbDirection.Input, pAno));
            parametro.Add(new MedusaSQLServer.DbParameter("@pMes", MedusaSQLServer.DbDirection.Input, pMes));
            DataTable dt=DBMapeoSLQ.ProcedureSelect("spSETLibroCompra", parametro);

            List<MedusaSQLServer2.DbParameter> parametro2 = new List<MedusaSQLServer2.DbParameter>();
            parametro2.Add(new MedusaSQLServer2.DbParameter("@pAno", MedusaSQLServer2.DbDirection.Input, pAno));
            parametro2.Add(new MedusaSQLServer2.DbParameter("@pMes", MedusaSQLServer2.DbDirection.Input, pMes));
            DataTable dt3 = DBMapeoSLQ2.ProcedureSelect("spLibroCompraISIL", parametro2);

            dt.Merge(dt3);

            List<Medusa.DbParameter> parametro1 = new List<Medusa.DbParameter>();
            parametro1.Add(new Medusa.DbParameter("panho", Medusa.DbDirection.Input, pAno));
            parametro1.Add(new Medusa.DbParameter("pmes", Medusa.DbDirection.Input, pMes));
            DataTable dt2= DBMapeo.ProcedureSelect("spSetLibroCompraSET", parametro1);

           


           
           // dt2.Columns["TipoRegistro"].DataType = typeof(Int32);

            DataTable dtCloned = dt2.Clone();
            dtCloned.Columns["TipoRegistro"].DataType = typeof(Int32);
            dtCloned.Columns["TipoDocumento"].DataType = typeof(Int32);
            dtCloned.Columns["Monto10"].DataType = typeof(double);
            dtCloned.Columns["Monto5"].DataType = typeof(double);
            dtCloned.Columns["IVA10"].DataType = typeof(double);
            dtCloned.Columns["IVA5"].DataType = typeof(double);
            dtCloned.Columns["Exenta"].DataType = typeof(double);
            dtCloned.Columns["TipoOperacion"].DataType = typeof(Int32);
            dtCloned.Columns["CondicionCompra"].DataType = typeof(Int32);
            dtCloned.Columns["CantidadCuotas"].DataType = typeof(Int32);
            foreach (DataRow row in dt2.Rows)
            {
                dtCloned.ImportRow(row);
            }



            dt.Merge(dtCloned);


            return dt;
        }

        private DataTable dtLibroVenta(int pAno, int pMes)
        {
            List<Medusa.DbParameter> parametro = new List<Medusa.DbParameter>();
            parametro.Add(new Medusa.DbParameter("panho", Medusa.DbDirection.Input, pAno));
            parametro.Add(new Medusa.DbParameter("pmes", Medusa.DbDirection.Input, pMes));
            DataTable dt2 = DBMapeo.ProcedureSelect("spSETLibroVenta", parametro);

            List<MedusaSQLServer2.DbParameter> parametro1 = new List<MedusaSQLServer2.DbParameter>();
            parametro1.Add(new MedusaSQLServer2.DbParameter("@pAno", MedusaSQLServer2.DbDirection.Input, pAno));
            parametro1.Add(new MedusaSQLServer2.DbParameter("@pMes", MedusaSQLServer2.DbDirection.Input, pMes));
            DataTable dt = DBMapeoSLQ2.ProcedureSelect("spLibroVentaISIL", parametro1);
            DataTable dtCloned = dt2.Clone();
            dtCloned.Columns["TipoRegistro"].DataType = typeof(Int64);
            dtCloned.Columns["TipoDocumento"].DataType = typeof(Int64);
            dtCloned.Columns["Monto10"].DataType = typeof(decimal);
            dtCloned.Columns["Monto5"].DataType = typeof(decimal);
            dtCloned.Columns["IVA10"].DataType = typeof(decimal);
            dtCloned.Columns["IVA5"].DataType = typeof(decimal);
            dtCloned.Columns["Exenta"].DataType = typeof(decimal);
            dtCloned.Columns["NroDocumento"].DataType = typeof(Int64);
            dtCloned.Columns["CondicionVenta"].DataType = typeof(Int64);
            dtCloned.Columns["CantidadCuotas"].DataType = typeof(Int64);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }

            dt2.Merge(dtCloned);
            object sumObject;
            DataRow[] rows = dt2.Select("Ruc = '44444401' ");
            if (rows.Length > 1)
            {
                int index =dt2.Rows.IndexOf(rows[0]);
                sumObject = dt2.Compute("Sum(Monto10)", "Ruc = '44444401' ");
                dt2.Rows[index]["Monto10"] = sumObject;
                sumObject = dt2.Compute("Sum(IVA10)", "Ruc = '44444401' ");
                dt2.Rows[index]["IVA10"] = sumObject;
                sumObject = dt2.Compute("Sum(Monto5)", "Ruc = '44444401' ");
                dt2.Rows[index]["Monto5"] = sumObject;
                sumObject = dt2.Compute("Sum(IVA5)", "Ruc = '44444401' ");
                dt2.Rows[index]["IVA5"] = sumObject;
                sumObject = dt2.Compute("Sum(Exenta)", "Ruc = '44444401' ");
                dt2.Rows[index]["Exenta"] = sumObject;
                sumObject = dt2.Compute("Sum(ImporteTotal)", "Ruc = '44444401' ");
                dt2.Rows[index]["ImporteTotal"] = sumObject;
                index = dt2.Rows.IndexOf(rows[1]);
                dt2.Rows[index].Delete();
                dt2.AcceptChanges();
            }
            return dt2;



           
        }

        private DataTable dtLibroVentaISIL(int pAno, int pMes)
        {
            List<MedusaSQLServer2.DbParameter> parametro = new List<MedusaSQLServer2.DbParameter>();
            parametro.Add(new MedusaSQLServer2.DbParameter("@pAno", MedusaSQLServer2.DbDirection.Input, pAno));
            parametro.Add(new MedusaSQLServer2.DbParameter("@pMes", MedusaSQLServer2.DbDirection.Input, pMes));
            return DBMapeoSLQ2.ProcedureSelect("spLibroVentaISIL", parametro);
        }


        public string calcular(string numero, int basemax)
        {
            long codigo = 0;
            string numero_al = null;

            dynamic i = null;
            for (i = 0; i < numero.Length; i++)
            {
            
                string c = numero.Substring( i, 1);
                try
                {

                    codigo = Convert.ToInt32(c.ToUpper());
                    if (!(codigo >= 48 & codigo <= 57))
                    {
                        numero_al = numero_al + codigo;
                    }
                    else
                    {
                        numero_al = numero_al + c;
                    }
                }
                catch (Exception ex) { return ""; }
            }

            dynamic k = null;
            dynamic total = null;
            k = 2;
            total = 0;

            for (i = numero_al.Length-1; i >= 0; i += -1)
            {
                if ((k > basemax))
                    k = 2;
                dynamic numero_aux = null;
                numero_aux = Convert.ToInt32(numero_al.Substring( i, 1));
                total = total + (numero_aux * k);
                k = k + 1;
            }


            dynamic resto = null;
            dynamic digito = null;
            resto = total % 11;
            if ((resto > 1))
            {
                digito = 11 - resto;
            }
            else
            {
                digito = 0;
            }
            return Convert.ToString(digito);
        }

        private void btnDV_Click(object sender, EventArgs e)
        {
            this.txtDV.Text = calcular(this.txtBuscarDV.Text,11);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

         //  DataTable dt=  dtLibroVentaISIL(2015, 2);
            this.Enabled = false;
            bool ingresar = true;
            if (Convert.ToInt32( cmbMes.SelectedValue) == 0)
            {
                MessageBox.Show("Falta elegir Mes!!");
                ingresar = false;
            }

            if (cmbTipo.Text.Length == 0)
            {
                MessageBox.Show("Falta elegir Tipo de Información!!");
                ingresar = false;
            }

            if (cmbTipoReporte.Text.Length == 0)
            {
                MessageBox.Show("Falta elegir Tipo de Reporte!!");
                ingresar = false;
            }
            if (ingresar)
            {
                int libro = this.cmbTipo.Text.ToUpper().Contains("COMPRA") ? 1 : 2;
                detalle(libro);
            }
            this.Enabled = true;
            Cursor.Current = Cursors.Default;

        }

    }
}

