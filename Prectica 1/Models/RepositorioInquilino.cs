using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic; // Make sure you have this for List<>
using Prectica_1.Models;
public class RepositorioInquilino
{
    readonly string connectionString = "Server=localhost; Port=3306; Database=inmotest; User=root;"; // Consider moving to a config file

    public RepositorioInquilino()
    {
    }
    /*
        public IList<Inquilino> GetInquilinos()
        {
            var inquilinos = new List<Inquilino>();
            using (var conexion = new MySqlConnection(connectionString))
            {
                var consulta = "SELECT * FROM inquilino";

                using (var command = new MySqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inquilinos.Add(new Inquilino
                            {
                                id = reader.GetInt32(nameof(Inquilino.id)),
                                nombre = reader.GetString(nameof(Inquilino.nombre)),
                                apellido = reader.GetString(nameof(Inquilino.apellido)),
                                dni = reader.GetString(nameof(Inquilino.dni)),
                                telefono = reader.GetString(nameof(Inquilino.telefono)),
                                email = reader.GetString(nameof(Inquilino.email))
                            });
                        }
                    }
                }
            }
            return inquilinos; // Return the list of inquilinos
        }}*/
    //forma corta
    public IList<Inquilino> GetInquilinos()
    {

        var inquilinos = new List<Inquilino>();
        using (var connection = new MySqlConnection(connectionString))
        {
            var sql = @$"SELECT {nameof(Inquilino.id_inquilino)}, {nameof(Inquilino.dni)},{nameof(Inquilino.apellido)},{nameof(Inquilino.nombre)},{nameof(Inquilino.telefono)},{nameof(Inquilino.email)},{nameof(Inquilino.estado)}
            FROM inquilino";
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inquilinos.Add(new Inquilino
                        {
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetInt32("telefono"),
                            email = reader.GetString("email"),
                            estado = reader.GetInt32("estado")
                        });
                    }
                }
            }
        }
        return inquilinos;
    }
    public void guardarInquilino(Inquilino inquilino)
    {

        using (var conecction = new MySqlConnection(connectionString))
        {
            var sql = $"INSERT INTO inquilino (dni, apellido, nombre, telefono, email, estado) VALUES ('{inquilino.dni}','{inquilino.apellido}','{inquilino.nombre}','{inquilino.telefono}','{inquilino.email}','{inquilino.estado}')";
            using (var command = new MySqlCommand(sql, conecction))
            {
                conecction.Open();
                command.ExecuteNonQuery();
                conecction.Close();
            }
        }
    }

    public Inquilino BuscaNuevoInquilinoPorDNI(int dni)
    {
        var inquilino = new Inquilino();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM inquilino WHERE dni = @dni";

            //pregunto si la consulta no vuelve vacia 
            if (!string.IsNullOrWhiteSpace(sql))
            {
                using (var comando = new MySqlCommand(sql, connection))
                {
                    comando.Parameters.AddWithValue("@dni", dni);

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            inquilino = (new Inquilino
                            {
                                id_inquilino = reader.GetInt32("id_inquilino"),
                                dni = reader.GetInt32("dni"),
                                apellido = reader.GetString("apellido"),
                                nombre = reader.GetString("nombre"),
                                telefono = reader.GetInt32("telefono"),
                                email = reader.GetString("email"),
                                estado = reader.GetInt32("estado")
                            });
                        }
                        else
                        {
                            inquilino = (new Inquilino
                            {
                                id_inquilino = 0,
                                dni = 99,
                                apellido = "apellido",
                                nombre = "nombre",
                                telefono = 99,
                                email = "email",
                                estado = 0
                            });
                        }

                    }
                }
            }
        }
        return inquilino;
    }
    public Inquilino ObtenerInquilinoPorId(int id)
    {
        var inquilino = new Inquilino();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var sql = $"SELECT * FROM inquilino WHERE id_inquilino = '{id}'";
            //var sql = "SELECT * FROM inquilino WHERE id = @Id";
            Console.WriteLine("SQL" + sql);
            using (var comando = new MySqlCommand(sql, connection))
            {
                comando.Parameters.AddWithValue("@Id", id);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inquilino = (new Inquilino
                        {
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetInt32("telefono"),
                            email = reader.GetString("email"),
                            estado = reader.GetInt32("estado")
                        });
                    }
                }
            }

        }
        return inquilino;
    }

    public void EditaDatos(Inquilino inquilino)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            var sql = $@"UPDATE inquilino 
             SET dni = '{inquilino.dni}', apellido = '{inquilino.apellido}', 
                 nombre = '{inquilino.nombre}', telefono = '{inquilino.telefono}', 
                 email = '{inquilino.email}'
             WHERE id_inquilino = {inquilino.id_inquilino}";
            using (var comando = new MySqlCommand(sql, connection))
            {
                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
    public void eliminarInquilino(Inquilino inquilino){
    using (var connection = new MySqlConnection(connectionString))
    {
        var sql = $@"UPDATE inquilino 
                 SET dni = '{inquilino.dni}', apellido = '{inquilino.apellido}', 
                     nombre = '{inquilino.nombre}', telefono = '{inquilino.telefono}', 
                     email = '{inquilino.email}',
                     estado = '{inquilino.estado}' 
                 WHERE id_inquilino = {inquilino.id_inquilino}";
        using (var comando = new MySqlCommand(sql, connection))
        {
            connection.Open();
            comando.ExecuteNonQuery();
            connection.Close();
        }
    }
}

    public IList<Inquilino> InquilinosAptos()
    {
        var inquilinos = new List<Inquilino>();
        using (var connection = new MySqlConnection(connectionString))
        {
            var sql = @$"SELECT {nameof(Inquilino.id_inquilino)}, {nameof(Inquilino.dni)}, {nameof(Inquilino.apellido)}, {nameof(Inquilino.nombre)}, {nameof(Inquilino.telefono)}, {nameof(Inquilino.email)}, {nameof(Inquilino.estado)}
            FROM inquilino
            WHERE {nameof(Inquilino.estado)} = 1
            ORDER BY {nameof(Inquilino.apellido)}"; // 1=Activo
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inquilinos.Add(new Inquilino
                        {
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetInt32("telefono"),
                            email = reader.GetString("email"),
                            estado = reader.GetInt32("estado")
                        });
                    }
                }
            }
        }
        return inquilinos;
    }

}







