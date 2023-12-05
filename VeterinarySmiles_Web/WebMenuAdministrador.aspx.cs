using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebMenuAdministrador : System.Web.UI.Page
    {
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

            

                if (Session["userID"]!=null) {

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ Session["userID"].ToString() + "')", true);

                //lblError.Text= Session["userID"].ToString() + Session["userName"].ToString()+ 
                //Session["role"].ToString() ;


                //lblError.Text = "Bienvenido " + Session["userName"].ToString() + " con rol " + Session["role"].ToString();
                lblError.Text = "Bienvenido " + Session["userName"].ToString();


                    if (Session["role"].ToString() == "Administrador")
                    {

                    }
                    else{
                        string urlVet = "Default.aspx";
                        Response.Redirect(urlVet);

                    }
                }
        }



    }
}