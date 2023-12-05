using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Interfaces;

namespace VeterinarySmilesDAO.Interfaces
{
    internal interface IUser:IBase<User>
    {

        DataTable login(string userName,string password);

        User Get(int id);

    }
}
