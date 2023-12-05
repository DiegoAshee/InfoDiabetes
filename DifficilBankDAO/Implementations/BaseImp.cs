using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace VeterinarySmilesDAO.Implementations
{
    public class BaseImpl
    {
        string connectionString = @"Server=HP\SQLEXPRESS;Database=BioInformaticaBD;User Id=sa;Password=Univalle;";
        public string query = "";
        public SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            return command;
        }

        public SqlCommand CreateBasicCommand(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            return command;
        }


        public List<SqlCommand> Create2BasicCommand(string sql1, string sql2)
        {

            List<SqlCommand> commands = new List<SqlCommand>();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command1 = new SqlCommand(sql1, connection);
            commands.Add(command1);
            SqlCommand command2 = new SqlCommand(sql2, connection);
            commands.Add(command2);


            return commands;
        }



        public string GetGenerateIdTable(string table)
        {
            query = "SELECT IDENT_CURRENT('"+table+"') + IDENT_INCR('"+table+"')";



            SqlCommand command = CreateBasicCommand(query);

            //command.ExecuteScalar().ToString();

            try
            {

                command.Connection.Open();

                return command.ExecuteScalar().ToString();

                //string salida = command.ExecuteNonQuery().ToString();

                //return "salida";

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                command.Connection.Close();
            }


        }






        public int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        
        }


        public void ExecuteNBasicCommand(List<SqlCommand> commands)
        {

            SqlCommand command0 = commands[0];


            try
            {
                commands[0].Connection.Open();


                foreach (SqlCommand item in commands)
                {
                    item.ExecuteNonQuery();
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command0.Connection.Close();
            }
        }






        public DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            DataTable table = new DataTable();

            try
            {
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return table;
        }
    }
}
