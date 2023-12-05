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
using VeterinarySmilesDAO.Interfaces;
using VeterinarySmilesDAO.Models;


namespace DifficilBankDAO.Implementations
{
    public class ClientImpl : BaseImpl, IClient
    {
        public int Delete(Client t)
        {
            query = @"UPDATE Client SET status=0,lastUpdate=CURRENT_TIMESTAMP
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

        public Client Get(int id)
        {
            Client t = null;

            query = @"SELECT id,ci,name,lastName,secondLastName,birthDate,gender,phone,address,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    from Client
                    where id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new Client(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(), table.Rows[0][4].ToString(), DateTime.Parse(table.Rows[0][5].ToString()),char.Parse(table.Rows[0][6].ToString()) , table.Rows[0][7].ToString(), table.Rows[0][8].ToString(), byte.Parse(table.Rows[0][9].ToString()), DateTime.Parse(table.Rows[0][10].ToString()), DateTime.Parse(table.Rows[0][11].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Client t)
        {
            
            query = @"INSERT INTO Client(ci, name, lastName, secondLastName, birthDate, gender, phone, address)
                    VALUES(@ci, @name, @lastName, ISNULL(@secondLastName,''), @birthDate, @gender, @phone, @address)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@address", t.Address);

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
            query = @"SELECT id,name AS 'Nombre',lastName AS 'Primer Apellido',secondLastName AS 'Segundo Apellido',birthDate AS 'Fecha de Nacimiento',gender AS 'Genero',phone AS 'Telefono',address AS 'Direccion'
                    FROM Client
                    WHERE status = 1
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

        public int Update(Client t)
        {
            query = @"UPDATE Client SET ci = @ci, name = @name, lastName = @lastName, secondLastName = @secondLastName, birthDate = @birthDate, gender = @gender, phone = @phone, address = @address, lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@address", t.Address);

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
