using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinarySmilesDAO.Models
{
    public class Person : BaseModel
    {
        #region Properties
        public int ID { get; set; }

        public string Ci { get; set; }

        public string Name { get; set; }

        public string FirsName { get; set; }

        public string SecondLastName { get; set; }
        public DateTime BirtDate { get; set; }
        public char Gender { get; set; }
      
        public string Email { get; set; }



        public float Peso {  get; set; }

        public float Altura { get; set; }

        public float IMC { get; set; }
        public string GradoDiabetes { get; set; }  

        #endregion

        #region Constructors
        //con mail
        /*
        public Person(int iD, string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string phone, string address, string email, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = iD;
            Ci = ci;
            Name = name;
            FirsName = firsName;
            SecondLastName = secondLastName;
            BirtDate = birtDate;
            Gender = gender;
            Phone = phone;
            Address = address;
            Email = email;
        }*/

        public Person(int iD, string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = iD;
            Ci = ci;
            Name = name;
            FirsName = firsName;
            SecondLastName = secondLastName;
            BirtDate = birtDate;
            Gender = gender;
            
          
           
        }

        public Person(int iD, string ci, string name, string firsName, string secondLastName, char gender,float peso,float altura,string gradoDiabetes, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = iD;
            Ci = ci;
            Name = name;
            FirsName = firsName;
            SecondLastName = secondLastName;
            //BirtDate = birtDate;
            Gender = gender;


        }



        public Person(string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string email)
        {
            this.Ci = ci;
            this.Name = name;
            this.FirsName = firsName;
            this.SecondLastName = secondLastName;
            this.BirtDate = birtDate;
            this.Gender = gender;
            this.Email = email;

        }


        public Person(string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender)
        {
            this.Ci = ci;
            this.Name = name;
            this.FirsName = firsName;
            this.SecondLastName = secondLastName;
            this.BirtDate = birtDate;
            this.Gender = gender;
            
            

        }

        public Person()
        {

        }



        #endregion
    }
}
