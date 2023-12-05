using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIngresar_OnClick(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inserto Con exito')", true);
            xd();
        }

        
        void xd()
        {
            try
            {
                UserImp2 impLUser = new UserImp2();
                DataTable table = impLUser.Login(txtLogin.Text, txtPassword.Text);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Entro", true);
                //DataTable primeraVez = impLUser.loginPrimeraVez(txtLogin.Text, txtPassword.Password);


                lblError.Text += "rol " + table.Rows.Count;

                if (table.Rows.Count > 0)
                {

                    //SessionClass.SessionID = int.Parse(table.Rows[0][0].ToString());
                    //SessionClass.SessionUserName = table.Rows[0][1].ToString();
                    //SessionClass.SessionRole = table.Rows[0][2].ToString();


                    Session["userID"] = int.Parse(table.Rows[0][0].ToString()); //Guardamo en la variable sesion el id
                    Session["userName"] = table.Rows[0][1].ToString();
                    Session["role"] = table.Rows[0][2].ToString();



                    switch (table.Rows[0][2].ToString()) // Nos devuelve el rol

                    {
                        case "Administrador":

                            string url = "WebMenuAdministrador.aspx";
                            Response.Redirect(url);

                            //Response.Redirect("WebMenuAdministrador.aspx");
                            break;

                        case "Cliente":
                            

                            string urlVet = "HomePage.aspx";
                            Response.Redirect(urlVet);

                            break;

                        //case "Cajero":
                        //    string urlCaj = "WebMenuCajero.aspx";
                        //    Response.Redirect(urlCaj);

                        //    break;
                        default:

                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Default')", true);
                            break;
                    }
                }
                else
                {
                    lblError.Text = "Usuario o Contraseña Incorrecta";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrecto')", true);
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción de manera adecuada, por ejemplo, muestra un mensaje de error.
                lblError.Text = "Error: " + ex.Message;
            }
        }
    }
}