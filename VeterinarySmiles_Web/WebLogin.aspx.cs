using DifficilBankDAO.Implementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinarySmilesDAO.Implementations;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebLogin : System.Web.UI.Page
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

                            string url = "WebAdmVeterinaryDoctor.aspx";
                            Response.Redirect(url);

                            //MessageBox.Show("Tienes que cambiar tu contraseña tienes una temporal se te envio a tu correo", "Contraseña Temporal", MessageBoxButton.OK, MessageBoxImage.Information);
                            //WinCambioContra wcc = new WinCambioContra();
                            //wcc.Show();

                            //MainWindow admin = new MainWindow();
                            //admin.Show();
                            //this.Visibility = Visibility.Hidden;

                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Administrador')", true);

                            break;

                        case "Cliente":

                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Veterinario')", true);

                            break;

                        case "Cajero":
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cajero')", true);

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