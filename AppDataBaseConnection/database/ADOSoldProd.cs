using AppDataBaseConnection.modelo;
using FinalProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseConnection.database
{
    public static class ADOSoldProd
    {
        public static SoldProduct GetSoldProduct(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from ProductoVendido where Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idRegister = Convert.ToInt32(reader[0]);
                    int stock = Convert.ToInt32(reader[1]);
                    int idProduct = Convert.ToInt32(reader[2]);
                    int idSale = Convert.ToInt32(reader[3]);
                    
                    SoldProduct soldProduct = new SoldProduct( stock,idProduct,idSale);

                    return soldProduct;
                }
            }
            throw new Exception("Id No encontrado");         
        }

        public static List<Product> getProductSoldList()
        {
            List<SoldProduct> listProductSold = new List<SoldProduct>();

            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from ProductoVendido";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {

                            int idRegister = Convert.ToInt32(dataReader[0]);
                            int stock = Convert.ToInt32(dataReader[1]);
                            int idProduct = Convert.ToInt32(dataReader[2]);
                            int idSale = Convert.ToInt32(dataReader[3]);

                            SoldProduct soldProduct = new SoldProduct(stock, idProduct, idSale);

                            listProductSold.Add(soldProduct);
                        }
                    }

                }
            }
            throw new Exception("Id No encontrado");
        }

        public static bool InsertSoldProduct(SoldProduct soldProduct)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO ProductoVendido  (Id,Stock,IdProducto,IdVenta) values (@id,@stock,@idProduct,@idSale); select @@IDENTITY as ID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", soldProduct.Id);
                command.Parameters.AddWithValue("stock", soldProduct.stock);
                command.Parameters.AddWithValue("idProduct", soldProduct.idProduct);
                command.Parameters.AddWithValue("idSale", soldProduct.idSale);
    

                connection.Open();

                //ExecuteNonQuery retornara un entero indicando el numero de filas afectadas.
                //El metodo InsertUser retornara un bool false o true si dependiendo si hubo cambios en la tabla
                return command.ExecuteNonQuery() > 0;


            }
        }

        public static bool DeleteSoldProduct(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM ProductoVendido where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateSoldProduct(int id, SoldProduct soldProduct)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "UPDATE ProductoVendido SET Stock = @stock, IdProducto=@idProduct, IdVenta=@idSale where id= @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("stock", soldProduct.stock);
                command.Parameters.AddWithValue("idProduct", soldProduct.idProduct);
                command.Parameters.AddWithValue("idSale", soldProduct.idSale);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateDescriptionSoldProduct(int id, int stoc)
        {
            throw new NotImplementedException("Metodo no implementado");
        }



    }
}
