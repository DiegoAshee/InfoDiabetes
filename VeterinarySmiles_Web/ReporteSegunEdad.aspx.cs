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
using System.Web.Helpers;
using System.Web.UI.DataVisualization.Charting;

namespace VeterinarySmiles_Web
{
    public partial class ReporteSegunEdad : System.Web.UI.Page
    {
        PersonImp impPer;




        void selectbyName()
        {
            try
            {
                impPer = new PersonImp();
                DataTable dt = impPer.SelectSegunEdad();

                DataTable table = new DataTable("Personas");
                table.Columns.Add("Menores de 18", typeof(string));
                table.Columns.Add("Entre 18 y 30", typeof(string));
                table.Columns.Add("Entre 31 y 50", typeof(string));
                table.Columns.Add("Mayores de 50", typeof(string));
                table.Columns.Add("Total Personas", typeof(string));
                table.Columns.Add("% Menores de 18", typeof(string));
                table.Columns.Add("% Entre 18 y 30", typeof(string));
                table.Columns.Add("% Entre 31 y 50", typeof(string));
                table.Columns.Add("% Mayores de 50", typeof(string));


                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }

                gridData.DataSource = table;
                gridData.DataBind();



                // Formatear valores numéricos con dos decimales en el GridView
                foreach (GridViewRow row in gridData.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (double.TryParse(row.Cells[i].Text, out double result))
                        {
                            row.Cells[i].Text = result.ToString("0.00");
                        }
                    }
                }



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



        void ExportReportByPDF()
        {

            


            // Obtener los datos desde la capa de acceso a datos
            PersonImp impPer = new PersonImp();
            DataTable dt = impPer.SelectSegunEdad();

            // Crear un documento PDF
            Document doc = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            // Estilo de fuente para títulos y datos
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Título del documento
            Paragraph title = new Paragraph("Informe de Personas según Su edad", titleFont);
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
            pdfTable.SpacingBefore = 10f; // Espacio antes de la tabla
            pdfTable.SpacingAfter = 10f; // Espacio después de la tabla

            // Encabezados de columna
            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, dataFont));
                headerCell.BackgroundColor = new BaseColor(51, 153, 255);
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell.Padding = 5f; // Espacio interno de la celda
                pdfTable.AddCell(headerCell);
            }

            // Agregar datos a la tabla con espaciado
            //...

            // Agregar datos a la tabla con espaciado y formato de dos decimales
            foreach (DataRow row in dt.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell();

                    // Formatear el texto a dos decimales si es un número
                    if (item is double || item is decimal)
                    {
                        string formattedValue = string.Format("{0:0.00}", item);
                        cell = new PdfPCell(new Phrase(formattedValue, dataFont));
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase(item.ToString(), dataFont));
                    }

                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5f; // Espacio interno de la celda
                    pdfTable.AddCell(cell);
                }
            }



            // Agregar la tabla al documento
            doc.Add(pdfTable);

            // Cerrar el documento PDF
            doc.Close();

            // Descargar el archivo PDF generado
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=ReporteSegunSuEdad.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {



            selectbyName();

        }


        protected void btnImprimeReporte_Click(object sender, EventArgs e)
        {

            ExportReportByPDF();

        }

    }
}