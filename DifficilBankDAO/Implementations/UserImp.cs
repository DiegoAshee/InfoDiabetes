using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Implementations;
using VeterinarySmilesDAO.Interfaces;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmilesDAO.Implementations
{
    public class UserImp : BaseImpl, IUser
    {
        public int Delete(User t)
        {
            query = @"UPDATE User2 SET status=0,lastUpdate=CURRENT_TIMESTAMP,userID=@userID
                    WHERE id=@id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", t.ID);
            command.Parameters.AddWithValue("@userID", t.UserID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert(User t)
        {




            query = @"INSERT INTO User2(ci, name, lastName, secondLastName, birthDate,
                    gender, phone, address,email,login,password,rol,userID)
                    VALUES(@ci, @name, @lastName, ISNULL(@secondLastName,''), @birthDate,@gender, 
                    @phone, @address,@email,@login,HASHBYTES('MD5',@password),@rol,@userID)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@login", t.UserName);
            command.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@userID", SessionClass.SessionID);
            command.Parameters.AddWithValue("@rol", t.Rol);




            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable login(string userName, string password)
        {

            query = @"SELECT id,login,rol
                    FROM [User2]
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

        public DataTable loginPrimeraVez(string userName, string password)
        {

            query = @"SELECT id,login,rol,tempPassword
                    FROM [User2]
                    WHERE status = 1 AND login = @login
                    AND password = HASHBYTES('MD5',@password) AND tempPassword = 1";

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



        public DataTable devuelveContra()
        {
            query = @"SELECT login,password
                    FROM User2
                    WHERE id = 2";
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

        public DataTable Select()
        {
            query = @"SELECT id,name 'Nombre',login AS 'User Name',rol AS 'Rol'
                    FROM User2
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

        public int Update(User t)
        {
            query = @"UPDATE User2 SET ci = @ci, name = @name, lastName = @lastName, secondLastName = @secondLastName, 
                    birthDate = @birthDate, gender = @gender, phone = @phone, address = @address,email=@email,
                    lastUpdate = CURRENT_TIMESTAMP,login=@login,rol=@rol,userID=@userID
                     WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@login", t.UserName);
            command.Parameters.AddWithValue("@rol", t.Rol);
            command.Parameters.AddWithValue("@userID",SessionClass.SessionID);

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

        


        public int UpdatePassword(string userName, string password,string nuevaPasword)
        {
            query = @"UPDATE User2 SET password = HASHBYTES('MD5',@nuevaPasword),
                    lastUpdate = CURRENT_TIMESTAMP,
					userID=1,tempPassword=0
                     WHERE login = @login AND password=HASHBYTES('MD5',@password)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@login", userName);
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
                    FROM User2
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

        public User Get(int id)
        {
            
                User t = null;

                query = @"SELECT id,ci,name,lastName,secondLastName,birthDate,gender,phone,address,email,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP),login,password,rol,userID,tempPassword
                    from User2
                    where id = @id";

                SqlCommand command = CreateBasicCommand(query);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    DataTable table = ExecuteDataTableCommand(command);

                    if (table.Rows.Count > 0)
                    {
                    t = new User(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(), table.Rows[0][4].ToString(), DateTime.Parse(table.Rows[0][5].ToString()), 
                        char.Parse(table.Rows[0][6].ToString()), table.Rows[0][7].ToString(), table.Rows[0][8].ToString(),
                        table.Rows[0][9].ToString(),
                        byte.Parse(table.Rows[0][10].ToString()), DateTime.Parse(table.Rows[0][11].ToString()), 
                        DateTime.Parse(table.Rows[0][12].ToString()), table.Rows[0][13].ToString(), 
                        table.Rows[0][14].ToString(), table.Rows[0][15].ToString(),
                        int.Parse(table.Rows[0][16].ToString()),byte.Parse(table.Rows[0][17].ToString()));
                }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return t;
        }

        public string enviaEmailConCredenciales(string correoDestino,string usuario,string contra)
        {
            string mesaje = "";

            try
            {

                var cliente = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("juancarlosrojasvargas1234@gmail.com", "htqnbdeasuvnusti")//correo        contra
                };

                var email = new MailMessage("juancarlosrojasvargas1234@gmail.com", correoDestino);

                //email.Subject = "Asunto : " + DateTime.Now.ToLongDateString();
                email.Subject = "Credenciales de usuario " + DateTime.Now.ToLongDateString();
                email.Body = "Tu usuario es : " + usuario  + "\n Tu contra es : " + contra;
                cliente.Send(email);

                
                cliente.Send(email);

                mesaje = "Se envio correctamente";
                return mesaje;



            }
            catch (Exception ex)
            {

                throw ex;
            }




        }
        
    }
}
