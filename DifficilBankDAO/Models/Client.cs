using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class Client : BaseModel
    {
        

        #region Properties
        public int ID { get; set; }

        public string Ci { get; set; }

        public string Name { get; set; }

        public string FirsName { get; set; }

        public string SecondLastName { get; set; }
        public DateTime BirtDate { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        #endregion

        #region Constructors
        public Client(int iD, string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string phone, string address, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
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
        }

        public Client(string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string phone, string address)
        {
            this.Ci = ci;
            this.Name = name;
            this.FirsName = firsName;
            this.SecondLastName = secondLastName;
            this.BirtDate = birtDate;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;

        }
        #endregion

    }
}
