﻿using MySql.Data.MySqlClient;
using System.Data;

namespace PoC.SendEmail.API.Infrastructure.Data;

public class MySqlConnectionFactory
{
    private readonly string _connectionString;

    public MySqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
