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
using VeterinarySmilesDAO.Models;

namespace VeterinarySmiles_Web
{
    public partial class WebAdmUser : System.Web.UI.Page
    {
        Person p;
        User u;

        PersonImp impPerson;
        UserImp2 imUser;//UserImp2 impuser

        ControlMio cs;

        int id;
        //Person

        protected void Page_Load(object sender, EventArgs e)
        {
            compruebaSesion();
            //load();
            //Select2();
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

            try
            {
                
                lblError.Text = "";

                cs = new ControlMio();

                bool banderaCi = false;
                bool banderaNombre = false;
                bool banderaApellidoPaterno = false;
                
                bool banderaDireccion = false;
                bool banderaFecha = false;

                bool banderaUsuario = false;
                bool banderaContra = false;


                if (txtCI.Text != "")
                {
                    string ciMio = limpia(txtCI.Text);
                    banderaCi = cs.ValidarNumeroCi7(ciMio);
                    if (banderaCi == false)
                    {
                        lblError.Text += "Tipo formato ci 9999999 ó 9999999-1K \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo CI esta vacio \n";
                }
                if (txtName.Text != "")
                {
                    string nombreMio = limpia(txtName.Text);
                    banderaNombre = cs.ValidarTextoConÑSinEspacios(nombreMio);
                    if (banderaNombre == false)
                    {
                        lblError.Text += "El nombre solo acepta letras sin espacios al principio ni \n al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Nombre esta vacio \n";
                }
                if (txtLastName.Text != "")
                {
                    string apellidoMio = limpia(txtLastName.Text);
                    banderaApellidoPaterno = cs.ValidarTextoConÑSinEspacios(apellidoMio);
                    if (banderaApellidoPaterno == false)
                    {
                        lblError.Text += "El Apellido paterno solo acepta letras sin espacios al \n principio ni al final ni mas de uno entre medias \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Primer Apellido esta vacio \n";
                }

                /*if (txtBirthDate.Text != "")
                {
                    banderaFecha = cs.CompruebaFecha(DateTime.Parse(txtBirthDate.Text));
                    if (banderaFecha == false)
                    {
                        lblError.Text += "Ingrese fecha Valida de mas de 25 años\n";
                    }
                }*/
                if(txtBirthDate.Text == "")
                {
                    lblError.Text += "El Campo fecha nacimiento esta vacio \n";
                }
                if (selGender.SelectedIndex == -1)
                {
                    lblError.Text += "Seleccione un Genero \n";
                }

                
                if (txtUser.Text != "")
                {
                    string usuarioMio = limpia(txtUser.Text);
                    banderaUsuario = cs.validarDireccionConNumeros(usuarioMio);
                    if (banderaDireccion == false)
                    {
                        lblError.Text += "El usuario solo acepta letras y numeros \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Usuario esta vacio \n";
                }
                if (txtContrsenia.Text != "")
                {

                    string codigoMio = limpia(txtContrsenia.Text);
                    banderaContra = cs.validarDireccionConNumeros(codigoMio);
                    if (banderaContra == false)
                    {
                        lblError.Text += "La Contraseña solo acepta letras y numeros \n";
                    }
                }
                else
                {
                    lblError.Text += "El Campo Codigo Veterinario esta vacio \n";
                }
              

                if (banderaCi == true && banderaNombre == true && banderaApellidoPaterno == true && banderaUsuario == true && banderaContra == true
                    )
                {

                    //si pasa los controles

                    string ciMio = limpia(txtCI.Text);
                    string nombreMio = limpia(txtName.Text);
                    string apellidoMio = limpia(txtLastName.Text);
                    string apellidoMat = limpia(txtSecondLastName.Text);
                    string usuarioMio = limpia(txtUser.Text);
                    string contraMia = limpia(txtContrsenia.Text);
                   

                    Person p = new Person(ciMio, nombreMio, apellidoMio, apellidoMat, DateTime.Parse(txtBirthDate.Text), Char.Parse(selGender.SelectedValue));

                    User v = new User(usuarioMio, contraMia, "Cliente");


                    UserImp2 impuser = new UserImp2();
                    impuser.Insert(p, v);
                    

                    //Select2();

                    //lblError.Text = "Inserto con exito";
                    string urlD = "WebAdmMuestraClientes.aspx";
                    Response.Redirect(urlD);
                }
            }
            catch (Exception ex)
            {

                //lblError.Text="";
            }

        }

        /*
        void Select2()
        {
            try
            {
                impVet = new VeterinarianImp();
                DataTable dt = impVet.Select();

                
                 //SELECT P.ci AS 'CI',P.name AS 'Nombre',P.firstName AS 'Primer Apellido',
                //P.secondLastName AS 'Segundo Apellido',VD.vetCode AS 'Codigo Veterinario', 
                //VD.specialty AS 'Especialidad' 


                DataTable table = new DataTable("Veterian");
                //table.Columns.Add("ID", typeof(string));
                table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Primer Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Codigo Veterinario", typeof(string));
                table.Columns.Add("Especialidad", typeof(string));


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
                    string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateVeterinaryDoctor.aspx?id=" + id + "&type=U'> Actualizar  </a> ";
                    string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmVeterinaryDoctor.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

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
        */

        /*void load()
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
        }*/

        /*void Delete()
        {
            id = int.Parse(Request.QueryString["id"]);

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+id.ToString()+"')", true);

            if (id > 0)
            {

                try
                {
                    impVet = new VeterinarianImp();

                    v = impVet.Get(id);
                    //lblError.Text = " no Nulooooooooooooo";
                    if (v != null)
                    {
                        impVet.Delete2(v);
                        // Realizar cualquier acción adicional después de la eliminación
                        //lblError.Text = " no Nulooooooooooooo";
                        Select2();
                    }
                    else
                    {
                        //lblError.Text = "Nulooooooooooooo"; 
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }*/
    


    }
}