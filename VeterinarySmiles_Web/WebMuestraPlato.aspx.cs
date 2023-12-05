using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
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
using System.Xml.Linq;

namespace VeterinarySmiles_Web
{
    public partial class WebMuestraPlato : System.Web.UI.Page
    {


        Plato p;
        PlatoImpl impPlato;

        int id;

        DataTable tablaMuestraPlatos;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            capturaId();
            muestraPlatos();

        }


        void capturaId()
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
        }

        void compruebaSesion()
        {
            try
            {
                if (Session["userID"] == null)
                {
                    string urlVet = "WebLogout.aspx";
                    Response.Redirect(urlVet);
                }
            }
            catch (System.NullReferenceException ex)
            {

                string urlVet = "WebLogout.aspx";
                Response.Redirect(urlVet);
            }
        }
        void ExportReportByPDF2(int id)
        {




            // Obtener los datos desde la capa de acceso a datos
            MenuImpl impPer = new MenuImpl();
            DataTable dt = impPer.SelectMenu(id);

            // Crear un documento PDF
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            // Estilo de fuente para títulos y datos
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // ...

            // Título del documento
            Paragraph title = new Paragraph("Menú", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Fecha del informe
            Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString(), dataFont);
            date.Alignment = Element.ALIGN_RIGHT;
            doc.Add(date);

            // Agregar espacio en blanco
            doc.Add(new Paragraph("\n"));

            int fontSizeMenu = 13;
            int fontSizePlato = 12;
            int fontSizeIngrediente = 10;

            string nombreMenuAnterior = string.Empty;
            string nombrePlatoAnterior = string.Empty;

            foreach (DataRow row in dt.Rows)
            {
                string nombreMenu = row["nombre_menu"].ToString();
                string nombrePlato = row["nombre_plato"].ToString();
                string nombreIngrediente = row["nombre_ingrediente"].ToString();

                // Mostrar el nombre del menú si es diferente del anterior
                if (nombreMenu != nombreMenuAnterior)
                {
                    Chunk chunkMenu = new Chunk($"Nombre del Menú: {nombreMenu}", FontFactory.GetFont(FontFactory.HELVETICA, fontSizeMenu, Font.BOLD, BaseColor.BLACK));
                    Paragraph paragraphMenu = new Paragraph(chunkMenu);
                    doc.Add(paragraphMenu);
                    doc.Add(Chunk.NEWLINE); // Agregar espacio después del nombre del menú
                    nombreMenuAnterior = nombreMenu; // Actualizar el nombre del menú actual
                }

                // Mostrar el nombre del plato si es diferente del anterior
                if (nombrePlato != nombrePlatoAnterior)
                {
                    Chunk chunkPlato = new Chunk($"Plato: {nombrePlato}", FontFactory.GetFont(FontFactory.HELVETICA, fontSizePlato, Font.NORMAL, BaseColor.BLACK));
                    Paragraph paragraphPlato = new Paragraph(chunkPlato);
                    doc.Add(paragraphPlato);
                    nombrePlatoAnterior = nombrePlato; // Actualizar el nombre del plato actual
                }

                if (!string.IsNullOrEmpty(nombreIngrediente))
                {
                    Chunk chunkIngrediente = new Chunk($"- Ingrediente: {nombreIngrediente}", FontFactory.GetFont(FontFactory.HELVETICA, fontSizeIngrediente, Font.NORMAL, BaseColor.BLACK));
                    Paragraph paragraphIngrediente = new Paragraph(chunkIngrediente);
                    doc.Add(paragraphIngrediente); // Listar ingredientes con viñetas
                }
                else
                {
                    doc.Add(Chunk.NEWLINE); // Agregar espacio entre platos si no hay ingredientes
                }
            }

            // Cerrar el documento PDF
            doc.Close();



            // Descargar el archivo PDF generado
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=ReporteSegunGradoDeDiabetes.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Se genero su pdf Correctamente");

            //imprimePDF();



            // string filePath = imprimePDFStrg();

            //ExportReportByPDF2();


        }
        void muestraPlatos()
        {
            try
            {
                if (id > 0)
                {
                    impPlato = new PlatoImpl();

                    tablaMuestraPlatos = impPlato.SelectPlatosSeleccionado(id);



                    DataTable table = new DataTable("Platos");

                    table.Columns.Add("Nombre", typeof(string));
                    table.Columns.Add("Descripcion", typeof(string));
                    table.Columns.Add(" ", typeof(string));
                    //table.Columns.Add("Pdf", typeof(string));


                    foreach (DataRow dr in tablaMuestraPlatos.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString());
                    }






                    gridData.DataSource = table;
                    gridData.DataBind();


                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {
                        string id = tablaMuestraPlatos.Rows[i][0].ToString();
                        string detallePlatos = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebMuestraIngredientes.aspx?id=" + id + "'> Ver Ingredientes  </a> ";
                        //string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";
                        //string detalleIngredientes2 = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebTemp.aspx?id=" + id + "'> Generar PDF </a> ";

                        gridData.Rows[i].Cells[2].Text = detallePlatos;
                        //gridData.Rows[i].Cells[3].Text =detalleIngredientes2;
                        gridData.Rows[i].Attributes["data-id"] = id;
                    }







                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }






    }
}