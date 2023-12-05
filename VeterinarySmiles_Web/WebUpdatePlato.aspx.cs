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

namespace VeterinarySmiles_Web
{
    public partial class WebUpdatePlato : System.Web.UI.Page
    {
        PlatoImpl implPlato;
        Plato P;
        ControlMio vl = new ControlMio();
        string type;
        static int id;
        bool b1 = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                compruebaSesion();
                id = int.Parse(Request.QueryString["id"]);
                LoadType();
                fillCombo1();
            
            
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
        void capturaId()
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
        }

        void LoadType()
        {
            try
            {
                type = Request.QueryString["type"];

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
            P = null;
            id = int.Parse(Request.QueryString["id"]);
            try
            {
                if (id > 0)
                {
                    implPlato = new PlatoImpl();
                    P = implPlato.Get(id);
                    if (P != null)
                    {
                        txtNombre.Text = P.Nombre.ToString();
                        txtDescripcion.Text = P.Descripcion.ToString();
                        //cbMenu.SelectedValue = P.MenuID.ToString();
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
            txtNombre.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            ValidDesc(txtNombre.Text);
            txtDescripcion.Text = txtDescripcion.Text.Trim();
            if (b1 == true)
            {
                try
                {
                    //string selectedId = Brand.SelectedValue;
                    int selectedId = Convert.ToInt32(cbMenu.SelectedValue);


                    id = int.Parse(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        implPlato = new PlatoImpl();
                        Plato plato = new Plato(id, txtNombre.Text, txtDescripcion.Text, (byte)selectedId);
                        int n = implPlato.Update(plato);
                        if (n > 0)
                        {
                            Response.Redirect("WebPlato.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        void fillCombo1()
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable combo = implPlato.ComboBox();
                    implPlato = new PlatoImpl();
                    cbMenu.DataSource = combo;
                    cbMenu.DataTextField = "nombre";
                    cbMenu.DataValueField = "id";
                    //Brand.DataSource = combo.DefaultView;
                    cbMenu.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        #region Validaciones
        void ValidDesc(string desc)
        {
            if (desc == "")
            {
                lblcontrol1.Text = "El campo no puede estar vacío.";
                b1 = false;
            }
            else if (!vl.IsOnlyLetters(desc))
            {
                lblcontrol1.Text = "El formato de entrada no es válido.";
                b1 = false;
            }
            else
            {
                lblcontrol1.Text = "";
                b1 = true;
            }
        }

        #endregion
    }
}