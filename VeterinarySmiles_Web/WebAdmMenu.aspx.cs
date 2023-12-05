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
using System.Windows.Forms;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmMenu : System.Web.UI.Page
    {
        ControlMio vl = new ControlMio();
        MenuImpl implMenu;
        MenuMio M;
        string type;
        byte id;
        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            Select();
            load();
            
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

        void Select()
        {
            try
            {
                implMenu = new MenuImpl();
                DataTable dt = implMenu.Select();
                DataTable table = new DataTable("Menu");
                //table.Columns.Add("Numero", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                table.Columns.Add("Tipo de Menu", typeof(string));
                table.Columns.Add("Editar", typeof(string));
                table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {

                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
                //GridData.DataSource = implSize.Select();
                gridData.DataSource = table;
                gridData.DataBind();

                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-sm btn-info' href='MenuCrud.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='WebAdmMenu.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a>  ";

                    gridData.Rows[i].Cells[3].Text = up;
                    gridData.Rows[i].Cells[4].Text = del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void load()
        {
            try
            {
                type = Request.QueryString["type"];

                if (type == "D")
                {
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Verificar la respuesta del usuario
                    if (resultado == DialogResult.Yes)
                    {
                        // Código para el caso de que el usuario seleccione "Sí"
                        // Puedes realizar aquí las acciones necesarias
                        //Console.WriteLine("El usuario seleccionó 'Sí'");

                        Delete();
                        Select();
                        Response.Redirect("WebAdmMenu.aspx");
                        lblControlFinal.Text = "Se eliminó de manera exitosa.";
                    }
                    else
                    {
                        Response.Redirect("WebAdmMenu.aspx");
                        // Código para el caso de que el usuario seleccione "No"
                        // Puedes realizar aquí las acciones necesarias
                        // Console.WriteLine("El usuario seleccionó 'No'");
                    }

                }
                /*string type = Request.QueryString["type"];

                if (type == "D")
                {
                    // Llamar a la función MostrarAlerta() en JavaScript
                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "MostrarAlerta();", true);
                }*/
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void Delete()
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implMenu = new MenuImpl();

                    int n = implMenu.Delete(id);
                    lblControlFinal.Text = "Se eliminó de manera exitosa";

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        protected void btnInsert_Click(object sender, EventArgs e)
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
            else
            {
                lblcontrol.Text = "";
                try
                {

                    M = new MenuMio(txtNombre.Text, txtDescripcion.Text, cmbTipoMenu.SelectedValue);
                    implMenu = new MenuImpl();
                    int n = implMenu.Insert(M);
                    if (n > 0)
                    {
                        lblControlFinal.Text = "Se insertó de manera exitosa";
                        txtNombre.Text = "";
                        txtDescripcion.Text = "";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Exito!','Se insertó de manera exitosa!','success')", true);
                        Select();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                M = new MenuMio(id, txtNombre.Text, txtDescripcion.Text, cmbTipoMenu.SelectedValue);
                implMenu = new MenuImpl();
                int n = implMenu.Update(M);
                if (n > 0)
                {
                    string mensaje = "Se Inserto el registro";
                    string script = $"alert('{mensaje}');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                    lblControlFinal.Text = "Se actualizo de manera exitosa";
                    Select();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Exito!','Se actualizó de manera exitosa!','success')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {


            /*if (B != null)
            {
                try
                {
                    implBrand = new BrandImpl();
                    int n = implBrand.Delete(B);
                    if (n > 0)
                    {
                        string mensaje = "Se elimino el registro";
                        string script = $"alert('{mensaje}');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                        Select();   
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                //MessageBox.Show("Debes seleccionar un registro");
            }*/
        }
    }
}