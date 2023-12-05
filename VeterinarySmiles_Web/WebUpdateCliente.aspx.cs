using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebUpdateCliente : System.Web.UI.Page
    {
        static int id;

        Person p;
        User v;

        PersonImp impPerson;
        UserImp2 impUser;

        ControlMio cs;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            LoadType();
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



        void LoadType()
        {
            try
            {
                string type = Request.QueryString["type"];

                if (type == "U")
                {
                    Get();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        void Get()
        {
            try
            {
                if (!IsPostBack)
                {
                    id = int.Parse(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        impUser = new UserImp2();
                        v = impUser.Get(id);
                        txtCI.Text = v.Ci.ToString();
                        txtName.Text = v.Name.ToString().Trim();
                        txtLastName.Text = v.FirsName.ToString().Trim();
                        txtSecondLastName.Text = v.SecondLastName.ToString().Trim();
                        txtBirthDate.Text = v.BirtDate.ToString();

                        selGender.Text = v.Gender.ToString().Trim();
                        //selGradoDiabetes.Text = v.GradoDiabetes.ToString().Trim();
                        //txtPeso.Text = v.Peso.ToString().Trim();
                        //txtCM.Text = v.Altura.ToString();
                        //txtPhone.Text = sup.Phone.ToString();
                        //txtEmail.Text = sup.Email.ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                /*
                lblError.Text = "";

                cs = new ControlMio();

                bool banderaCi = false;
                bool banderaNombre = false;
                bool banderaApellidoPaterno = false;
                bool banderaTelefono = false;
                bool banderaDireccion = false;
                bool banderaFecha = false;

                bool banderaCodvet = false;
                bool banderaEspecialtys = false;

                if (txtCI.Text != "")
                {
                    banderaCi = cs.ValidarNumeroCi7(txtCI.Text.Trim().Replace("  ", " "));
                    if (banderaCi == false)
                    {
                        lblError.Text += "Tipo formato ci 9999999 ó 9999999-1K\n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo CI esta vacio \n";
                }
                if (txtName.Text != "")
                {
                    banderaNombre = cs.ValidarTextoConÑSinEspacios(txtName.Text.Trim().Replace("  ", " "));
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }
                if (txtLastName.Text != "")
                {
                    banderaApellidoPaterno = cs.ValidarTextoConÑSinEspacios(txtLastName.Text.Trim().Replace("  ", " "));
                    if (banderaApellidoPaterno == false)
                    {
                        lblError.Text += "El Apellido paterno solo acepta letras \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Primer Apellido esta vacio \n";
                }

                if (txtBirthDate.Text != "")
                {
                    banderaFecha = cs.CompruebaFecha(DateTime.Parse(txtBirthDate.Text));
                    if (banderaFecha == false)
                    {
                        lblError.Text += "Ingrese fecha Valida de mas de 25 años\n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo fecha nacimiento esta vacio \n";
                }
                if (selGender.SelectedIndex == -1)
                {
                    lblError.Text += "Seleccione un Genero \n";
                }

                if (txtPhone.Text != "")
                {
                    banderaTelefono = cs.validatePhone2(txtPhone.Text.Trim().Replace("  ", " "));
                    if (banderaTelefono == false)
                    {
                        lblError.Text += "El telefono esta mal tiene que tener entre 7 a 12 numeros\n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Telefono esta vacio \n";
                }
                if (txtAddress.Text != "")
                {
                    banderaDireccion = cs.validarDireccionConNumeros(txtAddress.Text.Trim());
                    if (banderaDireccion == false)
                    {
                        lblError.Text += "La direccion solo acepta letras \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Direccion esta vacio \n";
                }
                if (txtCodigoVet.Text != "")
                {
                    banderaCodvet = cs.validarDireccionConNumeros(txtAddress.Text.Trim().Replace("  ", " "));
                    if (banderaCodvet == false)
                    {
                        lblError.Text += "El codigo de veterinario solo acepta letras \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Codigo Veterinario esta vacio \n";
                }
                if (txtEspeciality.Text != "")
                {
                    banderaEspecialtys = cs.validarDireccionConNumeros(txtAddress.Text.Trim().Replace("  ", " "));
                    if (banderaEspecialtys == false)
                    {
                        lblError.Text += "La especialidad solo acepta letras \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo especialidad esta vacio \n";
                }

                //MessageBox.Show(banderaCi.ToString() + banderaNombre.ToString() + banderaFecha.ToString() + banderaApellidoPaterno.ToString() +
                //banderaTelefono.ToString() + banderaDireccion.ToString());
                */
                //if (banderaCi == true && banderaNombre == true && banderaApellidoPaterno == true &&
                  //  banderaFecha == true && banderaTelefono == true && banderaDireccion == true &&
                    //banderaCodvet == true && banderaEspecialtys == true)
                //{

                    //si pasa los controles

                    impUser = new UserImp2();

                    Person p = new Person(txtCI.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, DateTime.Parse(txtBirthDate.Text), Char.Parse(selGender.SelectedValue));

                    //Person p = new Person(txtCI.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, DateTime.Parse(txtBirthDate.Text), Char.Parse(selGender.SelectedValue), txtPhone.Text, txtAddress.Text);

                    User v = new User(float.Parse(txtPeso.Text), float.Parse(txtCM.Text), selGradoDiabetes.SelectedValue);

                    //VeterinarianImp impuser = new VeterinarianImp();
                    //impuser.Update(p,v);
                    impUser.Update(p, v, id);

                    string url = "WebAdmMuestraClientes.aspx";
                    Response.Redirect(url);
                
            }
            catch (Exception ex)
            {

                //lblError.Text="";
            }















        }
    }
}