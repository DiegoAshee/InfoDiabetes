using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmIngrediente : System.Web.UI.Page
    {
        IngredienteImp implIngrediente;
        Ingrediente I;
        ControlMio vl = new ControlMio();
        string type;

        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

            Select();
            load();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            insert();
        }



        void insert()
        {
            txtNombre.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            //txtUnidadMedida.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            //txtTipoAlimento.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            //txtEnergia.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            //txtProteina.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            //txtGrasa.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            //txtPorcentajeAzucar.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            //string imagen = txtPorcentajeAzucar.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");

            byte[] imgData = ReadFileData(fileUploadImagen.PostedFile);

            try
            {

                I = new Ingrediente(txtNombre.Text, txtUnidadMedida.Text, txtTipoAlimento.Text, float.Parse(txtEnergia.Text),
                                    float.Parse(txtProteina.Text), float.Parse(txtGrasa.Text),
                                    float.Parse(txtPorcentajeAzucar.Text), imgData);
                implIngrediente = new IngredienteImp();
                int n = implIngrediente.Insert(I);
                if (n > 0)
                {
                    lblControlFinal.Text = "Se insertó de manera correcta.";
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Exito!','Se insertó de manera exitosa!','success')", true);

                    //Select();
                }
                else
                {
                    lblControlFinal.Text = "No se inserto.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private byte[] ReadFileData(HttpPostedFile file)
        {
            int fileLength = file.ContentLength;
            byte[] fileData = new byte[fileLength];
            file.InputStream.Read(fileData, 0, fileLength);
            return fileData;
        }



        public void mostrar()
        {
            try
            {
                implIngrediente = new IngredienteImp();
                DataTable dt = implIngrediente.Select();
                DataTable table = new DataTable("Ingrediente");
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Unida de Medida", typeof(string));
                table.Columns.Add("Tipo de Alimento", typeof(string));
                table.Columns.Add("Energia", typeof(string));
                table.Columns.Add("Proteina", typeof(string));
                table.Columns.Add("Grasa", typeof(string));
                table.Columns.Add("Porcentaje Azucar", typeof(string));
                table.Columns.Add("Imagen", typeof(string)); // Nueva columna para mostrar la imagen
                table.Columns.Add("Previsualizar", typeof(string)); // Nueva columna para previsualizar la imagen en grande

                //table.Columns.Add("Imagen", typeof(string));
                table.Columns.Add("Editar", typeof(string));
                table.Columns.Add("Eliminar", typeof(string));

                //foreach (DataRow dr in dt.Rows)
                //{

                //    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                //                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                //}
                ////GridData.DataSource = implSize.Select();
                //gridData.DataSource = table;
                //gridData.DataBind();

                //for (int i = 0; i < gridData.Rows.Count; i++)
                //{
                //    string id = dt.Rows[i][0].ToString();
                //    string up = " <a class='btn btn-sm btn-info' href='WebUpdatePlato.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
                //    string del = " <a class='btn btn-sm btn-danger' href='WebAdmPlato.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a>  ";

                //    gridData.Rows[i].Cells[7].Text = up;
                //    gridData.Rows[i].Cells[8].Text = del;
                //    gridData.Rows[i].Attributes["data-id"] = id;
                //}

                foreach (DataRow dr in dt.Rows)
                {
                    string nombre = dr["nombre"].ToString(); // Reemplaza "Nombre" por el nombre real de la columna en tu DataTable
                    string unidadMedida = dr["UnidadDeMedida"].ToString(); // Reemplaza "UnidadMedida" por el nombre real de la columna en tu DataTable
                    string tipoAlimento = dr["tipoAlimento"].ToString(); // Reemplaza "Nombre" por el nombre real de la columna en tu DataTable
                    string energia = dr["energia"].ToString();                                // Continúa obteniendo los datos de cada columna de tu DataTable
                    string proteina = dr["proteina"].ToString(); // Reemplaza "Nombre" por el nombre real de la columna en tu DataTable
                    string grasa = dr["grasa"].ToString();
                    string porcentajeAzucar = dr["porcentajeAzucar"].ToString(); // Reemplaza "Nombre" por el nombre real de la columna en tu DataTable

                    // Obtén la imagen (suponiendo que tienes una columna con datos de imagen en forma de cadena Base64)
                    string base64Image = dr["imagen"].ToString(); // Reemplaza "Imagen" por el nombre real de la columna que contiene la imagen en tu DataTable

                    // Construye la etiqueta de imagen con la imagen en tamaño reducido
                    string imageSrc = $"data:image/jpeg;base64,base64Image";
                    string imagenHtml = $"<img src='{imageSrc}' width='50' height='50'>";
                    string imagenHtml2 = "<img src='data:image/jpeg;base64," + base64Image + "' width='50' height='50'>";

                    // Construye el enlace para previsualizar la imagen en grande
                    string previsualizarHtml = $"<a href='{imageSrc}' target='_blank'>Previsualizar</a>";

                    // Agrega los datos al DataTable para mostrar en el GridView
                    table.Rows.Add(nombre, unidadMedida, tipoAlimento, energia, proteina, grasa, porcentajeAzucar, imagenHtml2, previsualizarHtml);
                }
                gridData.DataSource = table;
                gridData.DataBind();

                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-sm btn-info' href='WebUpdatePlato.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='WebAdmPlato.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a>  ";

                    gridData.Rows[i].Cells[9].Text = up;
                    gridData.Rows[i].Cells[10].Text = del;
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
                    tableHtml.Append("<th>Energia</th>");
                    tableHtml.Append("<th>Proteina</th>");
                    tableHtml.Append("<th>Grasa</th>");
                    tableHtml.Append("<th>Porcentaje De Azucar</th>");
                    tableHtml.Append("<th>Imagen</th>");
                    tableHtml.Append("<th>Actualizar</th>");
                    tableHtml.Append("<th>Eliminar</th>");


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

                        id = int.Parse(dr["idIngrediente"].ToString());

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




                        tableHtml.Append($"<td><a class='btn btn-sm btn-success' href='WebUpdateIngrediente.aspx?id={id}&type=U'><i class='fas fa-edit' style='color:#000000;'></i>Ver</a></td>");
                        tableHtml.Append($"<td><a class='btn btn-sm btn-danger' href='WebAdmIngrediente.aspx?id={id}&type=D'><i class='fas fa-trash' style='background:#FF0000;'></i>Rechazar</a></td>");


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













        void Delete()
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implIngrediente = new IngredienteImp();

                    int n = implIngrediente.Delete(id);
                    lblControlFinal.Text = "Se eliminó de manera correcta.";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        void load()
        {
            try
            {
                type = Request.QueryString["type"];

                if (type == "D")
                {
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Verificar la respuesta del usuario
                    if (resultado == DialogResult.Yes)
                    {
                        // Código para el caso de que el usuario seleccione "Sí"
                        // Puedes realizar aquí las acciones necesarias
                        //Console.WriteLine("El usuario seleccionó 'Sí'");
                        Delete();
                        Select();
                        Response.Redirect("WebAdmIngrediente.aspx");
                        lblControlFinal.Text = "Se eliminó de manera correcta.";
                    }
                    else
                    {
                        Response.Redirect("WebAdmIngrediente.aspx");
                        // Código para el caso de que el usuario seleccione "No"
                        // Puedes realizar aquí las acciones necesarias
                        // Console.WriteLine("El usuario seleccionó 'No'");
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}