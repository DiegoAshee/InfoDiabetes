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
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Implementations
{
    public class PersonImp : BaseImpl, IPerson
    {
        public int Delete(Person t)
        {
            query = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
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

        public Person Get(int id)
        {
            Person t = null;

            query = @"SELECT id,ci,name,firstName,secondLastName,birthDate,gender,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                    from Person
                    where id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    t = new Person(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        DateTime.Parse(table.Rows[0][5].ToString()),
                        char.Parse(table.Rows[0][6].ToString()),
                       
                        byte.Parse(table.Rows[0][7].ToString()),
                        DateTime.Parse(table.Rows[0][8].ToString()),
                        DateTime.Parse(table.Rows[0][9].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Person t)
        {

            query = @"INSERT INTO Person(ci, name, firstName, secondLastName, birthDate, gender, phone, address)
                    VALUES(@ci, @name, @firstName, ISNULL(@secondLastName,''), @birthDate, @gender, @phone, @address)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@firstName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
      

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }






        }

        public DataTable SelectSegunEdad()
        {
            query = @"SELECT
                        SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) < 18 THEN 1 ELSE 0 END) AS Menores18,
                        SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) BETWEEN 18 AND 30 THEN 1 ELSE 0 END) AS Entre18y30,
                        SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) BETWEEN 31 AND 50 THEN 1 ELSE 0 END) AS Entre31y50,
                        SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) > 50 THEN 1 ELSE 0 END) AS Mayores50,
                        COUNT(*) AS TotalPersonas,
                        ROUND((SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) < 18 THEN 1 ELSE 0 END) * 100.0 / COUNT(*)), 2) AS PorcentajeMenores18,
                        ROUND((SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) BETWEEN 18 AND 30 THEN 1 ELSE 0 END) * 100.0 / COUNT(*)), 2) AS PorcentajeEntre18y30,
                        ROUND((SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) BETWEEN 31 AND 50 THEN 1 ELSE 0 END) * 100.0 / COUNT(*)), 2) AS PorcentajeEntre31y50,
                        ROUND((SUM(CASE WHEN DATEDIFF(YEAR, birthDate, GETDATE()) > 50 THEN 1 ELSE 0 END) * 100.0 / COUNT(*)), 2) AS PorcentajeMayores50
                    FROM
                        [BioInformaticaBD].[dbo].[Person]
                    WHERE
                        status = 1";

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
            query = @"SELECT ci AS 'CI', name AS 'Nombre', firstName AS 'Primer Apellido', secondLastName AS 'Segundo Apellido',
                    DATEDIFF(YEAR, birthDate, GETDATE()) - 
                        CASE 
                            WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                            THEN 1 
                            ELSE 0 
                        END AS 'Edad', birthDate AS 'Fecha Nacimiento', gender AS 'Genero'
                    FROM Person";

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

        public int Update(Person t)
        {
            /*
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, birthDate = @birthDate, gender = @gender, phone = @phone, address = @address, lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";
            */

            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName,
                    secondLastName = @secondLastName,
                    peso = @peso ,altura = @altura, gradoDiabetes = @gradoDiabetes,
                    gender = @gender,lastUpdate = CURRENT_TIMESTAMP
                    WHERE id = @id";


            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@firstName", t.FirsName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            //command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@peso", t.Peso);
            command.Parameters.AddWithValue("@altura", t.Altura);
            command.Parameters.AddWithValue("@gradoDiabetes", t.GradoDiabetes);

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



        public int Update2(int id,char genero,float peso,float altura,string gradDiabetes,float imc)
        {
            /*
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, birthDate = @birthDate, gender = @gender, phone = @phone, address = @address, lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";
            */

            query = @"UPDATE Person SET peso = @peso ,altura = @altura, gradoDiabetes = @gradoDiabetes,
                    gender = @gender,imc=@imc,lastUpdate = CURRENT_TIMESTAMP
                    WHERE id = @id";


            SqlCommand command = CreateBasicCommand(query);

            
            //command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", genero);
            command.Parameters.AddWithValue("@peso", peso);
            command.Parameters.AddWithValue("@altura", altura);
            command.Parameters.AddWithValue("@gradoDiabetes", gradDiabetes);
            command.Parameters.AddWithValue("@imc", imc);

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




        public int Update3(int id, char genero, float peso, float altura, string gradDiabetes, float imc,string porcentajeDiabetes,
            byte alergiaLacteos,byte alergiaMariscos,byte alergiaFrutosSecos)
        {
            /*
            query = @"UPDATE Person SET ci = @ci, name = @name, firstName = @firstName, secondLastName = @secondLastName, birthDate = @birthDate, gender = @gender, phone = @phone, address = @address, lastUpdate = CURRENT_TIMESTAMP
                        WHERE id = @id";
            */

            query = @"UPDATE Person SET peso = @peso,altura = @altura, gradoDiabetes = @gradoDiabetes,
                    gender = @gender,imc=@imc,alergiaLacteos = @alergiaLacteos,alergiaMariscos = @alergiaMariscos,
					alergiaFrutosSecos = @alergiaFrutosSecos,
					lastUpdate = CURRENT_TIMESTAMP
                    WHERE id = @id";


            SqlCommand command = CreateBasicCommand(query);


            //command.Parameters.AddWithValue("@birthDate", t.BirtDate);
            command.Parameters.AddWithValue("@gender", genero);
            command.Parameters.AddWithValue("@peso", peso);
            command.Parameters.AddWithValue("@altura", altura);
            command.Parameters.AddWithValue("@gradoDiabetes", gradDiabetes);
            command.Parameters.AddWithValue("@imc", imc);
            
            command.Parameters.AddWithValue("@alergiaLacteos", alergiaLacteos);
            command.Parameters.AddWithValue("@alergiaMariscos", alergiaMariscos);
            command.Parameters.AddWithValue("@alergiaFrutosSecos", alergiaFrutosSecos);

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

       


        public DataTable muestraClientesSegunGradoDiabetes(string grado)
        {

            query = @"SELECT id,ci 'CI',name 'Nombre',firstName 'Primer Apellido',secondLastName 'Segundo Apellido',
                      DATEDIFF(YEAR,birthDate , GETDATE()) - 
                        CASE 
                            WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                 (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                            THEN 1 
                            ELSE 0 
                        END AS 'Edad',birthDate 'Fecha Nacimiento',gender 'Genero'
                      FROM Person
                      WHERE [status] = 1 AND gradoDiabetes = ISNULL(@gradoDiabetes,'Nula')";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@gradoDiabetes", grado);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable muestraClientesSegunGradoDiabetesParaImprimir(string grado)
        {
            
            query = @"SELECT ci 'CI',name 'Nombre',firstName 'Primer Apellido',secondLastName 'Segundo Apellido',
                      DATEDIFF(YEAR,birthDate , GETDATE()) - 
                        CASE 
                            WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                 (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                            THEN 1 
                            ELSE 0 
                        END AS 'Edad',birthDate 'Fecha Nacimiento',gender 'Genero'
                      FROM Person
                      WHERE [status] = 1 AND gradoDiabetes = ISNULL(@gradoDiabetes,'Nula')";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@gradoDiabetes", grado);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public DataTable MuestraClientesSegunRangoIMC(string rangoIMC)
        {
            string query = @"SELECT id, ci AS 'CI', name AS 'Nombre', firstName AS 'Primer Apellido', secondLastName AS 'Segundo Apellido',
                    DATEDIFF(YEAR, birthDate, GETDATE()) - 
                        CASE 
                            WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                            THEN 1 
                            ELSE 0 
                        END AS 'Edad', birthDate AS 'Fecha Nacimiento', gender AS 'Genero'
                    FROM Person
                    WHERE [status] = 1 AND imc BETWEEN @minIMC AND @maxIMC";

            SqlCommand command = CreateBasicCommand(query);

            // Definir los rangos de IMC según el parámetro recibido
            double minIMC = 0.0;
            double maxIMC = 0.0;

            switch (rangoIMC)
            {
                case "BajoPeso":
                    minIMC = 0.0;
                    maxIMC = 18.4;
                    break;
                case "Normal":
                    minIMC = 18.5;
                    maxIMC = 24.9;
                    break;
                case "Sobrepeso":
                    minIMC = 25.0;
                    maxIMC = 29.9;
                    break;
                case "Obeso":
                    minIMC = 30.0;
                    maxIMC = 39.9;
                    break;
                case "ObesoMorbido":
                    minIMC = 40.0;
                    maxIMC = double.MaxValue; // No hay límite superior para la obesidad mórbida
                    break;
                default:
                    // Si el rango no coincide con ninguno de los definidos, se puede manejar según tus necesidades.
                    // Aquí se puede lanzar una excepción, devolver un mensaje o ejecutar una acción predeterminada.
                    throw new ArgumentException("Rango de IMC no válido");
            }

            command.Parameters.AddWithValue("@minIMC", minIMC);
            command.Parameters.AddWithValue("@maxIMC", maxIMC);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable MuestraClientesSegunRangoIMCParaImprimir(string rangoIMC)
        {
            string query = @"SELECT ci AS 'CI', name AS 'Nombre', firstName AS 'Primer Apellido', secondLastName AS 'Segundo Apellido',
                    DATEDIFF(YEAR, birthDate, GETDATE()) - 
                        CASE 
                            WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                            THEN 1 
                            ELSE 0 
                        END AS 'Edad', birthDate AS 'Fecha Nacimiento', gender AS 'Genero'
                    FROM Person
                    WHERE [status] = 1 AND imc BETWEEN @minIMC AND @maxIMC";

            SqlCommand command = CreateBasicCommand(query);

            // Definir los rangos de IMC según el parámetro recibido
            double minIMC = 0.0;
            double maxIMC = 0.0;

            switch (rangoIMC)
            {
                case "BajoPeso":
                    minIMC = 0.0;
                    maxIMC = 18.4;
                    break;
                case "Normal":
                    minIMC = 18.5;
                    maxIMC = 24.9;
                    break;
                case "Sobrepeso":
                    minIMC = 25.0;
                    maxIMC = 29.9;
                    break;
                case "Obeso":
                    minIMC = 30.0;
                    maxIMC = 39.9;
                    break;
                case "ObesoMorbido":
                    minIMC = 40.0;
                    maxIMC = double.MaxValue; // No hay límite superior para la obesidad mórbida
                    break;
                default:
                    // Si el rango no coincide con ninguno de los definidos, se puede manejar según tus necesidades.
                    // Aquí se puede lanzar una excepción, devolver un mensaje o ejecutar una acción predeterminada.
                    throw new ArgumentException("Rango de IMC no válido");
            }

            command.Parameters.AddWithValue("@minIMC", minIMC);
            command.Parameters.AddWithValue("@maxIMC", maxIMC);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable muestraClientesSegunNombre(string nombre)
        {

            string query = @"SELECT ci AS 'CI', name AS 'Nombre', firstName AS 'Primer Apellido', secondLastName AS 'Segundo Apellido',
                    DATEDIFF(YEAR, birthDate, GETDATE()) - 
                        CASE 
                            WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                            THEN 1 
                            ELSE 0 
                        END AS 'Edad', birthDate AS 'Fecha Nacimiento', gender AS 'Genero'
                    FROM Person
                    WHERE name LIKE '%' + @nombre + '%';";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", nombre);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable muestraClientesSegunCi(string ci)
        {

            string query = @"SELECT ci AS 'CI', name AS 'Nombre', firstName AS 'Primer Apellido', secondLastName AS 'Segundo Apellido',
                    DATEDIFF(YEAR, birthDate, GETDATE()) - 
                        CASE 
                            WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                            THEN 1 
                            ELSE 0 
                        END AS 'Edad', birthDate AS 'Fecha Nacimiento', gender AS 'Genero'
                    FROM Person
                    WHERE ci LIKE '%' + @ci + '%';";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@ci", ci);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable muestraClientesEntreFechasDeNacimiento(DateTime fechaInicio, DateTime fechaFin)
        {

            string query = @"SELECT ci AS 'CI', name AS 'Nombre', firstName AS 'Primer Apellido', secondLastName AS 'Segundo Apellido',
                            DATEDIFF(YEAR, birthDate, GETDATE()) - 
                                CASE 
                                    WHEN (MONTH(birthDate) > MONTH(GETDATE())) OR 
                                        (MONTH(birthDate) = MONTH(GETDATE()) AND DAY(birthDate) > DAY(GETDATE())) 
                                    THEN 1 
                                    ELSE 0 
                                END AS 'Edad', birthDate AS 'Fecha Nacimiento', gender AS 'Genero'
                            FROM Person
                            WHERE birthDate BETWEEN @fechaInicio AND @fechaFin;";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            command.Parameters.AddWithValue("@fechaFin", fechaFin);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
