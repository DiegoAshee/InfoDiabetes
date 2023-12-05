using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifficilBankDAO.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UnidadDeMedida { get; set; }

        public string TipoAlimento { get; set; }

        public float Energia { get; set; }

        public float Proteina { get; set; }

        public float Grasa { get; set; }

        public float PorcentajeAzucar { get; set; }

        public byte[] Imagen;


        public Ingrediente() { }




        public Ingrediente(int id, string nombre, string unidadDeMedida, string tipoAlimento, float energia,
                            float proteina, float grasa, float porcentajeAzucar, byte[] imagen)
        {
            Id = id;
            Nombre = nombre;
            UnidadDeMedida = unidadDeMedida;
            TipoAlimento = tipoAlimento;
            Energia = energia;
            Proteina = proteina;
            Grasa = grasa;
            PorcentajeAzucar = porcentajeAzucar;
            Imagen = imagen;
        }


        public Ingrediente(string nombre, string unidadDeMedida, string tipoAlimento, float energia,
                            float proteina, float grasa, float porcentajeAzucar, byte[] imagen)
        {
            Nombre = nombre;
            UnidadDeMedida = unidadDeMedida;
            TipoAlimento = tipoAlimento;
            Energia = energia;
            Proteina = proteina;
            Grasa = grasa;
            PorcentajeAzucar = porcentajeAzucar;
            Imagen = imagen;
        }
        //public Plato(int id, string nombre, string descripcion, byte menuID)
        //{
        //    Id = id;
        //    Nombre = nombre;
        //    Descripcion = descripcion;
        //    MenuID = menuID;
        //}
        //public Plato(string nombre, string descripcion)
        //{
        //    Nombre = nombre;
        //    Descripcion = descripcion;
        //}


    }
}
