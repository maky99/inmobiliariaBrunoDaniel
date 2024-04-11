
using MySql.Data.MySqlClient;
using Prectica_1.Models;

namespace System.Configuration;

public class RepositorioPago
{
    readonly string ConnectionString = "Server = localhost; Port = 3306; Database = inmotest; User=root;";

    public RepositorioPago() { }

public List<Pago> GetPagos()
{
    var pagos = new List<Pago>();
    using (var connection = new MySqlConnection(ConnectionString))
    {
        var sql = @"SELECT id_pago, concepto, importe, fecha, estado, id_contrato
                    FROM pago
                    ORDER BY fecha DESC"; // Ordenar los pagos por fecha descendente
        using (var command = new MySqlCommand(sql, connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var pago = new Pago
                    {
                        id_pago = reader.GetInt32("id_pago"),
                        concepto = reader.IsDBNull(reader.GetOrdinal("concepto")) ? null : reader.GetString("concepto"),
                        importe = reader.GetDouble("importe"),
                        fecha = reader.GetDateTime("fecha"),
                        estado = reader.GetInt32("estado"),
                        id_contrato = reader.GetInt32("id_contrato")
                    };
                    pagos.Add(pago);
                }
            }
            connection.Close();
        }
    }
    return pagos;
}



}