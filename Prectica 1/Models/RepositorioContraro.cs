
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
            var sql = @"SELECT 
                    c.id_contrato, c.id_inquilino, c.id_inmueble, c.desde, c.meses, c.hasta, c.detalle,c.finalizacionAnticipada, c.monto,c.multa, c.estado,
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
                        contratos.Add(new Contrato
                        {
                            id_contrato = reader.GetInt32("id_contrato"),
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            id_inmueble = reader.GetInt32("id_inmueble"),
                            desde = reader.GetDateTime("desde"),
                            meses = reader.GetInt32("meses"),
                            hasta = reader.GetDateTime("hasta"),
                            detalle = reader.GetString("detalle"),
                            finalizacion_anticipada = !reader.IsDBNull(reader.GetOrdinal("finalizacionAnticipada")) ? reader.GetDateTime("finalizacionAnticipada") : default(DateTime),
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
        return contratos;
    }
    public List<Inquilino> inquilinosSinContrato()
    {
        List<Inquilino> inquilinosSinContrato = new List<Inquilino>();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @"SELECT inquilino.*
                FROM inquilino
                LEFT JOIN contrato ON inquilino.id_inquilino = contrato.id_inquilino
                WHERE contrato.id_contrato IS NULL";

            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inquilinosSinContrato.Add(new Inquilino
                        {
                            // Asigna los valores de las columnas del inquilino desde el resultado de la consulta
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            dni = reader.GetInt32("dni"),
                            apellido = reader.GetString("apellido"),
                            nombre = reader.GetString("nombre"),
                            telefono = reader.GetString("telefono"),
                            email = reader.GetString("email"),
                            estado = reader.IsDBNull(reader.GetOrdinal("estado")) ? default(int) : reader.GetInt32("estado")
                        });
                    }
                }
                connection.Close();
            }
        }
        return inquilinosSinContrato;
    }
    public List<Inmueble> inmueblesSinContrato()
    {
        List<Inmueble> inmueblesSinContrato = new List<Inmueble>();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @"SELECT inmueble.*
                    FROM inmueble
                    LEFT JOIN contrato ON inmueble.id_inmueble = contrato.id_inmueble
                    WHERE contrato.id_contrato IS NULL";

            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inmueblesSinContrato.Add(new Inmueble
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

                        });
                    }
                }
                connection.Close();
            }
        }
        return inmueblesSinContrato;
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
    public Contrato ContratoMonto(int numid)
    {
        Contrato contrato = null;

        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @"SELECT 
                    contrato.id_contrato,
                    inquilino.id_inquilino, 
                    inquilino.nombre AS nombre_inquilino, 
                    inquilino.apellido AS apellido_inquilino, 
                    contrato.monto AS monto_contrato
                FROM contrato
                JOIN inquilino ON contrato.id_inquilino = inquilino.id_inquilino
                WHERE contrato.estado IN (0, 1)
                AND contrato.id_contrato = @numid";

            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@numid", numid);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contrato = new Contrato
                        {
                            id_contrato = reader.GetInt32("id_contrato"),
                            inquilino = new Inquilino
                            {
                                id_inquilino = reader.GetInt32("id_inquilino"),
                                nombre = reader.GetString("nombre_inquilino"),
                                apellido = reader.GetString("apellido_inquilino"),
                            },
                            monto = reader.GetDouble("monto_contrato")
                        };
                    }
                }
                connection.Close();
            }
        }
        return contrato;
    }

    public Contrato Contrato(int idContrato)
    {
        Contrato contrato = null;

        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @"
            SELECT 
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
            WHERE c.id_contrato = @idContrato
            GROUP BY 
                c.id_contrato, c.id_inquilino, c.id_inmueble, c.desde, c.meses, c.hasta, c.detalle, c.monto, c.estado,
                i.apellido, i.nombre,
                im.direccion,
                p.apellido, p.nombre";

            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@idContrato", idContrato);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contrato = new Contrato
                        {
                            id_contrato = reader.GetInt32("id_contrato"),
                            id_inquilino = reader.GetInt32("id_inquilino"),
                            id_inmueble = reader.GetInt32("id_inmueble"),
                            desde = reader.GetDateTime("desde"),
                            meses = reader.GetInt32("meses"),
                            hasta = reader.GetDateTime("hasta"),
                            detalle = reader.GetString("detalle"),
                            finalizacion_anticipada = !reader.IsDBNull(reader.GetOrdinal("finalizacionAnticipada")) ? reader.GetDateTime("finalizacionAnticipada") : default(DateTime),
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
                        };
                    }
                }
            }
        }

        return contrato;
    }

    public void GuardarContratoFinalizado(Contrato contrato)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = $"UPDATE contrato SET id_inquilino = @id_inquilino,id_inmueble = @id_inmueble,desde = @desde,meses = @meses,hasta = @hasta,detalle = @detalle,   monto = @monto,finalizacion_anticipada = @finalizacion_anticipada, multa = @multa,estado = @estado WHERE id_contrato = @id_contrato";
            using (var command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }



}