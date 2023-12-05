using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class AttentionPoint : BaseModel
    {
        

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int IdTown { get; set; }

        #endregion



        #region constructor

        public AttentionPoint(int iD, string name, string phone, string address, string latitude,string longitude,int idTown, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = iD;
            Name = name;
            Phone = phone;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            IdTown = idTown;
            
        }

        public AttentionPoint(string name, string phone, string address, string latitude, string longitude, int idTown)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            IdTown = idTown;
        }

        public AttentionPoint(int iD, string name, string phone, string address, string latitude, string longitude, int idTown)
        {
            ID = iD;
            Name = name;
            Phone = phone;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            IdTown = idTown;
        }
        public AttentionPoint()
        {

        }
        #endregion


    }
}
