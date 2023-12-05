using DifficilBankDAO.Implementations;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinarySmilesDAO.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeterinarySmiles_Web
{
    public partial class WebMenu : System.Web.UI.Page
    {

        MenuMio menu;
        MenuImpl menuImpl;
        int id;

        Person p;
        PersonImp impPerson;


        string tipoIMC = "";


        bool alergiaMarisco=false, alergiaLacteo=false, alergiaFrutoSeco=false;
        int marisco=0, lacteo=0, frutoSeco=0;
        string diabetes = "";


        int contadorAlergias = 0;

        //String [] arrayAlergias = new string[contadorAlergias];
        List<string> listaAlergias = new List<string>();


        DataTable MuestraMenu;

        protected void Page_Load(object sender, EventArgs e)
        {

            compruebaSesion();
            id = int.Parse(Session["userID"].ToString());

            //Select2();


            calculaIMC();
            filtrarmenu();
            valorarMenu();
            limpia();

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


        void limpia()
        {
            string tipoIMC = "";


            bool alergiaMarisco = false, alergiaLacteo = false, alergiaFrutoSeco = false;
            int marisco = 0, lacteo = 0, frutoSeco = 0;
            string diabetes = "";


            int contadorAlergias = 0;

            //String [] arrayAlergias = new string[contadorAlergias];
            listaAlergias.Clear();
        }

       










        public void valoraDiabetes(string gradoDiabetes)
        {
            switch (gradoDiabetes)
            {
                case "Muy Alto":
                    // Tu lógica cuando el valor es "Muy Alto"
                    break;
                case "Alto":
                    // Tu lógica cuando el valor es "Alto"
                    break;
                case "Medio":
                    // Tu lógica cuando el valor es "Medio"
                    break;
                case "Bajo":
                    // Tu lógica cuando el valor es "Bajo"
                    break;
                case "Muy Bajo":
                    // Tu lógica cuando el valor es "Muy Bajo"
                    break;
                case "Nula":
                    // Tu lógica cuando el valor es "Nula"
                    break;
                default:
                    // Tu lógica por defecto si el valor no coincide con ninguno de los casos anteriores
                    break;
            }
        }

        public void valorarMenu()
        {

            try
            {


                if (marisco == 0 && lacteo == 0 && frutoSeco == 0) //no tuviera alergias
                {

                    if (diabetes == "Bajo" || diabetes == "Muy Bajo" || diabetes == "Nula") // No tiene diabetes
                    {
                        MuestraMenu = menuImpl.SelectSinAlergia(tipoIMC);
                    }
                    else
                    {
                        MuestraMenu = menuImpl.SelectSinAlergiaConDiabetes(tipoIMC);  //Con Diabetes
                    }
                }
                else   //puede que tenga una o varias alergias 
                {
                    if (diabetes == "Bajo" || diabetes == "Muy Bajo" || diabetes == "Nula") //Sin diabetes
                    {
                        if (contadorAlergias == 1)
                        {
                            MuestraMenu = menuImpl.SelectParaAlergico1(tipoIMC, listaAlergias[0]);  //con una alergia y sin diabetes
                        }
                        else if (contadorAlergias == 2)
                        {
                            MuestraMenu = menuImpl.SelectParaAlergico2(tipoIMC, listaAlergias[0], listaAlergias[1]);  //con 2 alergias y sin diabetes
                        }
                        else if (contadorAlergias == 3)
                        {
                            MuestraMenu = menuImpl.SelectParaAlergico3(tipoIMC, listaAlergias[0], listaAlergias[1], listaAlergias[2]);  //con 3 alergias y sin diabetes
                        }
                    }
                    else //Con diabetes
                    {
                        if (contadorAlergias == 1)
                        {
                            MuestraMenu = menuImpl.SelectParaAlergico1ConDiabetes(tipoIMC, listaAlergias[0]);  //con una alergia y con diabetes
                        }
                        else if (contadorAlergias == 2)
                        {
                            MuestraMenu = menuImpl.SelectParaAlergico2ConDiabetes(tipoIMC, listaAlergias[0], listaAlergias[1]);  //con 2 alergias y con diabetes
                        }
                        else if (contadorAlergias == 3)
                        {
                            MuestraMenu = menuImpl.SelectParaAlergico3ConDiabetes(tipoIMC, listaAlergias[0], listaAlergias[1], listaAlergias[2]);  //con 3 alergias y con diabetes
                        }
                    }
                }



                DataTable table = new DataTable("Menus");
               
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));

                table.Columns.Add(" ", typeof(string));


                foreach (DataRow dr in MuestraMenu.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString());
                }


                



                gridData.DataSource = table;
                gridData.DataBind();


                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = MuestraMenu.Rows[i][0].ToString();
                    string detallePlatos = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebMuestraPlato.aspx?id=" + id + "'> Muestra Plato  </a> ";
                    //string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                    gridData.Rows[i].Cells[2].Text = detallePlatos;
                    //gridData.Rows[i].Cells[6].Text += del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }


            }
            catch (Exception)
            {

                throw;
            }



            
        }



        public void filtrarmenu()
        {
            DataTable alergiasYDiabetes = menuImpl.SelectMuestraAlergiasYDiabetes(id);

            marisco = Convert.ToInt32(alergiasYDiabetes.Rows[0][0]); // nos devulve el marisco en int
            lacteo = Convert.ToInt32(alergiasYDiabetes.Rows[0][1]); // nos devulve el lacteo en int
            frutoSeco = Convert.ToInt32(alergiasYDiabetes.Rows[0][2]); // nos devulve el fruto seco en int
            diabetes = Convert.ToString(alergiasYDiabetes.Rows[0][3]); // nos devulve la diabetes en int

            if (marisco == 1)
            {
                contadorAlergias++;
                listaAlergias.Add("Marisco");
            }
            if (lacteo == 1)
            {
                contadorAlergias++;
                listaAlergias.Add("Lacteo");
            }
            if (frutoSeco == 1)
            {
                contadorAlergias++;
                listaAlergias.Add("Fruto Seco");
            }

        }



        void Select2()
        {
            try
            {


                //id = int.Parse(Session["userID"].ToString());



                menuImpl = new MenuImpl();
                DataTable imcDT = menuImpl.MuestraIMC(id);

                //float dato = float.Parse(imcDT.Rows[0][0]);
                int dato = Convert.ToInt32(imcDT.Rows[0][0]); // nos devulve el imc en int
                float imc = (float) dato;


                tipoIMC = ClasificarIMC(imc);

                DataTable dt = menuImpl.MuestraMenusSegunIMC(tipoIMC);


                /*
                 SELECT P.ci AS 'CI',P.name AS 'Nombre',P.firstName AS 'Primer Apellido',
                P.secondLastName AS 'Segundo Apellido',VD.vetCode AS 'Codigo Veterinario', 
                VD.specialty AS 'Especialidad' */


                DataTable table = new DataTable("Menus");
                //table.Columns.Add("ID", typeof(string));
                //table.Columns.Add("CI", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                //table.Columns.Add("Segundo Apellido", typeof(string));
                //table.Columns.Add("Usuario", typeof(string));
                //table.Columns.Add("Rol", typeof(string));


                //table.Columns.Add("Acciones", typeof(string));
                //table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }
                //GridData.DataSource = implSize.Select();
                gridData.DataSource = table;
                gridData.DataBind();

                /*for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebUpdateCliente.aspx?id=" + id + "&type=U'> Actualizar  </a> ";
                    string del = " <a class='btn btn-secondary' style='background-color:#2a3547' href='WebAdmMuestraClientes.aspx?id=" + id + "&type=De' onclick='return ConfirmDelete();'> Eliminar  </a>  ";

                    gridData.Rows[i].Cells[6].Text = up;
                    gridData.Rows[i].Cells[6].Text += del;
                    gridData.Rows[i].Attributes["data-id"] = id;
                }*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string ClasificarIMC(float imc)
        {
            string categoria = "";

            switch (imc)
            {
                case float imcValue when imcValue < 18.5f:
                    categoria = "Bajo Peso";
                    break;
                case float imcValue when imcValue >= 18.5f && imcValue <= 24.9f:
                    categoria = "Normal";
                    break;
                case float imcValue when imcValue >= 25f && imcValue <= 29.9f:
                    categoria = "Sobre Peso";
                    break;
                case float imcValue when imcValue > 30f:
                    categoria = "Obeso";
                    break;
            }

            return categoria;
        }


        public void calculaIMC()
        {
            menuImpl = new MenuImpl();
            DataTable imcDT = menuImpl.MuestraIMC(id);

            //float dato = float.Parse(imcDT.Rows[0][0]);
            int dato = Convert.ToInt32(imcDT.Rows[0][0]); // nos devulve el imc en int
            float imc = (float)dato;


            tipoIMC = ClasificarIMC(imc);

            //DataTable dt = menuImpl.MuestraMenusSegunIMC(tipoIMC);
        }




    }
}