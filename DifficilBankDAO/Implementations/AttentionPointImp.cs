using DifficilBankDAO.Interfaces;
using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Implementations;

namespace DifficilBankDAO.Implementations
{
    public class AttentionPointImp : BaseImpl, IAttentionPoint
    {
        public int Delete(AttentionPoint t)
        {
            query = @"UPDATE AttentionPoint SET status=0,lastUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", t.ID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AttentionPoint Get(int id)
        {
            AttentionPoint t = null; // Creamos el objeto como null

            query = @"SELECT id,name,phone,address,latitude,longitude,idTown,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    FROM AttentionPoint
					WHERE id=@id"; //hacemos un select con todos los atributos de la tabla

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new AttentionPoint(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        table.Rows[0][5].ToString(),
                        int.Parse(table.Rows[0][6].ToString()),
                        byte.Parse(table.Rows[0][7].ToString()),
                        DateTime.Parse(table.Rows[0][8].ToString()),
                        DateTime.Parse(table.Rows[0][9].ToString())); //creamos el objeto previamente puesto en null y le hacemos el new para instanciar
                                                                      //y seguimos los parametros del constructor
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
            
        }

        public int Insert(AttentionPoint t)
        {
            query = @"INSERT INTO AttentionPoint (name,address,phone,latitude,longitude,idTown,userID)
                    VALUES (@name,@address,@phone,@latitude,@longitude,@idTown,1)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@address", t.Address);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@latitude", t.Latitude);
            command.Parameters.AddWithValue("@longitude", t.Longitude);
            command.Parameters.AddWithValue("@idTown", t.IdTown);
           
            //command.Parameters.AddWithValue("@email", t.Email);


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
            query = @"SELECT AP.id,AP.name,AP.phone,AP.address,AP.latitude,AP.longitude,T.name AS 'Ciudad'
                    FROM AttentionPoint AP
					LEFT JOIN Town T ON AP.idTown = T.id
                    WHERE AP.status = 1
                    ORDER BY 2";

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


    

        public int Update(AttentionPoint t)
        {
            query = @"UPDATE AttentionPoint SET name = @name, phone = @phone, address = @address, latitude = @latitude,longitude=@longitude,idTown=@idTown, userID = 1,lastUpdate = CURRENT_TIMESTAMP
                    WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@address", t.Address);
            command.Parameters.AddWithValue("@latitude", t.Latitude);
            command.Parameters.AddWithValue("@longitude", t.Longitude);
            command.Parameters.AddWithValue("@idTown", t.IdTown);

            command.Parameters.AddWithValue("@id", t.ID);

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
