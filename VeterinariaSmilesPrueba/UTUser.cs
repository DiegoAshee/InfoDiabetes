using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VeterinarySmilesDAO.Models;
using VeterinarySmilesDAO.Implementations;
using DifficilBankDAO.Models;
using DifficilBankDAO.Implementations;
using System.Collections.Generic;
using System.Data;

namespace VeterinariaSmilesPrueba
{
    [TestClass]
    public class UTUser
    {
        [TestMethod]
        
        public void Insert()
        {
            Person p = new Person("1111","Diego","Rengifo","Rodriguez",DateTime.Parse("2000-12-24"),'M',"Diego@gmail.com");

            User u = new User("Diego", "1234","Cliente");


            UserImp2 impuser = new UserImp2();
            impuser.Insert(p,u);
        }
        /*
        public void Update()
        {
            VeterinarianImp impVet = new VeterinarianImp();
            //v = new Supplier(int.Parse(Request.QueryString["id"]), txtName.Text, txtPhone.Text, txtAddress.Text, txtEmail.Text);

            Person p = new Person("58255", "romaria", "Quizpe", "Morales", DateTime.Parse("2012-12-12"), Char.Parse("F"), "698866", "Calle esprezanza");

            Veterinarian v = new Veterinarian("Prueba codigo", "Prueba Especialidad");


            //VeterinarianImp impuser = new VeterinarianImp();
            //impuser.Update(p,v);
            impVet.Update(p, v,1);
        }*/

        public void muestra()
        {
            //TownImp impTown = new TownImp();

            //List<State> states = new List<State>();

            //DataTable dt3 = impTown.SelectStateMio("Cochabamba");




            //string mio = dt3[0][''];

            //states = ConvertirDataTableALista(dt3);

            //string mio = states[0].Name.ToString();
            /*
            foreach (State state in states) { 
            
                Console.WriteLine("Holaaa " + state.Name);
            
            }
            */
        }




        //public static List<State> ConvertirDataTableALista(DataTable dataTable)
        //{
        //    List<State> lista = new List<State>();

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        State miState = new State();
        //        //id,ci,name,lastName,secondLastName
        //        miState.Name = (row["id"].ToString());



        //        // Asigna los valores de las demás propiedades según las columnas del DataTable

        //        lista.Add(miState);
        //    }

        //    return lista;
        //}
    }
}
