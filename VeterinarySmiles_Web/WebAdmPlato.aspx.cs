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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmPlato : System.Web.UI.Page
    {
        PlatoImpl implPlato;
        Plato P;
        ControlMio vl = new ControlMio();
        string type;
        byte id;
        bool b1 = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            Select();
            fillCombo1();
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
        void fillCombo1()
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable combo = implPlato.ComboBox();
                    implPlato = new PlatoImpl();
                    cbxMenu.DataSource = combo;
                    cbxMenu.DataTextField = "nombre";
                    cbxMenu.DataValueField = "id";
                    //Brand.DataSource = combo.DefaultView;
                    cbxMenu.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        void Select()
        {
            try
            {
                implPlato = new PlatoImpl();
                DataTable dt = implPlato.Select();
                DataTable table = new DataTable("Plato");
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                table.Columns.Add("Menu", typeof(string));
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
                    string up = " <a class='btn btn-sm btn-info' href='WebUpdatePlato.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='WebAdmPlato.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a>  ";

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


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            txtNombre.Text = Regex.Replace(txtNombre.Text.Trim(), @"\s+", " ");
            txtDescripcion.Text = txtDescripcion.Text.Trim();
            ValidDesc(txtNombre.Text);
            if (b1 == true)
            {
                try
                {
                    byte selectedId = Convert.ToByte(cbxMenu.SelectedValue);
                    P = new Plato(txtNombre.Text, txtDescripcion.Text, selectedId);
                    implPlato = new PlatoImpl();
                    int n = implPlato.Insert(P);
                    if (n > 0)
                    {
                        lblControlFinal.Text = "Se insertó de manera correcta.";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Exito!','Se insertó de manera exitosa!','success')", true);
                        txtDescripcion.Text = "";
                        txtNombre.Text = "";
                        Select();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
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
                        Response.Redirect("WebPlato.aspx");
                        lblControlFinal.Text = "Se eliminó de manera correcta.";
                    }
                    else
                    {
                        Response.Redirect("WebPlato.aspx");
                        // Código para el caso de que el usuario seleccione "No"
                        // Puedes realizar aquí las acciones necesarias
                        // Console.WriteLine("El usuario seleccionó 'No'");
                    }

                }

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
                    implPlato = new PlatoImpl();

                    int n = implPlato.Delete(id);
                    lblControlFinal.Text = "Se eliminó de manera correcta.";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            byte selectedId = Convert.ToByte(cbxMenu.SelectedValue);
            string script = $"alert('{selectedId}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
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