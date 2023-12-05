using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Interfaces;

namespace DifficilBankDAO.Interfaces
{
    internal interface IAttentionPoint : IBase<AttentionPoint>
    {
        AttentionPoint Get(int id);
    }
}
