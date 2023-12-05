using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class Plato : BaseModel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte MenuID { get; set; }

        /// <summary>
        /// get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="price"></param>
        /// <param name="size"></param>
        /// <param name="status"></param>
        public Plato(int id, string nombre, string descripcion, byte status, byte menuID)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            MenuID = menuID;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="size"></param>
        public Plato(string nombre, string descripcion, byte menuID)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            MenuID = menuID;
        }
        public Plato(int id, string nombre, string descripcion, byte menuID)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            MenuID = menuID;
        }
        public Plato(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }


    }
}
