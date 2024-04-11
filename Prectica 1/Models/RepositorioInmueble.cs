using System.Collections;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Razor;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.SigI;
using Prectica_1.Models;
using ZstdSharp.Unsafe;
namespace System.Configuration;

public class RepositorioInmueble
{
    readonly string ConnectionString = "Server = localhost; Port = 3306; Database = inmotest; User=root;";

    public RepositorioInmueble() { }

    public List<Inmueble> GetInmueble()
    {

        var inmueble = new List<Inmueble>();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @$"SELECT i.{nameof(Inmueble.id_inmueble)}, i.{nameof(Inmueble.tipoDebien)}, i.{nameof(Inmueble.tipoDeUso)}, i.{nameof(Inmueble.direccion)}, i.{nameof(Inmueble.condicion)}, i.{nameof(Inmueble.costo)}, i.{nameof(Inmueble.ambiente)}, i.{nameof(Inmueble.estado)}, i.{nameof(Inmueble.id_propietario)},
                     p.apellido AS propietario_apellido, p.nombre AS propietario_nombre
                    FROM inmueble i
                    INNER JOIN propietario p ON i.{nameof(Inmueble.id_propietario)} = p.{nameof(Propietario.id_propietario)}";


            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inmueble.Add(new Inmueble
                        {
                            id_inmueble = reader.GetInt32("id_inmueble"),
                            tipoDebien = reader.GetString("tipoDebien"),
                            tipoDeUso = reader.GetString("tipoDeUso"),
                            direccion = reader.GetString("direccion"),
                            condicion = reader.GetString("condicion"),
                            costo = reader.GetDouble("costo"),
                            ambiente = reader.GetInt32("ambiente"),
                            estado = reader.GetInt32("estado"),
                            id_propietario = reader.GetInt32("id_propietario"),
                            dueno = new Propietario
                            {
                                id_propietario = reader.GetInt32("id_propietario"),
                                apellido = reader.GetString("propietario_apellido"),
                                nombre = reader.GetString("propietario_nombre")

                            }
                        });
                    }
                }
                connection.Close();
            }
        }
        return inmueble;
    }

    public void GuardarInmueble(Inmueble inmueble)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = $"INSERT INTO inmueble(tipoDebien, tipoDeUso, direccion, condicion, costo, ambiente, estado, id_propietario) VALUES (@tipoDebien, @tipoDeUso, @direccion, @condicion, @costo, @ambiente, @estado, @id_propietario)";
            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@tipoDebien", inmueble.tipoDebien);
                command.Parameters.AddWithValue("@tipoDeUso", inmueble.tipoDeUso);
                command.Parameters.AddWithValue("@direccion", inmueble.direccion);
                command.Parameters.AddWithValue("@condicion", inmueble.condicion);
                command.Parameters.AddWithValue("@costo", inmueble.costo);
                command.Parameters.AddWithValue("@ambiente", inmueble.ambiente);
                command.Parameters.AddWithValue("@estado", inmueble.estado);
                command.Parameters.AddWithValue("@id_propietario", inmueble.id_propietario);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
    // public void GuardarsInmueble(Inmueble inmueble)
    // {
    //     using (var connection = new MySqlConnection(ConnectionString))
    //     {
    //         var sql = $"INSERT INTO inmueble(tipoDebien,tipoDeUso,direccion,condicion,costo,detalle,estado,id_propietario) VALUES  ('{inmueble.tipoDebien}','{inmueble.tipoDeUso}','{inmueble.direccion}','{inmueble.condicion}','{inmueble.costo}','{inmueble.detalle}','{inmueble.estado}','{inmueble.id_propietario}')";
    //         using (var command = new MySqlCommand(sql, connection))
    //         {
    //             connection.Open();
    //             command.ExecuteNonQuery();
    //             connection.Close();
    //         }
    //     }
    // }

    public Inmueble ObtenerInmueblePorId(int id)
    {
        var inmu = new Inmueble();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var sql = @$"SELECT i.{nameof(Inmueble.id_inmueble)}, i.{nameof(Inmueble.tipoDebien)}, i.{nameof(Inmueble.tipoDeUso)}, i.{nameof(Inmueble.direccion)}, i.{nameof(Inmueble.condicion)}, i.{nameof(Inmueble.costo)}, i.{nameof(Inmueble.ambiente)}, i.{nameof(Inmueble.estado)}, i.{nameof(Inmueble.id_propietario)},
                     p.apellido AS propietario_apellido, p.nombre AS propietario_nombre
                    FROM inmueble i
                    INNER JOIN propietario p ON i.{nameof(Inmueble.id_propietario)} = p.{nameof(Propietario.id_propietario)}
                    WHERE i.{nameof(Inmueble.id_inmueble)} = @Id";
            using (var comando = new MySqlCommand(sql, connection))
            {
                comando.Parameters.AddWithValue("@Id", id);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inmu = new Inmueble
                        {
                            id_inmueble = reader.GetInt32("id_inmueble"),
                            tipoDebien = reader.GetString("tipoDebien"),
                            tipoDeUso = reader.GetString("tipoDeUso"),
                            direccion = reader.GetString("direccion"),
                            condicion = reader.GetString("condicion"),
                            costo = reader.GetDouble("costo"),
                            ambiente = reader.GetInt32("ambiente"),
                            estado = reader.GetInt32("estado"),
                            id_propietario = reader.GetInt32("id_propietario"),
                            dueno = new Propietario
                            {
                                id_propietario = reader.GetInt32("id_propietario"),
                                apellido = reader.GetString("propietario_apellido"),
                                nombre = reader.GetString("propietario_nombre")
                            }
                        };
                    }
                }
            }
        }
        return inmu;
    }

    public void EditaDatosInmueble(Inmueble inmueble)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            Console.WriteLine($"SQL query: {inmueble.id_inmueble}");
            var sql = $@"UPDATE inmueble
             SET tipoDebien = '{inmueble.tipoDebien}', tipoDeUso = '{inmueble.tipoDeUso}',
                direccion = '{inmueble.direccion}', condicion = '{inmueble.condicion}', 
                costo = '{inmueble.costo}', ambiente = '{inmueble.ambiente}', estado = '{inmueble.estado}',
                id_propietario='{inmueble.id_propietario}'   
             WHERE id_inmueble = {inmueble.id_inmueble} ";
            using (var comando = new MySqlCommand(sql, connection))
            {
                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

    }

    public void EliminarInmueblePorId(int id)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = "DELETE FROM inmueble WHERE id_inmueble = @Id";
            using (var comando = new MySqlCommand(sql, connection))
            {
                comando.Parameters.AddWithValue("@Id", id); // Agregar el parámetro @Id y asignarle el valor id
                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
public List<Inmueble> InmuebleLibre()
{
    var inmueble = new List<Inmueble>();
    using (var connection = new MySqlConnection(ConnectionString))
    {
        var sql = @$"SELECT i.{nameof(Inmueble.id_inmueble)}, i.{nameof(Inmueble.tipoDebien)}, i.{nameof(Inmueble.tipoDeUso)}, i.{nameof(Inmueble.direccion)}, i.{nameof(Inmueble.condicion)}, i.{nameof(Inmueble.costo)}, i.{nameof(Inmueble.ambiente)}, i.{nameof(Inmueble.estado)}, i.{nameof(Inmueble.id_propietario)},
                     p.apellido AS propietario_apellido, p.nombre AS propietario_nombre
                    FROM inmueble i
                    INNER JOIN propietario p ON i.{nameof(Inmueble.id_propietario)} = p.{nameof(Propietario.id_propietario)}
                    WHERE i.{nameof(Inmueble.estado)} = 0";

        using (var command = new MySqlCommand(sql, connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    inmueble.Add(new Inmueble
                    {
                        id_inmueble = reader.GetInt32("id_inmueble"),
                        tipoDebien = reader.GetString("tipoDebien"),
                        tipoDeUso = reader.GetString("tipoDeUso"),
                        direccion = reader.GetString("direccion"),
                        condicion = reader.GetString("condicion"),
                        costo = reader.GetDouble("costo"),
                        ambiente = reader.GetInt32("ambiente"),
                        estado = reader.GetInt32("estado"),
                        id_propietario = reader.GetInt32("id_propietario"),
                        dueno = new Propietario
                        {
                            id_propietario = reader.GetInt32("id_propietario"),
                            apellido = reader.GetString("propietario_apellido"),
                            nombre = reader.GetString("propietario_nombre")

                        }
                    });
                }
            }
            connection.Close();
        }
    }
    return inmueble;
}



}