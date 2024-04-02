using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.SigI;
using Prectica_1.Models;
using ZstdSharp.Unsafe;
namespace System.Configuration;

public class RepositorioPersona
{
    readonly string ConnectionString = "Server = localhost; Port = 3306; Database = inmobiliaria; User=root;";

    public RepositorioPersona() { }

    public List<Persona> GetPersonas()
    {

        var personas = new List<Persona>();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @$"SELECT {nameof(Persona.id)}, {nameof(Persona.dni)},{nameof(Persona.apellido)},{nameof(Persona.nombre)},{nameof(Persona.telefono)},{nameof(Persona.estado)}
                FROM persona
                ORDER BY apellido";
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personas.Add(new Persona
                        {
                            id = reader.GetInt32("id"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetInt32("telefono"),
                            estado = reader.GetInt32("estado")
                        });
                    }
                }
                connection.Close();
            }
        }
        return personas;
    }

    public void GuardarPersona(Persona persona)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = $"INSERT INTO persona(dni,apellido,nombre,telefono,estado) VALUES  ('{persona.dni}','{persona.apellido}','{persona.nombre}','{persona.telefono}','{persona.estado}')";
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public Persona ObtenerPersonaPorId(int id)
    {
        var perso = new Persona();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM persona WHERE id = @Id";
            using (var comando = new MySqlCommand(sql, connection))
            {
                comando.Parameters.AddWithValue("@Id", id);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        perso = (new Persona
                        {
                            id = reader.GetInt32("id"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetInt32("telefono"),
                            estado = reader.GetInt32("estado")
                        });
                    }
                }
            }
        }
        return perso;
    }

    public void EditaDatos(Persona persona)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = $@"UPDATE persona 
             SET dni = '{persona.dni}', apellido = '{persona.apellido}', 
                 nombre = '{persona.nombre}', telefono = '{persona.telefono}', 
                 estado = '{persona.estado}'
             WHERE id = {persona.id}";
            using (var comando = new MySqlCommand(sql, connection))
            {
                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
    public Persona BuscaNuevaPersonaDNI(int dni)
    {
        var perso = new Persona();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM persona WHERE dni = @dni";

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
                            perso = (new Persona
                            {
                                id = reader.GetInt32("id"),
                                dni = reader.GetInt32("dni"),
                                apellido = reader.GetString("apellido"),
                                nombre = reader.GetString("nombre"),
                                telefono = reader.GetInt32("telefono"),
                                estado = reader.GetInt32("estado")
                            });
                        }
                        else
                        {
                            perso = (new Persona
                            {
                                id = 0,
                                dni = 99,
                                apellido = "apellido",
                                nombre = "nombre",
                                telefono = 99,
                                estado = 0
                            });
                        }

                    }
                }
            }
        }
        return perso;
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



