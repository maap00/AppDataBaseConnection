using AppDataBaseConnection.modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseConnection.database
{
    public static class ADOUser
    {       

        public static User GetUserForId(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from Usuario where id = @id";
                
                SqlCommand command =  new SqlCommand(query, connection);

                //AddWithValue se bindea un parametro a un nombre string
                command.Parameters.AddWithValue("id", id);

                connection.Open();  

                SqlDataReader reader = command.ExecuteReader();
                
                //reader.Read() devuelve un booleano si ha podido encontrar algun registro
                if(reader.Read())
                {
                    int idUser = Convert.ToInt32(reader[0]);
                    string name = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string userName = reader.GetString(3);
                    string password = reader.GetString(4);
                    string mail = reader.GetString(5);

                    User user = new User(id,name, lastName,userName,password, mail);

                    return user;
                }

            }
            throw new Exception("Id No encontrado");
        }

      

        public static  User GetAllUserList()
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "Select * from Usuario";

                SqlCommand command = new SqlCommand(query, connection);

                List<User> usersList = new List<User>();
                connection.Open();  
                
                Form1 form = new Form1();   

                using(SqlDataReader dataReader = command.ExecuteReader()) {
                    if(dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            
                            int idUser = Convert.ToInt32(dataReader[0]);
                            string name = dataReader.GetString(1);
                            string lastName = dataReader.GetString(2);
                            string userName = dataReader.GetString(3);
                            string password = dataReader.GetString(4);
                            string mail = dataReader.GetString(5);

                            var user = new User(idUser,name,lastName,userName,password,mail);

                            usersList.Add(user);                        


                        }
                    }
                             
                }
            }
            throw new Exception("Id No encontrado");
        }


        public static bool InsertUser(User user)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) values (@nombre,@apellido,@nombreUsuario,@password,@email); select @@IDENTITY as ID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("nombre", user.name);
                command.Parameters.AddWithValue("apellido", user.lastName);
                command.Parameters.AddWithValue("nombreUsuario", user.userName);
                command.Parameters.AddWithValue("password", user.password);
                command.Parameters.AddWithValue("email", user.email);
                
                connection.Open();

                //ExecuteNonQuery retornara un entero indicando el numero de filas afectadas.
                //El metodo InsertUser retornara un bool false o true si dependiendo si hubo cambios en la tabla
                return command.ExecuteNonQuery() > 0;


            }
        }

        public static bool DeleteUser(int id)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";

            using (SqlConnection connection=new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Usuario where id = @id";

                SqlCommand command= new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static  bool UpdateUser(int id, User user)
        {
            string stringConnection = @"Server=localhost\SQLEXPRESS;Database=CoderHouse;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido=@apellido, NombreUsuario=@nombreUsuario, Contraseña=@password, Mail=@email where id= @id";
               
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("nombre", user.name);
                command.Parameters.AddWithValue("apellido", user.lastName);
                command.Parameters.AddWithValue("nombreUsuario", user.userName);
                command.Parameters.AddWithValue("password", user.password);
                command.Parameters.AddWithValue("email", user.email);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public static bool UpdateLastName(int id, string apellido)
        {
            throw new NotImplementedException("Metodo no implementado");
        }


    }
}
