using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Interfaces;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Interfaces
{
    internal interface IPerson : IBase<Person>
    {

        Person Get(int id);

        

    }
}
