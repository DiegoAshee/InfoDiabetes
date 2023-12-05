using DifficilBankDAO.Implementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class Web_Login : System.Web.UI.Page
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


                if (table.Rows.Count > 0)
                {

                    //SessionClass.SessionID = int.Parse(table.Rows[0][0].ToString());
                    //SessionClass.SessionUserName = table.Rows[0][1].ToString();
                    //SessionClass.SessionRole = table.Rows[0][2].ToString();

                    switch (table.Rows[0][2].ToString()) // Nos devuelve el rol

                    {
                        case "Administrador":

                            string url = "WebMenuAdministrador.aspx";
                            Response.Redirect(url);

                            //Response.Redirect("WebMenuAdministrador.aspx");
                            break;

                        case "Cliente":

                            string urlVet = "WebMenuVeterinary.aspx";
                            Response.Redirect(urlVet);

                            break;

                        case "Cajero":
                            string urlCaj = "WebMenuCajero.aspx";
                            Response.Redirect(urlCaj);

                            break;
                        default:

                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Default')", true);
                            break;
                    }
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrecto')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}