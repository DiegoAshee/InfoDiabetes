using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using VeterinarySmilesDAO.Implementations;

namespace VeterinarySmiles_Web
{
    public partial class WebUpdatePassword : System.Web.UI.Page
    {

        ControlMio cs;

        UserImp2 impUser;
        //UserImp2 impUser2;

        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            //xd();

            compruebaSesion();


        }

        void compruebaSesion()
        {
            try
            {
                if (Session["userID"] == null)
                {
                    string urlVet = "Default.aspx";
                    Response.Redirect(urlVet);
                }
            }
            catch (System.NullReferenceException ex)
            {

                string urlVet = "Default.aspx";
                Response.Redirect(urlVet);
            }


        }



        void xd()
        {




            if (Session["userID"] != null)
            {
                id = int.Parse(Session["userID"].ToString());
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ Session["userID"].ToString() + "')", true);

                //lblError.Text = Session["userID"].ToString() + Session["userName"].ToString() +
                //Session["role"].ToString();

                if (Session["role"].ToString() == "Administrador" || Session["role"].ToString() == "Cliente")
                {


                    impUser = new UserImp2();

                    ControlMio cs = new ControlMio();

                    string contraActual = txtpasswordActual.Text;
                    string contraNueva = txtPasswordNueva.Text;
                    string repetirPasword = txtRepetirPassword.Text;

                    bool banderaContraActual = false;

                    if (txtpasswordActual.Text != "")
                    {
                        DataTable usus = impUser.CompruebaContraDeUsu(id, contraActual);

                        try
                        {
                            int coincidencias = Convert.ToInt32(usus.Rows[0][0]);

                            if (coincidencias > 0)
                            {
                                banderaContraActual = true;
                            }
                            else
                            {
                                lblError.Text = "Contraseña actual Incorrecta \n";
                            }
                        }
                        catch (IndexOutOfRangeException ex)
                        {

                            lblError.Text = "Contraseña actual Incorrecta \n";
                        }


                    }
                    else
                    {
                        lblError.Text = "Campo Contraseña actual vacia \n";
                    }

                    if (txtPasswordNueva.Text != "")
                    {
                        if (contraNueva.Length >= 8)
                        {
                            bool banderaLetrasNumerosYCaracteresRaros = cs.ValidarContraseñaLetrasNumerosYCaracteresRaros(contraNueva);
                            if (banderaLetrasNumerosYCaracteresRaros == true)
                            {


                                if (banderaContraActual == true && contraNueva == repetirPasword) //comprobamos que la contraseña sea la misma
                                {
                                    int l = impUser.UpdatePassword(id, contraNueva); //nos devuelve mas de uno si todo bien

                                    if (l > 0)
                                    {
                                        //MessageBox.Show("", "¡¡¡Se actualizo la contrseña!!!");
                                        lblError.Text = "Se cambio la contraseña correctamente \n";
                                        //string script = "alertaPass();";
                                        //ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", script, true);
                                        string urlVet = "Default.aspx";
                                        Response.Redirect(urlVet);
                                    }
                                    else
                                    {
                                        //MessageBox.Show("Tu contraseña temporal esta mal escrita", "contraseña inexistente");
                                        lblError.Text = "Tu contraseña no se cambio \n";
                                    }
                                }
                                else
                                {
                                    //MessageBox.Show("Las contraseñas no coinciden", "No coinciden");
                                    lblError.Text = "Las contraseñas no coinciden \n";
                                }
                            }
                            else
                            {
                                //MessageBox.Show("La contraseña tiene que contener una minuscula una mayuscula un numero y un caracter raro ", "Contraseña sin minusculas");
                                lblError.Text = "La contraseña tiene que contener una minuscula una mayuscula un numero y un caracter raro \n";

                            }

                        }
                        else
                        {
                            //MessageBox.Show("La contraseña tiene que tener minimo 8 caracteres", "contraseña menor a 8 caracteres");
                            lblError.Text = "La contraseña tiene que tener minimo 8 caracteres \n";
                        }
                    }
                    else
                    {
                       //MessageBox.Show("El campo contraseña esta vacia", "contraseña vacia");
                        lblError.Text = "El campo contraseña nueva esta vacia \n";
                    }

                }
                else
                {
                    string urlVet = "Default.aspx";
                    Response.Redirect(urlVet);

                }
            }
            else
            {
                string urlVet = "Default.aspx";
                Response.Redirect(urlVet);
            }

        }
        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            //lblError.Text="";

            xd();






        }
    }
}