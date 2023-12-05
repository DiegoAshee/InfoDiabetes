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
    public class PlatoImpl : BaseImpl
    {

        public int Delete(Plato p)
        {
            query = @"UPDATE Plato SET status=0
                      WHERE idPlato=@id";
            SqlCommand command = CreateBasicCommand(query);
            //command.Parameters.AddWithValue("@userID", 1);
            command.Parameters.AddWithValue("@id", p.Id);
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
            query = @"UPDATE Plato SET status=0
                      WHERE idPlato=@id";
            SqlCommand command = CreateBasicCommand(query);
            //command.Parameters.AddWithValue("@userID", 1);
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

        public Plato Get(int id)
        {
            Plato p = null;
            query = @"SELECT idPlato,nombre ,descripcion, status, idMenu
                      FROM Plato
                      WHERE idPlato=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    p = new Plato(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), byte.Parse(table.Rows[0][3].ToString()));

                }
                return p;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int Insert(Plato t)
        {
            query = @"INSERT INTO Plato(nombre,descripcion,idMenu)
                      VALUES(@nombre,@descripcion,@menuID)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@menuID", t.MenuID);

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
            /*query = @"SELECT id,description AS 'Nombre del Producto',price AS Precio,size AS Talle
                      FROM Product
                      WHERE status=1
                      ORDER BY 2";*/
            /*query = @"SELECT P.id,P.description AS 'Producto',P.price AS Precio,P.size AS Talle, B.name AS Marca,c.name AS Categoria
                      FROM Product P
					  INNER JOIN Brand B ON P.brandID=B.id 
					  INNER JOIN Category C ON P.categoryID=B.id
                      WHERE P.status=1
                      ORDER BY 2";*/
            query = @"SELECT P.idPlato, P.nombre AS 'Nombre',P.descripcion AS 'Descripcion',M.Nombre as 'Nombre del Menu'
                      FROM Plato P
                      INNER JOIN Menu M ON M.id=P.idMenu
                      WHERE p.status=1";
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




        public DataTable SelectIngredientes(int id)
        {
            query = @"SELECT m.nombre AS nombre_menu, p.nombre AS nombre_plato, ISNULL(i.nombre,'') AS nombre_ingrediente
                                   FROM menu m
                                   LEFT JOIN plato p ON p.idMenu = m.id
                                   LEFT JOIN IngredientePlato ip ON ip.idPlato = p.idPlato
                                   LEFT JOIN Ingrediente i ON i.idIngrediente = ip.idIngrediente
                                   WHERE m.status = 1 AND i.nombre<> '' AND m.id=@id;";
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




        public DataTable SelectPlatosSeleccionado(int id)
        {
            query = @"SELECT P.idPlato,P.nombre 'Nombre', P.descripcion 'Descripcion'
                    FROM Plato P
                    INNER JOIN Menu M ON M.id=P.idMenu
                    WHERE M.id=@id AND M.status = 1;";
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


        public DataTable SelectIngredientesSeleccionado(int id)
        {
            query = @"SELECT I.idIngrediente,I.nombre 'Nombre', I.tipoAlimento 'Tipo de Alimento',I.energia 'Calorias',
                    I.proteina 'Proteina',I.grasa 'Grasa',I.porcentajeAzucar 'Porcentaje de Azucar'
                    FROM Plato P
                    INNER JOIN IngredientePlato Ipl ON Ipl.idPlato=P.idPlato
                    INNER JOIN Ingrediente I ON I.idIngrediente=Ipl.idIngrediente
                    WHERE P.idPlato=@id";
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

        public DataTable SelectLikeNamePlato(string name)
        {
            throw new NotImplementedException();
        }

        public int Update(Plato t)
        {
            query = @"UPDATE Plato SET nombre=@nombre, descripcion=@descripcion, idMenu=@menuID
                      WHERE idPlato=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@menuID", t.MenuID);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ComboBox()
        {
            query = @" SELECT id,nombre
                       FROM Menu
                       WHERE status=1";
            SqlCommand command = CreateBasicCommand(query);
            //command.Parameters.AddWithValue("@name", t.NameBrand);
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
        public DataTable SelectBrand(byte idBrand)
        {
            DataTable res = new DataTable();
            query = @" SELECT id,name
                       FROM Brand
                       WHERE status=1 AND id=@id
                       ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", idBrand);
            try
            {
                
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/



    }
}
