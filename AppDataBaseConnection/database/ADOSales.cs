using AppDataBaseConnection.modelo;
using FinalProject;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseConnection.database
{
    public static class ADOSales
    {

        public static Sales GetSalesforId(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from Venta where Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idSales = Convert.ToInt32(reader[0]);
                    string comments = reader.GetString(1);
                    int idUser = Convert.ToInt32(reader[2]);

                    Sales sales = new Sales(idSales,comments, idUser);  

                    return sales;
                }
            }
            throw new Exception("Id No encontrado");
        }

        public static List<Sales> getSalesList()
        {
            List<Sales> listSale = new List<Sales>();

            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from Venta";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {

                            int idSales = Convert.ToInt32(dataReader[0]);
                            string comments = dataReader.GetString(1);
                            int idUser = Convert.ToInt32(dataReader[2]);

                            var sales = new Sales(idSales, comments, idUser);


                            listSale.Add(sales);
                        }
                    }

                }
            }
            throw new Exception("Id No encontrado");
        }

        public static bool InsertSale(Sales sale)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            string query = "INSERT INTO Venta values (Comentario,IdUsuario) values (@Comment,@idUser); select @@IDENTITY as ID";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Comment", sale.Comments);
                    command.Parameters.AddWithValue("idUser", sale.IdUsuario);
                          

                    //ExecuteNonQuery retornara un entero indicando el numero de filas afectadas.
                    //El metodo InsertUser retornara un bool false o true si dependiendo si hubo cambios en la tabla
                    return command.ExecuteNonQuery() > 0;
                }

            }
        }

        public static bool DeleteSale(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Venta where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateSale(int id, Sales sale)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "UPDATE Venta SET Comentarios = @comments, IdUsuario=@idUser where id= @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("comments", sale.Comments);            
                command.Parameters.AddWithValue("idUser", sale.IdUsuario);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public static bool UpdateCommentsSales(int id, string commets)
        {
            throw new NotImplementedException("Metodo no implementado");
        }
    }
}
