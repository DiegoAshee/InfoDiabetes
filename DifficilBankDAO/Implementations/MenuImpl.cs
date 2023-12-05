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
    public class MenuImpl : BaseImpl
    {


        public int Delete(MenuMio m)
        {
            query = @"UPDATE menu SET status=0
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", m.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Delete(int t)
        {
            query = @"UPDATE Menu SET status=0
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MenuMio Get(int id)
        {
            MenuMio m = null;
            query = @"SELECT id, nombre,descripcion,tipoMenu
                      FROM Menu
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    m = new MenuMio(byte.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString());

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return m;
        }

        public int Insert(MenuMio t)
        {
            query = @"INSERT INTO Menu(nombre,descripcion,tipoMenu)
                      VALUES(@nombre,@descripcion,@tipoMenu)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@tipoMenu", t.TipoMenu);

            //command.Parameters.AddWithValue("@size", t.Size);

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
            query = @"SELECT id, nombre AS Nombre, descripcion AS Descripcion, tipoMenu as 'Tipo de Menu'
                        FROM Menu
                        where status=1";
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



        public DataTable SelectMenu(int id)
        {
            query = @"SELECT m.nombre AS nombre_menu, p.nombre AS nombre_plato, ISNULL(i.nombre,'') AS nombre_ingrediente
                                   FROM menu m
                                   LEFT JOIN plato p ON p.idMenu = m.id
                                   LEFT JOIN IngredientePlato ip ON ip.idPlato = p.idPlato
                                   LEFT JOIN Ingrediente i ON i.idIngrediente = ip.idIngrediente
                                   WHERE m.status = 1 AND i.nombre<> '' AND m.id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable SelectSinAlergia(string imc)
        {
            query = @"SELECT m.id,m.nombre,M.descripcion FROM
                    menu m
                    LEFT JOIN plato p ON p.idMenu = m.id
                    LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
                    LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
                    WHERE M.tipoMenu = @tipoMenuIMC AND m.status = 1";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@tipoMenuIMC", imc);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectParaAlergico1(string imc,string alergia)
        {
            query = @"SELECT m.id,m.nombre,M.descripcion FROM
                    menu m
                    LEFT JOIN plato p ON p.idMenu = m.id
                    LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
                    LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
                    WHERE NOT i.tipoAlimento=@tipoAlimento AND M.tipoMenu = @tipoMenuIMC AND m.status = 1;";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@tipoAlimento", alergia);
            command.Parameters.AddWithValue("@tipoMenuIMC", imc);


            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectParaAlergico2(string imc,string alergia1,string alergia2)
        {
            query = @"SELECT m.id,m.nombre, M.descripcion
					FROM menu m
					LEFT JOIN plato p ON p.idMenu = m.id
					LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
					LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
					WHERE NOT (i.tipoAlimento = @tipoAlimento1 OR i.tipoAlimento = @tipoAlimento2) AND M.tipoMenu = @tipoMenuIMC AND m.status = 1;";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@tipoAlimento1", alergia1);
            command.Parameters.AddWithValue("@tipoAlimento2", alergia2);
            command.Parameters.AddWithValue("@tipoMenuIMC", imc);


            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectParaAlergico3(string imc,string alergia1, string alergia2,string alergia3)
        {
            query = @"SELECT m.id,m.nombre, M.descripcion
                    FROM menu m
                    LEFT JOIN plato p ON p.idMenu = m.id
                    LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
                    LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
                    WHERE NOT (i.tipoAlimento = @tipoAlimento1 OR i.tipoAlimento = @tipoAlimento2 OR i.tipoAlimento = @tipoAlimento3)
                    AND M.tipoMenu = @tipoMenuIMC AND m.status = 1;";
            SqlCommand command = CreateBasicCommand(query);


            command.Parameters.AddWithValue("@tipoAlimento1", alergia1);
            command.Parameters.AddWithValue("@tipoAlimento2", alergia2);
            command.Parameters.AddWithValue("@tipoAlimento3", alergia3);
            command.Parameters.AddWithValue("@tipoMenuIMC", imc);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public DataTable SelectSinAlergiaConDiabetes(string imc)
        {
            query = @"SELECT m.id,m.nombre,M.descripcion FROM
                    menu m
                    LEFT JOIN plato p ON p.idMenu = m.id
                    LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
                    LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
                    WHERE ISNULL(i.porcentajeAzucar,0) = 0 AND M.tipoMenu = @tipoMenuIMC AND m.status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@tipoMenuIMC", imc);


            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectParaAlergico1ConDiabetes(string imc,string alergia)
        {
            query = @"SELECT m.id,m.nombre,M.descripcion FROM
                    menu m
                    LEFT JOIN plato p ON p.idMenu = m.id
                    LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
                    LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
                    WHERE NOT i.tipoAlimento=@tipoAlimento AND ISNULL(i.porcentajeAzucar,0) = 0 AND M.tipoMenu = @tipoMenuIMC AND m.status = 1;";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@tipoAlimento", alergia);
            command.Parameters.AddWithValue("@tipoMenuIMC", imc);


            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectParaAlergico2ConDiabetes(string imc,string alergia1, string alergia2)
        {
            query = @"SELECT m.id,m.nombre, M.descripcion
					FROM menu m
					LEFT JOIN plato p ON p.idMenu = m.id
					LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
					LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
					WHERE NOT (i.tipoAlimento = @tipoAlimento1 OR i.tipoAlimento = @tipoAlimento2) AND ISNULL(i.porcentajeAzucar,0) = 0 AND M.tipoMenu = @tipoMenuIMC AND m.status = 1;";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@tipoAlimento1", alergia1);
            command.Parameters.AddWithValue("@tipoAlimento2", alergia2);
            command.Parameters.AddWithValue("@tipoMenuIMC", imc);


            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SelectParaAlergico3ConDiabetes(string imc,string alergia1, string alergia2, string alergia3)
        {
            query = @"SELECT m.id,m.nombre, M.descripcion
                    FROM menu m
                    LEFT JOIN plato p ON p.idMenu = m.id
                    LEFT JOIN IngredientePlato inp ON inp.idPlato = p.idPlato
                    LEFT JOIN Ingrediente i ON i.idIngrediente = inp.idIngrediente
                    WHERE NOT (i.tipoAlimento = @tipoAlimento1 OR i.tipoAlimento = @tipoAlimento2 OR i.tipoAlimento = @tipoAlimento3) AND ISNULL(i.porcentajeAzucar,0) = 0
                    AND M.tipoMenu = @tipoMenuIMC AND m.status = 1;";
            SqlCommand command = CreateBasicCommand(query);


            command.Parameters.AddWithValue("@tipoAlimento1", alergia1);
            command.Parameters.AddWithValue("@tipoAlimento2", alergia2);
            command.Parameters.AddWithValue("@tipoAlimento3", alergia3);
            command.Parameters.AddWithValue("@tipoMenuIMC", imc);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectMuestraAlergiasYDiabetes(int id)
        {
            query = @"SELECT ISNULL(alergiaMariscos,0) 'Marisco',ISNULL(alergiaLacteos,0) 'Lacteo',ISNULL(alergiaFrutosSecos,0) 'Fruto Seco',ISNULL(gradoDiabetes,'Bajo') 'Diabetes'
                    FROM Person
					Where id = @id;";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable MuestraMenusSegunIMC(string imc)
        {
            query = @"SELECT P.nombre, P.descripcion
                    FROM Menu M
                    INNER JOIN Plato P ON P.idMenu= M.id
                    WHERE M.tipoMenu = @tipoMenuIMC";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@tipoMenuIMC", imc);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //SELECT id,imc from Person Where id = @id;

        
        public DataTable MuestraIMC(int id)
        {
            query = @"SELECT imc from Person Where id = @id";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


        /*
        public float MuestraIMC(int id)
        {
            float imc = 0.0f; // Valor predeterminado en caso de error.

            //using (SqlConnection connection = new SqlConnection(connectionString))

            {
                //connection.Open(); // Abre la conexión.


                
                string query = "SELECT imc FROM Person WHERE id = @id";

                SqlCommand command = CreateBasicCommand(query);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    // Ejecutar la consulta y obtener el valor IMC.
                    var result = command.ExecuteScalar();

                    

                    if (result != null && result != DBNull.Value)
                    {
                        imc = Convert.ToSingle(result);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores, como registro de excepciones.
                    // Puedes personalizar cómo manejas los errores aquí.
                }
            } // La conexión se cerrará automáticamente cuando salgas del bloque "using".

            return imc;
        }
        */





        public DataTable SelectLikeNameMenu(string name)
        {
            throw new NotImplementedException();
        }

        public int Update(MenuMio m)
        {
            query = @"UPDATE Menu SET descripcion=@descripcion, nombre=@nombre, tipoMenu=@tipoMenu
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", m.Nombre);
            command.Parameters.AddWithValue("@descripcion", m.Descripcion);
            command.Parameters.AddWithValue("@tipoMenu", m.TipoMenu);
            command.Parameters.AddWithValue("@id", m.Id);
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
