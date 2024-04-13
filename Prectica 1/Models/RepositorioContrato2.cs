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
//namespace System.Configuration;
namespace Prectica_1.Models;

public class RepositorioContrato2
{
    readonly string ConnectionString = "Server = localhost; Port = 3306; Database = inmotest; User=root;";

    public RepositorioContrato2() { }



    public Contrato modifiContra(Contrato contrato)
    {
        using (var connection = new MySqlConnection(ConnectionString)) 
        {

        var sql = @$"UPDATE contrato SET {nameof(Contrato.finalizacionAnticipada)} =@{nameof(Contrato.finalizacionAnticipada)},{nameof(Contrato.multa)} =@{nameof(Contrato.multa)}=@{nameof(Contrato.multa)}
            WHERE {nameof(Contrato.id_contrato)} =@{nameof(Contrato.id_contrato)}";

        using (var command = new MySqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue($"@{nameof(Contrato.id_contrato)}", contrato.id_contrato);
            command.Parameters.AddWithValue($"@{nameof(Contrato.finalizacionAnticipada)}", contrato.finalizacionAnticipada);
            command.Parameters.AddWithValue($"@{nameof(Contrato.multa)}", contrato.multa);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        }
        return new Contrato();
    }
}