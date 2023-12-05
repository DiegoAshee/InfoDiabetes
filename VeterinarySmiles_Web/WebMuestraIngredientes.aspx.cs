using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Crmf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

using System.Globalization;


namespace VeterinarySmiles_Web
{
    public partial class WebMuestraIngredientes : System.Web.UI.Page
    {
        

        Plato p;
        PlatoImpl impPlato;

        IngredienteImp implIngrediente;

        static int id;

        DataTable tablaMuestraIngredientes;


        //Para generar string aleatorio
        private static Random random = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static HashSet<string> usedCodes = new HashSet<string>(); // Almacenar códigos utilizados

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            capturaId();
            //muestraIngredientes();
            Select2();
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

        void muestraIngredientes()
        {
            try
            {
                if (id > 0)
                {
                    impPlato = new PlatoImpl();

                    tablaMuestraIngredientes = impPlato.SelectIngredientesSeleccionado(id);



                    DataTable table = new DataTable("Ingredientes");

                    table.Columns.Add("Nombre", typeof(string));
                    table.Columns.Add("Tipo de Alimento", typeof(string));        
                    table.Columns.Add("Calorias (g)", typeof(string));
                    table.Columns.Add("Proteina (g)", typeof(string));
                    table.Columns.Add("Grasa (g)", typeof(string));
                    table.Columns.Add("Porcentaje de Azucar %", typeof(string));


                    foreach (DataRow dr in tablaMuestraIngredientes.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString(),
                                       dr[3].ToString(), dr[4].ToString(),
                                       dr[5].ToString(), dr[6].ToString());
                    }


                    gridData.DataSource = table;
                    gridData.DataBind();

                    /*
                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {
                        string id = tablaMuestraPlatos.Rows[i][0].ToString();
                        string detallePlatos = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebMuestraIngredientes.aspx?id=" + id + "'> VerIngredientes  </a> ";
                        //string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                        gridData.Rows[i].Cells[7].Text = detallePlatos;
                        //gridData.Rows[i].Cells[6].Text += del;
                        gridData.Rows[i].Attributes["data-id"] = id;
                    }
                    */






                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        void imprimePDF()
        {



            iTextSharp.text.Document doc;

            try
            {
                // Crear el documento PDF
                doc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~/Descarga/menu" + id.ToString() +".pdf"), FileMode.Create));
                doc.Open();

                PdfPTable table = new PdfPTable(3); // Crear una tabla con 5 columnas

                // Añadir encabezados a la tabla
                //table.AddCell("ID Menú");
                table.AddCell("Nombre Menú");
                //table.AddCell("ID Plato");
                table.AddCell("Nombre Plato");
                table.AddCell("Nombre Ingrediente");

                // Realizar la conexión a la base de datos y ejecutar la consulta
                using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-P03JJMU\SQLEXPRESS;Database=BioInformaticaBD;User Id=sa;Password=univalle;"))
                {
                    string query = @"SELECT m.nombre AS nombre_menu, p.nombre AS nombre_plato, ISNULL(i.nombre,'') AS nombre_ingrediente
                                   FROM menu m
                                   LEFT JOIN plato p ON p.idMenu = m.id
                                   LEFT JOIN IngredientePlato ip ON ip.idPlato = p.idPlato
                                   LEFT JOIN Ingrediente i ON i.idIngrediente = ip.idIngrediente
                                   WHERE m.status = 1 AND i.nombre<> '' AND m.id=" + id.ToString() ;

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Agregar datos a la tabla del PDF
                            //table.AddCell(reader["id"].ToString());
                            table.AddCell(reader["nombre_menu"].ToString());
                            //table.AddCell(reader["idPlato"].ToString());
                            table.AddCell(reader["nombre_plato"].ToString());
                            table.AddCell(reader["nombre_ingrediente"].ToString());
                        }
                    }
                }

                // Agregar la tabla al documento PDF
                doc.Add(table);
                doc.Close(); // Cerrar el documento después de haber agregado la información
            }
            catch (Exception ex)
            {
                // Manejo de errores
            }


        }

        //Metodos para que nunca se repita

        public static string GenerateUniqueRandomCode(int length)
        {
            string code = GenerateRandomCode(length);

            // Verificar si el código generado ya ha sido utilizado
            while (usedCodes.Contains(code))
            {
                code = GenerateRandomCode(length);
            }

            // Agregar el código generado al conjunto de códigos utilizados
            usedCodes.Add(code);

            return code;
        }

        private static string GenerateRandomCode(int length)
        {
            StringBuilder code = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                code.Append(Chars[random.Next(Chars.Length)]);
            }

            return code.ToString();
        }

        
        static int lengthOfCode = 8;
        static string randomUniqueCode = GenerateUniqueRandomCode(lengthOfCode);
        //Console.WriteLine("Código aleatorio único generado: " + randomUniqueCode);


        void ExportReportByPDF()
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

