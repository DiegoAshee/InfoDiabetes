using DifficilBankDAO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;
using VeterinarySmilesDAO.Implementations;
using DifficilBankDAO.Interfaces;

namespace DifficilBankDAO.Implementations
{
    public class UserImp2 : BaseImpl,Iuser2
    {
        
        public void Insert(Person p, User u)
        {


            query = @"INSERT INTO Person (ci,name,firstName,secondLastName,birthDate,gender,userID)
                       VALUES (@ci,@name,@firstName,@secondLastName,@birthDate,@gender,1)";


            string query2 = @"INSERT INTO [user] (id,login,password,role,userID)
                            VALUES (@id,@name,HASHBYTES('md5',@password),@role,1)";


            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@ci", p.Ci);
            commands[0].Parameters.AddWithValue("@name", p.Name);
            commands[0].Parameters.AddWithValue("@firstName", p.FirsName);
            commands[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            commands[0].Parameters.AddWithValue("@birthDate", p.BirtDate);
            commands[0].Parameters.AddWithValue("@gender", p.Gender);
            

            int n = int.Parse(GetGenerateIdTable("Person"));

            commands[1].Parameters.AddWithValue("@id", n);
            commands[1].Parameters.AddWithValue("@name", u.UserName);
            commands[1].Parameters.AddWithValue("@password", u.Password).SqlDbType = SqlDbType.VarChar;
            commands[1].Parameters.AddWithValue("@role", u.Rol);



            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }


        public int UpdatePassword(int id, string password, string nuevaPasword)
        {
            query = @"UPDATE [User] SET password = HASHBYTES('MD5',@nuevaPasword),
                    lastUpdate = CURRENT_TIMESTAMP,
					userID=1,tempPassword=0
                     WHERE id = @id AND password=HASHBYTES('MD5',@password)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@nuevaPasword", nuevaPasword).SqlDbType = SqlDbType.VarChar;




            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public DataTable CompruebaUsuExistente(string userName)
        {
            query = @"SELECT login 
                   FROM [User]
                    WHERE status = 1 AND login = @login AND role <> 'Administrador'";


            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@login", userName);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public DataTable devuelveContra(string userName)
        {
            query = @"SELECT id
                    FROM [User]
                    WHERE login = @login AND status = 1";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@login", userName);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public DataTable CompruebaContraDeUsu(int id, string password)
        {
            query = @"SELECT id
                   FROM [User]
                   WHERE status = 1 AND id = @id AND password = HASHBYTES('MD5',@password)";


            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int UpdatePassword(int id, string password)
        {
            query = @"UPDATE [User] SET password = HASHBYTES('MD5',@password),
                    lastUpdate = CURRENT_TIMESTAMP,
					userID=1
                    WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            //command.Parameters.AddWithValue("@nuevaPasword", nuevaPasword).SqlDbType = SqlDbType.VarChar;




            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public DataTable CompruebaExistenciaDeUsuario(string userName)
        {
            query = @"SELECT login 
                   FROM [User]
                    WHERE status = 1 AND login = @login";


            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@login", userName);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }






















        public DataTable CompruebaUsuExistente2(string userName)
        {
            query = @"SELECT login 
                   FROM [User]
                    WHERE status = 1 AND login = @login";


            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@login", userName);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable CompruebaContraDeUsu2(int id,string password)
        {
            query = @"SELECT id
                   FROM [User]
                   WHERE status = 1 AND id = @id AND password = HASHBYTES('MD5',@password)";


            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Login(string userName, string password)
        {

            query = @"SELECT id,login,role
                    FROM [User]
                    WHERE status = 1 AND login = @login
                    AND password = HASHBYTES('MD5',@password)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@login", userName);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable Select()
        {
            query = @"SELECT U.id AS 'idVet',P.ci AS 'CI',P.name AS 'Nombre',P.firstName AS 'Primer Apellido',P.secondLastName AS 'Segundo Apellido',U.login AS 'Usuario', U.role AS 'Rol' 
                    FROM Person P
                    INNER Join [User] U ON P.id = U.id
                    WHERE U.status = 1
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



        public void Delete(User t)
        {



            query = @"UPDATE [User] SET status=0,lastUpdate=CURRENT_TIMESTAMP
                WHERE id=@id";

            string query2 = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
                WHERE id=@id";

            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@id", t.ID);
            commands[1].Parameters.AddWithValue("@id", t.ID);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Delete(int id)
        {



            query = @"UPDATE [User] SET status=0,lastUpdate=CURRENT_TIMESTAMP
                WHERE id=@id";

            string query2 = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
                WHERE id=@id";

            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@id", id);
            commands[1].Parameters.AddWithValue("@id", id);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Update2(Person p, User v, int id)
        {
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, 
                    birthDate = @birthDate, gender = @gender, peso = @peso, altura = @altura,gradoDiabetes = @gradoDiabetes,
                    lastUpdate = CURRENT_TIMESTAMP,userID=1
                    WHERE id = @idP";

            string query2 = @"UPDATE [User] SET login=@login,password=HASHBYTES('MD5',@password),lastUpdate = CURRENT_TIMESTAMP,userID=1
                            where id = @idV";


            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@ci", p.Ci);
            commands[0].Parameters.AddWithValue("@name", p.Name);
            commands[0].Parameters.AddWithValue("@firstName", p.FirsName);
            commands[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            commands[0].Parameters.AddWithValue("@birthDate", p.BirtDate);
            commands[0].Parameters.AddWithValue("@gender", p.Gender);
            commands[0].Parameters.AddWithValue("@peso", v.Peso);
            commands[0].Parameters.AddWithValue("@altura", v.Altura);
            commands[0].Parameters.AddWithValue("@gradoDiabetes", v.GradoDiabetes);


            //int n = int.Parse(GetGenerateIdTable("Person"));
            /*
            commands[1].Parameters.AddWithValue("@id", n);
            commands[1].Parameters.AddWithValue("@name", u.UserName);
            commands[1].Parameters.AddWithValue("@password", u.Password);
            commands[1].Parameters.AddWithValue("@role", u.Rol);
            */



            commands[1].Parameters.AddWithValue("@login", v.UserName);
            commands[1].Parameters.AddWithValue("@password", v.Password);

            commands[0].Parameters.AddWithValue("@idP", id);
            commands[1].Parameters.AddWithValue("@idV", id);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Person p, User v, int id)
        {
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, 
                    birthDate = @birthDate, gender = @gender, peso = @peso, altura = @altura,gradoDiabetes = @gradoDiabetes,
                    lastUpdate = CURRENT_TIMESTAMP,userID=1
                    WHERE id = @idP";

            string query2 = @"UPDATE [User] SET lastUpdate = CURRENT_TIMESTAMP,userID=1
                            where id = @idV";


            List<SqlCommand> commands = Create2BasicCommand(query, query2);

            commands[0].Parameters.AddWithValue("@ci", p.Ci);
            commands[0].Parameters.AddWithValue("@name", p.Name);
            commands[0].Parameters.AddWithValue("@firstName", p.FirsName);
            commands[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            commands[0].Parameters.AddWithValue("@birthDate", p.BirtDate);
            commands[0].Parameters.AddWithValue("@gender", p.Gender);
            commands[0].Parameters.AddWithValue("@peso", v.Peso);
            commands[0].Parameters.AddWithValue("@altura", v.Altura);
            commands[0].Parameters.AddWithValue("@gradoDiabetes", v.GradoDiabetes);


            //int n = int.Parse(GetGenerateIdTable("Person"));
            /*
            commands[1].Parameters.AddWithValue("@id", n);
            commands[1].Parameters.AddWithValue("@name", u.UserName);
            commands[1].Parameters.AddWithValue("@password", u.Password);
            commands[1].Parameters.AddWithValue("@role", u.Rol);
            */


           

            commands[0].Parameters.AddWithValue("@idP", id);
            commands[1].Parameters.AddWithValue("@idV", id);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public User Get(int id)
        {
            User t = null;

            query = @"SELECT U.id,P.ci,P.name,P.firstName,P.secondLastName,P.birthDate,P.gender,U.status,U.registerDate,ISNULL(U.lastUpdate,CURRENT_TIMESTAMP) AS lastUpdate,U.userID
                    FROM Person P
					INNER Join [User] U ON P.id = U.id
                    where U.id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new User(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        DateTime.Parse(table.Rows[0][5].ToString()),
                        //char.Parse(table.Rows[0][6].ToString()),
                        'M',
                        
                        byte.Parse(table.Rows[0][7].ToString()),
                        DateTime.Parse(table.Rows[0][8].ToString()),
                        DateTime.Parse(table.Rows[0][9].ToString()),
                        int.Parse(table.Rows[0][10].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }













    }
}
