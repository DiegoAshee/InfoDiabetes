using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace VeterinarySmiles_Web
{
    public partial class WebPrueba : System.Web.UI.Page
    {
        IngredienteImp implIngrediente;
        Ingrediente I;
        ControlMio vl = new ControlMio();
        string type;

        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

            Select();
            
        }

       


        


        private byte[] ReadFileData(HttpPostedFile file)
        {
            int fileLength = file.ContentLength;
            byte[] fileData = new byte[fileLength];
            file.InputStream.Read(fileData, 0, fileLength);
            return fileData;
        }



       
        void Select()
        {
            try
            {

                int id = 1; // Reemplaza con el ID del menú que deseas buscar

                string connectionString = "Data Source=TuServidor;Initial Catalog=TuBaseDeDatos;User ID=TUUsuario;Password=TuContraseña;";
                string query = "SELECT m.nombre AS nombre_menu, p.nombre AS nombre_plato, ISNULL(i.nombre,'') AS nombre_ingrediente " +
                               "FROM menu m " +
                               "LEFT JOIN plato p ON p.idMenu = m.id " +
                               "LEFT JOIN IngredientePlato ip ON ip.idPlato = p.idPlato " +
                               "LEFT JOIN Ingrediente i ON i.idIngrediente = ip.idIngrediente " +
                               "WHERE m.status = 1 AND i.nombre <> '' AND m.id = @MenuId";

                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MenuId", id);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción si ocurre algún error
                    }
                }
                string filePath = string.Empty;

            // Tu código existente para generar el PDF...
            iTextSharp.text.Document doc;

                // Crear el documento PDF
                doc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~/Descarga/menu.pdf"), FileMode.Create));
                doc.Open();

                // Recorrer los resultados y generar el documento PDF
                foreach (DataRow row in dt.Rows)
                {
                    string nombreMenu = row["nombre_menu"].ToString();
                    string nombrePlato = row["nombre_plato"].ToString();
                    string nombreIngrediente = row["nombre_ingrediente"].ToString();

                    // Agregar datos al documento PDF
                    doc.Add(new Paragraph($"Nombre del Menú: {nombreMenu}"));

                    if (!string.IsNullOrEmpty(nombrePlato))
                    {
                        doc.Add(new Paragraph($"Plato: {nombrePlato}"));

                        if (!string.IsNullOrEmpty(nombreIngrediente))
                        {
                            doc.Add(new Paragraph($"Ingrediente: {nombreIngrediente}"));
                        }
                    }
                }

                doc.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }













       
       
    }
}