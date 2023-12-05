using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class MenuMio : BaseModel
    {

        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoMenu { get; set; }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="nombre"></param>
        /// /// <param name="descripcion"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="userID"></param>
        public MenuMio(byte id, string nombre, string descripcion, string tipoMenu, byte status, DateTime registerDate, DateTime lastUpdate): base(status, registerDate, lastUpdate)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            TipoMenu = tipoMenu;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        public MenuMio(byte id, string nombre, string descripcion, string tipoMenu)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            TipoMenu = tipoMenu;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="nombre"></param>
        public MenuMio(string nombre, string descripcion, string tipoMenu)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            TipoMenu = tipoMenu;
        }
        public MenuMio()
        {

        }

    }
}
