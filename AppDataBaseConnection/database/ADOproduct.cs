using AppDataBaseConnection.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseConnection.database
{
    public static class ADOproduct
    {
        public static Product GetProductforId(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from Producto where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);  
               
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    int idProduct = Convert.ToInt32(reader[0]);
                    string description = reader.GetString(1);
                    double price = Convert.ToDouble(reader[2]);
                    double priceSale = Convert.ToDouble(reader[3]);
                    double stock = Convert.ToDouble(reader[4]);
                    int idUser = Convert.ToInt32(reader[5]);


                    Product product = new Product(idProduct, description, price, priceSale, stock,id) ;
                    return product;
                }
            }
            throw new Exception("Id No encontrado");
        }

        public static List<Product> getProductList()
        {
            List<Product> listProduct = new List<Product>();
            
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from Producto";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();         

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {

                            int idProduct = Convert.ToInt32(dataReader[0]);
                            string description = dataReader.GetString(1);
                            double price = Convert.ToDouble(dataReader[2]);
                            double priceSale = Convert.ToDouble(dataReader[3]);
                            double stock = Convert.ToDouble(dataReader[4]);
                            int idUser = Convert.ToInt32(dataReader[5]);

                            var product = new Product(idProduct, description, price, priceSale, stock, idUser);

                            listProduct.Add(product);
                        }
                    }

                }
            }
            throw new Exception("Id No encontrado");
        }

        public static bool InsertProduct(Product product)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            string query = "INSERT INTO Producto values (Descripciones,Costo,PrecioVenta,Stock, IdUsuario) values (@description,@price,@priceSale,@stock,@idUser); select @@IDENTITY as ID";
           
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("description", SqlDbType.VarChar) { Value = product.decriptionProduct });
                    command.Parameters.Add(new SqlParameter("price",SqlDbType.Money) { Value = product.priceProduct });
                    command.Parameters.Add(new SqlParameter("priceSale", SqlDbType.Money) { Value = product.priceSale });
                    command.Parameters.Add(new SqlParameter("stock", SqlDbType.Int) { Value = product.stock});
                    command.Parameters.Add(new SqlParameter("idUser",SqlDbType.Int) { Value = product.idUser });
               
                    
                    
                //ExecuteNonQuery retornara un entero indicando el numero de filas afectadas.
                //El metodo InsertUser retornara un bool false o true si dependiendo si hubo cambios en la tabla
                    return command.ExecuteNonQuery() > 0;
                } 

            }
        }

        public static bool DeleteProduct(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Producto where id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateProduct(int id, Product product)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "UPDATE Producto SET Descripciones = @description, Costo=@price, PrecioVenta=@priceSale, Stock=@stock, idUser=@idUser where id= @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("description", product.decriptionProduct);
                command.Parameters.AddWithValue("price", product.priceProduct);
                command.Parameters.AddWithValue("priceSale", product.priceSale);
                command.Parameters.AddWithValue("stock", product.stock);
                command.Parameters.AddWithValue("idUser", product.idUser);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public static bool UpdateDescriptionProduct(int id, string decriptionProduct)
        {
            throw new NotImplementedException("Metodo no implementado");
        }
    }
}
