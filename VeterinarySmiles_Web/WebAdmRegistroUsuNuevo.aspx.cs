using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmRegistroUsuNuevo : System.Web.UI.Page
    {

        ControlMio cs;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string limpia(string cadena)
        {
            string cadena2 = "";
            cadena2 = cadena.Trim();
            cadena2 = Regex.Replace(cadena, @"\s+", " ");

            return cadena2;
        }

        void inserta()
        {
            try
            {

                lblError.Text = "";

                cs = new ControlMio();

                bool banderaCi = false;
                bool banderaNombre = false;
                bool banderaApellidoPaterno = false;

                bool banderaDireccion = false;
                bool banderaFecha = false;

                bool banderaUsuario = false;
                bool banderaContra = false;
                bool banderaPassConfirm = false;

                if (txtCI.Text != "")
                {
                    string ciMio = limpia(txtCI.Text);
                    banderaCi = cs.ValidarNumeroCi7(ciMio);
                    if (banderaCi == false)
                    {
                        lblError.Text += "Tipo formato ci 9999999 ó 9999999-1K \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo CI esta vacio \n";
                }
                if (txtName.Text != "")
                {
                    string nombreMio = limpia(txtName.Text);
                    banderaNombre = cs.ValidarTextoConÑSinEspacios(nombreMio);
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras sin espacios al principio ni \n al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }
                if (txtLastName.Text != "")
                {
                    string apellidoMio = limpia(txtLastName.Text);
                    banderaApellidoPaterno = cs.ValidarTextoConÑSinEspacios(apellidoMio);
                    if (banderaApellidoPaterno == false)
                    {
                        lblError.Text += "El Apellido paterno solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Primer Apellido esta vacio \n";
                }

                /*if (txtBirthDate.Text != "")
                {
                    banderaFecha = cs.CompruebaFecha(DateTime.Parse(txtBirthDate.Text));
                    if (banderaFecha == false)
                    {
                        lblError.Text += "Ingrese fecha Valida de mas de 25 años\n";
                    }
                }*/
                if (txtBirthDate.Text == "")
                {
                    lblError.Text += "El Campo fecha nacimiento esta vacio \n";
                }
                if (selGender.SelectedIndex == -1)
                {
                    lblError.Text += "Seleccione un Genero \n";
                }


                if (txtUser.Text != "")
                {
                    string usuarioMio = limpia(txtUser.Text);
                    //banderaUsuario = cs.validarDireccionConNumeros(usuarioMio);

                    UserImp2 impUseUsu = new UserImp2();
                    DataTable user = impUseUsu.CompruebaExistenciaDeUsuario(txtUser.Text);

                    if (user.Rows.Count > 0)
                    {
                        banderaUsuario = false;
                        lblError.Text += "Usuario ya existente \n";
                    }
                    else
                    {
                        banderaUsuario = true;
                    }
                }
                else
                {
                    lblError.Text += "El Campo Usuario esta vacio \n";
                }
                if (txtContrsenia.Text != "")
                {

                    string codigoMio = limpia(txtContrsenia.Text);
                    banderaContra = cs.validarDireccionConNumeros(codigoMio);
                    if (banderaContra == false)
                    {
                        lblError.Text += "La Contraseña solo acepta letras y numeros \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Codigo Veterinario esta vacio \n";
                }
                if (txtPassConfirm.Text != txtContrsenia.Text)
                {
                    lblError.Text += "Las contraseñas no coinciden";
                }
                else
                {
                    banderaPassConfirm = true;
                }
                if (banderaCi == true && banderaNombre == true && banderaApellidoPaterno == true && banderaUsuario == true && banderaContra == true && banderaPassConfirm == true
                    )
                {

                    //si pasa los controles

                    string ciMio = limpia(txtCI.Text);
                    string nombreMio = limpia(txtName.Text);
                    string apellidoMio = limpia(txtLastName.Text);
                    string apellidoMat = limpia(txtSecondLastName.Text);
                    string usuarioMio = limpia(txtUser.Text);
                    string contraMia = limpia(txtContrsenia.Text);


                    Person p = new Person(ciMio, nombreMio, apellidoMio, apellidoMat, DateTime.Parse(txtBirthDate.Text), Char.Parse(selGender.SelectedValue));

                    User v = new User(usuarioMio, contraMia, "Cliente");


                    UserImp2 impuser = new UserImp2();
                    impuser.Insert(p, v);


                    //Select2();

                    //lblError.Text = "Inserto con exito";
                    string urlD = "Default.aspx";
                    Response.Redirect(urlD);
                }
            }
            catch (Exception ex)
            {

                //lblError.Text="";
            }

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            inserta();
            
        }
    }

}