using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebMenuCliente : System.Web.UI.Page
    {

        static int id;


        byte lacteo = 0, marisco = 0, frutoSeco = 0;


        Person p;
        User v;

        PersonImp impPerson;
        UserImp2 impUsu;

        ControlMio cs;
        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            xd();
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

        void xd()
        {

            
                if (Session["userID"] != null)
                {
                    //lblError.Text = Session["userID"].ToString() + Session["userName"].ToString() +
                    //Session["role"].ToString();
                    id = int.Parse(Session["userID"].ToString());

                //lblError.Text = "Bienvenido " + Session["userName"].ToString() + " con rol " + Session["role"].ToString();
                lblError.Text = "Bienvenido " + Session["userName"].ToString();



                    if (Session["role"].ToString() == "Cliente")
                    {
                        //string urlVet = "WebMenuAdministrador.aspx";
                        //Response.Redirect(urlVet);


                        //Uri urlActual = Request.Url;
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
                        impPerson = new PersonImp();
                        p = impPerson.Get(id);
                        txtPeso.Text = p.Peso.ToString().Trim();
                        txtCM.Text = p.Altura.ToString().Trim();
                        selGender.SelectedValue = p.Gender.ToString();
                        selGradoDiabetes.SelectedValue = p.GradoDiabetes.ToString();
                        
                       
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
                lblError.Text = "";

                cs = new ControlMio();

                bool banderaPeso = false;
                bool banderaAltura = false;
                bool banderaGradoDiabetes = false;
                bool banderaIMC = false;

                float imc = 0;
                float imcTruncado = 0;
               

                if (txtPeso.Text != "")
                {
                    banderaPeso = cs.validaNumeroPositivo(txtPeso.Text.Trim().Replace("  ", " "));
                    if (banderaPeso == false)
                    {
                        lblError.Text += "Tiene que ser numero positivo\n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Peso esta vacio \n";
                }
                if (txtCM.Text != "")
                {
                    banderaAltura = cs.validaNumeroPositivo(txtCM.Text.Trim().Replace("  ", " "));
                    if (banderaAltura == false)
                    {
                        lblError.Text += "Tiene que ser numero positivo \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }
                if (selGradoDiabetes.SelectedIndex == -1)
                {
                    lblError.Text += "Seleccione un Grado de diabetes \n";
                }
                /*
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
                }*/
                if (selGender.SelectedIndex == -1)
                {
                    lblError.Text += "Seleccione un Genero \n";
                }

                
                if (float.Parse(txtPeso.Text) > (float.Parse(txtCM.Text)/100))
                {
                    banderaIMC = true;
                    //IMC = Peso (en kilogramos) / (Altura (en metros) * Altura (en metros))
                    imc = (float.Parse(txtPeso.Text)/ ((float.Parse(txtCM.Text)/100)*(float.Parse(txtCM.Text) / 100)));
                    imcTruncado = (float)Math.Round(imc, 2);

                }
              
                    
                

                //MessageBox.Show(banderaCi.ToString() + banderaNombre.ToString() + banderaFecha.ToString() + banderaApellidoPaterno.ToString() +
                //banderaTelefono.ToString() + banderaDireccion.ToString());

                if (banderaPeso == true && banderaAltura == true && banderaIMC == true
                   )
                {

                    //si pasa los controles

                    impPerson = new PersonImp();

                    //Person p = new Person(txtCI.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, DateTime.Parse(txtBirthDate.Text), Char.Parse(selGender.SelectedValue));

                    //Person p = new Person(txtCI.Text, txtName.Text, txtLastName.Text, txtSecondLastName.Text, DateTime.Parse(txtBirthDate.Text), Char.Parse(selGender.SelectedValue), txtPhone.Text, txtAddress.Text);

                    //Veterinarian v = new Veterinarian(txtCodigoVet.Text, txtEspeciality.Text);

                    //VeterinarianImp impuser = new VeterinarianImp();
                    //impuser.Update(p,v);
                    //impVet.Update(p, v, id);



                    if (chkLacteo.Checked == true)
                    {
                        lacteo = 1;

                    }

                    if (chkMariscos.Checked == true)
                    {
                        marisco = 1;

                    }
                    if (chkFrutosSecos.Checked == true)
                    {
                        frutoSeco = 1;

                    }

                    impPerson.Update3(id, Char.Parse(selGender.SelectedValue), float.Parse(txtPeso.Text), float.Parse(txtCM.Text), selGradoDiabetes.SelectedValue.ToString(), 
                                                    imcTruncado,selGradoDiabetes.SelectedValue,
                                                    lacteo,marisco,frutoSeco);

                    //impPerson.Update2(id, Char.Parse(selGender.SelectedValue), float.Parse(txtPeso.Text),float.Parse(txtCM.Text),selGradoDiabetes.SelectedValue.ToString(), imcTruncado);




                    string url = "WebMenu.aspx";
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {

                //lblError.Text="";
            }















        }



    }
}