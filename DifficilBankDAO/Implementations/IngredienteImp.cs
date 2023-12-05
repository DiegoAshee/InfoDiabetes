using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Implementations;

namespace DifficilBankDAO.Implementations
{
    public class IngredienteImp : BaseImpl
    {

        public int Delete(int id)
        {
            query = @"UPDATE Ingrediente SET status=0
                      WHERE idIngrediente=@id";
            SqlCommand command = CreateBasicCommand(query);
            //command.Parameters.AddWithValue("@userID", 1);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int Insert(Ingrediente ingrediente)
        {
            string query = @"INSERT INTO Ingrediente(nombre, unidadDeMedida, tipoAlimento, energia, proteina, grasa, porcentajeAzucar, imagen)
                           VALUES (@Nombre, @UnidadDeMedida, @TipoAlimento, @Energia, @Proteina, @Grasa, @PorcentajeAzucar, @Imagen)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@Nombre", ingrediente.Nombre);
            command.Parameters.AddWithValue("@UnidadDeMedida", ingrediente.UnidadDeMedida);
            command.Parameters.AddWithValue("@TipoAlimento", ingrediente.TipoAlimento);
            command.Parameters.AddWithValue("@Energia", ingrediente.Energia);
            command.Parameters.AddWithValue("@Proteina", ingrediente.Proteina);
            command.Parameters.AddWithValue("@Grasa", ingrediente.Grasa);
            command.Parameters.AddWithValue("@PorcentajeAzucar", ingrediente.PorcentajeAzucar);
            command.Parameters.AddWithValue("@Imagen", ingrediente.Imagen); // Suponiendo que ya tienes la imagen en un array de bytes

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT 
                [idIngrediente],
                [nombre],
                [unidadDeMedida],
                [tipoAlimento],
                [energia],
                [proteina],
                [grasa],
                [porcentajeAzucar],imagen
                
            FROM 
                Ingrediente
                Where [status] = 1 ";

            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public DataTable Select(int id)
        {
            query = @"SELECT 
                i.idIngrediente,
                i.[nombre],
                i.[unidadDeMedida],
                i.[tipoAlimento],
                i.[energia],
                i.[proteina],
                i.[grasa],
                i.[porcentajeAzucar],imagen
                
            FROM menu m
                                    JOIN plato p ON p.idMenu = m.id
                                    JOIN IngredientePlato ip ON ip.idPlato = p.idPlato
                                    JOIN Ingrediente i ON i.idIngrediente = ip.idIngrediente
                                   WHERE m.status = 1 AND i.nombre<> '' AND m.id=@IdIngrediente;";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@IdIngrediente", id);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Ingrediente Get(int id)
        {
            try
            {
                Ingrediente ingrediente = null;

                string query = @"
            
                SELECT idIngrediente, nombre, unidadDeMedida, tipoAlimento, energia, proteina, grasa, porcentajeAzucar,ISNULL(imagen,NULL) AS imagen
                 FROM Ingrediente
            WHERE
                idIngrediente = @id";

                using (SqlCommand command = CreateBasicCommand(query))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (DataTable table = ExecuteDataTableCommand(command))
                    {
                        if (table.Rows.Count > 0)
                        {
                            DataRow row = table.Rows[0];

                            ingrediente = new Ingrediente
                            {
                                Id = short.Parse(row["idIngrediente"].ToString()),
                                Nombre = row["nombre"].ToString(),
                                UnidadDeMedida = row["unidadDeMedida"].ToString(),
                                TipoAlimento = row["tipoAlimento"].ToString(),
                                Energia = float.Parse(row["energia"].ToString()),
                                Proteina = float.Parse(row["proteina"].ToString()),
                                Grasa = float.Parse(row["grasa"].ToString()),
                                PorcentajeAzucar = float.Parse(row["porcentajeAzucar"].ToString()),
                                Imagen = row["imagen"] as byte[],

                            };
                        }
                    }
                }

                return ingrediente;
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrarla adecuadamente
                throw ex;
            }
        }

        public int Update(Ingrediente t)
        {
            string query = @"UPDATE Ingrediente
                 SET nombre = @Nombre, 
                     unidadDeMedida = @UnidadDeMedida, 
                     tipoAlimento = @TipoAlimento, 
                     energia = @Energia, 
                     proteina = @Proteina, 
                     grasa = @Grasa, 
                     porcentajeAzucar = @PorcentajeAzucar,
                     imagen = @Imagen
                     WHERE idIngrediente = @IdIngrediente";


            /*
             SELECT idIngrediente, nombre, unidadDeMedida, tipoAlimento,
            energia, proteina, grasa, porcentajeAzucar, imagen as imagen
                    FROM Ingrediente*/

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@Nombre", t.Nombre);
            command.Parameters.AddWithValue("@UnidadDeMedida", t.UnidadDeMedida);
            command.Parameters.AddWithValue("@TipoAlimento", t.TipoAlimento);
            command.Parameters.AddWithValue("@Energia", t.Energia);
            command.Parameters.AddWithValue("@Proteina", t.Proteina);
            command.Parameters.AddWithValue("@Grasa", t.Grasa);
            command.Parameters.AddWithValue("@PorcentajeAzucar", t.PorcentajeAzucar);
            command.Parameters.AddWithValue("@Imagen", t.Imagen);
            command.Parameters.AddWithValue("@IdIngrediente", t.Id);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




    }
}