            // Título del documento
            Paragraph title = new Paragraph("Menu", titleFont);
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
            Response.AddHeader("content-disposition", "attachment; filename=ReporteSegunGradoDeDiabetes.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }




        void ExportReportByPDF2()
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



        void imprimePDFConFoto()
        {
            try
            {
                impPlato = new PlatoImpl();
                DataTable dt = impPlato.SelectIngredientes(id);

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

        void Select()
        {
            try
            {
                implIngrediente = new IngredienteImp();
                DataTable dt = implIngrediente.Select();
                if (dt.Rows.Count <= 0)
                {
                    StringBuilder tableHtml2 = new StringBuilder();
                    tableHtml2.Append("<h1>No hay Ingredientes</h1>");
                    //lblControlFinal.Text = tableHtml2.ToString();
                }
                else
                {
                    StringBuilder tableHtml = new StringBuilder();
                    tableHtml.Append("<table class='table'>");
                    tableHtml.Append("<tr>");
                    //tableHtml.Append("<th>ID</th>");
                    tableHtml.Append("<th>Nombre</th>");
                    tableHtml.Append("<th>Unidad de Medida</th>");
                    tableHtml.Append("<th>Tipo de Alimento</th>");
                    tableHtml.Append("<th>Energia</th>");
                    tableHtml.Append("<th>Proteina</th>");
                    tableHtml.Append("<th>Grasa</th>");
                    tableHtml.Append("<th>Porcentaje De Azucar</th>");
                    tableHtml.Append("<th>Imagen</th>");
                   


                    tableHtml.Append("</tr>");

                    foreach (DataRow dr in dt.Rows)
                    {

                        string idMio = dr["idIngrediente"].ToString();
                        string nombre = dr["nombre"].ToString();
                        string unidadDeMedida = dr["unidadDeMedida"].ToString();
                        string tipoAlimento = dr["tipoAlimento"].ToString();
                        string energia = dr["energia"].ToString();
                        string proteina = dr["proteina"].ToString();
                        string grasa = dr["grasa"].ToString();
                        string porcentajeAzucar = dr["porcentajeAzucar"].ToString();
                        string imagen = dr["imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";

                        //id = int.Parse(dr["idIngrediente"].ToString());

                        tableHtml.Append("<tr>");
                        //tableHtml.Append($"<td>{idMio}</td>");
                        tableHtml.Append($"<td>{nombre}</td>");
                        tableHtml.Append($"<td>{unidadDeMedida}</td>");
                        tableHtml.Append($"<td>{tipoAlimento}</td>");
                        tableHtml.Append($"<td>{energia}</td>");
                        tableHtml.Append($"<td>{proteina}</td>");
                        tableHtml.Append($"<td>{grasa}</td>");
                        tableHtml.Append($"<td>{porcentajeAzucar}</td>");

                        tableHtml.Append($"<td><img src='{imagen}' alt='Imagen'  style='max-width:70px; max-height:70px;' /></td>");




                        


                        tableHtml.Append("</tr>");
                    }
                    tableHtml.Append("</table>");

                    //lblControlFinal.Text = tableHtml.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
    }







        void Select2()
        {
            try
            {
                implIngrediente = new IngredienteImp();
                DataTable dt = implIngrediente.Select(id);
                if (dt.Rows.Count <= 0)
                {
                    StringBuilder tableHtml2 = new StringBuilder();
                    tableHtml2.Append("<h1>No hay Ingredientes</h1>");
                    lblControlFinal.Text = tableHtml2.ToString();
                }
                else
                {
                    StringBuilder tableHtml = new StringBuilder();
                    tableHtml.Append("<table class='table'>");
                    tableHtml.Append("<tr>");
                    //tableHtml.Append("<th>ID</th>");
                    tableHtml.Append("<th>Nombre</th>");
                    tableHtml.Append("<th>Unidad de Medida</th>");
                    tableHtml.Append("<th>Tipo de Alimento</th>");
                    tableHtml.Append("<th>Energia (kcal)</th>");
                    tableHtml.Append("<th>Proteina (g)</th>");
                    tableHtml.Append("<th>Grasa (g)</th>");
                    tableHtml.Append("<th>Porcentaje De Azucar(%)</th>");
                    tableHtml.Append("<th>Imagen</th>");



                    tableHtml.Append("</tr>");

                    foreach (DataRow dr in dt.Rows)
                    {

                        string idMio = dr["idIngrediente"].ToString();
                        string nombre = dr["nombre"].ToString();
                        string unidadDeMedida = dr["unidadDeMedida"].ToString();
                        string tipoAlimento = dr["tipoAlimento"].ToString();
                        string energia = dr["energia"].ToString();
                        string proteina = dr["proteina"].ToString();
                        string grasa = dr["grasa"].ToString();
                        string porcentajeAzucar = dr["porcentajeAzucar"].ToString();
                        string imagen = dr["imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "/Image/Diabetes.jpg";

                        //id = int.Parse(dr["idIngrediente"].ToString());

                        tableHtml.Append("<tr>");
                        //tableHtml.Append($"<td>{idMio}</td>");
                        tableHtml.Append($"<td>{nombre}</td>");
                        tableHtml.Append($"<td>{unidadDeMedida}</td>");
                        tableHtml.Append($"<td>{tipoAlimento}</td>");
                        tableHtml.Append($"<td>{energia}</td>");
                        tableHtml.Append($"<td>{proteina}</td>");
                        tableHtml.Append($"<td>{grasa}</td>");
                        tableHtml.Append($"<td>{porcentajeAzucar}</td>");

                        tableHtml.Append($"<td><img src='{imagen}' alt='Imagen'  style='max-width:70px; max-height:70px;' /></td>");




                        tableHtml.Append("</tr>");
                    }
                    tableHtml.Append("</table>");

                    lblControlFinal.Text = tableHtml.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }











        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Se genero su pdf Correctamente");

            //imprimePDF();



            // string filePath = imprimePDFStrg();

            ExportReportByPDF2();


        }

        }
    }