using DifficilBankDAO.Implementations;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using System.Windows.Forms;
using iTextSharp.tool.xml;

namespace VeterinarySmiles_Web
{
    public partial class ReporteSegunDatosPersona : System.Web.UI.Page
    {

        PersonImp impPer;

        string tipoBusquedaPersona = "";
        





        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.IsEmpty())
            {
                lblResultadoReporte.Text = "Para buscar por nombre ingresa un nombre o parte de el de busqueda";
            }
            else
            {
                tipoBusquedaPersona = "Nombre";
                muestraPorNombre(txtNombre.Text.ToString());
            }
            
            
        }


        protected void btnBuscarCI_Click(object sender, EventArgs e)
        {

            if (txtCI.Text.IsEmpty())
            {
                lblResultadoReporte.Text = "Para buscar por ci ingresa un ci o parte de el de busqueda";
            }
            else
            {
                tipoBusquedaPersona = "CI";
                muestraPorCI(txtCI.Text);
            }

            

        }


        




        //muestra segun nombre
        void muestraPorNombre(string nombre)
        {
            try
            {
                impPer = new PersonImp();
                DataTable dt = impPer.muestraClientesSegunNombre(nombre);

                DataTable table = new DataTable("Personas");
                table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombres", typeof(string));
                table.Columns.Add("Primer Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Edad", typeof(string));
                table.Columns.Add("Fecha De Nacimiento", typeof(string));
                table.Columns.Add("Genero", typeof(string));


                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }

                gridData.DataSource = table;
                gridData.DataBind();

                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    gridData.Rows[i].Attributes["data-id"] = id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        void muestraPorCI(string ci)
        {
            try
            {
                impPer = new PersonImp();
                DataTable dt = impPer.muestraClientesSegunCi(ci);

                DataTable table = new DataTable("Personas");
                table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombres", typeof(string));
                table.Columns.Add("Primer Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Edad", typeof(string));
                table.Columns.Add("Fecha De Nacimiento", typeof(string));
                table.Columns.Add("Genero", typeof(string));


                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }

                gridData.DataSource = table;
                gridData.DataBind();
                
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    gridData.Rows[i].Attributes["data-id"] = id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void muestraPorFechasDeNacimiento(DateTime edadMinima ,DateTime edadMaxima)
        {
            try
            {
                impPer = new PersonImp();

               



                DataTable dt = impPer.muestraClientesEntreFechasDeNacimiento(edadMinima, edadMaxima);

                DataTable table = new DataTable("Personas");
                table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombres", typeof(string));
                table.Columns.Add("Primer Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Edad", typeof(string));
                table.Columns.Add("Fecha De Nacimiento", typeof(string));
                table.Columns.Add("Genero", typeof(string));


                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }

                gridData.DataSource = table;
                gridData.DataBind();

                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    gridData.Rows[i].Attributes["data-id"] = id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void ExportReportByPDF(string tipoBusqueda)
        {
            // Obtener los datos desde la capa de acceso a datos
            PersonImp impPer = new PersonImp();
            DataTable dt = impPer.Select();

            // Crear un documento PDF
            Document doc = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            // Estilo de fuente para títulos y datos
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Título del documento
            Paragraph title = new Paragraph("Informe de Personas ", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);


           

            // Fecha del informe
            Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString(), dataFont);
            date.Alignment = Element.ALIGN_RIGHT;
            doc.Add(date);

            // Agregar espacio en blanco
            doc.Add(new Paragraph("\n"));

            // Crear la tabla para el PDF
            PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
            pdfTable.WidthPercentage = 100;
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.DefaultCell.BackgroundColor = new BaseColor(240, 240, 240);

            // Encabezados de columna
            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, dataFont));
                headerCell.BackgroundColor = new BaseColor(51, 153, 255);
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(headerCell);
            }

            // Agregar datos a la tabla
            foreach (DataRow row in dt.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), dataFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }
            }

            // Agregar la tabla al documento
            doc.Add(pdfTable);

            // Cerrar el documento PDF
            doc.Close();

            // Descargar el archivo PDF generado
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=ReporteGeneral.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }

        protected void btnImprimeInforme_Click(object sender, EventArgs e)
        {
            ExportReportByPDF(tipoBusquedaPersona);
        }
    }
}