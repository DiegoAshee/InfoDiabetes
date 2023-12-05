using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinarySmilesDAO.Models
{
    public class BaseModel
    {
        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastDate { get; set; }
        public BaseModel()
        {

        }
        public BaseModel(byte status, DateTime registerDate, DateTime lastDate)
        {
            Status = status;
            RegisterDate = registerDate;
            LastDate = lastDate;
        }
    }
}
