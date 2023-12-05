using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Interfaces
{
    internal interface Iuser2
    {

        DataTable Login(string userName, string password);


        void Insert(Person p ,User u);
    }
}
