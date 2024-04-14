
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
                    ORDER BY fecha DESC";
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

    public List<Contrato> GetContratosVigentes()
    {
        var contratosVigentes = new List<Contrato>();

        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @"SELECT 
                    c.id_contrato, c.id_inquilino, c.id_inmueble, c.desde, c.meses, c.hasta, c.detalle, c.finalizacionAnticipada, c.monto, c.multa, c.estado,
                    i.apellido AS inquilino_apellido, i.nombre AS inquilino_nombre,
                    im.direccion AS direccion_inmueble,
                    p.apellido AS propietario_apellido, p.nombre AS propietario_nombre,
                    COUNT(pg.id_pago) AS cantidad_pagos,
                    SUM(pg.importe) AS importe_pagos
                FROM contrato c
                INNER JOIN inquilino i ON c.id_inquilino = i.id_inquilino
                INNER JOIN inmueble im ON c.id_inmueble = im.id_inmueble
                INNER JOIN propietario p ON im.id_propietario = p.id_propietario
                LEFT JOIN pago pg ON c.id_contrato = pg.id_contrato
                WHERE c.estado = 0
                GROUP BY 
                    c.id_contrato, c.id_inquilino, c.id_inmueble, c.desde, c.meses, c.hasta, c.detalle, c.monto, c.estado,
                    i.apellido, i.nombre,
                    im.direccion,
                    p.apellido, p.nombre";

            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contratosVigentes.Add(new Contrato
                        {
                            id_contrato = reader.GetInt32("id_contrato"),
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            id_inmueble = reader.GetInt32("id_inmueble"),
                            desde = reader.GetDateTime("desde"),
                            meses = reader.GetInt32("meses"),
                            hasta = reader.GetDateTime("hasta"),
                            detalle = reader.GetString("detalle"),
                            finalizacionAnticipada = !reader.IsDBNull(reader.GetOrdinal("finalizacionAnticipada")) ? reader.GetDateTime("finalizacionAnticipada") : default(DateTime),
                            multa = !reader.IsDBNull(reader.GetOrdinal("multa")) ? reader.GetDouble("multa") : 0.0,
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
                            },
                            pago = new Pago
                            {
                                cantidad_pagos = reader.IsDBNull(reader.GetOrdinal("cantidad_pagos")) ? 0 : reader.GetInt32("cantidad_pagos"),
                                importe = reader.IsDBNull(reader.GetOrdinal("importe_pagos")) ? 0.0 : reader.GetDouble("importe_pagos")
                            }
                        });
                    }
                }
                connection.Close();
            }
        }
        return contratosVigentes;
    }

    public void GuardarPago(Pago pago)
    {
        pago.estado = 1;
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = "INSERT INTO pago (concepto, importe, fecha, estado, id_contrato) VALUES (@concepto, @importe, @fecha, @estado, @id_contrato)";
            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@concepto", pago.concepto);
                command.Parameters.AddWithValue("@importe", pago.importe);
                command.Parameters.AddWithValue("@fecha", pago.fecha);
                command.Parameters.AddWithValue("@estado", pago.estado);
                command.Parameters.AddWithValue("@id_contrato", pago.id_contrato);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public Pago BuscarPagoPorIddd(int idPago)
    {
        Pago pago = null;
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var sql = @$"SELECT i.{nameof(Inquilino.id_inquilino)}, 
                    i.{nameof(Inquilino.dni)}, 
                    i.{nameof(Inquilino.apellido)} AS inquilino_apellido, 
                    i.{nameof(Inquilino.nombre)} AS inquilino_nombre, 
                    i.{nameof(Inquilino.telefono)} AS inquilino_telefono, 
                    i.{nameof(Inquilino.email)} AS inquilino_email
             FROM contrato c  
             INNER JOIN inquilino i ON c.{nameof(Contrato.id_inquilino)} = i.{nameof(Inquilino.id_inquilino)} 
             INNER JOIN pago p ON c.{nameof(Contrato.id_contrato)} = p.{nameof(Pago.id_contrato)}
             WHERE p.{nameof(Pago.id_pago)} = @idPago";

            //             var sql = @$"SELECT i.{nameof(Inquilino.id_inquilino)}, i.{nameof(Inquilino.dni)},i.{nameof(Inquilino.apellido)} AS inquilino_apellido,i.{nameof(Inquilino.nombre)} AS inquilino_nombre, i.{nameof(Inquilino.telefono)} AS inquilino_telefono, i.{nameof(Inquilino.email)} AS inquilino_email
            // FROM   contrato c  INNER JOIN inquilino i ON c.{nameof(Contrato.id_inquilino)} = i.{nameof(Inquilino.id_inquilino)} INNER JOIN pago p ON c.{nameof(Contrato.id_contrato)} = p.{nameof(Pago.id_contrato)}WHERE   p.{nameof(Pago.id_pago)} =@idPago";
            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@idPago", idPago);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pago = new Pago
                        {
                            importe = reader.GetDouble(reader.GetOrdinal(nameof(Pago.importe))),
                            inquilino = new Inquilino
                            {
                                id_inquilino = reader.GetInt32(reader.GetOrdinal(nameof(Inquilino.id_inquilino))),
                                nombre = reader.GetString(reader.GetOrdinal(nameof(Inquilino.nombre))),
                                apellido = reader.GetString(reader.GetOrdinal(nameof(Inquilino.apellido))),
                                telefono = reader.GetString(reader.GetOrdinal(nameof(Inquilino.telefono))),
                                email = reader.GetString(reader.GetOrdinal(nameof(Inquilino.email)))
                            },
                            id_contrato = reader.GetInt32(reader.GetOrdinal(nameof(Contrato.id_contrato)))
                        };
                    }
                }
            }
        }
        return pago;
    }
    public Pago BuscarPagoPorId(int idPago)
    {
        Pago pago = null;
        using (var connection = new MySqlConnection(ConnectionString))
        {
            connection.Open();
            var sql = @$"SELECT 
                    p.{nameof(Pago.id_pago)},
                    p.{nameof(Pago.importe)},
                    p.{nameof(Pago.concepto)}, 
                    p.{nameof(Pago.fecha)},
                    p.{nameof(Pago.estado)}, 
                    i.{nameof(Inquilino.id_inquilino)}, 
                    i.{nameof(Inquilino.dni)}, 
                    i.{nameof(Inquilino.apellido)} AS inquilino_apellido, 
                    i.{nameof(Inquilino.nombre)} AS inquilino_nombre, 
                    i.{nameof(Inquilino.telefono)} AS inquilino_telefono, 
                    i.{nameof(Inquilino.email)} AS inquilino_email
                FROM contrato c  
                INNER JOIN inquilino i ON c.{nameof(Contrato.id_inquilino)} = i.{nameof(Inquilino.id_inquilino)} 
                INNER JOIN pago p ON c.{nameof(Contrato.id_contrato)} = p.{nameof(Pago.id_contrato)}
                WHERE p.{nameof(Pago.id_pago)} = @idPago";

            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@idPago", idPago);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pago = new Pago
                        {
                            id_pago = reader.GetInt32(reader.GetOrdinal("id_pago")),
                            importe = reader.GetDouble(reader.GetOrdinal("importe")),
                            fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                            concepto = reader.GetString(reader.GetOrdinal("concepto")),
                            estado = reader.GetInt32(reader.GetOrdinal("estado")),
                            inquilino = new Inquilino
                            {
                                id_inquilino = reader.GetInt32(reader.GetOrdinal(nameof(Inquilino.id_inquilino))),
                                nombre = reader.GetString(reader.GetOrdinal("inquilino_nombre")),
                                apellido = reader.GetString(reader.GetOrdinal("inquilino_apellido")),
                                telefono = reader.GetString(reader.GetOrdinal("inquilino_telefono")),
                                email = reader.GetString(reader.GetOrdinal("inquilino_email"))
                            }
                        };
                    }
                }
            }
        }
        return pago;
    }


    public void modifiConcepto(int pagid, string concep)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {

            var sql = $"UPDATE pago SET {nameof(Pago.concepto)} = @concep WHERE {nameof(Pago.id_pago)} = @pagid";

            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@concep", concep);
                command.Parameters.AddWithValue("@pagid", pagid);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

}