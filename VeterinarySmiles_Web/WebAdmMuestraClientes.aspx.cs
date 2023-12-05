using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmMuestraClientes : System.Web.UI.Page
    {

        Person p;
        User v;

        PersonImp impPerson;
        UserImp2 impUser;

        ControlMio cs;

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            load();
            Select2();
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


        public string limpia(string cadena)
        {
            string cadena2 = "";
            cadena2 = cadena.Trim();
            cadena2 = Regex.Replace(cadena, @"\s+", " ");

            return cadena2;
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string url = "WebAdmUser.aspx";
            Response.Redirect(url);


        }


        void Select2()
        {
            try
            {
                impUser = new UserImp2();
                DataTable dt = impUser.Select();

                /*
                 SELECT P.ci AS 'CI',P.name AS 'Nombre',P.firstName AS 'Primer Apellido',
                P.secondLastName AS 'Segundo Apellido',VD.vetCode AS 'Codigo Veterinario', 
                VD.specialty AS 'Especialidad' */


                DataTable table = new DataTable("Veterian");
                //table.Columns.Add("ID", typeof(string));
                table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Primer Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Usuario", typeof(string));
                table.Columns.Add("Rol", typeof(string));


                table.Columns.Add("Acciones", typeof(string));
                //table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
                //GridData.DataSource = implSize.Select();
                gridData.DataSource = table;
                gridData.DataBind();

                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateCliente.aspx?id=" + id + "&type=U'> Actualizar  </a> ";
                    string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                    gridData.Rows[i].Cells[6].Text = up;
                    gridData.Rows[i].Cells[6].Text += del;
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
                string type = Request.QueryString["type"];

                if (type == "De")
                {
                    //lblError.Text = " no Nulooooooooooooo";
                    Delete();
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inserto Con exito')", true);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void Delete()
        {
            id = int.Parse(Request.QueryString["id"]);

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+id.ToString()+"')", true);

            if (id > 0)
            {

                try
                {
                    impUser = new UserImp2();

                    //v = impUser.Get(id);
                    //lblError.Text = " no Nulooooooooooooo";
                    //if (v != null)
                    //{
                        impUser.Delete(id);
                        // Realizar cualquier acción adicional después de la eliminación
                        //lblError.Text = " no Nulooooooooooooo";
                        Select2();
                    //}
                    //else
                    //{
                        //lblError.Text = "Nulooooooooooooo"; 
                    //}
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}