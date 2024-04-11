using MySql.Data.MySqlClient;
using Prectica_1.Models;
using ZstdSharp.Unsafe;
namespace System.Configuration;
public class RepositorioUsuario
{
   readonly string connectionString = "Server=localhost; Port=3306; Database=inmotest; User=root;";
   public void guardarUsuario(Usuario usuario){
        using (var conecction = new MySqlConnection(connectionString))
        {
            var sql = $"INSERT INTO usuarios (Nombre, Apellido, Email, Clave, Rol) VALUES ('{usuario.Nombre}','{usuario.Apellido}','{usuario.Email}','{usuario.Clave}','{usuario.Rol}')";
            using (var command = new MySqlCommand(sql, conecction))
            {
                conecction.Open();
                command.ExecuteNonQuery();
                conecction.Close();
            }
        }
   }


       public Usuario ObtenerPorEmail(string email) 
    {
        var Usuario = new Usuario();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var sql = $"SELECT * FROM usuarios WHERE Email = '{email}'";
            //var sql = "SELECT * FROM inquilino WHERE id = @Id";
            Console.WriteLine("SQL" + sql);
            using (var comando = new MySqlCommand(sql, connection))
            {
                comando.Parameters.AddWithValue("@Email", email);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Usuario = (new Usuario
                        {
                            Id = reader.GetInt32("Id"),
                            Apellido = reader.GetString("Apellido"),
                            Nombre = reader.GetString("Nombre"),
                            Email = reader.GetString("Email"),
                            Clave = reader.GetString("Clave")
                        });
                    }
                }
            }

        }
        return Usuario;
    }




}
