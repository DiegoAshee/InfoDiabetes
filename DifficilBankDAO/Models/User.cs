using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class User:Person
    {
        

        #region Properties

        public string UserName { get; set; }
        public string Password { get; set; }

        public string Rol { get; set; }

        public byte Temp { get; set; } 

        public int UserID {get; set; }


        #endregion
        //User v = new User(txtUser.Text, txtContrsenia.Text,txtPeso.Text,txtCM.Text,selGradoDiabetes.SelectedValue);

        //para update mio

        public User(string userName, string contra, float peso, float altura, string gradoDiabetes)
        {
            this.UserName = userName;
            this.Password = contra;
            this.Peso = peso;
            this.Altura = altura;
            this.GradoDiabetes = gradoDiabetes;
            //this.Rol = rol;
        }

        public User(float peso, float altura, string gradoDiabetes)
        {
            this.Peso = peso;
            this.Altura = altura;
            this.GradoDiabetes = gradoDiabetes;
        }

        public User(int iD, string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string phone, string address,string email ,byte status, DateTime registerDate, DateTime lastDate, string userName, string password, string rol,int userID,byte passwordTemp) : base(iD, ci, name, firsName, secondLastName, birtDate, gender,status, registerDate, lastDate)
        {
            this.UserName = userName;
            this.Password = password;
            this.Rol = rol;
            this.UserID = userID;
            this.Temp = passwordTemp;
         
        }

        public User(int iD, string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, byte status, DateTime registerDate, DateTime lastDate, int userID): base(iD, ci, name, firsName, secondLastName, birtDate, gender, status, registerDate, lastDate)
        {
            this.UserID = userID;
         
        }

        public User(int iD, string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, byte status, DateTime registerDate, DateTime lastDate, string user, string rol, int userID) : base(iD, ci, name, firsName, secondLastName, birtDate, gender, status, registerDate, lastDate)
        {
            this.UserName = user;
            this.Rol = rol;
            this.UserID = userID;

        }


        public User(string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string phone, string address, string email ,string userName, string password, string rol) : base(ci, name, firsName, secondLastName, birtDate, gender,email)
        {
            this.UserName = userName;
            this.Password = password;
            this.Rol = rol;
          

        }

        public User(string userName, string password, string rol)
        {
            this.UserName = userName;
            this.Password = password;
            this.Rol = rol;


        }


    }
}
