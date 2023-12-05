using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebUpdateIngrediente : System.Web.UI.Page
    {
        IngredienteImp IngImp;
        Ingrediente i;
        static int id;
        string type;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get();


            if (!IsPostBack)
            {
                LoadType();
            }

        }

        void LoadType()
        {
            type = Request.QueryString["type"];

            if (type == "U")
            {
                Get();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //insert();
            actualiza();
        }

        void actualiza()
        {
            try
            {
                string nombre = txtNombre.Text;
                string unidadDeMedida = txtUnidadMedida.Text;
                string tipoAlimento = txtTipoAlimento.Text;
                string energia = txtEnergia.Text;
                string proteina = txtProteina.Text;
                string grasa = txtGrasa.Text;
                string porcentajeAzucar = txtPorcentajeAzucar.Text;

                IngImp = new IngredienteImp();

                byte[] ImgOriginal = null;
                if (fileUploadNuevaImagen.HasFile)
                {

                    int img = fileUploadNuevaImagen.PostedFile.ContentLength;
                    ImgOriginal = new byte[img];

                    fileUploadNuevaImagen.PostedFile.InputStream.Read(ImgOriginal, 0, img);

                }
                else
                {
                    Ingrediente ImgExistente = IngImp.Get(id);

                    if (ImgExistente != null)

                    {

                        ImgOriginal = ImgExistente.Imagen;

                    }

                }





                //i = new Ingrediente();
                i = new Ingrediente(id, nombre, unidadDeMedida, tipoAlimento, float.Parse(energia),
                    float.Parse(proteina), float.Parse(grasa), float.Parse(porcentajeAzucar), fileUploadNuevaImagen.FileBytes);
                //int il = IngImp.Update();

                int salida = IngImp.Update(i);

                if (salida > 0)
                {
                    lblControlFinal.Text = "¡Datos actualizados correctamente!";
                    Response.Redirect("WebAdmIngrediente.aspx");
                }


            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblControlFinal.Text = "Error al actualizar los datos. Por favor, inténtalo de nuevo.";
                throw ex;
            }
        }


        public void Get()
        {
            i = null;
            id = int.Parse(Request.QueryString["id"]);
            //id = 67;

            //id = int.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                IngImp = new IngredienteImp();
                i = IngImp.Get(id);
                if (i != null && !IsPostBack)
                {
                    /*
                     SELECT idIngrediente, nombre, unidadDeMedida, tipoAlimento, 
                    energia, proteina, grasa, porcentajeAzucar, imagen
                    FROM Ingrediente*/
                    txtNombre.Text = i.Nombre.ToString();
                    txtUnidadMedida.Text = i.UnidadDeMedida.ToString();
                    txtTipoAlimento.Text = i.TipoAlimento.ToString();
                    txtEnergia.Text = i.Energia.ToString(); ;                                    //N.Birthdate.ToString("yyyy-MM-dd");
                    txtProteina.Text = i.Proteina.ToString();
                    txtGrasa.Text = i.Grasa.ToString();
                    txtPorcentajeAzucar.Text = i.PorcentajeAzucar.ToString();


                    if (i.Imagen != null && i.Imagen.Length > 0)
                    {
                        string base64Image = Convert.ToBase64String(i.Imagen);
                        imgImagenActual.ImageUrl = "data:image/jpeg;base64," + base64Image;
                    }
                    else
                    {
                        imgImagenActual.ImageUrl = string.Empty;
                    }
                }
            }
        }
    }
}