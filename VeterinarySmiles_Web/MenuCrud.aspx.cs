using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class MenuCrud : System.Web.UI.Page
    {
        ControlMio vl = new ControlMio();
        MenuImpl implMenu;
        MenuMio M;
        string ValidBrand;
        string type;
        byte id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = byte.Parse(Request.QueryString["id"]);
                LoadType();
                M = new MenuMio();
            }
            if (Session["username"] == null)
            {
                Response.Redirect("WebLogin.aspx");
            }
            if (Session["username"] != null && Session["role"].ToString() != "Administrador")
            {
                //lbla.Text = "inicio:" + Session["username"];
                Response.Redirect("WebLogout.aspx");
            }
            else
            {
                //Response.Redirect("WebLogin.aspx");
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
            M = null;
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implMenu = new MenuImpl();
                    M = implMenu.Get(id);
                    if (M != null)
                    {
                        txtNombre.Text = M.Nombre;
                        txtDescripcion.Text = M.Descripcion;
                        cmbTipoMenu.SelectedValue = M.TipoMenu.ToString();
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                implMenu = new MenuImpl();
                int n = implMenu.Delete(M);
                if (n > 0)
                {
                    lblControlFianl.Text = "Se elimino correctamente.";
                    Response.Redirect("WebMenu.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            txtNombre.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            if (txtNombre.Text == "")
            {
                lblcontrol.Text = "El campo no puede estar vacio";
            }
            else if (!vl.VlBrand(txtNombre.Text))
            {
                lblcontrol.Text = "El formato de entrada no es válido.";
            }
            else if (ValidBrand == txtNombre.Text)
            {
                lblcontrol.Text = "No realizo ningun cambio.";
            }
            else
            {
                try
                {
                    id = byte.Parse(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        implMenu = new MenuImpl();
                        MenuMio menumio = new MenuMio(id, txtNombre.Text, txtDescripcion.Text, cmbTipoMenu.SelectedValue);
                        int n = implMenu.Update(menumio);
                        if (n > 0)
                        {
                            lblControlFianl.Text = "Se actualizo de manera exitosa.";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Exito!','Se actualizó de manera exitosa!','success')", true);
                            Response.Redirect("WebAdmMenu.aspx");
                        }
                        else
                        {
                            string mensaje = "Nulo";
                            string script = $"alert('{mensaje}');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}