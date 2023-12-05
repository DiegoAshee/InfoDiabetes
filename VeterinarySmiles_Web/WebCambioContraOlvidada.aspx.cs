using DifficilBankDAO.Implementations;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using VeterinarySmilesDAO.Implementations;

namespace VeterinarySmiles_Web
{
    public partial class WebCambioContraOlvidada : System.Web.UI.Page
    {

        UserImp2 UserImp;

        static int id;


        protected void Page_Load(object sender, EventArgs e)
        {
            capturaId();
        }

        void capturaId()
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    //MessageBox.Show("id capturado ", "");

                }
                else
                {
                    //MessageBox.Show("No Capturo id", "");
                    Response.Redirect("WebLogout.aspx");
                }
            }
        }


        void CambioContrasenia()
        {

            UserImp = new UserImp2();

            ControlMio cs = new ControlMio();


            string contraNueva = txtPasswordNueva.Text;
            string repetirPasword = txtRepetirPassword.Text;

            if (txtPasswordNueva.Text != "")
            {
                if (contraNueva.Length >= 8)
                {
                    bool banderaLetrasNumerosYCaracteresRaros = cs.ValidarContraseñaLetrasNumerosYCaracteresRaros(contraNueva);
                    if (banderaLetrasNumerosYCaracteresRaros == true)
                    {


                        if (contraNueva == repetirPasword) //comprobamos que la contraseña sea la misma
                        {
                            int l = UserImp.UpdatePassword(id, contraNueva); //nos devuelve mas de uno si todo bien

                            if (l > 0)
                            {
                                //MessageBox.Show("", "¡¡¡Se actualizo la contrseña!!!");

                                lblError.Text = "Se cambio la contraseña correctamente";
                            }
                            else
                            {
                                //MessageBox.Show("Tu contraseña temporal esta mal escrita", "contraseña inexistente");
                                lblError.Text = "Tu contraseña temporal esta mal escrita";
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Las contraseñas no coinciden", "No coinciden");
                            lblError.Text = "Las contraseñas no coinciden";
                        }
                    }
                    else
                    {
                        //MessageBox.Show("La contraseña tiene que contener una minuscula una mayuscula un numero y un caracter raro ", "Contraseña sin minusculas");
                        lblError.Text = "La contraseña tiene que contener una minuscula una mayuscula un numero y un caracter raro";

                    }

                }
                else
                {
                    //MessageBox.Show("La contraseña tiene que tener minimo 8 caracteres", "contraseña menor a 8 caracteres");
                    lblError.Text = "La contraseña tiene que tener minimo 8 caracteres";
                }
            }
            else
            {
                //MessageBox.Show("El campo contraseña esta vacia", "contraseña vacia");
                lblError.Text = "El campo contraseña esta vacia";
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            CambioContrasenia();
        }
    }




}