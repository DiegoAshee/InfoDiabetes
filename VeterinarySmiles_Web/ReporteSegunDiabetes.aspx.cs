using DifficilBankDAO.Implementations;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web.Reportes
{
    public partial class ReporteSegunDiabetes : System.Web.UI.Page
    {

        PersonImp impPer;


        string salida = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        } 

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            
            salida = ddlGradoDiabetes.SelectedValue.ToString();

            lblResultadoReporte.Text = salida;

            selectbyName(salida);

        }


        protected void btnImprimeReporte_Click(object sender, EventArgs e)
        {

            ExportReportByPDF();

        }


        void selectbyName(string name)
        {
            try
            {
                impPer = new PersonImp();
                DataTable dt = impPer.muestraClientesSegunGradoDiabetes(name);

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
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
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



        //void exportReportbyPDF()
        //{
        //    impPer = new PersonImp();
        //    DataTable dt = impPer.muestraClientesSegunGradoDiabetesParaImprimir(ddlGradoDiabetes.SelectedValue.ToString());

        //    Document doc = new Document();
        //    MemoryStream ms = new MemoryStream();
        //    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
        //    doc.Open();


        //    PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);

        //    pdfTable.DefaultCell.Border = PdfPCell.BOX;
        //    pdfTable.DefaultCell.BorderColor = BaseColor.GRAY;
        //    pdfTable.DefaultCell.BackgroundColor = new BaseColor(230, 230, 230);
        //    pdfTable.DefaultCell.Padding = 5;
        //    pdfTable.WidthPercentage = 100;
        //    pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

        //    BaseFont customFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
        //    iTextSharp.text.Font customTitleFont = new iTextSharp.text.Font(customFont, 15, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);

        //    PdfPCell headerCell;


        //    foreach (DataColumn column in dt.Columns)
        //    {

        //        headerCell = new PdfPCell(new Phrase(column.ColumnName, customTitleFont));
        //        headerCell.BackgroundColor = new BaseColor(51, 153, 255);
        //        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        pdfTable.AddCell(headerCell);

        //    }

        //    Paragraph titleParagraph = new Paragraph("Informe de Personas segun Diabetes", customTitleFont);
        //    titleParagraph.Alignment = Element.ALIGN_CENTER;
        //    doc.Add(titleParagraph);

        //    Paragraph dateParagraph = new Paragraph("Fecha: " + DateTime.Now.ToString(), customTitleFont);
        //    dateParagraph.Alignment = Element.ALIGN_CENTER;
        //    doc.Add(dateParagraph);

        //    Paragraph emptySpace = new Paragraph(" ");
        //    emptySpace.SpacingBefore = 20f;
        //    doc.Add(emptySpace);



        //    foreach (DataRow row in dt.Rows)
        //    {
        //        foreach (object item in row.ItemArray)
        //        {
        //            PdfPCell cell = new PdfPCell(new Phrase(item.ToString()));
        //            pdfTable.AddCell(cell);

        //        }
        //    }

        //    doc.Add(pdfTable);
        //    doc.Close();

        //    //descargar
        //    Response.ContentType = "prueba/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=ReporteSegunGradoDeDiabetes.pdf");
        //    Response.BinaryWrite(ms.ToArray());
        //    Response.End();
        //}


        void ExportReportByPDF()
        {

            salida = ddlGradoDiabetes.SelectedValue.ToString();


            // Obtener los datos desde la capa de acceso a datos
            PersonImp impPer = new PersonImp();
            DataTable dt = impPer.muestraClientesSegunGradoDiabetesParaImprimir(ddlGradoDiabetes.SelectedValue.ToString());

            // Crear un documento PDF
            Document doc = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            // Estilo de fuente para títulos y datos
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Título del documento
            Paragraph title = new Paragraph("Informe de Personas según Diabetes", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);


            // Tipo de diabetes del informe
            Paragraph tipoDiabetes = new Paragraph("Tipo de Diabetes: " + salida, dataFont);
            tipoDiabetes.Alignment = Element.ALIGN_RIGHT;
            doc.Add(tipoDiabetes);

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
            Response.AddHeader("content-disposition", "attachment; filename=ReporteSegunGradoDeDiabetes.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }


    }
}