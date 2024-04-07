
using MySql.Data.MySqlClient;
using Prectica_1.Models;

namespace System.Configuration;

public class RepositorioContraro
{
    readonly string ConnectionString = "Server = localhost; Port = 3306; Database = inmotest; User=root;";

    public RepositorioContraro() { }

public List<Contrato> GetContratos()
{
    var contratos = new List<Contrato>();
  
    using (var connection = new MySqlConnection(ConnectionString))
    {
        var sql = @"SELECT c.id_contrato, c.id_inquilino, c.id_inmueble, c.desde, c.meses, c.hasta, c.detalle, c.monto, c.estado,
                           i.apellido AS inquilino_apellido, i.nombre AS inquilino_nombre,
                           im.direccion AS direccion_inmueble,
                           p.apellido AS propietario_apellido, p.nombre AS propietario_nombre
                    FROM contrato c
                    INNER JOIN inquilino i ON c.id_inquilino = i.id_inquilino
                    INNER JOIN inmueble im ON c.id_inmueble = im.id_inmueble
                    INNER JOIN propietario p ON im.id_propietario = p.id_propietario";

        using (var command = new MySqlCommand(sql, connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    contratos.Add(new Contrato
                    {
                        id_contrato = reader.GetInt32("id_contrato"),
                        id_inquilino = reader.GetInt32("id_inquilino"),
                        id_inmueble = reader.GetInt32("id_inmueble"),
                        desde = reader.GetDateTime("desde"),
                        meses = reader.GetInt32("meses"),
                        hasta = reader.GetDateTime("hasta"),
                        detalle = reader.GetString("detalle"),
                        monto = reader.GetDouble("monto"),
                        estado = reader.GetInt32("estado"),
                        inquilino = new Inquilino
                        {
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            apellido = reader.GetString("inquilino_apellido"),
                            nombre = reader.GetString("inquilino_nombre")
                        },
                        inmueble = new Inmueble
                        {
                            id_inmueble = reader.GetInt32("id_inmueble"),
                            direccion = reader.GetString("direccion_inmueble"),
                            dueno = new Propietario
                            {
                                apellido = reader.GetString("propietario_apellido"),
                                nombre = reader.GetString("propietario_nombre")
                            }
                        }
                    });
                }
            }
            connection.Close();
        }
    }
    return contratos;
}

    public void GuardarContrato(Contrato contrato)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = $"INSERT INTO contrato(id_inquilino, id_inmueble, desde, meses, hasta, detalle, monto, estado) VALUES (@id_inquilino, @id_inmueble, @desde, @meses, @hasta, @detalle, @monto, @estado)";
            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id_inquilino", contrato.id_inquilino);
                command.Parameters.AddWithValue("@id_inmueble", contrato.id_inmueble);
                command.Parameters.AddWithValue("@desde", contrato.desde);
                command.Parameters.AddWithValue("@meses", contrato.meses);
                command.Parameters.AddWithValue("@hasta", contrato.hasta);
                command.Parameters.AddWithValue("@detalle", contrato.detalle);
                command.Parameters.AddWithValue("@monto", contrato.monto);
                command.Parameters.AddWithValue("@estado", contrato.estado);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }


}