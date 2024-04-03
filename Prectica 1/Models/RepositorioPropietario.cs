using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.SigI;
using Prectica_1.Models;
using ZstdSharp.Unsafe;
namespace System.Configuration;

public class RepositorioPropietario
{
    readonly string ConnectionString = "Server = localhost; Port = 3306; Database = inmotest; User=root;";

    public RepositorioPropietario() { }

    public List<Propietario> GetPropietario()
    {

        var propietario = new List<Propietario>();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @$"SELECT {nameof(Propietario.id_propietario)}, {nameof(Propietario.dni)},{nameof(Propietario.apellido)},{nameof(Propietario.nombre)},{nameof(Propietario.telefono)},{nameof(Propietario.email)},{nameof(Propietario.estado)}
                FROM propietario
                 WHERE {nameof(Propietario.estado)} = 1
             ORDER BY {nameof(Propietario.apellido)}";
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        propietario.Add(new Propietario
                        {
                            id_propietario = reader.GetInt32("id_propietario"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetInt32("telefono"),
                            email = reader.GetString("email"),
                            estado = reader.GetInt32("estado")
                        });
                    }
                }
                connection.Close();
            }
        }
        return propietario;
    }

    public void GuardarPropietario(Propietario propietario)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = $"INSERT INTO propietario(dni,apellido,nombre,telefono,email,estado) VALUES  ('{propietario.dni}','{propietario.apellido}','{propietario.nombre}','{propietario.telefono}','{propietario.email}','{propietario.estado}')";
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public Propietario ObtenerPropietarioPorId(int id)
    {
        var prop = new Propietario();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM propietario WHERE id_propietario = @Id";
            using (var comando = new MySqlCommand(sql, connection))
            {
                comando.Parameters.AddWithValue("@Id", id);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        prop = (new Propietario
                        {
                            id_propietario = reader.GetInt32("id_propietario"),
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
        return prop;
    }

    public void EditaDatos(Propietario propietario)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = $@"UPDATE propietario 
             SET dni = '{propietario.dni}', apellido = '{propietario.apellido}', 
                 nombre = '{propietario.nombre}', telefono = '{propietario.telefono}', 
                 email = '{propietario.email}',estado = '{propietario.estado}'
             WHERE id_propietario = {propietario.id_propietario}";
            using (var comando = new MySqlCommand(sql, connection))
            {
                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
    public Propietario BuscaNuevaPropietarioDNI(int dni)
    {
        var propi = new Propietario();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM propietario WHERE dni = @dni";

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
                            propi = (new Propietario
                            {
                                id_propietario = reader.GetInt32("id_propietario"),
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
                            propi = (new Propietario
                            {
                                id_propietario = 0,
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
        return propi;
    }

    public List<Propietario> PropietarioMuestra()
    {

        var propietario = new List<Propietario>();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @$"SELECT {nameof(Propietario.id_propietario)}, {nameof(Propietario.dni)},{nameof(Propietario.apellido)},{nameof(Propietario.nombre)},{nameof(Propietario.telefono)},{nameof(Propietario.email)},{nameof(Propietario.estado)}
                 FROM propietario
                WHERE {nameof(Propietario.estado)} = 1
             ORDER BY {nameof(Propietario.apellido)}";
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        propietario.Add(new Propietario
                        {
                            id_propietario = reader.GetInt32("id_propietario"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetInt32("telefono"),
                            email = reader.GetString("email"),
                            estado = reader.GetInt32("estado")
                        });
                    }
                }
                connection.Close();
            }
        }
        return propietario;
    }

}













































// public int GuardarInquilino(Inquilino inquilino)
// {
//     int id = 0;
//     using (var connection = new MySqlConnection(ConnectionString))
//     {

//         var sql = @$"INSRT INTO inqulino({nameof(Inquilino.dni)},{nameof(Inquilino.apellido)},{nameof(Inquilino.nombre)},{nameof(Inquilino.telefono)},{nameof(Inquilino.estado)})
//     VALUES(@{nameof(Inquilino.dni)},@{nameof(Inquilino.apellido)},@{nameof(Inquilino.nombre)},@{nameof(Inquilino.telefono)},{nameof(Inquilino.estado)});
//     SelectionTypes LAST_INSERT_ID();";
//     }
//     using(var command = new MySqlCommand(sql, connection))
//     {
//         command.Parameters.AddWithValue($"@{nameof(Inquilino.dni)}",inquilino.dni);
//         command.Parameters.AddWithValue($"@{nameof(Inquilino.apellido)}",inquilino.apellido);
//         command.Parameters.AddWithValue($"@{nameof(Inquilino.nombre)}",inquilino.nombre);
//         command.Parameters.AddWithValue($"@{nameof(Inquilino.telefono)}",inquilino.telefono);
//         command.Parameters.AddWithValue($"@{nameof(Inquilino.estado)}",inquilino.estado);
//         connection.Open();
//         id= Convert.ToInt32(command.ExecuteScalar());
//         inquilino.id = id; 
//         Connection.Close();

//     }
//     return id;
// }



